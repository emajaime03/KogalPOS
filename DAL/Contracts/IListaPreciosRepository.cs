using Services.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IListaPreciosRepository<T> : IGenericRepository<T>
    {
        bool EsPredeterminada(Guid id);
    }
}
