using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Venta
    {
        public Guid IdVenta { get; set; }
        public int NroVenta { get; set; }
        public DateTime Fecha { get; set; }
        public E_EstadoVenta Estado { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public Guid? IdCliente { get; set; }
        public Guid IdListaPrecio { get; set; }
        public List<VentaDetalle> Items { get; set; }

        public Venta()
        {
            IdVenta = Guid.Empty;
            NroVenta = 0;
            Fecha = DateTime.Now;
            Estado = E_EstadoVenta.Cobrada;
            Total = 0;
            Descuento = 0;
            IdCliente = null;
            IdListaPrecio = Guid.Empty;
            Items = new List<VentaDetalle>();
        }
    }
}
