using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Windows.Forms;
using UI.Helpers;
using Services.Domain;

namespace UI.Formularios.Base
{
    /// <summary>
    /// Formulario base para pantallas de listado con grilla.
    /// Proporciona funcionalidad comÃºn: refrescar, exportar, nuevo y detalle.
    /// </summary>
    public partial class frmBaseGrilla : XtraForm, IObserver
    {
        #region "PROPIEDADES"

        /// <summary>
        /// SesiÃ³n del usuario actual del sistema.
        /// </summary>
        public GlobalCliente Sesion { get; private set; }

        /// <summary>
        /// Indica si el botÃ³n Nuevo estÃ¡ visible
        /// </summary>
        public bool MostrarBotonNuevo
        {
            get => layoutControlItem2.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            set => layoutControlItem2.Visibility = value
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        /// <summary>
        /// Indica si el botÃ³n Detalle estÃ¡ visible
        /// </summary>
        public bool MostrarBotonDetalle
        {
            get => layoutControlItem1.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            set => layoutControlItem1.Visibility = value
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        /// <summary>
        /// Acceso al GridView principal para configuraciÃ³n adicional
        /// </summary>
        protected GridView GridViewPrincipal => gridView;

        /// <summary>
        /// Obtiene el objeto actualmente seleccionado en la grilla
        /// </summary>
        protected object FilaSeleccionada
        {
            get
            {
                int rowHandle = gridView.FocusedRowHandle;
                return rowHandle >= 0 ? gridView.GetRow(rowHandle) : null;
            }
        }

        /// <summary>
        /// Obtiene el objeto seleccionado convertido al tipo especificado
        /// </summary>
        protected T ObtenerFilaSeleccionada<T>() where T : class
        {
            return FilaSeleccionada as T;
        }

        #endregion

        #region "CONSTRUCTOR"

        public frmBaseGrilla()
        {
            InitializeComponent();
            FormSubject.Current.Attach(this);
            ConfigurarEventos();
            ConfigurarGrillaBase();
            ConfigurarEstiloBotones();
        }

        public frmBaseGrilla(GlobalCliente sesion) : this()
        {
            Sesion = sesion;
        }

        #endregion

        #region "METODOS VIRTUALES"

        /// <summary>
        /// Configura los textos de la pantalla (tÃ­tulos, labels, captions de columnas, etc.)
        /// Sobrescribir en clases derivadas para actualizar textos traducibles.
        /// </summary>
        protected virtual void ConfigurarTextos()
        {
            // Actualizar textos de los botones de la barra de herramientas
            btnNuevo.Text = "Nuevo".Translate();
            btnDetalle.Text = "Ver Detalle".Translate();
            btnRefresh.Text = "Actualizar".Translate();
            btnExport.Text = "Exportar".Translate();

            // Traducir textos del FindPanel de DevExpress
            gridView.OptionsFind.FindNullPrompt = "Introduzca texto a buscar".Translate();
        }

        /// <summary>
        /// Carga los datos de la pantalla. Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void CargarPantalla()
        {
            // Implementar en clases derivadas
        }

        /// <summary>
        /// Se ejecuta al hacer clic en el botÃ³n Nuevo. Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void OnNuevoClick()
        {
            // Implementar en clases derivadas
        }

        /// <summary>
        /// Se ejecuta al hacer clic en el botÃ³n Detalle o doble clic en una fila.
        /// Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void OnDetalleClick()
        {
            // Implementar en clases derivadas
        }

        /// <summary>
        /// Se ejecuta cuando cambia la fila seleccionada. Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void OnFilaSeleccionadaCambiada(object filaSeleccionada)
        {
            // Implementar en clases derivadas si se necesita
        }

        /// <summary>
        /// Configura las columnas de la grilla. Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void ConfigurarColumnas()
        {
            // Implementar en clases derivadas
        }

        #endregion

        #region "METODOS PÃšBLICOS"

        /// <summary>
        /// Asigna el origen de datos a la grilla
        /// </summary>
        protected void EstablecerDataSource(object dataSource)
        {
            gridControl.DataSource = dataSource;
            gridControl.RefreshDataSource();
        }

        /// <summary>
        /// Agrega columnas a la grilla de forma simplificada
        /// </summary>
        protected void AgregarColumnas(params GridColumn[] columnas)
        {
            gridView.Columns.AddRange(columnas);
        }

        /// <summary>
        /// Crea una columna configurada
        /// </summary>
        protected GridColumn CrearColumna(string fieldName, string caption, bool visible = true, int width = 0)
        {
            var column = new GridColumn
            {
                FieldName = fieldName,
                Caption = caption,
                Visible = visible
            };

            if (width > 0)
                column.Width = width;

            return column;
        }

        /// <summary>
        /// Refresca la grilla manualmente
        /// </summary>
        public void RefrescarGrilla()
        {
            CargarPantalla();
        }

        #endregion

        #region "METODOS PRIVADOS"

        private void ConfigurarEventos()
        {
            this.Load += FrmBaseGrilla_Load;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.DoubleClick += GridView_DoubleClick;
        }

        private void ConfigurarGrillaBase()
        {
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.ReadOnly = true;
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsDetail.EnableMasterViewMode = false;

            // Aplicar estilos visuales
            GridStyleHelper.AplicarEstilo(gridView);
        }

        private void ConfigurarEstiloBotones()
        {
            // Aplicar estilos a los botones de la barra de herramientas
            ButtonStyleHelper.ConfigurarBarraHerramientas(
                btnNuevo: btnNuevo,
                btnDetalle: btnDetalle,
                btnRefresh: btnRefresh,
                btnExport: btnExport
            );
        }

        #endregion

        #region "EVENTOS"

        private void FrmBaseGrilla_Load(object sender, EventArgs e)
        {
            // Aplicar estilos automÃ¡ticamente a todos los controles
            FormStyleHelper.AplicarEstilosListado(this);

            ConfigurarTextos();
            ConfigurarColumnas();
            CargarPantalla();
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                OnFilaSeleccionadaCambiada(gridView.GetRow(e.FocusedRowHandle));
            }

            btnDetalle.Enabled = e.FocusedRowHandle >= 0;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (FilaSeleccionada != null && MostrarBotonDetalle)
            {
                OnDetalleClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (gridControl.MainView is GridView gv)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo Excel".Translate();
                    saveFileDialog.FileName = "Exportado.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        gv.ExportToXlsx(saveFileDialog.FileName);
                        XtraMessageBox.Show("ExportaciÃ³n completada exitosamente.".Translate(), "Ã‰xito".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("El GridControl no contiene un GridView vÃ¡lido.".Translate(), "Error".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OnNuevoClick();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (FilaSeleccionada != null)
            {
                OnDetalleClick();
            }
            else
            {
                XtraMessageBox.Show("Seleccione un registro para ver el detalle.".Translate(), "InformaciÃ³n".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "IMPLEMENTACIÃ“N IOBSERVER"

        /// <summary>
        /// MÃ©todo llamado cuando se notifica un cambio desde el Subject.
        /// </summary>
        public virtual void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Idioma.Equals(value))
            {
                ConfigurarTextos();
            }
        }

        #endregion

        #region "DISPOSE"

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            FormSubject.Current.Detach(this);
            base.OnFormClosed(e);
        }

        #endregion
    }
}
