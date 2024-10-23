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

namespace Services.DAL.Implementations.SqlServer
{
    public sealed class UsuarioPatenteRepository : Repository, IJoinRepository<Usuario>
    {
        public UsuarioPatenteRepository(SqlConnection context, SqlTransaction _transaction)
            : base(context, _transaction)
        {

        }

        public void Join(Usuario entity)
        {
            string query = $"SELECT IdPatente FROM Usuarios_Patentes WHERE IdUsuario = @IdUsuario";
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@IdUsuario", entity.IdUsuario) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    if (entity.Accesos.Any(x => x.Id == Guid.Parse(data[1].ToString())))
                    {
                        continue;
                    }

                    //Busco en el repositorio de patentes a partir del id patente de mi tupla-relación
                    entity.Accesos.Add(PatenteRepository.Current.GetById(Guid.Parse(data[0].ToString())));
                }
            }


        }

    }
}
