using DAL.Factories;
using DAL.Implementations.Api;
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

                    // Vamos acumulando los puntos (positivos o negativos)
                    sumatoriaPuntos += movimiento.Puntos;

                    context.Repositories.MovimientosPuntosRepository.Add(movimiento);
                }

                // 4. SINCRONIZACIÓN CON LA NUBE
                // Tomamos el ID del primer elemento (seguro, porque validamos arriba)
                // y le hacemos .ToString() para que coincida con la firma de Firebase
                string idFirebaseCliente = req.MovimientosPuntos[0].IdCliente.ToString();

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
    }
}
