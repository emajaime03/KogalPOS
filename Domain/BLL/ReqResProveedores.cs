using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqProveedoresObtener : ReqBase
    {
    }

    public class ResProveedoresObtener : ResBase
    {
        public List<Proveedor> Proveedores { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqProveedorObtener : ReqBase
    {
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
        public Guid Id { get; set; }
    }

    public class ResProveedorEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqProveedorRestaurar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResProveedorRestaurar : ResBase
    {
    }
    #endregion
}
