using DevExpress.Utils.VisualEffects;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Login
{
    public partial class frmLogin : Form
    {
        public Usuario UsuarioLogin { get; set; }

        public frmLogin()
        {
            InitializeComponent();

            ControlesInicializar();
        }

        private void ControlesInicializar()
        {
            lblUserName.Text = LanguageService.Translate("user");
            lblPassword.Text = LanguageService.Translate("password");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogin = UsuarioService.Login(txtUserName.Text, CryptographyService.HashPassword(txtPassword.Text));

            if (UsuarioLogin == null)
            {
                MessageBox.Show(LanguageService.Translate("Incorrect username or password."));
            } else
            {
                string mensajeLogin = "Login correcto";
                MessageBox.Show(mensajeLogin);
                LoggerService.WriteLog(new Log(mensajeLogin, UsuarioLogin.UserName));

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
