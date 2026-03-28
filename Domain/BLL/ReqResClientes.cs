using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using Services.Domain;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqClientesObtener : ReqBase
    {
        public ReqClientesObtener(GlobalCliente sesion) : base(sesion) { }
    }

    public class ResClientesObtener : ResBase
    {
        public List<Cliente> Clientes { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqClienteObtener : ReqBase
    {
        public ReqClienteObtener(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResClienteObtener : ResBase
    {
        public Cliente Cliente { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqClienteInsertar : ReqBase
    {
        public ReqClienteInsertar(GlobalCliente sesion) : base(sesion) { }
        public Cliente Cliente { get; set; }
    }

    public class ResClienteInsertar : ResBase
    {
        public Cliente Cliente { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqClienteModificar : ReqBase
    {
        public ReqClienteModificar(GlobalCliente sesion) : base(sesion) { }
        public Cliente Cliente { get; set; }
    }

    public class ResClienteModificar : ResBase
    {
        public Cliente Cliente { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqClienteEliminar : ReqBase
    {
        public ReqClienteEliminar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResClienteEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqClienteRestaurar : ReqBase
    {
        public ReqClienteRestaurar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResClienteRestaurar : ResBase
    {
    }
    #endregion
}
