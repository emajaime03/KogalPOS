using Services.DAL.Contracts;
using Services.DAL.Factories;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    internal static class LanguageBLL
    {
        private static readonly ILanguageRepository languageDAO = LanguageFactory.Current.Language();

        public static string Translate(string key)
        {
            try
            {
                return languageDAO.Translate(key);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }

            return key;
        }
    }
}
