using Services.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class LanguageService
    {
        public static string Translate(string key)
        {
            return LanguageBLL.Translate(key);
        }
    }
}
