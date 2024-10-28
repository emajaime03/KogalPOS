using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    public interface IUsuarioRepository<T> : IGenericRepository<T>
    {
        T GetByUserPassword(string user, string password);
        string GetHashedVH(Guid idUsuario);
    }
}
