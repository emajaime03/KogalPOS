using System;
using Services.Domain;
using Services.DAL.Contracts;
using System.Data.SqlClient;

namespace Services.DAL.Implementations.SqlServer
{
    internal class LoggerRepository : ILoggerRepository
    {
        #region Singleton
        private readonly static LoggerRepository _instance = new LoggerRepository();

        public static LoggerRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        private readonly string LoggerConnectionString = ApplicationSettings.Current.LoggerConnectionString;
        private readonly string LoggerDbName = ApplicationSettings.Current.LoggerDbName;

        public void WriteLog(Log log)
        {
            WriteToDatabase(LoggerConnectionString, LoggerDbName, log);
        }

        private void WriteToDatabase(string connectionString, string dbName, Log log)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"INSERT INTO {dbName} (Date, Message, Level, IdUsuario) VALUES ({DateTime.Now.ToString()}, '{log.Message}', {log.TraceLevel}, {log.Usuario})", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
