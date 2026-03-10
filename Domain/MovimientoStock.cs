using Services.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class MovimientoStock
    {
        public Guid IdMovimientoStock { get; set; }
        public DateTime Fecha { get; set; }
        public E_TipoMovimiento TipoMovimiento { get; set; }
        public E_Estados Estado { get; set; }
        public List<MovimientoItem> Items { get; set; }

        public MovimientoStock()
        {
            IdMovimientoStock = Guid.Empty;
            Fecha = DateTime.Now;
            TipoMovimiento = E_TipoMovimiento.Alta;
            Estado = E_Estados.Activo;
            Items = new List<MovimientoItem>();
        }
    }
}

