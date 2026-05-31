using DevExpress.XtraEditors;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.BLL.Services;
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
        #region "PROPIEDADES"
        public Services.Domain.GlobalCliente Sesion { get; private set; }
        #endregion

        #region "CONSTRUCTOR"
        public frmBackupRestore(Services.Domain.GlobalCliente sesion)
        {
            this.Sesion = sesion;
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
            string defaultPath = Services.Domain.ApplicationSettings.Current.DefaultBackupPath;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccioná la carpeta donde guardar los backups";
                folderDialog.ShowNewFolderButton = true;

                // Abrir el diálogo ya parado en la carpeta por defecto
                if (!string.IsNullOrWhiteSpace(defaultPath) && System.IO.Directory.Exists(defaultPath))
                    folderDialog.SelectedPath = defaultPath;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var req = new ReqBackupRealizar(this.Sesion) { RutaArchivo = folderDialog.SelectedPath };
                    var res = BackupBLL.Current.RealizarBackup(req, this.Sesion);
                    Cursor.Current = Cursors.Default;

                    MostrarResultado(res);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var confirmResult = XtraMessageBox.Show(
                "ADVERTENCIA: Restaurar una base de datos sobrescribirá todos los datos actuales y cerrará la sesión de la aplicación. ¿Desea continuar?".Translate(),
                "Confirmar restauración".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Server Backup (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar archivo de Backup";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // El nombre del archivo tiene el formato: {ConnectionStringName}_Backup_{timestamp}.bak
                    // Extraemos el ConnectionStringName del nombre del archivo para saber a qué DB restaurar
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    string connStringName = fileName.Contains("_Backup_")
                        ? fileName.Substring(0, fileName.IndexOf("_Backup_"))
                        : null;

                    var req = new ReqBackupRestaurar(this.Sesion)
                    {
                        RutaArchivo = openFileDialog.FileName,
                        ConnectionStringName = connStringName
                    };

                    Cursor.Current = Cursors.WaitCursor;
                    var res = BackupBLL.Current.RealizarRestore(req, this.Sesion);
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
