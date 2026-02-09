using DevExpress.XtraEditors;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.Facade;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Helpers;

namespace UI.Formularios.Administrador.BackupRestore
{
    public partial class frmBackupRestore : XtraForm, IObserver
    {
        #region "CONSTRUCTOR"
        public frmBackupRestore()
        {
            InitializeComponent();
            FormSubject.Current.Attach(this);
            ConfigurarTextos();
        }
        #endregion

        #region "METODOS"
        private void ConfigurarTextos()
        {
            this.Text = "Copias de Seguridad".Translate();
            btnBackup.Text = "Generar Backup".Translate();
            btnRestore.Text = "Restaurar Backup".Translate();
            lblInstrucciones.Text = "Seleccione una opción para gestionar la copia de seguridad de la base de datos.".Translate();
        }

        private void MostrarResultado(Services.Domain.BLL.Base.ResBase res)
        {
            if (res.Success)
            {
                XtraMessageBox.Show(res.Message.Translate(), "Éxito".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show(res.Message.Translate(), "Error".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region "EVENTOS"
        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SQL Server Backup (*.bak)|*.bak";
                saveFileDialog.Title = "Guardar Backup";
                saveFileDialog.FileName = $"KogalPOS_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var req = new ReqBackupRealizar { RutaArchivo = saveFileDialog.FileName };
                    var res = RequestService.Current.GetResponse(req);

                    MostrarResultado(res);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var confirmResult = XtraMessageBox.Show(
                "ADVERTENCIA: Restaurar una base de datos sobrescribirá todos los datos actuales y cerrará la sesión de la aplicación. ¿Desea continuar?".Translate(),
                "Confirmar Restauración".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Server Backup (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar archivo de Backup";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var req = new ReqBackupRestaurar { RutaArchivo = openFileDialog.FileName };
                    
                    // Mostrar wait form o cursor de espera sería ideal aquí, pero simplificamos
                    Cursor.Current = Cursors.WaitCursor;
                    var res = RequestService.Current.GetResponse(req);
                    Cursor.Current = Cursors.Default;

                    MostrarResultado(res);

                    if (res.Success)
                    {
                        Application.Restart();
                    }
                }
            }
        }
        #endregion

        #region "OBSERVER"
        public void Update<T>(T value, object data = null)
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
