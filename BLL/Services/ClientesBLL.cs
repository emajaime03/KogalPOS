using DAL.Factories;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;

namespace BLL.Services
{
    public sealed class ClientesBLL
    {
        #region Singleton
        private readonly static ClientesBLL _instance = new ClientesBLL();

        public static ClientesBLL Current
        {
            get { return _instance; }
        }

        private ClientesBLL()
        {
        }
        #endregion

        public ResClientesObtener ObtenerLista(ReqClientesObtener req)
        {
            ResClientesObtener res = new ResClientesObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Clientes = context.Repositories.ClienteRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResClienteObtener Obtener(ReqClienteObtener req)
        {
            ResClienteObtener res = new ResClienteObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Cliente = context.Repositories.ClienteRepository.GetById(req.Id);

                // Si tiene fidelizacion activa obtengo sus puntos
                if (ConfiguracionApp.Current.configuracionLocal.Loyalty_IsEnabled)
                {
                    res.Cliente.Puntos = context.Repositories.LoyaltyRepository.ObtenerPuntosAsync(res.Cliente.NroDocumento).GetAwaiter().GetResult();
                }

                res.Success = res.Cliente != null;

                if (!res.Success)
                    res.Message = "Cliente no encontrado.";
            }

            return res;
        }

        public ResClienteInsertar Insertar(ReqClienteInsertar req)
        {
            ResClienteInsertar res = new ResClienteInsertar();

            req.Cliente.IdCliente = Guid.NewGuid();
            req.Cliente.Estado = E_Estados.Activo;

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ClienteRepository.Add(req.Cliente);
                context.SaveChanges();
                res.Cliente = req.Cliente;
                res.Success = true;
                res.Message = "Cliente creado exitosamente.";
            }

            return res;
        }

        public ResClienteModificar Modificar(ReqClienteModificar req)
        {
            ResClienteModificar res = new ResClienteModificar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ClienteRepository.Update(req.Cliente);
                context.SaveChanges();
                res.Cliente = req.Cliente;
                res.Success = true;
                res.Message = "Cliente modificado exitosamente.";
            }

            return res;
        }

        public ResClienteEliminar Eliminar(ReqClienteEliminar req)
        {
            ResClienteEliminar res = new ResClienteEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ClienteRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Cliente eliminado exitosamente.";
            }

            return res;
        }

        public ResClienteRestaurar Restaurar(ReqClienteRestaurar req)
        {
            ResClienteRestaurar res = new ResClienteRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ClienteRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Cliente restaurado exitosamente.";
            }

            return res;
        }
    }
}
