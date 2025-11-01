using Services.Domain.BLL.Base;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BLL
{
    public class ReqPatentesSincronizar : ReqBase { }

    public class ReqPatentesObtener : ReqBase
    {

    }
    public class ResPatentesObtener : ResBase
    {
        public List<Patente> Patentes { get; set; }
    }
}
