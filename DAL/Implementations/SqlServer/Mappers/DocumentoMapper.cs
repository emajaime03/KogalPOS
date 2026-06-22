using Domain;
using Domain.Enums;
using System;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class DocumentoMapper
    {
        #region singleton
        private readonly static DocumentoMapper _instance = new DocumentoMapper();

        public static DocumentoMapper Current
        {
            get { return _instance; }
        }

        private DocumentoMapper() { }
        #endregion

        /// <summary>
        /// Columnas esperadas: IdDocumento, NroDocumento, Fecha, TipoComprobante, IdVenta, Total
        /// </summary>
        public Documento Fill(object[] values)
        {
            Documento doc = new Documento();
            doc.IdDocumento = Guid.Parse(values[0].ToString());
            doc.NroDocumento = Convert.ToInt32(values[1]);
            doc.Fecha = Convert.ToDateTime(values[2]);
            doc.TipoComprobante = (E_TipoComprobante)Convert.ToInt32(values[3]);
            doc.IdVenta = Guid.Parse(values[4].ToString());
            doc.Total = Convert.ToDecimal(values[5]);

            return doc;
        }
    }
}
