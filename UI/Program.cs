using DevExpress.XtraEditors;
using Services.Domain;
using Services.Facade;
using System;
using System.Threading;
using UI.Login;
using System.Windows.Forms;
using UI.Principal;
using Services.Domain.BLL;
using UI.Helpers;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// Indica si se solicitó cerrar sesión (para volver al login)
        /// </summary>
        public static bool CerrarSesion { get; set; } = false;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar manejadores globales de excepciones
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Configurar fuente predeterminada para controles DevExpress
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = FontHelper.FuenteBase;

                // Sincronizo todas las patentes del enum a la base de datos
                var res = RequestService.Current.GetResponse(new ReqPatentesSincronizar());

                // Ciclo de login - permite volver al login después de cerrar sesión
                bool continuar = true;
                while (continuar)
                {
                    CerrarSesion = false;
                    Usuario usuario = null;

                    using (frmLogin login = new frmLogin())
                    {
                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            usuario = login.UsuarioLogin;
                        }
                    }

                    if (usuario == null)
                    {
                        continuar = false;
                    }
                    else
                    {
                        GlobalCliente.UsuarioLogin = usuario;
                        
                        using (frmPrincipal principal = new frmPrincipal())
                        {
                            Application.Run(principal);
                        }

                        // Si no se cerró sesión, salir del ciclo
                        if (!CerrarSesion)
                        {
                            continuar = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                ManejarExcepcionFatal(ex);
            }
        }

        /// <summary>
        /// Maneja excepciones del hilo de UI (Windows Forms).
        /// La aplicación puede continuar después de mostrar el mensaje.
        /// </summary>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ManejarExcepcion(e.Exception, false);
        }

        /// <summary>
        /// Maneja excepciones no controladas de otros hilos.
        /// La aplicación generalmente se cierra después de este tipo de excepciones.
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            ManejarExcepcion(exception, e.IsTerminating);
        }

        /// <summary>
        /// Maneja una excepción mostrando un mensaje al usuario y registrándola en el log.
        /// </summary>
        private static void ManejarExcepcion(Exception ex, bool esTerminal)
        {
            try
            {
                // Registrar en el log
                LoggerService.WriteException(ex);

                // Construir mensaje para el usuario
                string mensaje = "Se ha producido un error inesperado en la aplicación.\n\n" +
                                 "El error ha sido registrado. Por favor, contacte al administrador del sistema.\n\n" +
                                 $"Detalle técnico: {ex?.Message ?? "Error desconocido"}";

                if (esTerminal)
                {
                    mensaje += "\n\nLa aplicación se cerrará.";
                }

                // Mostrar mensaje al usuario
                XtraMessageBox.Show(
                    mensaje,
                    "Error Inesperado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                // Si falla el manejo de la excepción, intentar mostrar un MessageBox básico
                try
                {
                    MessageBox.Show(
                        "Se ha producido un error crítico en la aplicación.\n" +
                        "Por favor, contacte al administrador del sistema.",
                        "Error Crítico",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch
                {
                    // Si todo falla, al menos intentamos que la excepción quede en el log
                }
            }
        }

        /// <summary>
        /// Maneja excepciones fatales que ocurren durante la inicialización.
        /// </summary>
        private static void ManejarExcepcionFatal(Exception ex)
        {
            try
            {
                LoggerService.WriteException(ex);

                XtraMessageBox.Show(
                    "Se ha producido un error crítico durante la inicialización de la aplicación.\n\n" +
                    $"Detalle: {ex.Message}\n\n" +
                    "La aplicación se cerrará. Por favor, verifique la configuración y vuelva a intentar.",
                    "Error de Inicialización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show(
                    "Error crítico durante la inicialización.\n" +
                    "La aplicación se cerrará.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
