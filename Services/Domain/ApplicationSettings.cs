using System.Configuration;

namespace Services.Domain
{
    public sealed class ApplicationSettings
    {
        #region Singleton
        private readonly static ApplicationSettings _instance = new ApplicationSettings();

        public static ApplicationSettings Current
        {
            get
            {
                return _instance;
            }
        }

        private ApplicationSettings()
        {
            //Implement here the initialization code
        }
        #endregion

        public int ServicesPersistance
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["ServicesPersistance"]);
            }
        }

        public string ServicesConnectionStringSqlServer
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ServicesConnectionStringSqlServer"].ToString();
            }
        }

        public int LoggerPersistance
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["LoggerPersistance"]);
            }
        }

        public string LoggerPath
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LoggerPath"].ToString();
            }
        }

        public string LoggerConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LoggerConnectionString"].ToString();
            }
        }

        public string LoggerDbName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LoggerDbName"].ToString();
            }
        }

        public int LanguagePersistance
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["LanguagePersistance"]);
            }
        }

        public string LanguagePath
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LanguagePath"].ToString();
            }
        }
    }
}
