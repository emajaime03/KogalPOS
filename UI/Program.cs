using Domain;
using Services.Domain;
using Services.Facade;
using System;
using UI.Login;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Usuario usuario = default;

                frmLogin frmLogin = new frmLogin();
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    usuario = frmLogin.UsuarioLogin;
                }

                if (usuario == null)
                {
                    return;
                }
                else
                {
                    GlobalCliente.UsuarioLogin = usuario;
                    Application.Run(new frmInicio());
                }
            }
            catch (Exception ex)
            { 
                LoggerService.WriteException(ex);
            }
        }
    }
}
