using Services.DAL.Factories;
using Services.Domain;
using Services.Domain.BLL;
using Services.Facade;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ResBackupRealizar RealizarBackup(ReqBackupRealizar req, GlobalCliente sesion)
        {
            ResBackupRealizar res = new ResBackupRealizar();

            // Ahora evaluamos RutaArchivo como una CARPETA de destino, no un archivo final.
            if (string.IsNullOrWhiteSpace(req.RutaArchivo))
            {
                res.Success = false;
                res.Message = "La ruta de la carpeta destino es requerida.";
                return res;
            }

            // Detectar si el usuario pasó un archivo en lugar de una carpeta
            if (File.Exists(req.RutaArchivo))
            {
                res.Success = false;
                res.Message = $"La ruta especificada es un archivo, no una carpeta: '{req.RutaArchivo}'. Seleccioná la carpeta donde guardar los backups.";
                return res;
            }

            // Crear la carpeta destino si no existe
            if (!Directory.Exists(req.RutaArchivo))
            {
                Directory.CreateDirectory(req.RutaArchivo);
            }

            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                int backupsRealizados = 0;
                List<string> errores = new List<string>();

                // Crear subcarpeta para esta tanda: {carpetaElegida}\KogalPOS_Backup_{timestamp}\
                string subFolder = Path.Combine(req.RutaArchivo, $"KogalPOS_Backup_{timestamp}");
                Directory.CreateDirectory(subFolder);

                // Iterar sobre las cadenas de conexión del config
                foreach (ConnectionStringSettings connSetting in ConfigurationManager.ConnectionStrings)
                {
                    // Ignorar la conexión por defecto de .NET y cadenas vacías
                    if (connSetting.Name == "LocalSqlServer" || string.IsNullOrWhiteSpace(connSetting.ConnectionString))
                    {
                        continue;
                    }

                    string fileName = $"{connSetting.Name}_Backup_{timestamp}.bak";
                    string fullPath = Path.Combine(subFolder, fileName);

                    try
                    {
                        using (var context = ApplicationFactory.UnitOfWork.Create(connSetting.ConnectionString))
                        {
                            context.Repositories.SystemRepository.Backup(fullPath);
                        }

                        backupsRealizados++;
                        LoggerService.WriteLog(new Log($"Backup de la base '{connSetting.Name}' realizado en: {fullPath}", sesion?.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Info));
                    }
                    catch (Exception exDb)
                    {
                        string errorMsj = $"Falló {connSetting.Name}: {exDb.Message}";
                        errores.Add(errorMsj);
                        LoggerService.WriteLog(new Log(errorMsj, sesion?.UsuarioLogin?.UserName ?? "Sistema", TraceLevel.Error));
                    }
                }

                // Evaluar el resultado final
                if (errores.Count == 0 && backupsRealizados > 0)
                {
                    res.Success = true;
                    res.Message = $"Se realizaron {backupsRealizados} backups exitosamente.";
                }
                else if (backupsRealizados > 0 && errores.Count > 0)
                {
                    res.Success = false; // O true, dependiendo de si consideras un éxito parcial como válido
                    res.Message = $"Se realizaron {backupsRealizados} backups. Hubo errores: {string.Join(" | ", errores)}";
                }
                else
                {
                    res.Success = false;
                    res.Message = $"No se pudo realizar ningún backup. Errores: {string.Join(" | ", errores)}";
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = "Error general al procesar los backups: " + ex.Message;
                ex.Handle(this);
            }

            return res;
        }
        #endregion

        #region "RESTORE"
        public ResBackupRestaurar RealizarRestore(ReqBackupRestaurar req, GlobalCliente sesion)
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

            // Resolver la connection string: si viene un nombre, buscarla en el config;
            // si no viene, usar la de ApplicationSettings por defecto.
            string connectionString = null;
            string dbLabel = "base de datos por defecto";

            if (!string.IsNullOrWhiteSpace(req.ConnectionStringName))
            {
                var connSetting = ConfigurationManager.ConnectionStrings[req.ConnectionStringName];
                if (connSetting == null || string.IsNullOrWhiteSpace(connSetting.ConnectionString))
                {
                    res.Success = false;
                    res.Message = $"No se encontró la cadena de conexión '{req.ConnectionStringName}' en el archivo de configuración.";
                    return res;
                }
                connectionString = connSetting.ConnectionString;
                dbLabel = req.ConnectionStringName;
            }

            try
            {
                using (var context = connectionString != null
                    ? ApplicationFactory.UnitOfWork.Create(connectionString)
                    : ApplicationFactory.UnitOfWork.Create())
                {
                    context.Repositories.SystemRepository.Restore(req.RutaArchivo);

                    res.Success = true;
                    res.Message = $"Base de datos '{dbLabel}' restaurada exitosamente.";

                    LoggerService.WriteLog(new Log(
                        $"Restore de '{dbLabel}' realizado desde: {req.RutaArchivo}",
                        sesion?.UsuarioLogin?.UserName ?? "Sistema",
                        TraceLevel.Warning));
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = $"Error al restaurar '{dbLabel}': " + ex.Message;
                ex.Handle(this);
            }

            return res;
        }
        #endregion
    }
}
