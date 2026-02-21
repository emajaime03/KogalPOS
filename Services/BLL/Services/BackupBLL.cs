using Services.DAL.Factories;
using Services.Domain;
using Services.Domain.BLL;
using Services.Facade;
using Services.Facade.Extensions;
using System;
using System.Diagnostics;
using System.IO;

namespace Services.BLL.Services
{
    public class BackupBLL
    {
        #region "Singleton"
        private readonly static BackupBLL _instance = new BackupBLL();

        public static BackupBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private BackupBLL()
        {
        }
        #endregion

        #region "BACKUP"
        public ResBackupRealizar RealizarBackup(ReqBackupRealizar req)
        {
            ResBackupRealizar res = new ResBackupRealizar();

            if (string.IsNullOrWhiteSpace(req.RutaArchivo))
            {
                res.Success = false;
                res.Message = "La ruta del archivo es requerida.";
                return res;
            }

            try
            {
                using (var context = ApplicationFactory.UnitOfWork.Create())
                {
                    context.Repositories.SystemRepository.Backup(req.RutaArchivo);
                    
                    res.Success = true;
                    res.Message = "Backup realizado exitosamente.";
                    
                    LoggerService.WriteLog(new Log($"Backup realizado en: {req.RutaArchivo}", GlobalCliente.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Info));
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = "Error al realizar el backup: " + ex.Message;
                ex.Handle(this);
            }

            return res;
        }
        #endregion

        #region "RESTORE"
        public ResBackupRestaurar RealizarRestore(ReqBackupRestaurar req)
        {
            ResBackupRestaurar res = new ResBackupRestaurar();

            if (string.IsNullOrWhiteSpace(req.RutaArchivo))
            {
                res.Success = false;
                res.Message = "La ruta del archivo es requerida.";
                return res;
            }

            if (!File.Exists(req.RutaArchivo))
            {
                res.Success = false;
                res.Message = "El archivo de backup no existe.";
                return res;
            }

            try
            {
                using (var context = ApplicationFactory.UnitOfWork.Create())
                {
                    // El repositorio se encargará de cambiar la conexión a Master
                    context.Repositories.SystemRepository.Restore(req.RutaArchivo);
                    
                    res.Success = true;
                    res.Message = "Base de datos restaurada exitosamente. La aplicación se reiniciará.";
                    
                    LoggerService.WriteLog(new Log($"Restore realizado desde: {req.RutaArchivo}", GlobalCliente.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Warning));
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = "Error al restaurar la base de datos: " + ex.Message;
                ex.Handle(this);
            }

            return res;
        }
        #endregion
    }
}
