using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using Services.Domain;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqProveedoresObtener : ReqBase
    {
        public ReqProveedoresObtener(GlobalCliente sesion) : base(sesion) { }
    }

    public class ResProveedoresObtener : ResBase
    {
        public List<Proveedor> Proveedores { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqProveedorObtener : ReqBase
    {
        public ReqProveedorObtener(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResProveedorObtener : ResBase
    {
        public Proveedor Proveedor { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqProveedorInsertar : ReqBase
    {
        public ReqProveedorInsertar(GlobalCliente sesion) : base(sesion) { }
        public Proveedor Proveedor { get; set; }
    }

    public class ResProveedorInsertar : ResBase
    {
        public Proveedor Proveedor { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqProveedorModificar : ReqBase
    {
        public ReqProveedorModificar(GlobalCliente sesion) : base(sesion) { }
        public Proveedor Proveedor { get; set; }
    }

    public class ResProveedorModificar : ResBase
    {
        public Proveedor Proveedor { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqProveedorEliminar : ReqBase
    {
        public ReqProveedorEliminar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResProveedorEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqProveedorRestaurar : ReqBase
    {
        public ReqProveedorRestaurar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResProveedorRestaurar : ResBase
    {
    }
    #endregion
}
