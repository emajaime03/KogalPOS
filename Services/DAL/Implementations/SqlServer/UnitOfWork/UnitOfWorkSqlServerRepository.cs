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
        public IGenericRepository<Patente> PatenteRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            UsuarioRepository = new UsuarioRepository(context, transaction, this);
            UsuarioPatenteRepository = new UsuarioPatenteRepository(context, transaction);
            UsuarioFamiliaRepository = new UsuarioFamiliaRepository(context, transaction);
            FamiliaRepository = new FamiliaRepository(context, transaction);
            FamiliaFamiliaRepository = new FamiliaFamiliaRepository(context, transaction);
            FamiliaPatenteRepository = new FamiliaPatenteRepository(context, transaction);
            PatenteRepository = new PatenteRepository(context, transaction);
        }
    }
}
