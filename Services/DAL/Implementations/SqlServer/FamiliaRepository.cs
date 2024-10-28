using Services.DAL.Implementations.SqlServer.Mappers;
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
    public sealed class FamiliaRepository : Repository, IGenericRepository<Familia>
    {
        public FamiliaRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {

        }

        public void Add(Familia obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Familia obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Familia GetById(Guid id)
        {
            Familia familia = default;

            string query = $"SELECT * FROM Familias WHERE IdFamilia = @IdFamilia";
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@IdFamilia", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    familia = FamiliaMapper.Current.Fill(data);

                    _unitOfWorkRepository.FamiliaPatenteRepository.Join(familia);
                    _unitOfWorkRepository.FamiliaFamiliaRepository.Join(familia);
                }
            }

            return familia;
        }

        public List<Familia> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
