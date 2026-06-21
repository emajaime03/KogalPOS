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

namespace UI.Formularios.Catalogos
{
    public partial class frmCatalogosABM : frmBaseABM
    {
        #region "PROPIEDADES"
        private Catalogo CatalogoActual { get; set; }

        private List<ArticuloCatalogoDTO> ArticulosGrilla
        {
            get => (List<ArticuloCatalogoDTO>)gcArticulos.DataSource;
            set => gcArticulos.DataSource = value;
        }
        #endregion

        #region "CONSTRUCTOR"
        public frmCatalogosABM(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciArticulos, false);
        }
        #endregion

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Catálogo".Translate() : "Detalle Catálogo".Translate();
            lciDescripcion.Text = "Descripción".Translate();
            lciArticulos.Text = "Artículos Asignados".Translate();

            ActualizarCaptionsColumnas();
        }

        protected override void ConfigurarGrillas()
        {
            gvArticulos.OptionsDetail.EnableMasterViewMode = false;
            gvArticulos.OptionsView.ShowGroupPanel = false;

            gvArticulos.Columns.AddRange(new GridColumn[]
            {
                new GridColumn
                {
                    FieldName = nameof(ArticuloCatalogoDTO.Descripcion),
                    Caption = "Descripción".Translate(),
                    Visible = true,
                    OptionsColumn = { AllowEdit = false }
                },
                new GridColumn
                {
                    FieldName = nameof(ArticuloCatalogoDTO.Seleccionado),
                    Caption = "Seleccionado".Translate(),
                    Visible = true,
                    ColumnEdit = new RepositoryItemCheckEdit()
                }
            });

            GridStyleHelper.AplicarEstilo(gvArticulos);
        }

        protected override void CargarDatos()
        {
            var todosArticulos = ArticulosBLL.Current
                .ObtenerLista(new ReqArticulosObtener(this.Sesion))
                .Articulos
                ?.Where(a => a.Estado == E_Estados.Activo)
                .ToList() ?? new List<Articulo>();

            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
                ArticulosGrilla = todosArticulos
                    .Select(a => new ArticuloCatalogoDTO(a, false))
                    .ToList();
            }
            else
            {
                var resCatalogo = CatalogosBLL.Current.Obtener(new ReqCatalogoObtener(this.Sesion) { Id = Id });

                if (resCatalogo.Success && resCatalogo.Catalogo != null)
                {
                    CatalogoActual = resCatalogo.Catalogo;
                    txtDescripcion.Text = resCatalogo.Catalogo.Descripcion;

                    TipoPantalla = resCatalogo.Catalogo.Estado == E_Estados.Activo
                        ? E_TipoPantalla.Visualizar
                        : E_TipoPantalla.VisualizarEliminado;

                    var resArticulos = CatalogosBLL.Current.ObtenerArticulosAsignados(
                        new ReqCatalogoObtenerArticulos(this.Sesion) { IdCatalogo = Id });

                    var idsAsignados = resArticulos.IdsArticulos ?? new List<Guid>();

                    ArticulosGrilla = todosArticulos
                        .Select(a => new ArticuloCatalogoDTO(a, idsAsignados.Contains(a.IdArticulo)))
                        .ToList();
                }
            }
        }

        protected override bool ValidarDatos()
        {
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
            var idsSeleccionados = ArticulosGrilla?
                .Where(a => a.Seleccionado)
                .Select(a => a.IdArticulo)
                .ToList() ?? new List<Guid>();

            if (EsNuevo)
            {
                var req = new ReqCatalogoInsertar(this.Sesion)
                {
                    Catalogo = new Catalogo { Descripcion = txtDescripcion.Text.Trim() },
                    IdsArticulos = idsSeleccionados
                };

                var res = CatalogosBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                CatalogoActual.Descripcion = txtDescripcion.Text.Trim();

                var req = new ReqCatalogoModificar(this.Sesion)
                {
                    Catalogo = CatalogoActual,
                    IdsArticulos = idsSeleccionados
                };

                var res = CatalogosBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = CatalogosBLL.Current.Eliminar(new ReqCatalogoEliminar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = CatalogosBLL.Current.Restaurar(new ReqCatalogoRestaurar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new[] { this.txtDescripcion },
                itemsLayout: new[] { this.lciDescripcion, this.lciArticulos },
                grillas: new[] { this.gvArticulos }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Catalogo;
        }

        #endregion

        #region "HELPERS"

        private void ActualizarCaptionsColumnas()
        {
            if (gvArticulos.Columns.Count >= 2)
            {
                gvArticulos.Columns[0].Caption = "Descripción".Translate();
                gvArticulos.Columns[1].Caption = "Seleccionado".Translate();
            }
        }

        #endregion
    }
}
