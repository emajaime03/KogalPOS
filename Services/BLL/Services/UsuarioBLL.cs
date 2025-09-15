using Services.DAL.Factories;
using Services.DAL.Implementations.SqlServer;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.BLL.Base;
using Services.Facade;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    internal class UsuarioBLL
    {
        private readonly static UsuarioBLL _instance = new UsuarioBLL();

        public static UsuarioBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private UsuarioBLL()
        {
            //Implent here the initialization of your singleton
        }

        public ResUsuarioLogin Login(ReqUsuarioLogin req)
        {
            ResUsuarioLogin res = new ResUsuarioLogin();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                res.Usuario = context.Repositories.UsuarioRepository.GetByUserPassword(req.Username, req.Password);
                 
                if (res.Usuario != null)
                {
                    if (context.Repositories.UsuarioRepository.GetHashedVH(res.Usuario.IdUsuario) != res.Usuario.HashVH)
                    {
                        res.Success = false;
                        res.Message = "Ha ocurrido un error de seguridad, por favor comunicar a soporte.";
                        LoggerService.WriteLog(new Log("Error de seguridad en el login.", res.Usuario.UserName, TraceLevel.Warning));
                        return res;
                    }
                }
                else
                {
                    res.Success = false;
                    res.Message = "Usuario o contraseña incorrectos.";
                    return res;
                }

                LoggerService.WriteLog(new Log("Login exitoso.", res.Usuario.UserName, TraceLevel.Info));

                context.SaveChanges();
                    
            }

            return res;
        }
            
    }
}
