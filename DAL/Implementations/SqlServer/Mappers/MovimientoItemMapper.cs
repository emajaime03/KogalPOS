using Domain;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class MovimientoItemMapper
    {
        #region singleton
        private readonly static MovimientoItemMapper _instance = new MovimientoItemMapper();

        public static MovimientoItemMapper Current
        {
            get { return _instance; }
        }

        private MovimientoItemMapper() { }
        #endregion

        /// <summary>
        /// Mapea un MovimientoItem desde un JOIN con Articulos.
        /// Columnas esperadas: IdMovimientoItem, IdMovimientoStock, IdArticulo, Cantidad, Codigo, Descripcion
        /// </summary>
        public MovimientoItem Fill(object[] values)
        {
            MovimientoItem item = new MovimientoItem();
            item.IdMovimientoItem = System.Guid.Parse(values[0].ToString());
            item.IdMovimientoStock = System.Guid.Parse(values[1].ToString());
            item.IdArticulo = System.Guid.Parse(values[2].ToString());
            item.Cantidad = System.Convert.ToDecimal(values[3]);
            item.CodigoArticulo = values[4].ToString();
            item.DescripcionArticulo = values[5].ToString();

            return item;
        }
    }
}
