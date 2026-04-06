using DAL.Implementations.SqlServer.Mappers;
using Domain;
using Services.DAL.Contracts;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SqlServer
{
    public class PremiosRepository : BusinessRepository, IGenericRepository<Premio>
    {
        public PremiosRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Add(Premio obj)
        {
            string query = @"INSERT INTO Premios (IdPremio, Estado, IdArticulo, Descripcion, PuntosRequeridos) 
                             VALUES (@IdPremio, @Estado, @IdArticulo, @Descripcion, @PuntosRequeridos)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdPremio", obj.IdPremio),
                new SqlParameter("@Estado", (int)obj.Estado),
                new SqlParameter("@IdArticulo", obj.IdArticulo),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@PuntosRequeridos", obj.PuntosRequeridos),
            });
        }

        public List<Premio> GetAll()
        {
            List<Premio> premios = new List<Premio>();

            string query = "SELECT * FROM Premios";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    premios.Add(PremioMapper.Current.Fill(data));
                }
            }

            return premios;
        }

        public Premio GetById(Guid id)
        {
            Premio premio = default;

            string query = "SELECT * FROM Premios WHERE IdPremio = @IdPremio";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdPremio", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    premio = PremioMapper.Current.Fill(data);
                }
            }

            return premio;
        }

        public void Remove(Guid id)
        {
            string query = @"UPDATE Premios SET Estado = @Estado WHERE IdPremio = @IdPremio";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdPremio", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        public void Restore(Guid id)
        {
            string query = @"UPDATE Premios SET Estado = @Estado WHERE IdPremio = @IdPremio";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdPremio", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        public void Update(Premio obj)
        {
            string query = @"UPDATE Premios 
                             SET Estado = @Estado, IdArticulo = @IdArticulo, Descripcion = @Descripcion, PuntosRequeridos = @PuntosRequeridos
                             WHERE IdPremio = @IdPremio";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdPremio", obj.IdPremio),
                new SqlParameter("@Estado", (int)obj.Estado),
                new SqlParameter("@IdArticulo", obj.IdArticulo),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@PuntosRequeridos", obj.PuntosRequeridos),
            });
        }
    }
}
