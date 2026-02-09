using Services.DAL.Contracts;
using Services.DAL.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer
{
    public class SystemRepository : Repository, ISystemRepository
    {
        public SystemRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository) 
            : base(context, _transaction, unitOfWorkRepository)
        {
        }

        public void Backup(string path)
        {
            string dbName = _context.Database;
            string query = $"BACKUP DATABASE [{dbName}] TO DISK = @path WITH FORMAT, MEDIANAME = 'KogalPOS_Backup', NAME = 'Full Backup of KogalPOS';";
            
            ExecuteNonQuery(query, System.Data.CommandType.Text, new SqlParameter("@path", path));
        }

        public void Restore(string path)
        {
            string dbName = _context.Database;
            
            // Obtener cadena de conexión actual y cambiar Initial Catalog a master
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_context.ConnectionString);
            builder.InitialCatalog = "master";
            
            using (SqlConnection masterConnection = new SqlConnection(builder.ConnectionString))
            {
                masterConnection.Open();
                
                // 1. Poner la DB en modo SINGLE_USER para desconectar otros usuarios
                string step1 = $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                using (SqlCommand cmd = new SqlCommand(step1, masterConnection))
                {
                    cmd.ExecuteNonQuery();
                }

                // 2. Ejecutar el RESTORE
                string step2 = $"RESTORE DATABASE [{dbName}] FROM DISK = @path WITH REPLACE";
                using (SqlCommand cmd = new SqlCommand(step2, masterConnection))
                {
                    cmd.Parameters.AddWithValue("@path", path);
                    cmd.ExecuteNonQuery();
                }

                // 3. Volver a poner la DB en modo MULTI_USER
                string step3 = $"ALTER DATABASE [{dbName}] SET MULTI_USER";
                using (SqlCommand cmd = new SqlCommand(step3, masterConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
