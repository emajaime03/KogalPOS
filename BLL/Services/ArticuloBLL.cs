using DAL.Factories;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;

namespace BLL.Services
{
    public sealed class ArticuloBLL
    {
        #region Singleton
        private readonly static ArticuloBLL _instance = new ArticuloBLL();

        public static ArticuloBLL Current
        {
            get { return _instance; }
        }

        private ArticuloBLL()
        {
        }
        #endregion

        public ResArticulosObtener ObtenerLista(ReqArticulosObtener req)
        {
            ResArticulosObtener res = new ResArticulosObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Articulos = context.Repositories.ArticuloRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResArticuloObtener Obtener(ReqArticuloObtener req)
        {
            ResArticuloObtener res = new ResArticuloObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Articulo = context.Repositories.ArticuloRepository.GetById(req.Id);
                res.Success = res.Articulo != null;

                if (!res.Success)
                    res.Message = "Artículo no encontrado.";
            }

            return res;
        }

        public ResArticuloInsertar Insertar(ReqArticuloInsertar req)
        {
            ResArticuloInsertar res = new ResArticuloInsertar();

            req.Articulo.IdArticulo = Guid.NewGuid();
            req.Articulo.Estado = E_Estados.Activo;
            req.Articulo.StockActual = 0;

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Add(req.Articulo);
                context.SaveChanges();
                res.Articulo = req.Articulo;
                res.Success = true;
                res.Message = "Artículo creado exitosamente.";
            }

            return res;
        }

        public ResArticuloModificar Modificar(ReqArticuloModificar req)
        {
            ResArticuloModificar res = new ResArticuloModificar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Update(req.Articulo);
                context.SaveChanges();
                res.Articulo = req.Articulo;
                res.Success = true;
                res.Message = "Artículo modificado exitosamente.";
            }

            return res;
        }

        public ResArticuloEliminar Eliminar(ReqArticuloEliminar req)
        {
            ResArticuloEliminar res = new ResArticuloEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Artículo eliminado exitosamente.";
            }

            return res;
        }

        public ResArticuloRestaurar Restaurar(ReqArticuloRestaurar req)
        {
            ResArticuloRestaurar res = new ResArticuloRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Artículo restaurado exitosamente.";
            }

            return res;
        }
    }
}
