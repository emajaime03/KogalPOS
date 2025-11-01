using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    public interface IPatenteRepository<T> : IGenericRepository<T>
    {
        void AddMany(IEnumerable<T> patentes);
    }
}
