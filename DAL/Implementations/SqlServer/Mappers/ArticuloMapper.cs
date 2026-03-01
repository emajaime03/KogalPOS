using Domain;
using Services.Domain.Enums;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class ArticuloMapper
    {
        #region singleton
        private readonly static ArticuloMapper _instance = new ArticuloMapper();

        public static ArticuloMapper Current
        {
            get { return _instance; }
        }

        private ArticuloMapper() { }
        #endregion

        public Articulo Fill(object[] values)
        {
            Articulo articulo = new Articulo();
            articulo.IdArticulo = System.Guid.Parse(values[0].ToString());
            articulo.Estado = (E_Estados)values[1];
            articulo.Codigo = values[2].ToString();
            articulo.Descripcion = values[3].ToString();
            articulo.StockActual = System.Convert.ToDecimal(values[4]);

            return articulo;
        }
    }
}
