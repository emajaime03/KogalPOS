using BLL.Services;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Catalogos
{
    public partial class frmCatalogos : frmBaseGrilla
    {
        public frmCatalogos(Services.Domain.GlobalCliente sesion) : base(sesion)
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Catálogos".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(Catalogo.IdCatalogo), "ID", visible: false),
                CrearColumna(nameof(Catalogo.Estado), "Estado".Translate()),
                CrearColumna(nameof(Catalogo.Descripcion), "Descripción".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = CatalogosBLL.Current.ObtenerLista(new ReqCatalogosObtener(this.Sesion));
            EstablecerDataSource(res.Catalogos);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.CatalogosABM();
        }

        protected override void OnDetalleClick()
        {
            var catalogo = ObtenerFilaSeleccionada<Catalogo>();
            if (catalogo != null)
            {
                FormulariosManager.CatalogosABM(catalogo.IdCatalogo);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.Catalogo.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
