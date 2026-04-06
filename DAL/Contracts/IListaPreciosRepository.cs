using Domain;
using Services.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IListaPreciosRepository : IGenericRepository<ListaPrecio>
    {
        bool EsPredeterminada(Guid id);
    }
}
