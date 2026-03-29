using BLL.Services;
using DevExpress.XtraEditors;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Proveedores
{
    public partial class frmProveedoresABM : frmBaseABM
    {
        public frmProveedoresABM(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            InicializarFormulario();

            // 1. Estilizamos los "Labels" nativos del LayoutControl (false porque no son tÃ­tulos de secciÃ³n)
            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciEmail, false);
            ControlFactory.ConfigurarLayoutItem(this.lciCelular, false);

        }

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Proveedor".Translate() : "Detalle de Proveedor".Translate();
            lciDescripcion.Text = "Descripción".Translate();
            lciEmail.Text = "Email".Translate();
            lciCelular.Text = "Celular".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
            }
            else
            {
                var res = ProveedorBLL.Current.Obtener(new ReqProveedorObtener(this.Sesion) { Id = Id });

                if (res.Success && res.Proveedor != null)
                {
                    txtDescripcion.Text = res.Proveedor.Descripcion;
                    txtEmail.Text = res.Proveedor.Email;
                    txtCelular.Text = res.Proveedor.Celular;

                    TipoPantalla = res.Proveedor.Estado == E_Estados.Activo
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
                var req = new ReqProveedorInsertar(this.Sesion)
                {
                    Proveedor = new Proveedor
                    {
                        Descripcion = txtDescripcion.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Celular = txtCelular.Text.Trim()
                    }
                };

                var res = ProveedorBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                var req = new ReqProveedorModificar(this.Sesion)
                {
                    Proveedor = new Proveedor
                    {
                        IdProveedor = Id,
                        Descripcion = txtDescripcion.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Celular = txtCelular.Text.Trim()
                    }
                };

                var res = ProveedorBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = ProveedorBLL.Current.Eliminar(new ReqProveedorEliminar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = ProveedorBLL.Current.Restaurar(new ReqProveedorRestaurar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                EsModoEdicion, 
                textEdits: new[] { this.txtDescripcion, this.txtEmail, this.txtCelular },
                itemsLayout: new[] { this.lciDescripcion, this.lciEmail, this.lciCelular }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Proveedor;
        }

        #endregion
    }
}
