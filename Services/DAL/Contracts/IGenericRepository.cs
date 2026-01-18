using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    public interface IGenericRepository<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Remove(Guid id);

        void Restore(Guid id);

        T GetById(Guid id);

        List<T> GetAll();
    }
}
