using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BLL
{
    public class ReqConfiguracionLocalModificar : ReqBase
    {
        public ReqConfiguracionLocalModificar(GlobalCliente sesion) : base(sesion)
        {
        }

        public ConfiguracionLocal configuracionLocal { get; set; }
    }
    public class ResConfiguracionLocalModificar : ResBase
    {
        public ConfiguracionLocal configuracionLocal { get; set; }
    }
}
