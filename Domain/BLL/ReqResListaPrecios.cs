using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using Services.Domain;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqListaPreciosObtener : ReqBase
    {
        public ReqListaPreciosObtener(GlobalCliente sesion) : base(sesion) { }
    }

    public class ResListaPreciosObtener : ResBase
    {
        public List<ListaPrecio> ListaPrecios { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqListaPrecioObtener : ReqBase
    {
        public ReqListaPrecioObtener(GlobalCliente sesion) : base(sesion) { }
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
        public ReqListaPrecioInsertar(GlobalCliente sesion) : base(sesion) { }
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
        public ReqListaPrecioModificar(GlobalCliente sesion) : base(sesion) { }
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
        public ReqListaPrecioEliminar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResListaPrecioEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqListaPrecioRestaurar : ReqBase
    {
        public ReqListaPrecioRestaurar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResListaPrecioRestaurar : ResBase
    {
    }
    #endregion
}
