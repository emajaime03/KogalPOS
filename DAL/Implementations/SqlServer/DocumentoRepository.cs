using DAL.Contracts;
using DAL.Implementations.SqlServer.Mappers;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para Documentos (comprobantes) y sus Pagos.
    /// El Documento es la raíz: Add inserta cabecera (con NroDocumento correlativo) + pagos.
    /// </summary>
    public sealed class DocumentoRepository : BusinessRepository, IDocumentoRepository
    {
        public DocumentoRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        /// <summary>
        /// Inserta un documento completo: cabecera (con NroDocumento correlativo) + pagos.
        /// Asigna el NroDocumento generado al objeto recibido.
        /// </summary>
        public void Add(Documento documento)
        {
            object max = base.ExecuteScalar("SELECT ISNULL(MAX(NroDocumento), 0) + 1 FROM Documentos", CommandType.Text);
            documento.NroDocumento = Convert.ToInt32(max);

            string queryCabecera = @"INSERT INTO Documentos (IdDocumento, NroDocumento, Fecha, TipoComprobante, IdVenta, Total)
                                     VALUES (@Id, @Nro, @Fecha, @Tipo, @IdVenta, @Total)";
            base.ExecuteNonQuery(queryCabecera, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", documento.IdDocumento),
                new SqlParameter("@Nro", documento.NroDocumento),
                new SqlParameter("@Fecha", documento.Fecha),
                new SqlParameter("@Tipo", (int)documento.TipoComprobante),
                new SqlParameter("@IdVenta", documento.IdVenta),
                new SqlParameter("@Total", documento.Total)
            });

            foreach (var pago in documento.Pagos)
            {
                string queryPago = @"INSERT INTO Pagos (IdPago, IdDocumento, FormaPago, Importe, Fecha)
                                     VALUES (@IdPago, @IdDoc, @Forma, @Importe, @Fecha)";
                base.ExecuteNonQuery(queryPago, CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@IdPago", pago.IdPago),
                    new SqlParameter("@IdDoc", documento.IdDocumento),
                    new SqlParameter("@Forma", (int)pago.FormaPago),
                    new SqlParameter("@Importe", pago.Importe),
                    new SqlParameter("@Fecha", pago.Fecha)
                });
            }
        }

        /// <summary>
        /// Obtiene el comprobante de venta asociado (Tique/TiqueNoFiscal), con sus pagos.
        /// Si hubiera más de un documento para la venta, devuelve el de menor NroDocumento (el original).
        /// </summary>
        public Documento GetByVenta(Guid idVenta)
        {
            Documento doc = null;

            string query = @"SELECT TOP 1 IdDocumento, NroDocumento, Fecha, TipoComprobante, IdVenta, Total
                             FROM Documentos
                             WHERE IdVenta = @IdVenta AND TipoComprobante IN (1, 2)
                             ORDER BY NroDocumento ASC";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdVenta", idVenta) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    doc = DocumentoMapper.Current.Fill(data);
                }
            }

            if (doc == null) return null;

            string queryPagos = "SELECT IdPago, IdDocumento, FormaPago, Importe, Fecha FROM Pagos WHERE IdDocumento = @IdDoc";
            using (var reader = base.ExecuteReader(queryPagos, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdDoc", doc.IdDocumento) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    doc.Pagos.Add(PagoMapper.Current.Fill(data));
                }
            }

            return doc;
        }

        public Documento GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Documento> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Documento obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Restore(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
