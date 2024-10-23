using Services.Domain;
using Services.DAL.Contracts;

namespace Services.DAL.Factories
{
    internal sealed class LanguageFactory
    {
        #region Singleton
        private readonly static LanguageFactory _instance = new LanguageFactory();

        public static LanguageFactory Current
        {
            get
            {
                return _instance;
            }
        }

        private LanguageFactory()
        {
            //Implement here the initialization code
        }
        #endregion

        private int languagePersistance = ApplicationSettings.Current.LanguagePersistance;

        public ILanguageRepository Language()
        {
            switch (languagePersistance)
            {
                case (int)ELoggerPersistance.File:
                    return Implementations.PlainText.LanguageRepository.Current;
                default:
                    return null;
            }
        }
    }

    internal enum ELanguagePersistance
    {
        File
    }
}
