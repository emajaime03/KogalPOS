using BLL.Services;
using DevExpress.XtraEditors;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using System.Windows.Forms;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Articulos
{
    public partial class frmArticulosABM : frmBaseABM
    {
        #region "PROPIEDADES"
        private Articulo ArticuloActual { get; set; }
        #endregion

        #region "CONSTRUCTOR"
        public frmArticulosABM(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciCodigo, false);
            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciStockActual, false);
        }
        #endregion

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Artículo".Translate() : "Detalle Artículo".Translate();
            lciCodigo.Text = "Código".Translate();
            lciDescripcion.Text = "Descripción".Translate();
            lciStockActual.Text = "Stock Actual".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
                txtStockActual.Text = "0";
            }
            else
            {
                var res = ArticuloBLL.Current.Obtener(new ReqArticuloObtener(this.Sesion) { Id = Id });

                if (res.Success && res.Articulo != null)
                {
                    ArticuloActual = res.Articulo;
                    txtCodigo.Text = res.Articulo.Codigo;
                    txtDescripcion.Text = res.Articulo.Descripcion;
                    txtStockActual.Text = res.Articulo.StockActual.ToString("N2");

                    TipoPantalla = res.Articulo.Estado == E_Estados.Activo
                        ? E_TipoPantalla.Visualizar
                        : E_TipoPantalla.VisualizarEliminado;
                }
            }
        }

        protected override bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                XtraMessageBox.Show(
                    "El código es requerido".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                XtraMessageBox.Show(
                    "La descripción es requerida".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            if (EsNuevo)
            {
                var req = new ReqArticuloInsertar(this.Sesion)
                {
                    Articulo = new Articulo
                    {
                        Codigo = txtCodigo.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim()
                    }
                };

                var res = ArticuloBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                ArticuloActual.Codigo = txtCodigo.Text.Trim();
                ArticuloActual.Descripcion = txtDescripcion.Text.Trim();

                var req = new ReqArticuloModificar(this.Sesion) { Articulo = ArticuloActual };
                var res = ArticuloBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = ArticuloBLL.Current.Eliminar(new ReqArticuloEliminar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = ArticuloBLL.Current.Restaurar(new ReqArticuloRestaurar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new[] { this.txtCodigo, this.txtDescripcion },
                itemsLayout: new[] { this.lciCodigo, this.lciDescripcion, this.lciStockActual }
            );

            ControlFactory.AplicarModo(
                esEditable: false,
                textEdits: new[] { this.txtStockActual }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Articulo;
        }

        #endregion
    }
}
