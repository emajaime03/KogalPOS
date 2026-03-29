using DAL.Contracts;
using DAL.Contracts.UnitOfWork;
using Domain;
using Services.DAL.Contracts;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer.UnitOfWork
{
    public class BusinessUnitOfWorkRepository : IBusinessUnitOfWorkRepository
    {
        public IGenericRepository<Proveedor> ProveedorRepository { get; }
        public IGenericRepository<Articulo> ArticuloRepository { get; }
        public IGenericRepository<Cliente> ClienteRepository { get; }
        public IGenericRepository<MovimientoStock> MovimientoStockRepository { get; }
        public IListaPreciosRepository<ListaPrecio> ListaPrecioRepository { get; }
        public IConfiguracionesRepository<ConfiguracionLocal> ConfiguracionLocalRepository { get; }

        public BusinessUnitOfWorkRepository(SqlConnection context, SqlTransaction transaction)
        {
            ProveedorRepository = new ProveedorRepository(context, transaction);
            ArticuloRepository = new ArticuloRepository(context, transaction);
            ClienteRepository = new ClienteRepository(context, transaction);
            MovimientoStockRepository = new MovimientoStockRepository(context, transaction);
            ListaPrecioRepository = new ListaPrecioRepository(context, transaction);
            ConfiguracionLocalRepository = new ConfiguracionLocalRepository(context, transaction);
        }
    }
}
