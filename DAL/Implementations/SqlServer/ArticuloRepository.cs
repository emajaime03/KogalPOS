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
    public sealed class ArticuloRepository : BusinessRepository, IGenericRepository<Articulo>
    {
        public ArticuloRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Add(Articulo obj)
        {
            string query = @"INSERT INTO Articulos (IdArticulo, Codigo, Descripcion, Estado, StockActual) 
                             VALUES (@IdArticulo, @Codigo, @Descripcion, @Estado, @StockActual)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdArticulo", obj.IdArticulo),
                new SqlParameter("@Codigo", obj.Codigo),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@Estado", (int)obj.Estado),
                new SqlParameter("@StockActual", obj.StockActual)
            });
        }

        public void Update(Articulo obj)
        {
            string query = @"UPDATE Articulos 
                             SET Codigo = @Codigo, Descripcion = @Descripcion, Estado = @Estado
                             WHERE IdArticulo = @IdArticulo";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdArticulo", obj.IdArticulo),
                new SqlParameter("@Codigo", obj.Codigo),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Remove(Guid id)
        {
            string query = @"UPDATE Articulos SET Estado = @Estado WHERE IdArticulo = @IdArticulo";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdArticulo", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        public void Restore(Guid id)
        {
            string query = @"UPDATE Articulos SET Estado = @Estado WHERE IdArticulo = @IdArticulo";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdArticulo", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        public Articulo GetById(Guid id)
        {
            Articulo articulo = default;

            string query = "SELECT * FROM Articulos WHERE IdArticulo = @IdArticulo";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdArticulo", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    articulo = ArticuloMapper.Current.Fill(data);
                }
            }

            return articulo;
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> articulos = new List<Articulo>();

            string query = "SELECT * FROM Articulos";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    articulos.Add(ArticuloMapper.Current.Fill(data));
                }
            }

            return articulos;
        }
    }
}
