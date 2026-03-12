using DAL.Factories;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;

namespace BLL.Services
{
    public sealed class ListaPrecioBLL
    {
        #region Singleton
        private readonly static ListaPrecioBLL _instance = new ListaPrecioBLL();

        public static ListaPrecioBLL Current
        {
            get { return _instance; }
        }

        private ListaPrecioBLL()
        {
        }
        #endregion

        public ResListaPreciosObtener ObtenerLista(ReqListaPreciosObtener req)
        {
            ResListaPreciosObtener res = new ResListaPreciosObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.ListaPrecios = context.Repositories.ListaPrecioRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResListaPrecioObtener Obtener(ReqListaPrecioObtener req)
        {
            ResListaPrecioObtener res = new ResListaPrecioObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.ListaPrecio = context.Repositories.ListaPrecioRepository.GetById(req.Id);
                res.Success = res.ListaPrecio != null;

                if (!res.Success)
                    res.Message = "Lista de precios no encontrada.";
            }

            return res;
        }

        public ResListaPrecioInsertar Insertar(ReqListaPrecioInsertar req)
        {
            ResListaPrecioInsertar res = new ResListaPrecioInsertar();

            req.ListaPrecio.IdListaPrecio = Guid.NewGuid();
            req.ListaPrecio.Estado = E_Estados.Activo;

            foreach (var item in req.ListaPrecio.Items)
            {
                item.IdListaPrecioArticulo = Guid.NewGuid();
                item.IdListaPrecio = req.ListaPrecio.IdListaPrecio;
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Add(req.ListaPrecio);
                context.SaveChanges();
                res.ListaPrecio = req.ListaPrecio;
                res.Success = true;
                res.Message = "Lista de precios creada exitosamente.";
            }

            return res;
        }

        public ResListaPrecioModificar Modificar(ReqListaPrecioModificar req)
        {
            ResListaPrecioModificar res = new ResListaPrecioModificar();

            foreach (var item in req.ListaPrecio.Items)
            {
                if (item.IdListaPrecioArticulo == Guid.Empty)
                    item.IdListaPrecioArticulo = Guid.NewGuid();
                item.IdListaPrecio = req.ListaPrecio.IdListaPrecio;
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Update(req.ListaPrecio);
                context.SaveChanges();
                res.ListaPrecio = req.ListaPrecio;
                res.Success = true;
                res.Message = "Lista de precios modificada exitosamente.";
            }

            return res;
        }

        public ResListaPrecioEliminar Eliminar(ReqListaPrecioEliminar req)
        {
            ResListaPrecioEliminar res = new ResListaPrecioEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                // Validar que no sea la lista predeterminada
                if (context.Repositories.ListaPrecioRepository.EsPredeterminada(req.Id))
                {
                    res.Success = false;
                    res.Message = "No se puede eliminar la lista predeterminada.";
                    return res;
                }
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Lista de precios eliminada exitosamente.";
            }

            return res;
        }

        public ResListaPrecioRestaurar Restaurar(ReqListaPrecioRestaurar req)
        {
            ResListaPrecioRestaurar res = new ResListaPrecioRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Lista de precios restaurada exitosamente.";
            }

            return res;
        }
    }
}
