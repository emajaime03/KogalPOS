using System;
using Services.Domain;
using System.IO;
using Services.DAL.Contracts;

namespace Services.DAL.Implementations.PlainText
{
    internal class LoggerRepository : ILoggerRepository
    {
        #region Singleton
        private readonly static LoggerRepository _instance = new LoggerRepository();

        public static LoggerRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        private readonly string LoggerPath = ApplicationSettings.Current.LoggerPath;

        public void WriteLog(Log log)
        {
            try
            {
                WriteToFile(LoggerPath, FormatMessage(log));
            } catch { }
        }

        private string FormatMessage(Log log)
        {
            try
            {
                if (string.IsNullOrEmpty(log.Usuario))
                {
                    return $"{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")} [LEVEL {log.TraceLevel.ToString()}] Mensaje: {log.Message}";
                } 

                return $"{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")} [LEVEL {log.TraceLevel.ToString()}] User: {log.Usuario}, Mensaje: {log.Message}";
            } catch { }

            return "";
        }

        private void WriteToFile(string path, string message)
        {
            try
            {
                using (StreamWriter str = new StreamWriter(path, true))
                {
                    str.WriteLine(message);
                }
            } catch { }
        }
    }
}
