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

    public class ReqArticulosObtenerPorIds : ReqBase
    {
        public ReqArticulosObtenerPorIds(GlobalCliente sesion) : base(sesion)
        {
        }
        public List<Guid> Ids { get; set; }
    }

    public class ResArticulosObtenerPorIds : ResBase
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
        public List<Guid> IdsCatalogos { get; set; }
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
        public List<Guid> IdsCatalogos { get; set; }
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

    #region "VERIFICAR STOCK"
    public class ReqArticulosVerificarStock : ReqBase
    {
        public ReqArticulosVerificarStock(GlobalCliente sesion) : base(sesion) { }
        /// <summary>Cantidad pedida por artículo (IdArticulo → cantidad).</summary>
        public Dictionary<Guid, decimal> Cantidades { get; set; }
    }

    public class ResArticulosVerificarStock : ResBase
    {
        /// <summary>Descripciones de los artículos cuyo pedido supera el stock actual en BD.</summary>
        public List<string> Faltantes { get; set; }
    }
    #endregion

    #region "OBTENER CATALOGOS ASIGNADOS"
    public class ReqArticuloObtenerCatalogos : ReqBase
    {
        public ReqArticuloObtenerCatalogos(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid IdArticulo { get; set; }
    }

    public class ResArticuloObtenerCatalogos : ResBase
    {
        public List<Guid> IdsCatalogos { get; set; }
    }
    #endregion
}
