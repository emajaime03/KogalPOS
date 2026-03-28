using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BLL
{
    public class ReqConfiguracionAppObtener : ReqBase
    {
        public ReqConfiguracionAppObtener(GlobalCliente sesion) : base(sesion)
        {
        }
    }

    public class ResConfiguracionAppObtener : ResBase
    {
        public ConfiguracionLocal configuracionLocal { get; set; }
    }
}
