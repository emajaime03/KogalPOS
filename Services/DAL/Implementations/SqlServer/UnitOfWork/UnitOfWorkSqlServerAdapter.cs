using Services.DAL.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.UnitOfWork
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _context { get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkSqlServerAdapter(string connectionString, bool useTransaction)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("La cadena de conexión no puede estar vacía.", nameof(connectionString));

            try
            {
                _context = new SqlConnection(connectionString);
                _context.Open(); // puede lanzar SqlException
                    
                if (useTransaction)
                {
                    _transaction = _context.BeginTransaction(); // también puede lanzar error si falla la conexión
                }

                Repositories = new UnitOfWorkSqlServerRepository(_context, _transaction);
            }
            catch (SqlException ex)
            {
                // Error típico de SQL Server (login failed, timeout, etc.)
                throw new InvalidOperationException("No se pudo abrir la conexión a SQL Server.", ex);
            }
            catch (Exception ex)
            {
                // Cualquier otro error inesperado
                throw new InvalidOperationException("Error al inicializar UnitOfWorkSqlServerAdapter.", ex);
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            if (_transaction != null)
                _transaction.Commit();
        }
    }
}
