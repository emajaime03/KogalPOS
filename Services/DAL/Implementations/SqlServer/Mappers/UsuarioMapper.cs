using Services.DAL.Contracts;
using Services.Domain;
using Services.Domain.Enums;
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
            Usuario usuario = new Usuario(Guid.Parse(values[0].ToString()));
            usuario.Estado = (E_Estados)Convert.ToInt32(values[1]);
            usuario.UserName = values[2].ToString();
            usuario.Password = values[3].ToString();

            return usuario;
        }

    }
}
