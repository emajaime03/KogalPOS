using Services.DAL.Contracts;
using Services.DAL.Contracts.UnitOfWork;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.UnitOfWork
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IUsuarioRepository<Usuario> UsuarioRepository { get; }
        public IJoinRepository<Usuario> UsuarioPatenteRepository { get; }
        public IJoinRepository<Usuario> UsuarioFamiliaRepository { get; }
        public IGenericRepository<Familia> FamiliaRepository { get; }
        public IJoinRepository<Familia> FamiliaFamiliaRepository { get; }
        public IJoinRepository<Familia> FamiliaPatenteRepository { get; }
        public IPatenteRepository<Patente> PatenteRepository { get; }
        public ISystemRepository SystemRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            UsuarioRepository = new UsuarioRepository(context, transaction, this);
            UsuarioPatenteRepository = new UsuarioPatenteRepository(context, transaction, this);
            UsuarioFamiliaRepository = new UsuarioFamiliaRepository(context, transaction, this);
            FamiliaRepository = new FamiliaRepository(context, transaction, this);
            FamiliaFamiliaRepository = new FamiliaFamiliaRepository(context, transaction, this);
            FamiliaPatenteRepository = new FamiliaPatenteRepository(context, transaction, this);
            PatenteRepository = new PatenteRepository(context, transaction, this);
            SystemRepository = new SystemRepository(context, transaction, this);
        }
    }
}
