using Domain;
using Services.Domain.Enums;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class CatalogoMapper
    {
        #region singleton
        private readonly static CatalogoMapper _instance = new CatalogoMapper();

        public static CatalogoMapper Current
        {
            get { return _instance; }
        }

        private CatalogoMapper() { }
        #endregion

        public Catalogo Fill(object[] values)
        {
            Catalogo catalogo = new Catalogo();
            catalogo.IdCatalogo = System.Guid.Parse(values[0].ToString());
            catalogo.Estado = (E_Estados)values[1];
            catalogo.Descripcion = values[2].ToString();
            return catalogo;
        }
    }
}
