using DAL.Contracts;
using Services.DAL.Contracts.UnitOfWork;
using System.Configuration;

namespace DAL.Implementations.SqlServer.UnitOfWork
{
    public class BusinessUnitOfWork : IUnitOfWork<IBusinessUnitOfWorkRepository>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["BusinessConnectionStringSqlServer"].ToString();

        public BusinessUnitOfWork()
        {
        }

        public IUnitOfWorkAdapter<IBusinessUnitOfWorkRepository> Create(bool useTransaction = true)
        {
            return new BusinessUnitOfWorkAdapter(_connectionString, useTransaction);
        }
    }
}
