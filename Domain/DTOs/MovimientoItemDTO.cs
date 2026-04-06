using System;

namespace Domain.DTOs
{
    public class MovimientoItemDTO
    {
        public Guid IdMovimientoItem { get; set; }
        public Guid IdMovimientoStock { get; set; }
        public Guid IdArticulo { get; set; }
        public decimal Cantidad { get; set; }
        
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }

        public MovimientoItemDTO()
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
