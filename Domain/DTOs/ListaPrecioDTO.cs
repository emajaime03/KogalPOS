using Services.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class ListaPrecioDTO
    {
        public Guid IdListaPrecio { get; set; }
        public string Descripcion { get; set; }
        public E_Estados Estado { get; set; }
        public bool EsPredeterminada { get; set; }
        public DateTime? VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }

        public List<ListaPrecioArticuloDTO> Items { get; set; }

        public ListaPrecioDTO()
        {
            IdListaPrecio = Guid.Empty;
            Descripcion = string.Empty;
            EsPredeterminada = false;
            Items = new List<ListaPrecioArticuloDTO>();
        }
    }
}
