using Services.Domain;
using Services.DAL.Contracts;

namespace Services.DAL.Factories
{
    internal sealed class LoggerFactory
    {
        #region Singleton
        private readonly static LoggerFactory _instance = new LoggerFactory();

        public static LoggerFactory Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerFactory()
        {
            //Implement here the initialization code
        }
        #endregion

        private int loggerPersistance = ApplicationSettings.Current.LoggerPersistance;

        public ILoggerRepository Logger()
        {
            switch (loggerPersistance)
            {
                case (int)ELoggerPersistance.File:
                    return Implementations.PlainText.LoggerRepository.Current;
                case (int)ELoggerPersistance.Sql:
                    return Implementations.SqlServer.LoggerRepository.Current;
                default:
                    return null;
            }
        }
    }

    internal enum ELoggerPersistance
    {
        File,
        Sql
    }
}
