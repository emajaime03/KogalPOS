using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BLL.Base
{
    public abstract class ReqBase
    {
        public GlobalCliente Sesion { get; private set; }

        protected ReqBase(GlobalCliente sesion)
        {
            Sesion = sesion;
        }
    }

}
