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
        public IArticulosRepository ArticuloRepository { get; }
        public IGenericRepository<Cliente> ClienteRepository { get; }
        public IGenericRepository<MovimientoStock> MovimientoStockRepository { get; }
        public IListaPreciosRepository ListaPrecioRepository { get; }
        public IConfiguracionesRepository<ConfiguracionLocal> ConfiguracionLocalRepository { get; }
        public IGenericRepository<Premio> PremiosRepository { get; }
        public IMovimientosPuntosRepository MovimientosPuntosRepository { get; }

        private ILoyaltyRepository _loyaltyRepository;
        public ILoyaltyRepository LoyaltyRepository => _loyaltyRepository ?? (_loyaltyRepository = new DAL.Implementations.Api.FirebaseLoyaltyRepository());


        public BusinessUnitOfWorkRepository(SqlConnection context, SqlTransaction transaction)
        {
            ProveedorRepository = new ProveedorRepository(context, transaction);
            ArticuloRepository = new ArticuloRepository(context, transaction);
            ClienteRepository = new ClienteRepository(context, transaction);
            MovimientoStockRepository = new MovimientoStockRepository(context, transaction);
            ListaPrecioRepository = new ListaPrecioRepository(context, transaction);
            ConfiguracionLocalRepository = new ConfiguracionLocalRepository(context, transaction);
            PremiosRepository = new PremiosRepository(context, transaction);
            MovimientosPuntosRepository = new MovimientosPuntosRepository(context, transaction);
        }
    }
}
