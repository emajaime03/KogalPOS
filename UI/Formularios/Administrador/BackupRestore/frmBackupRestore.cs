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
            lblInstrucciones.Text = "Seleccione una opciÃ³n para gestionar la copia de seguridad de la base de datos.".Translate();
        }

        private void MostrarResultado(Services.Domain.BLL.Base.ResBase res)
        {
            if (res.Success)
            {
                XtraMessageBox.Show(res.Message.Translate(), "Ã‰xito".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    var req = new ReqBackupRealizar(this.Sesion) { RutaArchivo = saveFileDialog.FileName };
                    var res = BackupBLL.Current.RealizarBackup(req, this.Sesion);

                    MostrarResultado(res);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var confirmResult = XtraMessageBox.Show(
                "ADVERTENCIA: Restaurar una base de datos sobrescribirÃ¡ todos los datos actuales y cerrarÃ¡ la sesiÃ³n de la aplicaciÃ³n. Â¿Desea continuar?".Translate(),
                "Confirmar RestauraciÃ³n".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Server Backup (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar archivo de Backup";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var req = new ReqBackupRestaurar(this.Sesion) { RutaArchivo = openFileDialog.FileName };
                    
                    // Mostrar wait form o cursor de espera serÃ­a ideal aquÃ­, pero simplificamos
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
