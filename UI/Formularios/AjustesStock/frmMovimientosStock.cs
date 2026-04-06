using BLL.Services;
using Domain;
using Domain.DTOs;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.AjustesStock
{
    public partial class frmMovimientosStock : frmBaseGrilla
    {
        public frmMovimientosStock(Services.Domain.GlobalCliente sesion) : base(sesion)
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Ajustes de Stock".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(MovimientoStockDTO.IdMovimientoStock), "ID", visible: false),
                CrearColumna(nameof(MovimientoStockDTO.Estado), "Estado".Translate()),
                CrearColumna(nameof(MovimientoStockDTO.Fecha), "Fecha".Translate()),
                CrearColumna(nameof(MovimientoStockDTO.TipoMovimiento), "Tipo".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = AjustesStockBLL.Current.ObtenerLista(new ReqAjustesStockObtener(this.Sesion));
            EstablecerDataSource(res.Movimientos);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.AjusteStockABM();
        }

        protected override void OnDetalleClick()
        {
            var movimiento = ObtenerFilaSeleccionada<MovimientoStockDTO>();
            if (movimiento != null)
            {
                FormulariosManager.AjusteStockABM(movimiento.IdMovimientoStock);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.AjusteStock.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
