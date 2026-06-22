using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    public class ArticuloCatalogoDTO
    {
        public Guid IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public bool Seleccionado { get; set; }

        public ArticuloCatalogoDTO() { }

        public ArticuloCatalogoDTO(Articulo articulo, bool seleccionado)
        {
            IdArticulo = articulo.IdArticulo;
            Descripcion = articulo.Descripcion;
            Seleccionado = seleccionado;
        }
    }

    /// <summary>
    /// DTO para la grilla de catálogos (con checkbox) en el ABM de Artículos.
    /// </summary>
    public class CatalogoArticuloDTO
    {
        public Guid IdCatalogo { get; set; }
        public string Descripcion { get; set; }
        public bool Seleccionado { get; set; }

        public CatalogoArticuloDTO() { }

        public CatalogoArticuloDTO(Catalogo catalogo, bool seleccionado)
        {
            IdCatalogo = catalogo.IdCatalogo;
            Descripcion = catalogo.Descripcion;
            Seleccionado = seleccionado;
        }
    }

    #region "OBTENER LISTA"
    public class ReqCatalogosObtener : ReqBase
    {
        public ReqCatalogosObtener(GlobalCliente sesion) : base(sesion) { }
    }

    public class ResCatalogosObtener : ResBase
    {
        public List<Catalogo> Catalogos { get; set; }
    }
    #endregion

    #region "OBTENER"
    public class ReqCatalogoObtener : ReqBase
    {
        public ReqCatalogoObtener(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResCatalogoObtener : ResBase
    {
        public Catalogo Catalogo { get; set; }
    }
    #endregion

    #region "OBTENER ARTICULOS ASIGNADOS"
    public class ReqCatalogoObtenerArticulos : ReqBase
    {
        public ReqCatalogoObtenerArticulos(GlobalCliente sesion) : base(sesion) { }
        public Guid IdCatalogo { get; set; }
    }

    public class ResCatalogoObtenerArticulos : ResBase
    {
        public List<Guid> IdsArticulos { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqCatalogoInsertar : ReqBase
    {
        public ReqCatalogoInsertar(GlobalCliente sesion) : base(sesion) { }
        public Catalogo Catalogo { get; set; }
        public List<Guid> IdsArticulos { get; set; }
    }

    public class ResCatalogoInsertar : ResBase
    {
        public Catalogo Catalogo { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqCatalogoModificar : ReqBase
    {
        public ReqCatalogoModificar(GlobalCliente sesion) : base(sesion) { }
        public Catalogo Catalogo { get; set; }
        public List<Guid> IdsArticulos { get; set; }
    }

    public class ResCatalogoModificar : ResBase
    {
        public Catalogo Catalogo { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqCatalogoEliminar : ReqBase
    {
        public ReqCatalogoEliminar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResCatalogoEliminar : ResBase { }
    #endregion

    #region "RESTAURAR"
    public class ReqCatalogoRestaurar : ReqBase
    {
        public ReqCatalogoRestaurar(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResCatalogoRestaurar : ResBase { }
    #endregion
}
