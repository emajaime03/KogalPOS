using BLL.Services;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Proveedores
{
    public partial class frmProveedores : frmBaseGrilla
    {
        public frmProveedores()
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Proveedores".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(Proveedor.IdProveedor), "ID", visible: false),
                CrearColumna(nameof(Proveedor.Estado), "ESTADO".Translate()),
                CrearColumna(nameof(Proveedor.Descripcion), "DESCRIPCIÓN".Translate()),
                CrearColumna(nameof(Proveedor.Email), "EMAIL".Translate()),
                CrearColumna(nameof(Proveedor.Celular), "CELULAR".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = ProveedorBLL.Current.ObtenerLista(new ReqProveedoresObtener());
            EstablecerDataSource(res.Proveedores);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.ProveedoresABM();
        }

        protected override void OnDetalleClick()
        {
            var proveedor = ObtenerFilaSeleccionada<Proveedor>();
            if (proveedor != null)
            {
                FormulariosManager.ProveedoresABM(proveedor.IdProveedor);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.Proveedor.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
