using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Documento
    {
        public Guid IdDocumento { get; set; }
        public int NroDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public E_TipoComprobante TipoComprobante { get; set; }
        public Guid IdVenta { get; set; }
        public decimal Total { get; set; }
        public List<Pago> Pagos { get; set; }

        public Documento()
        {
            IdDocumento = Guid.Empty;
            NroDocumento = 0;
            Fecha = DateTime.Now;
            TipoComprobante = E_TipoComprobante.Tique;
            IdVenta = Guid.Empty;
            Total = 0;
            Pagos = new List<Pago>();
        }
    }
}
