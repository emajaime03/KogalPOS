using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqListaPreciosObtener : ReqBase
    {
    }

    public class ResListaPreciosObtener : ResBase
    {
        public List<ListaPrecio> ListaPrecios { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqListaPrecioObtener : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResListaPrecioObtener : ResBase
    {
        public ListaPrecio ListaPrecio { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqListaPrecioInsertar : ReqBase
    {
        public ListaPrecio ListaPrecio { get; set; }
    }

    public class ResListaPrecioInsertar : ResBase
    {
        public ListaPrecio ListaPrecio { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqListaPrecioModificar : ReqBase
    {
        public ListaPrecio ListaPrecio { get; set; }
    }

    public class ResListaPrecioModificar : ResBase
    {
        public ListaPrecio ListaPrecio { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqListaPrecioEliminar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResListaPrecioEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqListaPrecioRestaurar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResListaPrecioRestaurar : ResBase
    {
    }
    #endregion
}
