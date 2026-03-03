using BLL.Services;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Clientes
{
    public partial class frmClientes : frmBaseGrilla
    {
        public frmClientes()
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Clientes".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(Cliente.IdCliente), "ID", visible: false),
                CrearColumna(nameof(Cliente.Estado), "ESTADO".Translate()),
                CrearColumna(nameof(Cliente.Descripcion), "DESCRIPCIÓN".Translate()),
                CrearColumna(nameof(Cliente.NroDocumento), "NRO DOCUMENTO".Translate()),
                CrearColumna(nameof(Cliente.TipoDocumento), "TIPO DOCUMENTO".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = ClienteBLL.Current.ObtenerLista(new ReqClientesObtener());
            EstablecerDataSource(res.Clientes);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.ClientesABM();
        }

        protected override void OnDetalleClick()
        {
            var cliente = ObtenerFilaSeleccionada<Cliente>();
            if (cliente != null)
            {
                FormulariosManager.ClientesABM(cliente.IdCliente);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.Cliente.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
