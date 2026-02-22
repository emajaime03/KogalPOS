using DAL.Factories;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;

namespace BLL.Services
{
    public sealed class ProveedorBLL
    {
        #region Singleton
        private readonly static ProveedorBLL _instance = new ProveedorBLL();

        public static ProveedorBLL Current
        {
            get { return _instance; }
        }

        private ProveedorBLL()
        {
        }
        #endregion

        public ResProveedoresObtener ObtenerLista(ReqProveedoresObtener req)
        {
            ResProveedoresObtener res = new ResProveedoresObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Proveedores = context.Repositories.ProveedorRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResProveedorObtener Obtener(ReqProveedorObtener req)
        {
            ResProveedorObtener res = new ResProveedorObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Proveedor = context.Repositories.ProveedorRepository.GetById(req.Id);
                res.Success = res.Proveedor != null;

                if (!res.Success)
                    res.Message = "Proveedor no encontrado.";
            }

            return res;
        }

        public ResProveedorInsertar Insertar(ReqProveedorInsertar req)
        {
            ResProveedorInsertar res = new ResProveedorInsertar();

            req.Proveedor.IdProveedor = Guid.NewGuid();
            req.Proveedor.Estado = E_Estados.Activo;

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ProveedorRepository.Add(req.Proveedor);
                context.SaveChanges();
                res.Proveedor = req.Proveedor;
                res.Success = true;
                res.Message = "Proveedor creado exitosamente.";
            }

            return res;
        }

        public ResProveedorModificar Modificar(ReqProveedorModificar req)
        {
            ResProveedorModificar res = new ResProveedorModificar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ProveedorRepository.Update(req.Proveedor);
                context.SaveChanges();
                res.Proveedor = req.Proveedor;
                res.Success = true;
                res.Message = "Proveedor modificado exitosamente.";
            }

            return res;
        }

        public ResProveedorEliminar Eliminar(ReqProveedorEliminar req)
        {
            ResProveedorEliminar res = new ResProveedorEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ProveedorRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Proveedor eliminado exitosamente.";
            }

            return res;
        }

        public ResProveedorRestaurar Restaurar(ReqProveedorRestaurar req)
        {
            ResProveedorRestaurar res = new ResProveedorRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ProveedorRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Proveedor restaurado exitosamente.";
            }

            return res;
        }
    }
}
