using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    public interface IJoinRepository<T>
    {
        void Join(T entity);
    }
}
