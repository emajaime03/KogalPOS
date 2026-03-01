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
        public frmProveedoresABM(Guid id = default) : base(id)
        {
            InitializeComponent();
            InicializarFormulario();
        }

        #region "MÉTODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Proveedor".Translate() : "Detalle de Proveedor".Translate();
            lblDescripcion.Text = "Descripción".Translate();
            lblEmail.Text = "Email".Translate();
            lblCelular.Text = "Celular".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
            }
            else
            {
                var res = ProveedorBLL.Current.Obtener(new ReqProveedorObtener { Id = Id });

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
                    "La descripción es obligatoria.".Translate(),
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
                var req = new ReqProveedorInsertar
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
                var req = new ReqProveedorModificar
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
            var res = ProveedorBLL.Current.Eliminar(new ReqProveedorEliminar { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = ProveedorBLL.Current.Restaurar(new ReqProveedorRestaurar { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                EsModoEdicion,
                new[] { txtDescripcion, txtEmail, txtCelular },
                new[] { lblDescripcion, lblEmail, lblCelular }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Proveedor;
        }

        #endregion
    }
}
