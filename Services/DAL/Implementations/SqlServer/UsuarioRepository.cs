using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DAL.Contracts;
using Services.DAL.Implementations.SqlServer.Mappers;
using Services.DAL.Tools.Helpers;
using Services.DAL.Contracts.UnitOfWork;

namespace Services.DAL.Implementations.SqlServer
{
    internal class UsuarioRepository : Repository, IUsuarioRepository<Usuario>
    {
        public UsuarioRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {

        }

        public void Add(Usuario obj)
        {
            ////Esto debería ser una Tx
            //SqlHelper.ExecuteNonQuery("UsuarioInsert", CommandType.StoredProcedure,
            //  new SqlParameter[] { new SqlParameter("@IdUsuario", obj.IdUsuario),
            //                       new SqlParameter("@UserName", obj.UserName),
            //                       new SqlParameter("@Password", obj.Password) });

            ////Stop al SQL SERVER

            ////Hay que verificar las relaciones?
            //foreach (var item in obj.Accesos)
            //{
            //    if (item.GetCount() == 0)
            //    {
            //        //Estoy ante una patente
            //        //Usuario_PatenteInsert

            //    }
            //    else
            //    {
            //        //Estoy ante una familia
            //        //Usuario_FamiliaInsert
            //    }
            //}
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetByUserPassword(string user, string password)
        {
            Usuario usuario = default;

            string query = $"SELECT * FROM Usuarios WHERE UserName = @UserName AND Password = @Password";
            using (var reader = ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@UserName", user), new SqlParameter("@Password", password) }))
            {
                while (reader.Read())   
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    usuario = UsuarioMapper.Current.Fill(data);

                }
            }

            if (usuario != null)
            {
                _unitOfWorkRepository.UsuarioPatenteRepository.Join(usuario);
                _unitOfWorkRepository.UsuarioFamiliaRepository.Join(usuario);
            }           

            return usuario;
        }

        public string GetHashedVH(Guid idUsuario)
        {
            string query = $"SELECT VH FROM Usuarios WHERE IdUsuario = @IdUsuario";
            var VH = ExecuteScalar(query, CommandType.Text, new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) }).ToString();
            return VH;
        }
    }
}
