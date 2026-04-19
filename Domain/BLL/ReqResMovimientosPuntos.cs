using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BLL
{
    #region "INSERTAR"
    public class ReqMovimientosPuntosInsertar : ReqBase
    {
        public ReqMovimientosPuntosInsertar(GlobalCliente sesion) : base(sesion) { }
        public List<MovimientoPuntos> MovimientosPuntos { get; set; }
    }

    public class ResMovimientosPuntosInsertar : ResBase
    {
    }
    #endregion
}
