using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.BLL.Services;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Helpers;

namespace UI.Formularios.Administrador.Familias
{
    public partial class frmFamilias : XtraForm, IObserver
    {
        #region "CONSTRUCTOR"
        public frmFamilias()
        {
            InitializeComponent();

            FormSubject.Current.Attach(this);

            ControlesInicializar();
        }
        #endregion

        #region "PROCEDIMIENTOS"
        private void ControlesInicializar()
        {
            gvFamilias.FocusedRowChanged += gvFamilias_FocusedRowChanged;
            gvFamilias.DoubleClick += gvFamilias_DoubleClick;

            gvFamilias.OptionsDetail.EnableMasterViewMode = false;
            gvFamiliasHijos.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            ConfigurarTextos();
            ConfigurarColumnas();
            
            // Aplicar estilos automáticamente (grilla principal + grillas compactas de detalle)
            FormStyleHelper.AplicarEstilosListado(this, "gcFamilias");
            ButtonStyleHelper.ConfigurarBarraHerramientas(btnNuevo, btnDetalle, btnRefresh, btnExport);
            
            CargarPantalla();
        }

        private void ConfigurarTextos()
        {
            this.Text = "Familias".Translate();
            labelControl3.Text = "Familias".Translate();
            labelControl1.Text = "Familias Hijos".Translate();
            labelControl2.Text = "Patentes".Translate();

            // Actualizar textos de los botones de la barra de herramientas
            btnNuevo.Text = "Nuevo".Translate();
            btnDetalle.Text = "Ver Detalle".Translate();
            btnRefresh.Text = "Actualizar".Translate();
            btnExport.Text = "Exportar".Translate();

            // Actualizar captions de las columnas de grillas
            ActualizarCaptionsColumnas();
        }

        private void ActualizarCaptionsColumnas()
        {
            // Columnas de gvFamilias
            if (gvFamilias.Columns.Count > 0)
            {
                var colId = gvFamilias.Columns[nameof(Familia.Id)];
                var colEstado = gvFamilias.Columns[nameof(Familia.Estado)];
                var colDescripcion = gvFamilias.Columns[nameof(Familia.Descripcion)];

                if (colId != null) colId.Caption = "ID";
                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
            }

            // Columnas de gvFamiliasHijos
            if (gvFamiliasHijos.Columns.Count > 0)
            {
                var colDescripcion = gvFamiliasHijos.Columns[nameof(Familia.Descripcion)];
                var colEstado = gvFamiliasHijos.Columns[nameof(Familia.Estado)];

                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
            }

            // Columnas de gvPatentes
            if (gvPatentes.Columns.Count > 0)
            {
                var colId = gvPatentes.Columns[nameof(Patente.Id)];
                var colEstado = gvPatentes.Columns[nameof(Patente.Estado)];
                var colDescripcion = gvPatentes.Columns[nameof(Patente.Descripcion)];

                if (colId != null) colId.Caption = "ID";
                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
            }
        }

        private void ConfigurarColumnas()
        {
            List<GridColumn> gridColumnsFamilias = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Id),
                    Caption = "ID",
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Estado),
                    Caption = "ESTADO".Translate(),
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true,
                },
            };

            gvFamilias.Columns.AddRange(gridColumnsFamilias.ToArray());
            
            // Columnas para familias hijos (sin ID)
            List<GridColumn> gridColumnsFamiliasHijos = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Estado),
                    Caption = "ESTADO".Translate(),
                    Visible = true,
                },
            };
            
            gvFamiliasHijos.Columns.AddRange(gridColumnsFamiliasHijos.ToArray());

            List<GridColumn> gridColumnsPatentes = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Patente.Id),
                    Caption = "ID",
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Estado),
                    Caption = "ESTADO".Translate(),
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true,
                }
            };

            gvPatentes.Columns.AddRange(gridColumnsPatentes.ToArray());
        }

        private void CargarPantalla()
        {
            var res = FamiliasBLL.Current.ObtenerLista(new ReqFamiliasObtener());
            this.gcFamilias.DataSource = res.Familias;
        }

        private void CargarDetallesFamilia(Familia familia)
        {
            if (familia != null)
            {
                this.gcFamiliasHijos.DataSource = familia.GetFamilias();
                this.gcPatentes.DataSource = familia.GetPatentes();

                this.gcFamiliasHijos.RefreshDataSource();
                this.gcPatentes.RefreshDataSource();
            }
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Familia.Equals(value))
            {
                CargarPantalla();
            }
            else if (E_FormsServicesValues.Idioma.Equals(value))
            {
                ConfigurarTextos();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            FormSubject.Current.Detach(this);
            base.OnFormClosed(e);
        }
        #endregion

        #region "EVENTOS"
        private void gvFamilias_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowHandle = e.FocusedRowHandle;

            if (rowHandle >= 0)
            {
                Familia familia = gvFamilias.GetRow(rowHandle) as Familia;
                CargarDetallesFamilia(familia);
            }

            btnDetalle.Enabled = rowHandle >= 0;
        }

        private void gvFamilias_DoubleClick(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (gcFamilias.MainView is DevExpress.XtraGrid.Views.Grid.GridView gridView)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo Excel";
                    saveFileDialog.FileName = "Exportado.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        gridView.ExportToXlsx(saveFileDialog.FileName);
                        XtraMessageBox.Show("Exportación completada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("El GridControl no contiene un GridView válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormulariosManager.FamiliasABM();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        private void AbrirDetalle()
        {
            int rowHandle = gvFamilias.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                Familia familiaSeleccionada = gvFamilias.GetRow(rowHandle) as Familia;

                if (familiaSeleccionada != null)
                {
                    FormulariosManager.FamiliasABM(familiaSeleccionada.Id);
                }
            }
        }
        #endregion
    }
}
