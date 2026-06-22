using Domain;
using System;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class VentaDetalleMapper
    {
        #region singleton
        private readonly static VentaDetalleMapper _instance = new VentaDetalleMapper();

        public static VentaDetalleMapper Current
        {
            get { return _instance; }
        }

        private VentaDetalleMapper() { }
        #endregion

        /// <summary>
        /// Columnas esperadas: IdVentaDetalle, IdVenta, IdArticulo, Cantidad, PrecioUnitario, Descuento, Subtotal
        /// </summary>
        public VentaDetalle Fill(object[] values)
        {
            VentaDetalle d = new VentaDetalle();
            d.IdVentaDetalle = Guid.Parse(values[0].ToString());
            d.IdVenta = Guid.Parse(values[1].ToString());
            d.IdArticulo = Guid.Parse(values[2].ToString());
            d.Cantidad = Convert.ToDecimal(values[3]);
            d.PrecioUnitario = Convert.ToDecimal(values[4]);
            d.Descuento = Convert.ToDecimal(values[5]);
            d.Subtotal = Convert.ToDecimal(values[6]);

            return d;
        }
    }
}
