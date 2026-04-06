using System;

namespace Domain.DTOs
{
    public class ListaPrecioArticuloDTO
    {
        public Guid IdListaPrecioArticulo { get; set; }
        public Guid IdListaPrecio { get; set; }
        public Guid IdArticulo { get; set; }
        public decimal Precio { get; set; }

        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }

        public ListaPrecioArticuloDTO()
        {
            IdListaPrecioArticulo = Guid.Empty;
            IdListaPrecio = Guid.Empty;
            IdArticulo = Guid.Empty;
            Precio = 0;
            CodigoArticulo = string.Empty;
            DescripcionArticulo = string.Empty;
        }
    }
}
