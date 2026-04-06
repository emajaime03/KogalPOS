using DAL.Factories;
using Domain.BLL;
using Domain.DTOs;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PremiosBLL
    {

		#region "Singleton"				
		private readonly static PremiosBLL _instance = new PremiosBLL();

		public static PremiosBLL Current
		{
			get
			{
				return _instance;
			}
		}

		private PremiosBLL()
		{
			//Implent here the initialization of your singleton
		}
        #endregion

        public ResPremiosObtener ObtenerLista(ReqPremiosObtener req)
        {
            ResPremiosObtener res = new ResPremiosObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var premios = context.Repositories.PremiosRepository.GetAll();

                var reqArticulos = new ReqArticulosObtenerPorIds(req.Sesion) 
                { 
                    Ids = premios.Select(x => x.IdArticulo).Distinct().ToList() 
                };
                var articulosRes = ArticulosBLL.Current.ObtenerPorIds(reqArticulos);
                var listaArticulos = articulosRes.Success && articulosRes.Articulos != null ? articulosRes.Articulos : new System.Collections.Generic.List<Domain.Articulo>();

                res.Premios = premios.Select(x => 
                {
                    var articulo = listaArticulos.FirstOrDefault(a => a.IdArticulo == x.IdArticulo);
                    return new PremioDTO
                    {
                        IdPremio = x.IdPremio,
                        Estado = x.Estado,
                        IdArticulo = x.IdArticulo,
                        Descripcion = x.Descripcion,
                        PuntosRequeridos = x.PuntosRequeridos,
                        Articulo = articulo != null ? articulo.Descripcion : string.Empty
                    };
                }).ToList();

                res.Success = true;
            }

            return res;
        }

        public ResPremioObtener Obtener(ReqPremioObtener req)
        {
            ResPremioObtener res = new ResPremioObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var premio = context.Repositories.PremiosRepository.GetById(req.Id);

                var articulosRes = ArticulosBLL.Current.ObtenerLista(new ReqArticulosObtener(req.Sesion));

                res.Premio = premio;
                res.TodosArticulos = articulosRes.Articulos;

                res.Success = true;
            }

            return res;
        }


        public ResPremiosInsertar Insertar(ReqPremiosInsertar req)
        {
            ResPremiosInsertar res = new ResPremiosInsertar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                req.Premio.IdPremio = Guid.NewGuid();
                req.Premio.Estado = E_Estados.Activo;

                context.Repositories.PremiosRepository.Add(req.Premio);

                Task.Run(() => context.Repositories.LoyaltyRepository.SyncPremioAsync(
                    req.Premio.IdPremio, 
                    req.Premio.PuntosRequeridos, 
                    req.Premio.Descripcion)).GetAwaiter().GetResult();

                context.SaveChanges();
                res.Success = true;
                res.Message = "Premio creado exitosamente.";
            }

            return res;
        }

        public ResPremiosModificar Modificar(ReqPremiosModificar req)
        {
            ResPremiosModificar res = new ResPremiosModificar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.PremiosRepository.Update(req.Premio);

                Task.Run(() => context.Repositories.LoyaltyRepository.SyncPremioAsync(
                    req.Premio.IdPremio,
                    req.Premio.PuntosRequeridos,
                    req.Premio.Descripcion)).GetAwaiter().GetResult();

                context.SaveChanges();
                res.Success = true;
                res.Message = "Premio modificado exitosamente.";
            }

            return res;
        }

        public ResPremiosEliminar Eliminar(ReqPremiosEliminar req)
        {
            ResPremiosEliminar res = new ResPremiosEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.PremiosRepository.Remove(req.Id);

                Task.Run(() => context.Repositories.LoyaltyRepository.EliminarPremioAsync(req.Id)).GetAwaiter().GetResult();

                context.SaveChanges();
                res.Success = true;
                res.Message = "Premio eliminado exitosamente.";
            }

            return res;
        }

        public ResPremiosRestaurar Restaurar(ReqPremiosRestaurar req)
        {
            ResPremiosRestaurar res = new ResPremiosRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.PremiosRepository.Restore(req.Id);

                var premio = context.Repositories.PremiosRepository.GetById(req.Id);
                if (premio != null)
                {
                    Task.Run(() => context.Repositories.LoyaltyRepository.SyncPremioAsync(
                        premio.IdPremio,
                        premio.PuntosRequeridos,
                        premio.Descripcion)).GetAwaiter().GetResult();
                }

                context.SaveChanges();
                res.Success = true;
                res.Message = "Premio restaurado exitosamente.";
            }

            return res;
        }
    }
}
