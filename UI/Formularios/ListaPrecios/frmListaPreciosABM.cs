using BLL.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.ListaPrecios
{
    public partial class frmListaPreciosABM : frmBaseABM
    {
        #region "PROPIEDADES"
        private ListaPrecio ListaPrecioActual { get; set; }
        private BindingList<ListaPrecioArticulo> ItemsBinding { get; set; }
        private List<Articulo> ArticulosDisponibles { get; set; }
        #endregion

        #region "CONSTRUCTOR"
        public frmListaPreciosABM(Guid id = default) : base(id)
        {
            InitializeComponent();

            // Cargar artículos para el LookUpEdit
            CargarArticulosDisponibles();

            // Configurar grilla de ítems
            ConfigurarGrillaItems();

            // Configurar eventos de botones
            btnAgregarFila.Click += BtnAgregarFila_Click;
            btnQuitarFila.Click += BtnQuitarFila_Click;

            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciVigenciaDesde, false);
            ControlFactory.ConfigurarLayoutItem(this.lciVigenciaHasta, false);
            ControlFactory.ConfigurarLayoutItem(this.lciGridItems, true);
        }
        #endregion

        #region "MÉTODOS PRIVADOS"

        private void CargarArticulosDisponibles()
        {
            var res = ArticuloBLL.Current.ObtenerLista(new ReqArticulosObtener());
            ArticulosDisponibles = res.Articulos ?? new List<Articulo>();
        }

        private void ConfigurarGrillaItems()
        {
            gridViewItems.Columns.Clear();

            // Columna Artículo (LookUpEdit)
            var colArticulo = new GridColumn
            {
                FieldName = nameof(ListaPrecioArticulo.IdArticulo),
                Caption = "Artículo".Translate(),
                Visible = true,
                Width = 350
            };

            var lkpArticulo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            lkpArticulo.DataSource = ArticulosDisponibles;
            lkpArticulo.ValueMember = nameof(Articulo.IdArticulo);
            lkpArticulo.DisplayMember = nameof(Articulo.Descripcion);
            lkpArticulo.NullText = "";
            lkpArticulo.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Articulo.Codigo), "Código".Translate(), 80));
            lkpArticulo.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Articulo.Descripcion), "Descripción".Translate(), 200));
            gridItems.RepositoryItems.Add(lkpArticulo);
            colArticulo.ColumnEdit = lkpArticulo;
            gridViewItems.Columns.Add(colArticulo);

            // Columna Código (readonly, para visualización)
            var colCodigo = new GridColumn
            {
                FieldName = nameof(ListaPrecioArticulo.CodigoArticulo),
                Caption = "Código".Translate(),
                Visible = true,
                Width = 100
            };
            colCodigo.OptionsColumn.AllowEdit = false;
            gridViewItems.Columns.Add(colCodigo);

            // Columna Precio
            var colPrecio = new GridColumn
            {
                FieldName = nameof(ListaPrecioArticulo.Precio),
                Caption = "Precio".Translate(),
                Visible = true,
                Width = 120
            };

            var spnPrecio = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            spnPrecio.MinValue = 0.01m;
            spnPrecio.MaxValue = 99999999;
            spnPrecio.Increment = 1;
            spnPrecio.IsFloatValue = true;
            spnPrecio.EditFormat.FormatString = "N2";
            gridItems.RepositoryItems.Add(spnPrecio);
            colPrecio.ColumnEdit = spnPrecio;
            gridViewItems.Columns.Add(colPrecio);

            // Columnas ocultas
            var colId = new GridColumn { FieldName = nameof(ListaPrecioArticulo.IdListaPrecioArticulo), Visible = false };
            gridViewItems.Columns.Add(colId);

            var colIdLista = new GridColumn { FieldName = nameof(ListaPrecioArticulo.IdListaPrecio), Visible = false };
            gridViewItems.Columns.Add(colIdLista);

            var colDescripcion = new GridColumn { FieldName = nameof(ListaPrecioArticulo.DescripcionArticulo), Visible = false };
            gridViewItems.Columns.Add(colDescripcion);

            // Evento para auto-llenar código al seleccionar artículo
            gridViewItems.CellValueChanged += GridViewItems_CellValueChanged;
        }

        private void GridViewItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == nameof(ListaPrecioArticulo.IdArticulo) && e.Value != null)
            {
                Guid idArticulo = (Guid)e.Value;
                var articulo = ArticulosDisponibles.Find(a => a.IdArticulo == idArticulo);
                if (articulo != null)
                {
                    gridViewItems.SetRowCellValue(e.RowHandle, nameof(ListaPrecioArticulo.CodigoArticulo), articulo.Codigo);
                    gridViewItems.SetRowCellValue(e.RowHandle, nameof(ListaPrecioArticulo.DescripcionArticulo), articulo.Descripcion);
                }
            }
        }

        #endregion

        #region "EVENTOS BOTONES"

        private void BtnAgregarFila_Click(object sender, EventArgs e)
        {
            ItemsBinding.Add(new ListaPrecioArticulo());
        }

        private void BtnQuitarFila_Click(object sender, EventArgs e)
        {
            int rowHandle = gridViewItems.FocusedRowHandle;
            if (rowHandle >= 0 && rowHandle < ItemsBinding.Count)
            {
                ItemsBinding.RemoveAt(rowHandle);
            }
        }

        #endregion

        #region "MÉTODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nueva Lista de Precios".Translate() : "Detalle Lista de Precios".Translate();
            lciDescripcion.Text = "Descripción".Translate();
            chkEsPredeterminada.Text = "Es Predeterminada".Translate();
            lciVigenciaDesde.Text = "Vigencia Desde".Translate();
            lciVigenciaHasta.Text = "Vigencia Hasta".Translate();
            lciGridItems.Text = "Artículos y Precios".Translate();
            btnAgregarFila.Text = "Agregar Artículo".Translate();
            btnQuitarFila.Text = "Quitar Artículo".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;

                ItemsBinding = new BindingList<ListaPrecioArticulo>();
                gridItems.DataSource = ItemsBinding;
            }
            else
            {
                var res = ListaPrecioBLL.Current.Obtener(new ReqListaPrecioObtener { Id = Id });

                if (res.Success && res.ListaPrecio != null)
                {
                    ListaPrecioActual = res.ListaPrecio;
                    txtDescripcion.Text = res.ListaPrecio.Descripcion;
                    chkEsPredeterminada.Checked = res.ListaPrecio.EsPredeterminada;

                    if (res.ListaPrecio.VigenciaDesde.HasValue)
                        dtVigenciaDesde.DateTime = res.ListaPrecio.VigenciaDesde.Value;
                    else
                        dtVigenciaDesde.EditValue = null;

                    if (res.ListaPrecio.VigenciaHasta.HasValue)
                        dtVigenciaHasta.DateTime = res.ListaPrecio.VigenciaHasta.Value;
                    else
                        dtVigenciaHasta.EditValue = null;

                    ItemsBinding = new BindingList<ListaPrecioArticulo>(res.ListaPrecio.Items);
                    gridItems.DataSource = ItemsBinding;

                    TipoPantalla = res.ListaPrecio.Estado == E_Estados.Activo
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
                    "La descripción es requerida".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (ItemsBinding != null)
            {
                foreach (var item in ItemsBinding)
                {
                    if (item.IdArticulo == Guid.Empty)
                    {
                        XtraMessageBox.Show(
                            "Todos los ítems deben tener un artículo seleccionado".Translate(),
                            "Validación".Translate(),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return false;
                    }

                    if (item.Precio <= 0)
                    {
                        XtraMessageBox.Show(
                            "El precio debe ser mayor a cero".Translate(),
                            "Validación".Translate(),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            if (EsNuevo)
            {
                var listaPrecio = new ListaPrecio
                {
                    Descripcion = txtDescripcion.Text.Trim(),
                    EsPredeterminada = chkEsPredeterminada.Checked,
                    VigenciaDesde = dtVigenciaDesde.EditValue != null ? (DateTime?)dtVigenciaDesde.DateTime : null,
                    VigenciaHasta = dtVigenciaHasta.EditValue != null ? (DateTime?)dtVigenciaHasta.DateTime : null,
                    Items = new List<ListaPrecioArticulo>(ItemsBinding)
                };

                var req = new ReqListaPrecioInsertar { ListaPrecio = listaPrecio };
                var res = ListaPrecioBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                ListaPrecioActual.Descripcion = txtDescripcion.Text.Trim();
                ListaPrecioActual.EsPredeterminada = chkEsPredeterminada.Checked;
                ListaPrecioActual.VigenciaDesde = dtVigenciaDesde.EditValue != null ? (DateTime?)dtVigenciaDesde.DateTime : null;
                ListaPrecioActual.VigenciaHasta = dtVigenciaHasta.EditValue != null ? (DateTime?)dtVigenciaHasta.DateTime : null;
                ListaPrecioActual.Items = new List<ListaPrecioArticulo>(ItemsBinding);

                var req = new ReqListaPrecioModificar { ListaPrecio = ListaPrecioActual };
                var res = ListaPrecioBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = ListaPrecioBLL.Current.Eliminar(new ReqListaPrecioEliminar { Id = Id });
            if (!res.Success)
            {
                XtraMessageBox.Show(
                    res.Message,
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = ListaPrecioBLL.Current.Restaurar(new ReqListaPrecioRestaurar { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new DevExpress.XtraEditors.TextEdit[] {
                    this.txtDescripcion,
                    this.dtVigenciaDesde,
                    this.dtVigenciaHasta
                },
                itemsLayout: new[] {
                    this.lciDescripcion,
                    this.lciVigenciaDesde,
                    this.lciVigenciaHasta,
                    this.lciGridItems
                },
                grillas: new[] { this.gridViewItems },
                botones: new[] { this.btnAgregarFila, this.btnQuitarFila },
                checkEdits: new[] { this.chkEsPredeterminada }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.ListaPrecio;
        }

        #endregion
    }
}
