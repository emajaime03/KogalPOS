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
        public frmArticulos(Services.Domain.GlobalCliente sesion) : base(sesion)
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
                CrearColumna(nameof(Articulo.Estado), "Estado".Translate()),
                CrearColumna(nameof(Articulo.Codigo), "Código".Translate()),
                CrearColumna(nameof(Articulo.Descripcion), "Descripción".Translate()),
                CrearColumna(nameof(Articulo.StockActual), "Stock Actual".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = ArticulosBLL.Current.ObtenerLista(new ReqArticulosObtener(this.Sesion));
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
