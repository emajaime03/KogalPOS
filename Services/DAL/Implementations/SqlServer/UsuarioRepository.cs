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
using Services.Facade;
using Services.Domain.Enums;

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
            string query = @"INSERT INTO Usuarios (IdUsuario, Estado, UserName, Password, DVH) 
                             VALUES (@IdUsuario, @Estado, @UserName, @Password, @DVH)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", obj.IdUsuario),
                new SqlParameter("@Estado", (int)obj.Estado),
                new SqlParameter("@UserName", obj.UserName),
                new SqlParameter("@Password", obj.Password),
                new SqlParameter("@DVH", obj.HashedDVH)
            });
        }

        public void Update(Usuario obj)
        {
            // Determinar si se proporciona una nueva contraseña
            // Si Password es null o vacío, significa que no se quiere cambiar la contraseña
            bool cambiarPassword = !string.IsNullOrEmpty(obj.Password);

            if (cambiarPassword)
            {
                // La contraseña es nueva (texto plano), hashearla
                obj.Password = CryptographyService.Hash(obj.Password);
            }
            else
            {
                // Obtener la contraseña actual de la BD para mantenerla y calcular el DVH correctamente
                string queryPassword = "SELECT Password FROM Usuarios WHERE IdUsuario = @IdUsuario";
                var passwordActual = base.ExecuteScalar(queryPassword, CommandType.Text, 
                    new SqlParameter[] { new SqlParameter("@IdUsuario", obj.IdUsuario) });
                obj.Password = passwordActual?.ToString() ?? string.Empty;
            }

            // Siempre actualizar UserName, Password y DVH (el DVH se recalcula con todos los campos actuales)
            string query = @"UPDATE Usuarios 
                          SET UserName = @UserName, 
                              Password = @Password,
                              DVH = @DVH
                          WHERE IdUsuario = @IdUsuario";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", obj.IdUsuario),
                new SqlParameter("@UserName", obj.UserName),
                new SqlParameter("@Password", obj.Password),
                new SqlParameter("@DVH", obj.HashedDVH)
            };

            base.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Remove(Guid id)
        {
            // Obtener el usuario actual para recalcular el DVH con el nuevo estado
            var usuario = GetById(id);
            if (usuario == null) return;

            usuario.Estado = E_Estados.Inactivo;

            // Eliminación lógica con actualización del DVH
            string query = @"UPDATE Usuarios SET Estado = @Estado, DVH = @DVH WHERE IdUsuario = @IdUsuario";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo),
                new SqlParameter("@DVH", usuario.HashedDVH)
            });
        }

        public void Restore(Guid id)
        {
            // Obtener el usuario actual para recalcular el DVH con el nuevo estado
            var usuario = GetById(id);
            if (usuario == null) return;

            usuario.Estado = E_Estados.Activo;

            // Restauración con actualización del DVH
            string query = @"UPDATE Usuarios SET Estado = @Estado, DVH = @DVH WHERE IdUsuario = @IdUsuario";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo),
                new SqlParameter("@DVH", usuario.HashedDVH)
            });
        }

        public Usuario GetById(Guid id)
        {
            Usuario usuario = null;

            string query = "SELECT * FROM Usuarios WHERE IdUsuario = @IdUsuario";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdUsuario", id) }))
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

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string query = "SELECT * FROM Usuarios ORDER BY UserName";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    var usuario = UsuarioMapper.Current.Fill(data);

                    _unitOfWorkRepository.UsuarioPatenteRepository.Join(usuario);
                    _unitOfWorkRepository.UsuarioFamiliaRepository.Join(usuario);

                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public Usuario GetByUserPassword(string user, string password)
        {
            Usuario usuario = default;

            string query = $"SELECT * FROM Usuarios WHERE UserName = @UserName AND Password = @Password";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
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
            var VH = base.ExecuteScalar(query, CommandType.Text, new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) }).ToString();
            return VH;
        }

        public bool VerifyDVH(Usuario usuario)
        {
            string query = $"SELECT DVH FROM Usuarios WHERE IdUsuario = @IdUsuario";
            var DVH = base.ExecuteScalar(query, CommandType.Text, new SqlParameter[] { new SqlParameter("@IdUsuario", usuario.IdUsuario) }).ToString();

            if (usuario.HashedDVH.Equals(DVH))
                return true;
            else
                return false;
        }
    }
}
