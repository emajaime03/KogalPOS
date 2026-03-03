using DAL.Implementations.SqlServer.Mappers;
using Domain;
using Services.DAL.Contracts;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    public sealed class ClienteRepository : BusinessRepository, IGenericRepository<Cliente>
    {
        public ClienteRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Add(Cliente obj)
        {
            string query = @"INSERT INTO Clientes (IdCliente, Descripcion, NroDocumento, TipoDocumento, Estado) 
                             VALUES (@IdCliente, @Descripcion, @NroDocumento, @TipoDocumento, @Estado)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCliente", obj.IdCliente),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@NroDocumento", (object)obj.NroDocumento ?? DBNull.Value),
                new SqlParameter("@TipoDocumento", (int)obj.TipoDocumento),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Update(Cliente obj)
        {
            string query = @"UPDATE Clientes 
                             SET Descripcion = @Descripcion, NroDocumento = @NroDocumento, TipoDocumento = @TipoDocumento, Estado = @Estado
                             WHERE IdCliente = @IdCliente";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCliente", obj.IdCliente),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@NroDocumento", (object)obj.NroDocumento ?? DBNull.Value),
                new SqlParameter("@TipoDocumento", (int)obj.TipoDocumento),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Remove(Guid id)
        {
            string query = @"UPDATE Clientes SET Estado = @Estado WHERE IdCliente = @IdCliente";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCliente", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        public void Restore(Guid id)
        {
            string query = @"UPDATE Clientes SET Estado = @Estado WHERE IdCliente = @IdCliente";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCliente", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        public Cliente GetById(Guid id)
        {
            Cliente cliente = default;

            string query = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdCliente", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    cliente = ClienteMapper.Current.Fill(data);
                }
            }

            return cliente;
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            string query = "SELECT * FROM Clientes";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    clientes.Add(ClienteMapper.Current.Fill(data));
                }
            }

            return clientes;
        }
    }
}
