using Services.DAL.Contracts;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.Mappers
{
    public sealed class UsuarioMapper
    {
        #region singleton
        private readonly static UsuarioMapper _instance = new UsuarioMapper();

        public static UsuarioMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private UsuarioMapper()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Usuario Fill(object[] values)
        {
            //Nivel de hidratación 1 (Primitivos)
            Usuario usuario = new Usuario();
            usuario.IdUsuario = Guid.Parse(values[0].ToString());
            usuario.UserName = values[2].ToString();

            return usuario;
        }

    }
}
