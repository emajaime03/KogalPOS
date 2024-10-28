using Services.DAL.Contracts;
using Services.Domain;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Services.DAL.Implementations.PlainText
{
    internal class LanguageRepository : ILanguageRepository
    {
        #region Singleton
        private readonly static LanguageRepository _instance = new LanguageRepository();

        public static LanguageRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LanguageRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        private string Path = ApplicationSettings.Current.LanguagePath;
        public string Translate(string key)
        {
            string language = Thread.CurrentThread.CurrentUICulture.Name;
            string fileName = Path + language;

            using (StreamReader str = new StreamReader(fileName))
            {
                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    string[] columns = line.Split('=');

                    if (columns[0].ToLower() == key.ToLower())
                    {
                        //Mejorar la técnica con el usuario de diccionarios en memoria    
                        //Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();
                        //Probar redis o algún soft de caché
                        //Encontré la clave buscada...
                        return columns[1];
                    }
                }
            }
            //No encontré la clave...
            throw new Exception("Palabra o frase no encontrada");

        }
    }
}
