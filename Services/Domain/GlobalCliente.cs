using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public abstract class GlobalCliente
    {
        public Usuario UsuarioLogin { get; set; }
    }
}
