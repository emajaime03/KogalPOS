using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BLL
{
    public class ReqUsuarioLogin : ReqBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ResUsuarioLogin : ResBase
    {
        public Usuario Usuario { get; set; }
    }
}
