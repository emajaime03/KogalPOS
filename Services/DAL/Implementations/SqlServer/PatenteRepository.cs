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
    public sealed class PatenteRepository : Repository, IGenericRepository<Patente>
    {
        public PatenteRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {

        }
        public void Add(Patente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Patente obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Patente GetById(Guid id)
        {
            Patente patente = default;

            string query = $"SELECT * FROM Patentes WHERE IdPatente = @IdPatente";

            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@IdPatente", id) }))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    patente = PatenteMapper.Current.Fill(data);
                }
            }

            return patente;
        }

        public List<Patente> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
