using BLL.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Articulos
{
    public partial class frmArticulosABM : frmBaseABM
    {
        #region "PROPIEDADES"
        private Articulo ArticuloActual { get; set; }

        private List<CatalogoArticuloDTO> CatalogosGrilla
        {
            get => (List<CatalogoArticuloDTO>)gcCatalogos.DataSource;
            set => gcCatalogos.DataSource = value;
        }
        #endregion

        #region "CONSTRUCTOR"
        public frmArticulosABM(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciCodigo, false);
            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciStockActual, false);
            ControlFactory.ConfigurarLayoutItem(this.lciCatalogos, false);
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
            lciCatalogos.Text = "Catálogos".Translate();

            ActualizarCaptionsColumnas();
        }

        protected override void ConfigurarGrillas()
        {
            gvCatalogos.OptionsDetail.EnableMasterViewMode = false;
            gvCatalogos.OptionsView.ShowGroupPanel = false;

            gvCatalogos.Columns.AddRange(new GridColumn[]
            {
                new GridColumn
                {
                    FieldName = nameof(CatalogoArticuloDTO.Descripcion),
                    Caption = "Descripción".Translate(),
                    Visible = true,
                    OptionsColumn = { AllowEdit = false }
                },
                new GridColumn
                {
                    FieldName = nameof(CatalogoArticuloDTO.Seleccionado),
                    Caption = "Seleccionado".Translate(),
                    Visible = true,
                    ColumnEdit = new RepositoryItemCheckEdit()
                }
            });

            GridStyleHelper.AplicarEstilo(gvCatalogos);
        }

        protected override void CargarDatos()
        {
            var todosCatalogos = CatalogosBLL.Current
                .ObtenerLista(new ReqCatalogosObtener(this.Sesion))
                .Catalogos
                ?.Where(c => c.Estado == E_Estados.Activo)
                .ToList() ?? new List<Catalogo>();

            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
                txtStockActual.Text = "0";

                CatalogosGrilla = todosCatalogos
                    .Select(c => new CatalogoArticuloDTO(c, false))
                    .ToList();
            }
            else
            {
                var res = ArticulosBLL.Current.Obtener(new ReqArticuloObtener(this.Sesion) { Id = Id });

                if (res.Success && res.Articulo != null)
                {
                    ArticuloActual = res.Articulo;
                    txtCodigo.Text = res.Articulo.Codigo;
                    txtDescripcion.Text = res.Articulo.Descripcion;
                    txtStockActual.Text = res.Articulo.StockActual.ToString("N2");

                    TipoPantalla = res.Articulo.Estado == E_Estados.Activo
                        ? E_TipoPantalla.Visualizar
                        : E_TipoPantalla.VisualizarEliminado;

                    var resCatalogos = ArticulosBLL.Current.ObtenerCatalogosAsignados(
                        new ReqArticuloObtenerCatalogos(this.Sesion) { IdArticulo = Id });

                    var idsAsignados = resCatalogos.IdsCatalogos ?? new List<Guid>();

                    CatalogosGrilla = todosCatalogos
                        .Select(c => new CatalogoArticuloDTO(c, idsAsignados.Contains(c.IdCatalogo)))
                        .ToList();
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
            var idsSeleccionados = CatalogosGrilla?
                .Where(c => c.Seleccionado)
                .Select(c => c.IdCatalogo)
                .ToList() ?? new List<Guid>();

            if (EsNuevo)
            {
                var req = new ReqArticuloInsertar(this.Sesion)
                {
                    Articulo = new Articulo
                    {
                        Codigo = txtCodigo.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim()
                    },
                    IdsCatalogos = idsSeleccionados
                };

                var res = ArticulosBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                ArticuloActual.Codigo = txtCodigo.Text.Trim();
                ArticuloActual.Descripcion = txtDescripcion.Text.Trim();

                var req = new ReqArticuloModificar(this.Sesion)
                {
                    Articulo = ArticuloActual,
                    IdsCatalogos = idsSeleccionados
                };
                var res = ArticulosBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = ArticulosBLL.Current.Eliminar(new ReqArticuloEliminar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = ArticulosBLL.Current.Restaurar(new ReqArticuloRestaurar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new[] { this.txtCodigo, this.txtDescripcion },
                itemsLayout: new[] { this.lciCodigo, this.lciDescripcion, this.lciStockActual, this.lciCatalogos },
                grillas: new[] { this.gvCatalogos }
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

        #region "HELPERS"

        private void ActualizarCaptionsColumnas()
        {
            if (gvCatalogos.Columns.Count >= 2)
            {
                gvCatalogos.Columns[0].Caption = "Descripción".Translate();
                gvCatalogos.Columns[1].Caption = "Seleccionado".Translate();
            }
        }

        #endregion
    }
}
