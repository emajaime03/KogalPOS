using BLL.Services;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.AjustesStock
{
    public partial class frmMovimientosStock : frmBaseGrilla
    {
        public frmMovimientosStock()
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
                CrearColumna(nameof(MovimientoStock.IdMovimientoStock), "ID", visible: false),
                CrearColumna(nameof(MovimientoStock.Estado), "Estado".Translate()),
                CrearColumna(nameof(MovimientoStock.Fecha), "Fecha".Translate()),
                CrearColumna(nameof(MovimientoStock.TipoMovimiento), "Tipo".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = AjusteStockBLL.Current.ObtenerLista(new ReqAjustesStockObtener());
            EstablecerDataSource(res.Movimientos);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.AjusteStockABM();
        }

        protected override void OnDetalleClick()
        {
            var movimiento = ObtenerFilaSeleccionada<MovimientoStock>();
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
