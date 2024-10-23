using Services.DAL.Contracts;
using Services.DAL.Factories;
using Services.Domain;
using System;

namespace Services.BLL.Services
{
    internal static class LoggerBLL
    {
        private static readonly ILoggerRepository loggerDAO = LoggerFactory.Current.Logger();
        public static void WriteLog(Log log)
        {
            loggerDAO.WriteLog(log);
        }
    }
}
