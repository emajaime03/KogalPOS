using Domain;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class ListaPrecioArticuloMapper
    {
        #region singleton
        private readonly static ListaPrecioArticuloMapper _instance = new ListaPrecioArticuloMapper();

        public static ListaPrecioArticuloMapper Current
        {
            get { return _instance; }
        }

        private ListaPrecioArticuloMapper() { }
        #endregion

        /// <summary>
        /// Mapea un ListaPrecioArticulo desde un JOIN con Articulos.
        /// Columnas esperadas: IdListaPrecioArticulo, IdListaPrecio, IdArticulo, Precio, Codigo, Descripcion
        /// </summary>
        public ListaPrecioArticulo Fill(object[] values)
        {
            ListaPrecioArticulo item = new ListaPrecioArticulo();
            item.IdListaPrecioArticulo = System.Guid.Parse(values[0].ToString());
            item.IdListaPrecio = System.Guid.Parse(values[1].ToString());
            item.IdArticulo = System.Guid.Parse(values[2].ToString());
            item.Precio = System.Convert.ToDecimal(values[3]);
            item.CodigoArticulo = values[4].ToString();
            item.DescripcionArticulo = values[5].ToString();

            return item;
        }
    }
}
