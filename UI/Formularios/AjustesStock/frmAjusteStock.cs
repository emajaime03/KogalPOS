using BLL.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Domain.DTOs;
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

namespace UI.Formularios.AjustesStock
{
    public partial class frmAjusteStock : frmBaseABM
    {
        #region "PROPIEDADES"
        private MovimientoStockDTO MovimientoActual { get; set; }
        private BindingList<MovimientoItemDTO> ItemsBinding { get; set; }
        private List<Articulo> ArticulosDisponibles { get; set; }
        #endregion

        #region "CONSTRUCTOR"
        public frmAjusteStock(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();

            // Cargar Artículos para el LookUpEdit
            CargarArticulosDisponibles();

            // Configurar grilla de Items
            ConfigurarGrillaItems();

            // Configurar eventos de botones
            btnAgregarFila.Click += BtnAgregarFila_Click;
            btnQuitarFila.Click += BtnQuitarFila_Click;

            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciTipoMovimiento, false);
            ControlFactory.ConfigurarLayoutItem(this.lciFecha, false);
            ControlFactory.ConfigurarLayoutItem(this.lciGridItems, false); // Como es la grilla, le pasamos true
                        
        }
        #endregion

        #region "METODOS PRIVADOS"

        private void CargarArticulosDisponibles()
        {
            var res = ArticulosBLL.Current.ObtenerLista(new ReqArticulosObtener(this.Sesion));
            ArticulosDisponibles = res.Articulos ?? new List<Articulo>();
        }

