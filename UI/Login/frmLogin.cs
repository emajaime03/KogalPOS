using DevExpress.XtraEditors;
using Services.BLL;
using Services.Domain;
using Services.Domain.BLL;
using Services.Facade;
using Services.Facade.Extensions;
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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public Usuario UsuarioLogin { get; set; }

        public frmLogin()
        {
            InitializeComponent();

            ControlesInicializar();
        }

        private void ControlesInicializar()
        {
            //lblUserName.Text = LanguageService.Translate("Usuario");
            //lblPassword.Text = LanguageService.Translate("Contraseña");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var response = RequestService.Current.GetResponse(
                new ReqUsuarioLogin
                {
                    Username = txtUserName.Text,
                    Password = CryptographyService.Hash(txtPassword.Text)
                }
            );

            if (response is ResUsuarioLogin res && res.Success)
            {
                this.UsuarioLogin = res.Usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMensaje.Text = (response as ResUsuarioLogin)?.Message.Translate() ?? "Error en login.";
                lblMensaje.Visible = true;
            }
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
#if DEBUG
            if ((Control.ModifierKeys == Keys.Shift) && (e.KeyChar == '_' || e.KeyChar == '-'))
            {
                txtUserName.Text = "emajaime073@gmail.com";
                txtPassword.Text = "1234";
                btnIngresar.PerformClick();
            }
#endif
        }
    }
}