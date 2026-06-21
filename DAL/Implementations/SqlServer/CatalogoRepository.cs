using DAL.Contracts;
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
    public sealed class CatalogoRepository : BusinessRepository, ICatalogosRepository
    {
        public CatalogoRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Add(Catalogo obj)
        {
            string query = @"INSERT INTO catalogos (IdCatalogo, Estado, Descripcion)
                             VALUES (@IdCatalogo, @Estado, @Descripcion)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCatalogo", obj.IdCatalogo),
                new SqlParameter("@Estado", (int)obj.Estado),
                new SqlParameter("@Descripcion", obj.Descripcion)
            });
        }

        public void Update(Catalogo obj)
        {
            string query = @"UPDATE catalogos
                             SET Estado = @Estado, Descripcion = @Descripcion
                             WHERE IdCatalogo = @IdCatalogo";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCatalogo", obj.IdCatalogo),
                new SqlParameter("@Estado", (int)obj.Estado),
                new SqlParameter("@Descripcion", obj.Descripcion)
            });
        }

        public void Remove(Guid id)
        {
            string query = "UPDATE catalogos SET Estado = @Estado WHERE IdCatalogo = @IdCatalogo";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCatalogo", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        public void Restore(Guid id)
        {
            string query = "UPDATE catalogos SET Estado = @Estado WHERE IdCatalogo = @IdCatalogo";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCatalogo", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        public Catalogo GetById(Guid id)
        {
            Catalogo catalogo = default;

            string query = "SELECT * FROM catalogos WHERE IdCatalogo = @IdCatalogo";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdCatalogo", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    catalogo = CatalogoMapper.Current.Fill(data);
                }
            }

            return catalogo;
        }

        public List<Catalogo> GetAll()
        {
            List<Catalogo> catalogos = new List<Catalogo>();

            string query = "SELECT * FROM catalogos";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    catalogos.Add(CatalogoMapper.Current.Fill(data));
                }
            }

            return catalogos;
        }

        public List<Guid> GetArticulosAsignados(Guid idCatalogo)
        {
            var ids = new List<Guid>();

            string query = "SELECT IdArticulo FROM articulos_catalogos WHERE IdCatalogo = @IdCatalogo";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdCatalogo", idCatalogo) }))
            {
                while (reader.Read())
                {
                    ids.Add(Guid.Parse(reader[0].ToString()));
                }
            }

            return ids;
        }

        public void ReasignarArticulos(Guid idCatalogo, List<Guid> idsArticulos)
        {
            string deleteQuery = "DELETE FROM articulos_catalogos WHERE IdCatalogo = @IdCatalogo";
            base.ExecuteNonQuery(deleteQuery, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdCatalogo", idCatalogo)
            });

            if (idsArticulos == null || idsArticulos.Count == 0)
                return;

            string insertQuery = @"INSERT INTO articulos_catalogos (IdArticuloCatalogo, IdCatalogo, IdArticulo)
                                   VALUES (@IdArticuloCatalogo, @IdCatalogo, @IdArticulo)";

            foreach (var idArticulo in idsArticulos)
            {
                base.ExecuteNonQuery(insertQuery, CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@IdArticuloCatalogo", Guid.NewGuid()),
                    new SqlParameter("@IdCatalogo", idCatalogo),
                    new SqlParameter("@IdArticulo", idArticulo)
                });
            }
        }
    }
}
