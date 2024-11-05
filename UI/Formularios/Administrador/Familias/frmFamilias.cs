using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Services.BLL;
using Services.Domain;
using Services.Domain.BLL;
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
    public partial class frmFamilias : DevExpress.XtraEditors.XtraForm
    {
        private List<Familia> familias;

        public frmFamilias()
        {
            InitializeComponent();

            ControlesInicializar();
        }

        private void CargarPantalla()
        {
            ResFamiliasObtener res = (ResFamiliasObtener)RequestBLL.Current.GetResponse(new ReqFamiliasObtener());

            familias = res.Familias;

            this.gcFamilias.DataSource = res.Familias;
        }

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

        private void ControlesInicializar()
        {
            gvFamilias.FocusedRowChanged += gvFamilias_FocusedRowChanged;

            this.Text = "Familias";

            List<GridColumn> gridColumnsFamilias = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN",
                    Visible = true,
                }
            };

            // Agregar columnas al GridView
            gvFamilias.Columns.AddRange(gridColumnsFamilias.ToArray());
            gvFamiliasHijos.Columns.AddRange(gridColumnsFamilias.ToArray());

            List<GridColumn> gridColumnspatentes = new List<GridColumn>
            {
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
    }
}