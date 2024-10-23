using Services.Domain;
using System;
using System.Diagnostics;
using Services.BLL.Services;

namespace Services.Facade
{
    public static class LoggerService
    {
        public static void WriteLog(Log log)
        {
            LoggerBLL.WriteLog(log);
        }

        public static void WriteException(Exception ex)
        {
            LoggerBLL.WriteLog(new Log(ex.Message, string.Empty, TraceLevel.Error));
        }
    }
}
