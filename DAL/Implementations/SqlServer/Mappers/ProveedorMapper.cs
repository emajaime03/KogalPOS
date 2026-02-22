using Domain;
using Services.Domain.Enums;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class ProveedorMapper
    {
        #region singleton
        private readonly static ProveedorMapper _instance = new ProveedorMapper();

        public static ProveedorMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private ProveedorMapper()
        {
        }
        #endregion

        public Proveedor Fill(object[] values)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.IdProveedor = System.Guid.Parse(values[0].ToString());
            proveedor.Estado = (E_Estados)values[1];
            proveedor.Descripcion = values[2].ToString();
            proveedor.Email = values[3] != System.DBNull.Value ? values[3].ToString() : string.Empty;
            proveedor.Celular = values[4] != System.DBNull.Value ? values[4].ToString() : string.Empty;

            return proveedor;
        }
    }
}
