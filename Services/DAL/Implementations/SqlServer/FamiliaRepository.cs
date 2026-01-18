using Services.DAL.Implementations.SqlServer.Mappers;
using Services.Domain;
using Services.Domain.Enums;
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
            string query = @"INSERT INTO Familias (IdFamilia, Descripcion, Estado) 
                             VALUES (@IdFamilia, @Descripcion, @Estado)";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", obj.Id),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Update(Familia obj)
        {
            string query = @"UPDATE Familias 
                             SET Descripcion = @Descripcion, Estado = @Estado 
                             WHERE IdFamilia = @IdFamilia";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", obj.Id),
                new SqlParameter("@Descripcion", obj.Descripcion),
                new SqlParameter("@Estado", (int)obj.Estado)
            });
        }

        public void Remove(Guid id)
        {
            // Eliminación lógica - cambiar estado a Inactivo
            string query = @"UPDATE Familias SET Estado = @Estado WHERE IdFamilia = @IdFamilia";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        public void Restore(Guid id)
        {
            // Restaurar - cambiar estado a Activo
            string query = @"UPDATE Familias SET Estado = @Estado WHERE IdFamilia = @IdFamilia";

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        public Familia GetById(Guid id)
        {
            Familia familia = default;

            string query = "SELECT * FROM Familias WHERE IdFamilia = @IdFamilia";
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
            List<Familia> familias = new List<Familia>();

            string query = "SELECT * FROM Familias";
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    Familia familia = FamiliaMapper.Current.Fill(data);

                    _unitOfWorkRepository.FamiliaPatenteRepository.Join(familia);
                    _unitOfWorkRepository.FamiliaFamiliaRepository.Join(familia);

                    familias.Add(familia);
                }
            }

            return familias;
        }
    }
}
