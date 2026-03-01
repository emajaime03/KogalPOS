using BLL.Services;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Articulos
{
    public partial class frmArticulos : frmBaseGrilla
    {
        public frmArticulos()
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Artículos".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(Articulo.IdArticulo), "ID", visible: false),
                CrearColumna(nameof(Articulo.Estado), "ESTADO".Translate()),
                CrearColumna(nameof(Articulo.Codigo), "CÓDIGO".Translate()),
                CrearColumna(nameof(Articulo.Descripcion), "DESCRIPCIÓN".Translate()),
                CrearColumna(nameof(Articulo.StockActual), "STOCK ACTUAL".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = ArticuloBLL.Current.ObtenerLista(new ReqArticulosObtener());
            EstablecerDataSource(res.Articulos);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.ArticulosABM();
        }

        protected override void OnDetalleClick()
        {
            var articulo = ObtenerFilaSeleccionada<Articulo>();
            if (articulo != null)
            {
                FormulariosManager.ArticulosABM(articulo.IdArticulo);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.Articulo.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
