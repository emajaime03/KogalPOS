using DAL.Contracts;
using Services.DAL.Contracts.UnitOfWork;

namespace DAL.Implementations.SqlServer.UnitOfWork
{
    public class BusinessUnitOfWork : IUnitOfWork<IBusinessUnitOfWorkRepository>
    {
        private readonly string _connectionString;

        public BusinessUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUnitOfWorkAdapter<IBusinessUnitOfWorkRepository> Create(bool useTransaction = true)
        {
            return new BusinessUnitOfWorkAdapter(_connectionString, useTransaction);
        }
    }
}
