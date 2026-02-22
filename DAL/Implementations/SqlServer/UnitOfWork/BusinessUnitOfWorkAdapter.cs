using DAL.Contracts;
using Services.DAL.Implementations.SqlServer.UnitOfWork;

namespace DAL.Implementations.SqlServer.UnitOfWork
{
    /// <summary>
    /// Adapter concreto para la capa de negocio.
    /// Hereda la lógica de conexión/transacción del base genérico de Services.
    /// </summary>
    public class BusinessUnitOfWorkAdapter : UnitOfWorkSqlServerAdapter<IBusinessUnitOfWorkRepository>
    {
        public BusinessUnitOfWorkAdapter(string connectionString, bool useTransaction)
            : base(connectionString, useTransaction)
        {
            Repositories = new BusinessUnitOfWorkRepository(_context, _transaction);
        }
    }
}
