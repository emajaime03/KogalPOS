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
            ResUsuarioLogin res = (ResUsuarioLogin)RequestBLL.Current.GetResponse(new ReqUsuarioLogin { Username = txtUserName.Text, Password = txtPassword.Text });

            if (res.Success)
            {
                this.UsuarioLogin = res.Usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMensaje.Text = res.Message.Translate();
                lblMensaje.Visible = true;
            }
        }
    }
}