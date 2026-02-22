using Services.DAL.Contracts.UnitOfWork;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.UnitOfWork
{
    public class UnitOfWorkSqlServer : IUnitOfWork<IUnitOfWorkRepository>
    {
        string connectionString = ApplicationSettings.Current.ServicesConnectionStringSqlServer;

        public UnitOfWorkSqlServer()
        {
        }

        public IUnitOfWorkAdapter<IUnitOfWorkRepository> Create(bool useTransaction = true)
        {
            return new ServicesUnitOfWorkAdapter(connectionString, useTransaction);
        }
    }
}
