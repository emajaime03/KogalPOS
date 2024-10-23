using Services.Domain;
using System;

namespace Services.DAL.Contracts
{
    public interface ILoggerRepository
    {
        void WriteLog(Log log);
    }
}
