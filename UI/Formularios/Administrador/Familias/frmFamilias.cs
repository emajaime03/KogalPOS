using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Services.BLL;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.Facade;
using Services.Facade.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Administrador.Familias
{
    public partial class frmFamilias : DevExpress.XtraEditors.XtraForm, IObserver
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

            this.Text = "Familias";

            gvFamilias.OptionsDetail.EnableMasterViewMode = false;
            gvFamiliasHijos.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

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
                    Caption = "ESTADO",
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN",
                    Visible = true,
                },
            };

            // Agregar columnas al GridView
            gvFamilias.Columns.AddRange(gridColumnsFamilias.ToArray());
            gvFamiliasHijos.Columns.AddRange(gridColumnsFamilias.ToArray());

            List<GridColumn> gridColumnspatentes = new List<GridColumn>
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
                    Caption = "ESTADO",
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN",
                    Visible = true,
                }
            };

            gvPatentes.Columns.AddRange(gridColumnspatentes.ToArray());

            CargarPantalla();
        }
        private void CargarPantalla()
        {
            ResFamiliasObtener res = (ResFamiliasObtener)RequestService.Current.GetResponse(new ReqFamiliasObtener());

            this.gcFamilias.DataSource = res.Familias;
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Familia.Equals(value))
            {
                CargarPantalla();
            }
        }
        #endregion

        #region "EVENTOS"
        private void gvFamilias_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowHandle = e.FocusedRowHandle;

            if (rowHandle >= 0)
            {
                // Obtener la fila y convertirla al tipo MiClase
                Familia familia = gvFamilias.GetRow(rowHandle) as Familia;

                if (familia != null)
                {
                    this.gcFamiliasHijos.DataSource = familia.GetFamilias();
                    this.gcPatentes.DataSource = familia.GetPatentes();

                    this.gcFamiliasHijos.RefreshDataSource();
                    this.gcPatentes.RefreshDataSource();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Verificar si el GridControl tiene datos
            if (gcFamilias.MainView is DevExpress.XtraGrid.Views.Grid.GridView gridView)
            {
                // Mostrar un cuadro de diálogo para seleccionar la ubicación del archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo Excel";
                    saveFileDialog.FileName = "Exportado.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Exportar el GridView a un archivo Excel
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
            // Obtén el objeto seleccionado del GridView
            int rowHandle = gvFamilias.FocusedRowHandle;
            if (rowHandle >= 0) // Asegúrate de que hay una fila seleccionada
            {
                // Convierte el elemento al tipo específico
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