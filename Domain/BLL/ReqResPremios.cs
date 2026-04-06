using Domain.DTOs;
using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqPremiosObtener : ReqBase
    {
        public ReqPremiosObtener(GlobalCliente sesion) : base(sesion)
        {
        }
    }

    public class ResPremiosObtener : ResBase
    {
        public List<PremioDTO> Premios { get; set; }
    }
    #endregion


    #region "OBTENER DETALLE"
    public class ReqPremioObtener : ReqBase
    {
        public ReqPremioObtener(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResPremioObtener : ResBase
    {
        public Premio Premio { get; set; }
        public List<Articulo> TodosArticulos { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqPremiosInsertar : ReqBase
    {
        public ReqPremiosInsertar(GlobalCliente sesion) : base(sesion) { }
        public Premio Premio { get; set; }
    }

    public class ResPremiosInsertar : ResBase
    {
    }
    #endregion

    #region "MODIFICAR"
    public class ReqPremiosModificar : ReqBase
    {
        public ReqPremiosModificar(GlobalCliente sesion) : base(sesion) { }
        public Premio Premio { get; set; }
    }

    public class ResPremiosModificar : ResBase
    {
    }
    #endregion

    #region "ELIMINAR"
    public class ReqPremiosEliminar : ReqBase
    {
        public ReqPremiosEliminar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResPremiosEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqPremiosRestaurar : ReqBase
    {
        public ReqPremiosRestaurar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResPremiosRestaurar : ResBase
    {
    }
    #endregion
}
