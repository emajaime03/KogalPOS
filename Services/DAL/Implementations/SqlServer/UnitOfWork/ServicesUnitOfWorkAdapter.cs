using Services.DAL.Contracts.UnitOfWork;

namespace Services.DAL.Implementations.SqlServer.UnitOfWork
{
    public class ServicesUnitOfWorkAdapter : UnitOfWorkSqlServerAdapter<IUnitOfWorkRepository>
    {
        public ServicesUnitOfWorkAdapter(string connectionString, bool useTransaction)
            : base(connectionString, useTransaction)
        {
            Repositories = new UnitOfWorkSqlServerRepository(_context, _transaction);
        }
    }
}
