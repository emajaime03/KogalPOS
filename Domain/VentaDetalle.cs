using System;

namespace Domain
{
    public class VentaDetalle
    {
        public Guid IdVentaDetalle { get; set; }
        public Guid IdVenta { get; set; }
        public Guid IdArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }

        public VentaDetalle()
        {
            IdVentaDetalle = Guid.Empty;
            IdVenta = Guid.Empty;
            IdArticulo = Guid.Empty;
            Cantidad = 0;
            PrecioUnitario = 0;
            Descuento = 0;
            Subtotal = 0;
        }
    }
}
