using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DAL.Contracts;
using Services.DAL.Tools.Helpers;
using Services.DAL.Contracts.UnitOfWork;

namespace Services.DAL.Implementations.SqlServer
{
    public sealed class FamiliaPatenteRepository : Repository, IJoinRepository<Familia>
    {
        public FamiliaPatenteRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {
        }

        public void Join(Familia entity)
        {
            string query = "SELECT IdPatente FROM Familias_Patentes WHERE IdFamilia = @IdFamilia";
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdFamilia", entity.Id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    // Busco en el repositorio de patentes a partir del id patente de mi tupla-relación
                    entity.Add(_unitOfWorkRepository.PatenteRepository.GetById(Guid.Parse(data[0].ToString())));
                }
            }
        }

        public void Add(Guid familiaId, Guid patenteId)
        {
            string query = @"INSERT INTO Familias_Patentes (IdFamilia, IdPatente) 
                             VALUES (@IdFamilia, @IdPatente)";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", familiaId),
                new SqlParameter("@IdPatente", patenteId)
            });
        }

        public void RemoveByFamilia(Guid familiaId)
        {
            string query = "DELETE FROM Familias_Patentes WHERE IdFamilia = @IdFamilia";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", familiaId)
            });
        }
    }
}
