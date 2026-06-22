using Domain;
using Domain.Enums;
using System;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class PagoMapper
    {
        #region singleton
        private readonly static PagoMapper _instance = new PagoMapper();

        public static PagoMapper Current
        {
            get { return _instance; }
        }

        private PagoMapper() { }
        #endregion

        /// <summary>
        /// Columnas esperadas: IdPago, IdDocumento, FormaPago, Importe, Fecha
        /// </summary>
        public Pago Fill(object[] values)
        {
            Pago p = new Pago();
            p.IdPago = Guid.Parse(values[0].ToString());
            p.IdDocumento = Guid.Parse(values[1].ToString());
            p.FormaPago = (E_FormaPago)Convert.ToInt32(values[2]);
            p.Importe = Convert.ToDecimal(values[3]);
            p.Fecha = Convert.ToDateTime(values[4]);

            return p;
        }
    }
}
