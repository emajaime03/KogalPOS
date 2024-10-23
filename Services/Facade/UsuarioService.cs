using Services.BLL.Services;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class UsuarioService
    {
        public static Usuario Login(string userName, string password)
        {
            return UsuarioBLL.Login(userName, password);
        } 
    }
}
