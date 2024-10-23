using Services.DAL.Contracts.UnitOfWork;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.UnitOfWork
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        string connectionString = ApplicationSettings.Current.ServicesConnectionStringSqlServer;

        public UnitOfWorkSqlServer()
        {
        }

        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkSqlServerAdapter(connectionString);
        }
    }
}
