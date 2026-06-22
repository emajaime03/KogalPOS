using Domain;
using Services.DAL.Contracts;
using System;

namespace DAL.Contracts
{
    public interface IDocumentoRepository : IGenericRepository<Documento>
    {
        /// <summary>
        /// Obtiene el comprobante de venta (Tique/TiqueNoFiscal) asociado a una venta, con sus pagos.
        /// </summary>
        Documento GetByVenta(Guid idVenta);
    }
}
