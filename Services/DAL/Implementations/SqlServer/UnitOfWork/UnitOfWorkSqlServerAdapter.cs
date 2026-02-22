using Services.DAL.Contracts.UnitOfWork;
using System;
using System.Data.SqlClient;

namespace Services.DAL.Implementations.SqlServer.UnitOfWork
{
    public class UnitOfWorkSqlServerAdapter<TRepository> : IUnitOfWorkAdapter<TRepository>
    {
        protected SqlConnection _context { get; set; }
        protected SqlTransaction _transaction { get; set; }
        public TRepository Repositories { get; set; }

        public UnitOfWorkSqlServerAdapter(string connectionString, bool useTransaction)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("La cadena de conexión no puede estar vacía.", nameof(connectionString));

            try
            {
                _context = new SqlConnection(connectionString);
                _context.Open();
                    
                if (useTransaction)
                {
                    _transaction = _context.BeginTransaction();
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("No se pudo abrir la conexión a SQL Server.", ex);
            }
            catch (Exception ex)
            {
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

            Repositories = default(TRepository);
        }

        public void SaveChanges()
        {
            if (_transaction != null)
                _transaction.Commit();
        }
    }
}
