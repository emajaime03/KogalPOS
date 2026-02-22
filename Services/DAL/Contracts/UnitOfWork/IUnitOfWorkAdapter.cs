using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts.UnitOfWork
{
    public interface IUnitOfWorkAdapter<TRepository> : IDisposable
    {
        TRepository Repositories { get; }
        void SaveChanges();
    }
}
