using Services.DAL.Factories;
using Services.DAL.Implementations.SqlServer;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    internal static class UsuarioBLL
    {
        public static Usuario Login(string userName, string password)
        {
            try
            {
                using (var context = ApplicationFactory.UnitOfWork.Create())
                {
                    Usuario usuario = context.Repositories.UsuarioRepository.GetByUserPassword(userName, password);

                    return usuario;
                }

            } catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }

            return null;
        }
            
    }
}
