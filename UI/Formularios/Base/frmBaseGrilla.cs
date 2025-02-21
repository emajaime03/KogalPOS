using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace UI.Formularios.Base
{
    public partial class frmBaseGrilla : DevExpress.XtraEditors.XtraForm
    {
        public frmBaseGrilla()
        {
            InitializeComponent();
        }

        protected virtual void CargarPantalla()
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Verificar si el GridControl tiene datos
            if (gridControl.MainView is DevExpress.XtraGrid.Views.Grid.GridView gridView)
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