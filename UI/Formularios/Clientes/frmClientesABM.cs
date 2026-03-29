using BLL.Services;
using DevExpress.XtraEditors;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Clientes
{
    public partial class frmClientesABM : frmBaseABM
    {
        public frmClientesABM(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            CargarComboTipoDocumento();
            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciNroDocumento, false);
            ControlFactory.ConfigurarLayoutItem(this.lciTipoDocumento, false);
        }

        #region "METODOS PRIVADOS"

        private void CargarComboTipoDocumento()
        {
            cmbTipoDocumento.Properties.Items.Clear();
            foreach (E_TipoDocumento tipo in Enum.GetValues(typeof(E_TipoDocumento)))
            {
                cmbTipoDocumento.Properties.Items.Add(tipo);
            }
        }

        #endregion

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Cliente".Translate() : "Detalle de Cliente".Translate();
            lciDescripcion.Text = "Descripción".Translate();
            lciNroDocumento.Text = "Nro Documento".Translate();
            lciTipoDocumento.Text = "Tipo Documento".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
                cmbTipoDocumento.SelectedIndex = 0;
            }
            else
            {
                var res = ClienteBLL.Current.Obtener(new ReqClienteObtener(this.Sesion) { Id = Id });

                if (res.Success && res.Cliente != null)
                {
                    txtDescripcion.Text = res.Cliente.Descripcion;
                    txtNroDocumento.Text = res.Cliente.NroDocumento;
                    cmbTipoDocumento.SelectedItem = res.Cliente.TipoDocumento;

                    TipoPantalla = res.Cliente.Estado == E_Estados.Activo
                        ? E_TipoPantalla.Visualizar
                        : E_TipoPantalla.VisualizarEliminado;
                }
            }
        }

        protected override bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                XtraMessageBox.Show(
                    "La Descripción es obligatoria.".Translate(),
                    "Validación".Translate(),
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            if (EsNuevo)
            {
                var req = new ReqClienteInsertar(this.Sesion)
                {
                    Cliente = new Cliente
                    {
                        Descripcion = txtDescripcion.Text.Trim(),
                        NroDocumento = txtNroDocumento.Text.Trim(),
                        TipoDocumento = (E_TipoDocumento)cmbTipoDocumento.SelectedItem
                    }
                };

                var res = ClienteBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                var req = new ReqClienteModificar(this.Sesion)
                {
                    Cliente = new Cliente
                    {
                        IdCliente = Id,
                        Descripcion = txtDescripcion.Text.Trim(),
                        NroDocumento = txtNroDocumento.Text.Trim(),
                        TipoDocumento = (E_TipoDocumento)cmbTipoDocumento.SelectedItem
                    }
                };

                var res = ClienteBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = ClienteBLL.Current.Eliminar(new ReqClienteEliminar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = ClienteBLL.Current.Restaurar(new ReqClienteRestaurar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new[] { this.txtDescripcion, this.txtNroDocumento, this.cmbTipoDocumento },
                itemsLayout: new[] { this.lciDescripcion, this.lciNroDocumento, this.lciTipoDocumento }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Cliente;
        }

        #endregion
    }
}
