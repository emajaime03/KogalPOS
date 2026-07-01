using DAL.Factories;
using DAL.Implementations.Api;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MovimientosPuntosBLL
    {

		#region "Singleton"				
		private readonly static MovimientosPuntosBLL _instance = new MovimientosPuntosBLL();

		public static MovimientosPuntosBLL Current
		{
			get
			{
				return _instance;
			}
		}

		private MovimientosPuntosBLL()
		{
			//Implent here the initialization of your singleton
		}
        #endregion

        public ResMovimientosPuntosInsertar Insertar(ReqMovimientosPuntosInsertar req)
        {
            ResMovimientosPuntosInsertar res = new ResMovimientosPuntosInsertar();

            // 1. VALIDACIÓN DE SEGURIDAD (Evita que .First() rompa todo si viene vacío)
            if (req.MovimientosPuntos == null || req.MovimientosPuntos.Count == 0)
            {
                res.Success = false;
                res.Message = "No se recibieron movimientos para procesar.";
                return res;
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                // 2. DECLARAMOS LA SUMATORIA
                int sumatoriaPuntos = 0;

                // 3. REGISTRO LOCAL Y CÁLCULO
                foreach (var movimiento in req.MovimientosPuntos)
                {
                    movimiento.IdMovimientoPuntos = Guid.NewGuid();

                    if (movimiento.Fecha == default(DateTime))
                        movimiento.Fecha = DateTime.Now;

                    // Vamos acumulando los puntos (positivos o negativos)
                    sumatoriaPuntos += movimiento.Puntos;

                    context.Repositories.MovimientosPuntosRepository.Add(movimiento);
                }

                // 4. SINCRONIZACIÓN CON LA NUBE
                // En Firebase los puntos se guardan bajo el NroDocumento del cliente
                // (ver ClientesBLL.Obtener -> ObtenerPuntosAsync(cliente.NroDocumento)).
                // Por eso resolvemos el cliente y usamos su NroDocumento como clave,
                // para que lectura y escritura impacten el mismo nodo.
                var cliente = context.Repositories.ClienteRepository.GetById(req.MovimientosPuntos[0].IdCliente);
                if (cliente == null || string.IsNullOrWhiteSpace(cliente.NroDocumento))
                {
                    res.Success = false;
                    res.Message = "No se pudo identificar al cliente para sincronizar los puntos.";
                    return res;
                }

                string idFirebaseCliente = cliente.NroDocumento;

                // Usamos .Result para mantener el flujo sincrónico en este método
                bool nubeOk = context.Repositories.LoyaltyRepository
                                    .UpdatePuntosBalanceAsync(idFirebaseCliente, sumatoriaPuntos).Result;

                // 5. RESOLUCIÓN DE LA TRANSACCIÓN
                if (nubeOk)
                {
                    // Solo si Firebase dio el OK, impactamos SQL.
                    context.SaveChanges();
                    res.Success = true;
                }
                else
                {
                    // Si la nube falla, NO hay SaveChanges. Al salir del 'using', se descarta todo.
                    res.Success = false;
                    res.Message = "Error al sincronizar puntos con la nube. La operación fue cancelada.";
                }
            }

            return res;
        }

        /// <summary>
        /// Calcula cuántos puntos de acumulación otorga un monto, según la configuración de fidelización.
        /// Regla: si el monto alcanza el mínimo y hay un monto requerido configurado,
        /// se otorgan PuntosOtorgados por cada MontoRequerido completo.
        /// </summary>
        public int CalcularPuntosPorMonto(decimal monto)
        {
            var config = ConfiguracionApp.Current.configuracionLocal;

            if (monto < config.Loyalty_MontoMinimo || config.Loyalty_MontoRequerido <= 0)
                return 0;

            int bloques = (int)Math.Floor(monto / config.Loyalty_MontoRequerido);
            return bloques * (int)config.Loyalty_PuntosOtorgados;
        }
    }
}
