using Domain.Enums;
using System;

namespace Domain
{
    public class MovimientoPuntos
    {
        public Guid IdMovimientoPuntos { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdPremio { get; set; }
        public E_TipoMovimientoPuntos TipoMovimiento { get; set; }
        public int Puntos { get; set; }
        public decimal MontoOperacion { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
    }
}
