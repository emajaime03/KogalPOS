using DAL.Factories;
using Domain;
using Domain.BLL;
using Domain.DTOs;
using Domain.Enums;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public sealed class VentasBLL
    {
        #region Singleton
        private readonly static VentasBLL _instance = new VentasBLL();

        public static VentasBLL Current
        {
            get { return _instance; }
        }

        private VentasBLL() { }
        #endregion

        /// <summary>
        /// Historial de ventas (cabeceras), con nombre de cliente resuelto.
        /// </summary>
        public ResVentasObtener ObtenerLista(ReqVentasObtener req)
        {
            ResVentasObtener res = new ResVentasObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var ventas = context.Repositories.VentaRepository.GetAll();
                var clientes = context.Repositories.ClienteRepository.GetAll();
                var dictCli = clientes.ToDictionary(c => c.IdCliente, c => c.Descripcion);

                res.Ventas = ventas.Select(v => new VentaDTO
                {
                    IdVenta = v.IdVenta,
                    NroVenta = v.NroVenta,
                    Fecha = v.Fecha,
                    Estado = v.Estado,
                    Total = v.Total,
                    IdCliente = v.IdCliente,
                    DescripcionCliente = (v.IdCliente.HasValue && dictCli.ContainsKey(v.IdCliente.Value))
                        ? dictCli[v.IdCliente.Value]
                        : "Consumidor Final"
                }).ToList();
                res.Success = true;
            }

            return res;
        }

        /// <summary>
        /// Detalle de una venta: ítems + cliente + lista + comprobante/pago.
        /// </summary>
        public ResVentaObtener Obtener(ReqVentaObtener req)
        {
            ResVentaObtener res = new ResVentaObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var v = context.Repositories.VentaRepository.GetById(req.Id);
                res.Success = v != null;
                if (!res.Success)
                {
                    res.Message = "Venta no encontrada.";
                    return res;
                }

                var dto = new VentaDTO
                {
                    IdVenta = v.IdVenta,
                    NroVenta = v.NroVenta,
                    Fecha = v.Fecha,
                    Estado = v.Estado,
                    Total = v.Total,
                    Descuento = v.Descuento,
                    IdCliente = v.IdCliente,
                    IdListaPrecio = v.IdListaPrecio
                };

                if (v.IdCliente.HasValue)
                {
                    var cli = context.Repositories.ClienteRepository.GetById(v.IdCliente.Value);
                    dto.DescripcionCliente = cli != null ? cli.Descripcion : "Consumidor Final";
                }
                else
                {
                    dto.DescripcionCliente = "Consumidor Final";
                }

                var lista = context.Repositories.ListaPrecioRepository.GetById(v.IdListaPrecio);
                dto.DescripcionListaPrecio = lista != null ? lista.Descripcion : string.Empty;

                var articulos = context.Repositories.ArticuloRepository
                    .GetByIds(v.Items.Select(i => i.IdArticulo).Distinct().ToList())
                    .ToList();

                foreach (var it in v.Items)
                {
                    var art = articulos.FirstOrDefault(a => a.IdArticulo == it.IdArticulo);
                    dto.Items.Add(new VentaItemDTO
                    {
                        IdArticulo = it.IdArticulo,
                        Codigo = art != null ? art.Codigo : string.Empty,
                        Descripcion = art != null ? art.Descripcion : "Articulo Inexistente",
                        Cantidad = it.Cantidad,
                        PrecioUnitario = it.PrecioUnitario,
                        Descuento = it.Descuento,
                        StockActual = art != null ? art.StockActual : 0
                    });
                }

                var doc = context.Repositories.DocumentoRepository.GetByVenta(req.Id);
                if (doc != null)
                {
                    dto.NroDocumento = doc.NroDocumento;
                    dto.TipoComprobante = doc.TipoComprobante;
                    if (doc.Pagos.Count > 0)
                        dto.FormaPago = doc.Pagos[0].FormaPago;
                }

                res.Venta = dto;
            }

            return res;
        }

        /// <summary>
        /// Confirma una venta: persiste Venta + detalle, descuenta stock (MovimientoStock Baja)
        /// y emite el comprobante (Documento) con su Pago. Todo en una transacción.
        /// </summary>
        public ResVentaConfirmar ConfirmarVenta(ReqVentaConfirmar req)
        {
            ResVentaConfirmar res = new ResVentaConfirmar();

            if (req.Items == null || req.Items.Count == 0)
            {
                res.Success = false;
                res.Message = "El carrito está vacío.";
                return res;
            }

            var idVenta = Guid.NewGuid();
            var venta = new Venta
            {
                IdVenta = idVenta,
                Fecha = DateTime.Now,
                Estado = E_EstadoVenta.Cobrada,
                IdCliente = req.IdCliente,
                IdListaPrecio = req.IdListaPrecio
            };

            decimal bruto = 0;
            foreach (var item in req.Items)
            {
                decimal subtotal = item.Cantidad * item.PrecioUnitario;
                venta.Items.Add(new VentaDetalle
                {
                    IdVentaDetalle = Guid.NewGuid(),
                    IdVenta = idVenta,
                    IdArticulo = item.IdArticulo,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Descuento = 0,
                    Subtotal = subtotal
                });
                bruto += subtotal;
            }

            // El descuento se aplica a nivel venta (monto ya resuelto por la UI).
            decimal descuento = req.Descuento;
            if (descuento < 0) descuento = 0;
            if (descuento > bruto) descuento = bruto;

            venta.Descuento = descuento;
            decimal total = bruto - descuento;
            venta.Total = total;

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                // 1. Venta + detalle (genera NroVenta)
                context.Repositories.VentaRepository.Add(venta);

                // 2. Descuento de stock (MovimientoStock Baja)
                var movimiento = new MovimientoStock
                {
                    IdMovimientoStock = Guid.NewGuid(),
                    Fecha = DateTime.Now,
                    TipoMovimiento = E_TipoMovimientoStock.Baja,
                    Estado = E_Estados.Activo
                };
                foreach (var item in venta.Items)
                {
                    movimiento.Items.Add(new MovimientoItem
                    {
                        IdMovimientoItem = Guid.NewGuid(),
                        IdMovimientoStock = movimiento.IdMovimientoStock,
                        IdArticulo = item.IdArticulo,
                        Cantidad = item.Cantidad
                    });
                }
                context.Repositories.MovimientoStockRepository.Add(movimiento);

                // 3. Comprobante + pago (genera NroDocumento)
                var documento = new Documento
                {
                    IdDocumento = Guid.NewGuid(),
                    Fecha = DateTime.Now,
                    TipoComprobante = req.Cobro.TipoComprobante,
                    IdVenta = idVenta,
                    Total = total
                };
                documento.Pagos.Add(new Pago
                {
                    IdPago = Guid.NewGuid(),
                    IdDocumento = documento.IdDocumento,
                    FormaPago = req.Cobro.FormaPago,
                    Importe = total,
                    Fecha = DateTime.Now
                });
                context.Repositories.DocumentoRepository.Add(documento);

                context.SaveChanges();

                res.NroVenta = venta.NroVenta;
                res.NroDocumento = documento.NroDocumento;
                res.Success = true;
                res.Message = "Venta confirmada.";
            }

            return res;
        }

        /// <summary>
        /// Anula una venta: cambia su estado a Anulada, repone el stock (MovimientoStock Alta)
        /// y emite una Nota de Crédito. Todo en una transacción.
        /// </summary>
        public ResVentaAnular Anular(ReqVentaAnular req)
        {
            ResVentaAnular res = new ResVentaAnular();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                var venta = context.Repositories.VentaRepository.GetById(req.Id);
                if (venta == null)
                {
                    res.Success = false;
                    res.Message = "Venta no encontrada.";
                    return res;
                }
                if (venta.Estado == E_EstadoVenta.Anulada)
                {
                    res.Success = false;
                    res.Message = "La venta ya está anulada.";
                    return res;
                }

                var docOriginal = context.Repositories.DocumentoRepository.GetByVenta(req.Id);

                // 1. Anular la venta
                context.Repositories.VentaRepository.Remove(req.Id);

                // 2. Reponer stock (MovimientoStock Alta)
                var movimiento = new MovimientoStock
                {
                    IdMovimientoStock = Guid.NewGuid(),
                    Fecha = DateTime.Now,
                    TipoMovimiento = E_TipoMovimientoStock.Alta,
                    Estado = E_Estados.Activo
                };
                foreach (var item in venta.Items)
                {
                    movimiento.Items.Add(new MovimientoItem
                    {
                        IdMovimientoItem = Guid.NewGuid(),
                        IdMovimientoStock = movimiento.IdMovimientoStock,
                        IdArticulo = item.IdArticulo,
                        Cantidad = item.Cantidad
                    });
                }
                context.Repositories.MovimientoStockRepository.Add(movimiento);

                // 3. Nota de crédito (fiscal o no fiscal según el comprobante original)
                var tipoNC = (docOriginal != null && docOriginal.TipoComprobante == E_TipoComprobante.TiqueNoFiscal)
                    ? E_TipoComprobante.NotaCreditoNoFiscal
                    : E_TipoComprobante.NotaCredito;

                var notaCredito = new Documento
                {
                    IdDocumento = Guid.NewGuid(),
                    Fecha = DateTime.Now,
                    TipoComprobante = tipoNC,
                    IdVenta = req.Id,
                    Total = venta.Total
                };
                context.Repositories.DocumentoRepository.Add(notaCredito);

                context.SaveChanges();

                res.Success = true;
                res.Message = "Venta anulada. Se emitió la Nota de Crédito.";
            }

            return res;
        }
    }
}
