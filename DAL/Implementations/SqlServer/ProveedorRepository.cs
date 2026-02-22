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
    public sealed class ProveedorRepository : BusinessRepository, IGenericRepository<Proveedor>
    {
        public ProveedorRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Add(Proveedor obj)
        {
            string query = @"INSERT INTO Proveedores (IdProveedor, Descripcion, Email, Celular, Estado) 
                             VALUES (@IdProveedor, @Descripcion, @Email, @Celular, @Estado)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", obj.IdProveedor),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@Email", (object)obj.Email ?? DBNull.Value),
                new SqlParameter("@Celular", (object)obj.Celular ?? DBNull.Value),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Update(Proveedor obj)
        {
            string query = @"UPDATE Proveedores 
                             SET Descripcion = @Descripcion, Email = @Email, Celular = @Celular, Estado = @Estado
                             WHERE IdProveedor = @IdProveedor";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", obj.IdProveedor),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@Email", (object)obj.Email ?? DBNull.Value),
                new SqlParameter("@Celular", (object)obj.Celular ?? DBNull.Value),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Remove(Guid id)
        {
            string query = @"UPDATE Proveedores SET Estado = @Estado WHERE IdProveedor = @IdProveedor";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        public void Restore(Guid id)
        {
            string query = @"UPDATE Proveedores SET Estado = @Estado WHERE IdProveedor = @IdProveedor";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        public Proveedor GetById(Guid id)
        {
            Proveedor proveedor = default;

            string query = "SELECT * FROM Proveedores WHERE IdProveedor = @IdProveedor";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdProveedor", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    proveedor = ProveedorMapper.Current.Fill(data);
                }
            }

            return proveedor;
        }

        public List<Proveedor> GetAll()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            string query = "SELECT * FROM Proveedores";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    proveedores.Add(ProveedorMapper.Current.Fill(data));
                }
            }

            return proveedores;
        }
    }
}
