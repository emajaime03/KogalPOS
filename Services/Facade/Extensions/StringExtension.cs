using Services.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Extensions
{
    public static class StringExtension
    {
        public static string Translate(this string key)
        {
            return LanguageBLL.Translate(key);
        }
    }
}
