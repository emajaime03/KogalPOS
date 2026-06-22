using Domain;
using Domain.Enums;
using System;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class VentaMapper
    {
        #region singleton
        private readonly static VentaMapper _instance = new VentaMapper();

        public static VentaMapper Current
        {
            get { return _instance; }
        }

        private VentaMapper() { }
        #endregion

        /// <summary>
        /// Columnas esperadas: IdVenta, NroVenta, Fecha, Estado, Total, Descuento, IdCliente, IdListaPrecio
        /// </summary>
        public Venta Fill(object[] values)
        {
            Venta v = new Venta();
            v.IdVenta = Guid.Parse(values[0].ToString());
            v.NroVenta = Convert.ToInt32(values[1]);
            v.Fecha = Convert.ToDateTime(values[2]);
            v.Estado = (E_EstadoVenta)Convert.ToInt32(values[3]);
            v.Total = Convert.ToDecimal(values[4]);
            v.Descuento = Convert.ToDecimal(values[5]);
            v.IdCliente = values[6] == DBNull.Value ? (Guid?)null : Guid.Parse(values[6].ToString());
            v.IdListaPrecio = Guid.Parse(values[7].ToString());

            return v;
        }
    }
}
