using Services.Domain;
using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using Domain.DTOs;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqAjustesStockObtener : ReqBase
    {
        public ReqAjustesStockObtener(GlobalCliente sesion) : base(sesion)
        {
        }
    }

    public class ResAjustesStockObtener : ResBase
    {
        public List<MovimientoStockDTO> Movimientos { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqAjusteStockObtener : ReqBase
    {
        public ReqAjusteStockObtener(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid Id { get; set; }
    }

    public class ResAjusteStockObtener : ResBase
    {
        public MovimientoStockDTO Movimiento { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqAjusteStockInsertar : ReqBase
    {
        public ReqAjusteStockInsertar(GlobalCliente sesion) : base(sesion)
        {
        }

        public MovimientoStockDTO Movimiento { get; set; }
    }

    public class ResAjusteStockInsertar : ResBase
    {
        public MovimientoStockDTO Movimiento { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqAjusteStockEliminar : ReqBase
    {
        public ReqAjusteStockEliminar(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid Id { get; set; }
    }

    public class ResAjusteStockEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqAjusteStockRestaurar : ReqBase
    {
        public ReqAjusteStockRestaurar(GlobalCliente sesion) : base(sesion)
        {
        }

        public Guid Id { get; set; }
    }

    public class ResAjusteStockRestaurar : ResBase
    {
    }
    #endregion
}
