using DAL.Contracts;
using Domain;
using Services.DAL.Contracts;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer.UnitOfWork
{
    public class BusinessUnitOfWorkRepository : IBusinessUnitOfWorkRepository
    {
        public IGenericRepository<Proveedor> ProveedorRepository { get; }
        public IGenericRepository<Articulo> ArticuloRepository { get; }

        public BusinessUnitOfWorkRepository(SqlConnection context, SqlTransaction transaction)
        {
            ProveedorRepository = new ProveedorRepository(context, transaction);
            ArticuloRepository = new ArticuloRepository(context, transaction);
        }
    }
}
