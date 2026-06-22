using Domain.Enums;
using System;

namespace Domain
{
    public class Pago
    {
        public Guid IdPago { get; set; }
        public Guid IdDocumento { get; set; }
        public E_FormaPago FormaPago { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }

        public Pago()
        {
            IdPago = Guid.Empty;
            IdDocumento = Guid.Empty;
            FormaPago = E_FormaPago.Efectivo;
            Importe = 0;
            Fecha = DateTime.Now;
        }
    }
}
