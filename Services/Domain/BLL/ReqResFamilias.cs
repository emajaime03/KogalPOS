using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BLL
{
    public class ReqFamiliasObtener : ReqBase
    {

    }
    public class ResFamiliasObtener : ResBase
    {
        public List<Familia> Familias { get; set; }
    }
}
