using Services.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Extensions
{
    public static class ExceptionExtension
    {
        public static void Handle(this Exception ex, object sender)
        {
            ExceptionBLL.Handle(ex, sender);
        }
    }
}
