using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqArticulosObtener : ReqBase
    {
    }

    public class ResArticulosObtener : ResBase
    {
        public List<Articulo> Articulos { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqArticuloObtener : ReqBase
    {
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
        public Guid Id { get; set; }
    }

    public class ResArticuloEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqArticuloRestaurar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResArticuloRestaurar : ResBase
    {
    }
    #endregion
}
