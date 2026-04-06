using Domain.DTOs;
using Domain.BLL;
using System.Collections.Generic;
using System.Linq;
using System;
using DAL.Factories;
using Domain;

namespace BLL.Services
{
    public sealed class AjustesStockBLL
    {
        #region Singleton
        private readonly static AjustesStockBLL _instance = new AjustesStockBLL();

        public static AjustesStockBLL Current
        {
            get { return _instance; }
        }

        private AjustesStockBLL()
        {
        }
        #endregion

        public ResAjustesStockObtener ObtenerLista(ReqAjustesStockObtener req)
        {
            ResAjustesStockObtener res = new ResAjustesStockObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var movimientos = context.Repositories.MovimientoStockRepository.GetAll();
                res.Movimientos = movimientos.Select(m => new MovimientoStockDTO
                {
                    IdMovimientoStock = m.IdMovimientoStock,
                    Fecha = m.Fecha,
                    TipoMovimiento = m.TipoMovimiento,
                    Estado = m.Estado
                }).ToList();
                res.Success = true;
            }

            return res;
        }

        public ResAjusteStockObtener Obtener(ReqAjusteStockObtener req)
        {
            ResAjusteStockObtener res = new ResAjusteStockObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var m = context.Repositories.MovimientoStockRepository.GetById(req.Id);
                res.Success = m != null;

                if (!res.Success)
                {
                    res.Message = "Movimiento de stock no encontrado.";
                    return res;
                }

                var dto = new MovimientoStockDTO
                {
                    IdMovimientoStock = m.IdMovimientoStock,
                    Fecha = m.Fecha,
                    TipoMovimiento = m.TipoMovimiento,
                    Estado = m.Estado
                };

                // Recuperar los articulos de la BLL para adjuntar nombres usando IN(...)
                var reqArticulos = new ReqArticulosObtenerPorIds(req.Sesion) 
                { 
                    Ids = m.Items.Select(x => x.IdArticulo).Distinct().ToList() 
                };
                var articulosRes = ArticulosBLL.Current.ObtenerPorIds(reqArticulos);
                var listaArticulos = articulosRes.Success && articulosRes.Articulos != null ? articulosRes.Articulos : new List<Articulo>();

                foreach(var item in m.Items)
                {
                    var articulo = listaArticulos.FirstOrDefault(a => a.IdArticulo == item.IdArticulo);
                    dto.Items.Add(new MovimientoItemDTO
                    {
                        IdMovimientoItem = item.IdMovimientoItem,
                        IdMovimientoStock = item.IdMovimientoStock,
                        IdArticulo = item.IdArticulo,
                        Cantidad = item.Cantidad,
                        CodigoArticulo = articulo != null ? articulo.Codigo : string.Empty,
                        DescripcionArticulo = articulo != null ? articulo.Descripcion : "Articulo Inexistente"
                    });
                }
                res.Movimiento = dto;
            }

            return res;
        }

        public ResAjusteStockInsertar Insertar(ReqAjusteStockInsertar req)
        {
            ResAjusteStockInsertar res = new ResAjusteStockInsertar();

            var dominio = new MovimientoStock
            {
                IdMovimientoStock = Guid.NewGuid(),
                Fecha = DateTime.Now,
                TipoMovimiento = req.Movimiento.TipoMovimiento,
                Estado = req.Movimiento.Estado
            };

            foreach (var itemDto in req.Movimiento.Items)
            {
                dominio.Items.Add(new MovimientoItem
                {
                    IdMovimientoItem = Guid.NewGuid(),
                    IdMovimientoStock = dominio.IdMovimientoStock,
                    IdArticulo = itemDto.IdArticulo,
                    Cantidad = itemDto.Cantidad
                });
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.MovimientoStockRepository.Add(dominio);
                context.SaveChanges();
                
                // Completar el DTO con los IDs generados antes de retornarlo
                req.Movimiento.IdMovimientoStock = dominio.IdMovimientoStock;
                req.Movimiento.Fecha = dominio.Fecha;
                for (int i = 0; i < req.Movimiento.Items.Count; i++)
                {
                    req.Movimiento.Items[i].IdMovimientoItem = dominio.Items[i].IdMovimientoItem;
                    req.Movimiento.Items[i].IdMovimientoStock = dominio.Items[i].IdMovimientoStock;
                }
                
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
