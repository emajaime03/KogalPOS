using System;

namespace Domain.DTOs
{
    /// <summary>
    /// Línea del carrito de venta / selección de artículos en el POS.
    /// </summary>
    public class VentaItemDTO
    {
        public Guid IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal StockActual { get; set; }

        /// <summary>Subtotal de la línea: Cantidad * PrecioUnitario - Descuento.</summary>
        public decimal Subtotal => (Cantidad * PrecioUnitario) - Descuento;

        public VentaItemDTO()
        {
            IdArticulo = Guid.Empty;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            Cantidad = 0;
            PrecioUnitario = 0;
            Descuento = 0;
            StockActual = 0;
        }
    }
}
