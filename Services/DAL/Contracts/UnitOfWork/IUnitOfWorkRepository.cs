using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        IUsuarioRepository<Usuario> UsuarioRepository { get; }
        IJoinRepository<Usuario> UsuarioPatenteRepository { get; }
        IJoinRepository<Usuario> UsuarioFamiliaRepository { get; }
        IGenericRepository<Familia> FamiliaRepository { get; }
        IJoinRepository<Familia> FamiliaFamiliaRepository { get; }
        IJoinRepository<Familia> FamiliaPatenteRepository { get; }
        IPatenteRepository<Patente> PatenteRepository { get; }
        ISystemRepository SystemRepository { get; }
    }
}
