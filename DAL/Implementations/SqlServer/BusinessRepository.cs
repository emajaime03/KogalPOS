using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Clase base para repositorios del negocio.
    /// Provee helpers SQL (ExecuteNonQuery, ExecuteReader, ExecuteScalar).
    /// </summary>
    public abstract class BusinessRepository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        private SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }

        public BusinessRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        protected int ExecuteNonQuery(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);

            using (var cmd = CreateCommand(commandText))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        private void CheckNullables(SqlParameter[] parameters)
        {
            foreach (SqlParameter item in parameters)
            {
                if (item.SqlValue == null)
                {
                    item.SqlValue = DBNull.Value;
                }
            }
        }

        protected object ExecuteScalar(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (var cmd = CreateCommand(commandText))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        protected SqlDataReader ExecuteReader(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (var cmd = CreateCommand(commandText))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
        }
    }
}
