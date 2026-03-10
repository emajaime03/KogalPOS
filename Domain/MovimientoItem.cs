using System;

namespace Domain
{
    public class MovimientoItem
    {
        public Guid IdMovimientoItem { get; set; }
        public Guid IdMovimientoStock { get; set; }
        public Guid IdArticulo { get; set; }
        public decimal Cantidad { get; set; }

        // Propiedades de visualización (se cargan via JOIN, no se persisten aparte)
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }

        public MovimientoItem()
        {
            IdMovimientoItem = Guid.Empty;
            IdMovimientoStock = Guid.Empty;
            IdArticulo = Guid.Empty;
            Cantidad = 0;
            CodigoArticulo = string.Empty;
            DescripcionArticulo = string.Empty;
        }
    }
}
