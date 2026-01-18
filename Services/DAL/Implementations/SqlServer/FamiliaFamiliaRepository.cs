using Services.DAL.Contracts;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DAL.Tools.Helpers;
using Services.DAL.Contracts.UnitOfWork;

namespace Services.DAL.Implementations.SqlServer
{
    public sealed class FamiliaFamiliaRepository : Repository, IJoinRepository<Familia>
    {
        public FamiliaFamiliaRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {
        }

        public void Join(Familia entity)
        {
            string query = "SELECT IdFamiliaHijo FROM Familias_Familias WHERE IdFamilia = @IdFamilia";
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdFamilia", entity.Id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    // Busco en el repositorio de familias a partir del id familia de mi tupla-relación
                    entity.Add(_unitOfWorkRepository.FamiliaRepository.GetById(Guid.Parse(data[0].ToString())));
                }
            }
        }

        public void Add(Guid familiaId, Guid familiaHijoId)
        {
            string query = @"INSERT INTO Familias_Familias (IdFamilia, IdFamiliaHijo) 
                             VALUES (@IdFamilia, @IdFamiliaHijo)";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", familiaId),
                new SqlParameter("@IdFamiliaHijo", familiaHijoId)
            });
        }

        public void RemoveByFamilia(Guid familiaId)
        {
            string query = "DELETE FROM Familias_Familias WHERE IdFamilia = @IdFamilia";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", familiaId)
            });
        }
    }
}
