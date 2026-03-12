using System;

namespace Domain
{
    public class ListaPrecioArticulo
    {
        public Guid IdListaPrecioArticulo { get; set; }
        public Guid IdListaPrecio { get; set; }
        public Guid IdArticulo { get; set; }
        public decimal Precio { get; set; }

        // Propiedades de visualización (se cargan via JOIN, no se persisten aparte)
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }

        public ListaPrecioArticulo()
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
