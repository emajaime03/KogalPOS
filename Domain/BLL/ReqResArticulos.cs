using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqArticulosObtener : ReqBase
    {
        public ReqArticulosObtener(GlobalCliente sesion) : base(sesion)
        {
        }
    }

    public class ResArticulosObtener : ResBase
    {
        public List<Articulo> Articulos { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqArticuloObtener : ReqBase
    {
        public ReqArticuloObtener(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid Id { get; set; }
    }

    public class ResArticuloObtener : ResBase
    {
        public Articulo Articulo { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqArticuloInsertar : ReqBase
    {
        public ReqArticuloInsertar(GlobalCliente sesion) : base(sesion)
        {
        }

        public Articulo Articulo { get; set; }
    }

    public class ResArticuloInsertar : ResBase
    {
        public Articulo Articulo { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqArticuloModificar : ReqBase
    {
        public ReqArticuloModificar(GlobalCliente sesion) : base(sesion)
        {
        }

        public Articulo Articulo { get; set; }
    }

    public class ResArticuloModificar : ResBase
    {
        public Articulo Articulo { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqArticuloEliminar : ReqBase
    {
        public ReqArticuloEliminar(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid Id { get; set; }
    }

    public class ResArticuloEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqArticuloRestaurar : ReqBase
    {
        public ReqArticuloRestaurar(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid Id { get; set; }
    }

    public class ResArticuloRestaurar : ResBase
    {
    }
    #endregion
}
