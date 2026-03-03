using Domain;
using Services.Domain.Enums;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class ClienteMapper
    {
        #region singleton
        private readonly static ClienteMapper _instance = new ClienteMapper();

        public static ClienteMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private ClienteMapper()
        {
        }
        #endregion

        public Cliente Fill(object[] values)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = System.Guid.Parse(values[0].ToString());
            cliente.Estado = (E_Estados)values[1];
            cliente.Descripcion = values[2].ToString();
            cliente.NroDocumento = values[3] != System.DBNull.Value ? values[3].ToString() : string.Empty;
            cliente.TipoDocumento = values[4] != System.DBNull.Value ? (E_TipoDocumento)values[4] : E_TipoDocumento.DNI;

            return cliente;
        }
    }
}
