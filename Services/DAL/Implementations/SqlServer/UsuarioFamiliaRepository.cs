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
    public sealed class UsuarioFamiliaRepository : Repository, IJoinRepository<Usuario>
    {
        public UsuarioFamiliaRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {

        }

        public void Join(Usuario entity)
        {
            //Familia_PatenteSelectByIdFamilia
            string query = $"SELECT IdFamilia FROM Usuarios_Familias WHERE IdUsuario = @IdUsuario";
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@IdUsuario", entity.IdUsuario) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    //Busco en el repositorio de familias a partir del id familia de mi tupla-relación
                    entity.Accesos.Add(_unitOfWorkRepository.FamiliaRepository.GetById(Guid.Parse(data[0].ToString())));
                }
            }


        }

    }
}
