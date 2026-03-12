using Services.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class ListaPrecio
    {
        public Guid IdListaPrecio { get; set; }
        public string Descripcion { get; set; }
        public E_Estados Estado { get; set; }
        public bool EsPredeterminada { get; set; }
        public DateTime? VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }
        public List<ListaPrecioArticulo> Items { get; set; }

        public ListaPrecio()
        {
            IdListaPrecio = Guid.Empty;
            Descripcion = string.Empty;
            Estado = E_Estados.Activo;
            EsPredeterminada = false;
            VigenciaDesde = null;
            VigenciaHasta = null;
            Items = new List<ListaPrecioArticulo>();
        }
    }
}
