using Domain;
using Services.DAL.Contracts;
using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface IArticulosRepository : IGenericRepository<Articulo>
    {
        IEnumerable<Articulo> GetByIds(IEnumerable<Guid> ids);
    }
}
