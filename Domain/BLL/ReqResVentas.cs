using Domain.DTOs;
using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    #region "OBTENER LISTA (HISTORIAL)"
    public class ReqVentasObtener : ReqBase
    {
        public ReqVentasObtener(GlobalCliente sesion) : base(sesion) { }
    }

    public class ResVentasObtener : ResBase
    {
        public List<VentaDTO> Ventas { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqVentaObtener : ReqBase
    {
        public ReqVentaObtener(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResVentaObtener : ResBase
    {
        public VentaDTO Venta { get; set; }
    }
    #endregion

    #region "CONFIRMAR VENTA"
    public class ReqVentaConfirmar : ReqBase
    {
        public ReqVentaConfirmar(GlobalCliente sesion) : base(sesion) { }
        public List<VentaItemDTO> Items { get; set; }
        public Guid? IdCliente { get; set; }
        public Guid IdListaPrecio { get; set; }
        public decimal Descuento { get; set; }
        public CobroDTO Cobro { get; set; }
    }

    public class ResVentaConfirmar : ResBase
    {
        public int NroVenta { get; set; }
        public int NroDocumento { get; set; }
    }
    #endregion

    #region "ANULAR VENTA"
    public class ReqVentaAnular : ReqBase
    {
        public ReqVentaAnular(GlobalCliente sesion) : base(sesion) { }
        public Guid Id { get; set; }
    }

    public class ResVentaAnular : ResBase
    {
    }
    #endregion
}
