using Services.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class MovimientoStockDTO
    {
        public Guid IdMovimientoStock { get; set; }
        public DateTime Fecha { get; set; }
        public E_TipoMovimiento TipoMovimiento { get; set; }
        public E_Estados Estado { get; set; }

        public List<MovimientoItemDTO> Items { get; set; }

        public MovimientoStockDTO()
        {
            IdMovimientoStock = Guid.Empty;
            Fecha = DateTime.Now;
            Items = new List<MovimientoItemDTO>();
        }
    }
}
