using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;

namespace Domain.BLL
{
    #region "OBTENER LISTA"
    public class ReqAjustesStockObtener : ReqBase
    {
    }

    public class ResAjustesStockObtener : ResBase
    {
        public List<MovimientoStock> Movimientos { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqAjusteStockObtener : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResAjusteStockObtener : ResBase
    {
        public MovimientoStock Movimiento { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqAjusteStockInsertar : ReqBase
    {
        public MovimientoStock Movimiento { get; set; }
    }

    public class ResAjusteStockInsertar : ResBase
    {
        public MovimientoStock Movimiento { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqAjusteStockEliminar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResAjusteStockEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqAjusteStockRestaurar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResAjusteStockRestaurar : ResBase
    {
    }
    #endregion
}
