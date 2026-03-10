using DAL.Factories;
using Domain;
using Domain.BLL;
using System;

namespace BLL.Services
{
    public sealed class AjusteStockBLL
    {
        #region Singleton
        private readonly static AjusteStockBLL _instance = new AjusteStockBLL();

        public static AjusteStockBLL Current
        {
            get { return _instance; }
        }

        private AjusteStockBLL()
        {
        }
        #endregion

        public ResAjustesStockObtener ObtenerLista(ReqAjustesStockObtener req)
        {
            ResAjustesStockObtener res = new ResAjustesStockObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Movimientos = context.Repositories.MovimientoStockRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResAjusteStockObtener Obtener(ReqAjusteStockObtener req)
        {
            ResAjusteStockObtener res = new ResAjusteStockObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Movimiento = context.Repositories.MovimientoStockRepository.GetById(req.Id);
                res.Success = res.Movimiento != null;

                if (!res.Success)
                    res.Message = "Movimiento de stock no encontrado.";
            }

            return res;
        }

        public ResAjusteStockInsertar Insertar(ReqAjusteStockInsertar req)
        {
            ResAjusteStockInsertar res = new ResAjusteStockInsertar();

            req.Movimiento.IdMovimientoStock = Guid.NewGuid();
            req.Movimiento.Fecha = DateTime.Now;

            foreach (var item in req.Movimiento.Items)
            {
                item.IdMovimientoItem = Guid.NewGuid();
                item.IdMovimientoStock = req.Movimiento.IdMovimientoStock;
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.MovimientoStockRepository.Add(req.Movimiento);
                context.SaveChanges();
                res.Movimiento = req.Movimiento;
                res.Success = true;
                res.Message = "Ajuste de stock registrado exitosamente.";
            }

            return res;
        }

        public ResAjusteStockEliminar Eliminar(ReqAjusteStockEliminar req)
        {
            ResAjusteStockEliminar res = new ResAjusteStockEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.MovimientoStockRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Ajuste de stock eliminado exitosamente.";
            }

            return res;
        }

        public ResAjusteStockRestaurar Restaurar(ReqAjusteStockRestaurar req)
        {
            ResAjusteStockRestaurar res = new ResAjusteStockRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.MovimientoStockRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Ajuste de stock restaurado exitosamente.";
            }

            return res;
        }
    }
}