        private void ConfigurarGrillaItems()
        {
            gridViewItems.Columns.Clear();

            // Columna Artículo (LookUpEdit)
            var colArticulo = new GridColumn
            {
                FieldName = nameof(MovimientoItemDTO.IdArticulo),
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

            // Columna Código (readonly, para visualizaciÃ³n)
            var colCodigo = new GridColumn
            {
                FieldName = nameof(MovimientoItemDTO.CodigoArticulo),
                Caption = "Código".Translate(),
                Visible = true,
                Width = 100
            };
            colCodigo.OptionsColumn.AllowEdit = false;
            gridViewItems.Columns.Add(colCodigo);

            // Columna Cantidad
            var colCantidad = new GridColumn
            {
                FieldName = nameof(MovimientoItemDTO.Cantidad),
                Caption = "Cantidad".Translate(),
                Visible = true,
                Width = 120
            };

            var spnCantidad = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            spnCantidad.MinValue = 0.01m;
            spnCantidad.MaxValue = 999999;
            spnCantidad.Increment = 1;
            spnCantidad.IsFloatValue = true;
            spnCantidad.EditFormat.FormatString = "N2";
            gridItems.RepositoryItems.Add(spnCantidad);
            colCantidad.ColumnEdit = spnCantidad;
            gridViewItems.Columns.Add(colCantidad);

            // Columna ID oculta
            var colId = new GridColumn
            {
                FieldName = nameof(MovimientoItemDTO.IdMovimientoItem),
                Visible = false
            };
            gridViewItems.Columns.Add(colId);

            // Ocultar columnas no necesarias en la grilla editable
            var colIdStock = new GridColumn
            {
                FieldName = nameof(MovimientoItemDTO.IdMovimientoStock),
                Visible = false
            };
            gridViewItems.Columns.Add(colIdStock);

            var colDescripcion = new GridColumn
            {
                FieldName = nameof(MovimientoItemDTO.DescripcionArticulo),
                Visible = false
            };
            gridViewItems.Columns.Add(colDescripcion);

            // Evento para auto-llenar Código al seleccionar Artículo
            gridViewItems.CellValueChanged += GridViewItems_CellValueChanged;
        }

        private void GridViewItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == nameof(MovimientoItemDTO.IdArticulo) && e.Value != null)
            {
                Guid idArticulo = (Guid)e.Value;
                var articulo = ArticulosDisponibles.Find(a => a.IdArticulo == idArticulo);
                if (articulo != null)
                {
                    gridViewItems.SetRowCellValue(e.RowHandle, nameof(MovimientoItemDTO.CodigoArticulo), articulo.Codigo);
                    gridViewItems.SetRowCellValue(e.RowHandle, nameof(MovimientoItemDTO.DescripcionArticulo), articulo.Descripcion);
                }
            }
        }

        #endregion

        #region "EVENTOS BOTONES"

        private void BtnAgregarFila_Click(object sender, EventArgs e)
        {
            ItemsBinding.Add(new MovimientoItemDTO());
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

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Ajuste de Stock".Translate() : "Detalle Ajuste de Stock".Translate();
            lciTipoMovimiento.Text = "Tipo Movimiento".Translate();
            lciFecha.Text = "Fecha".Translate();
            lciGridItems.Text = "Artículos del Ajuste".Translate();
            btnAgregarFila.Text = "Agregar Artículo".Translate();
            btnQuitarFila.Text = "Quitar Artículo".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;

                // Cargar opciones del combo
                cmbTipoMovimiento.Properties.Items.Clear();
                cmbTipoMovimiento.Properties.Items.Add("Alta".Translate());
                cmbTipoMovimiento.Properties.Items.Add("Baja".Translate());
                cmbTipoMovimiento.SelectedIndex = 0;

                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                ItemsBinding = new BindingList<MovimientoItemDTO>();
                gridItems.DataSource = ItemsBinding;
            }
            else
            {
                var res = AjustesStockBLL.Current.Obtener(new ReqAjusteStockObtener(this.Sesion) { Id = Id });

                if (res.Success && res.Movimiento != null)
                {
                    MovimientoActual = res.Movimiento;

                    // Cargar combo y seleccionar
                    cmbTipoMovimiento.Properties.Items.Clear();
                    cmbTipoMovimiento.Properties.Items.Add("Alta".Translate());
                    cmbTipoMovimiento.Properties.Items.Add("Baja".Translate());
                    cmbTipoMovimiento.SelectedIndex = res.Movimiento.TipoMovimiento == E_TipoMovimiento.Alta ? 0 : 1;

                    txtFecha.Text = res.Movimiento.Fecha.ToString("dd/MM/yyyy HH:mm");

                    ItemsBinding = new BindingList<MovimientoItemDTO>(res.Movimiento.Items);
                    gridItems.DataSource = ItemsBinding;

                    // Estado determina modo de visualizaciÃ³n
                    TipoPantalla = res.Movimiento.Estado == E_Estados.Activo 
                        ? E_TipoPantalla.Visualizar 
                        : E_TipoPantalla.VisualizarEliminado;
                }
            }
        }

        protected override bool ValidarDatos()
        {
            if (ItemsBinding == null || ItemsBinding.Count == 0)
            {
                XtraMessageBox.Show(
                    "Debe agregar al menos un Artículo al ajuste".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            foreach (var item in ItemsBinding)
            {
                if (item.IdArticulo == Guid.Empty)
                {
                    XtraMessageBox.Show(
                        "Todos los Items deben tener un Artículo seleccionado".Translate(),
                        "Validación".Translate(),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (item.Cantidad <= 0)
                {
                    XtraMessageBox.Show(
                        "La cantidad debe ser mayor a cero".Translate(),
                        "Validación".Translate(),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            var movimiento = new MovimientoStockDTO
            {
                TipoMovimiento = cmbTipoMovimiento.SelectedIndex == 0
                    ? E_TipoMovimiento.Alta
                    : E_TipoMovimiento.Baja,
                Items = new List<MovimientoItemDTO>(ItemsBinding)
            };

            var req = new ReqAjusteStockInsertar(this.Sesion) { Movimiento = movimiento };
            var res = AjustesStockBLL.Current.Insertar(req);
            return res.Success;
        }

        protected override bool EliminarRegistro()
        {
            var req = new ReqAjusteStockEliminar(this.Sesion) { Id = Id };
            var res = AjustesStockBLL.Current.Eliminar(req);
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var req = new ReqAjusteStockRestaurar(this.Sesion) { Id = Id };
            var res = AjustesStockBLL.Current.Restaurar(req);
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new[] { this.cmbTipoMovimiento },
                itemsLayout: new[] { this.lciTipoMovimiento, this.lciFecha, this.lciGridItems },
                grillas: new[] { this.gridViewItems },
                botones: new[] { this.btnAgregarFila, this.btnQuitarFila }
            );

            ControlFactory.AplicarModo(
                esEditable: false,
                textEdits: new[] { this.txtFecha }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.AjusteStock;
        }

        #endregion
    }
}
