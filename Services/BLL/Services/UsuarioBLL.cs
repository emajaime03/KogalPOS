using Services.DAL.Factories;
using Services.DAL.Implementations.SqlServer;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.BLL.Base;
using Services.Domain.Enums;
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
        #region "Singleton"
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
        }
        #endregion

        #region "LOGIN"
        public ResUsuarioLogin Login(ReqUsuarioLogin req)
        {
            ResUsuarioLogin res = new ResUsuarioLogin();

            using (var context = ApplicationFactory.UnitOfWork.Create(false))
            {
                res.Usuario = context.Repositories.UsuarioRepository.GetByUserPassword(req.Username, req.Password);
                
                if (res.Usuario != null)
                {
                    if (!context.Repositories.UsuarioRepository.VerifyDVH(res.Usuario))
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


                    
            }

            return res;
        }
        #endregion

        #region "OBTENER"
        public ResUsuariosObtener ObtenerLista(ReqUsuariosObtener req)
        {
            ResUsuariosObtener res = new ResUsuariosObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create(false))
            {
                res.Usuarios = context.Repositories.UsuarioRepository.GetAll();

            }

            return res;
        }

        public ResUsuarioObtener Obtener(ReqUsuarioObtener req)
        {
            ResUsuarioObtener res = new ResUsuarioObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create(false))
            {
                res.ListaFamilias = context.Repositories.FamiliaRepository.GetAll()
                    .Where(f => f.Estado == E_Estados.Activo)
                    .ToList();
                res.ListaPatentes = context.Repositories.PatenteRepository.GetAll()
                    .Where(p => p.Estado == E_Estados.Activo)
                    .ToList();

                if (req.Id != null && req.Id != Guid.Empty)
                {
                    res.Usuario = context.Repositories.UsuarioRepository.GetById(req.Id);
                }


            }

            return res;
        }
        #endregion

        #region "INSERTAR"
        public ResUsuarioInsertar Insertar(ReqUsuarioInsertar req)
        {
            ResUsuarioInsertar res = new ResUsuarioInsertar();

            // Validaciones
            if (string.IsNullOrWhiteSpace(req.Usuario?.UserName))
            {
                res.Success = false;
                res.Message = "El nombre de usuario es requerido";
                return res;
            }

            if (string.IsNullOrWhiteSpace(req.Usuario?.Password))
            {
                res.Success = false;
                res.Message = "La contraseña es requerida";
                return res;
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                // Verificar que el nombre de usuario no exista
                var usuarios = context.Repositories.UsuarioRepository.GetAll();
                if (usuarios.Any(u => u.UserName.Equals(req.Usuario.UserName, StringComparison.OrdinalIgnoreCase)))
                {
                    res.Success = false;
                    res.Message = "El nombre de usuario ya existe";
                    return res;
                }

                req.Usuario.IdUsuario = Guid.NewGuid();
                req.Usuario.Estado = E_Estados.Activo;

                // Encriptar la contraseña
                req.Usuario.Password = CryptographyService.Hash(req.Usuario.Password);

                context.Repositories.UsuarioRepository.Add(req.Usuario);

                // Agregar relaciones con familias
                if (req.FamiliasIds != null)
                {
                    foreach (var familiaId in req.FamiliasIds)
                    {
                        context.Repositories.UsuarioFamiliaRepository.Add(req.Usuario.IdUsuario, familiaId);
                    }
                }

                // Agregar relaciones con patentes (solo las directas, no heredadas de familias)
                if (req.PatentesIds != null)
                {
                    foreach (var patenteId in req.PatentesIds)
                    {
                        context.Repositories.UsuarioPatenteRepository.Add(req.Usuario.IdUsuario, patenteId);
                    }
                }

                context.SaveChanges();

                res.Usuario = req.Usuario;
                res.Success = true;
                res.Message = "Usuario creado exitosamente";

                LoggerService.WriteLog(new Log($"Usuario '{req.Usuario.UserName}' creado.", GlobalCliente.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Info));
            }

            return res;
        }
        #endregion

        #region "MODIFICAR"
        public ResUsuarioModificar Modificar(ReqUsuarioModificar req)
        {
            ResUsuarioModificar res = new ResUsuarioModificar();

            // Validaciones
            if (req.Usuario?.IdUsuario == null || req.Usuario.IdUsuario == Guid.Empty)
            {
                res.Success = false;
                res.Message = "El ID del usuario es requerido";
                return res;
            }

            if (string.IsNullOrWhiteSpace(req.Usuario.UserName))
            {
                res.Success = false;
                res.Message = "El nombre de usuario es requerido";
                return res;
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                // Verificar que el nombre de usuario no exista en otro registro
                var usuarios = context.Repositories.UsuarioRepository.GetAll();
                if (usuarios.Any(u => u.UserName.Equals(req.Usuario.UserName, StringComparison.OrdinalIgnoreCase) 
                    && u.IdUsuario != req.Usuario.IdUsuario))
                {
                    res.Success = false;
                    res.Message = "El nombre de usuario ya existe";
                    return res;
                }

                // Actualizar el usuario
                context.Repositories.UsuarioRepository.Update(req.Usuario);

                // Eliminar relaciones anteriores
                context.Repositories.UsuarioFamiliaRepository.RemoveByFamilia(req.Usuario.IdUsuario);
                context.Repositories.UsuarioPatenteRepository.RemoveByFamilia(req.Usuario.IdUsuario);

                // Agregar nuevas relaciones con familias
                if (req.FamiliasIds != null)
                {
                    foreach (var familiaId in req.FamiliasIds)
                    {
                        context.Repositories.UsuarioFamiliaRepository.Add(req.Usuario.IdUsuario, familiaId);
                    }
                }

                // Agregar nuevas relaciones con patentes
                if (req.PatentesIds != null)
                {
                    foreach (var patenteId in req.PatentesIds)
                    {
                        context.Repositories.UsuarioPatenteRepository.Add(req.Usuario.IdUsuario, patenteId);
                    }
                }

                context.SaveChanges();

                res.Usuario = req.Usuario;
                res.Success = true;
                res.Message = "Usuario modificado exitosamente";

                LoggerService.WriteLog(new Log($"Usuario '{req.Usuario.UserName}' modificado.", GlobalCliente.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Info));
            }

            return res;
        }
        #endregion

        #region "ELIMINAR"
        public ResUsuarioEliminar Eliminar(ReqUsuarioEliminar req)
        {
            ResUsuarioEliminar res = new ResUsuarioEliminar();

            if (req.Id == Guid.Empty)
            {
                res.Success = false;
                res.Message = "El ID del usuario es requerido";
                return res;
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                var usuario = context.Repositories.UsuarioRepository.GetById(req.Id);
                
                // No permitir eliminar el usuario actual
                if (GlobalCliente.UsuarioLogin != null && GlobalCliente.UsuarioLogin.IdUsuario == req.Id)
                {
                    res.Success = false;
                    res.Message = "No puede eliminar el usuario con el que está logueado";
                    return res;
                }

                // Eliminación lógica (cambiar estado a Inactivo)
                context.Repositories.UsuarioRepository.Remove(req.Id);
                context.SaveChanges();

                res.Success = true;
                res.Message = "Usuario eliminado exitosamente";

                LoggerService.WriteLog(new Log($"Usuario '{usuario?.UserName}' eliminado.", GlobalCliente.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Info));
            }

            return res;
        }
        #endregion

        #region "RESTAURAR"
        public ResUsuarioRestaurar Restaurar(ReqUsuarioRestaurar req)
        {
            ResUsuarioRestaurar res = new ResUsuarioRestaurar();

            if (req.Id == Guid.Empty)
            {
                res.Success = false;
                res.Message = "El ID del usuario es requerido";
                return res;
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                context.Repositories.UsuarioRepository.Restore(req.Id);
                context.SaveChanges();

                var usuario = context.Repositories.UsuarioRepository.GetById(req.Id);

                res.Success = true;
                res.Message = "Usuario restaurado exitosamente";

                LoggerService.WriteLog(new Log($"Usuario '{usuario?.UserName}' restaurado.", GlobalCliente.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Info));
            }

            return res;
        }
        #endregion
    }
}
