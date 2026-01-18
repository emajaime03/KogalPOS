using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqFamiliasObtener : ReqBase
    {
    }

    public class ResFamiliasObtener : ResBase
    {
        public List<Familia> Familias { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqFamiliaObtener : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResFamiliaObtener : ResBase
    {
        public Familia Familia { get; set; }
        public List<Patente> ListaPatentes { get; set; }
        public List<Familia> ListaFamilias { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqFamiliaInsertar : ReqBase
    {
        public Familia Familia { get; set; }
        public List<Guid> FamiliasHijosIds { get; set; }
        public List<Guid> PatentesIds { get; set; }
    }

    public class ResFamiliaInsertar : ResBase
    {
        public Familia Familia { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqFamiliaModificar : ReqBase
    {
        public Familia Familia { get; set; }
        public List<Guid> FamiliasHijosIds { get; set; }
        public List<Guid> PatentesIds { get; set; }
    }

    public class ResFamiliaModificar : ResBase
    {
        public Familia Familia { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqFamiliaEliminar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResFamiliaEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqFamiliaRestaurar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResFamiliaRestaurar : ResBase
    {
    }
    #endregion
}
