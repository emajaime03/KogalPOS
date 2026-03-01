using Services.Domain.Enums;
using System;

namespace Domain
{
    public class Articulo
    {
        public Guid IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public E_Estados Estado { get; set; }
        public decimal StockActual { get; set; }

        public Articulo()
        {
            IdArticulo = Guid.Empty;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            Estado = E_Estados.Activo;
            StockActual = 0;
        }
    }
}
