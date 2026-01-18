using Services.BLL;
using Services.Domain;
using Services.Domain.BLL;
using Services.Facade;
using Services.Facade.Extensions;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UI.Helpers;

namespace UI.Login
{
    public partial class frmLogin : Form
    {
        public Usuario UsuarioLogin { get; set; }

        // Para arrastrar la ventana sin bordes
        private bool arrastrando = false;
        private Point puntoInicio;

        // Paneles para líneas bajo los campos
        private Panel lineaUserName;
        private Panel lineaPassword;

        // Botón cerrar
        private Label btnCerrar;

        // Colores del tema (azul igual al ribbon de DevExpress)
        private readonly Color colorPrimario = Color.FromArgb(0, 114, 198);
        private readonly Color colorPrimarioHover = Color.FromArgb(0, 95, 170);
        private readonly Color colorAccento = Color.FromArgb(0, 114, 198);
        private readonly Color colorLinea = Color.FromArgb(220, 220, 220);
        private readonly Color colorLineaActiva = Color.FromArgb(0, 114, 198);

        public frmLogin()
        {
            InitializeComponent();
            ConfigurarFuentes();
            ConfigurarFormulario();
            ConfigurarControles();
            ConfigurarEventos();
        }

        private void ConfigurarFuentes()
        {
            // Título principal del sistema (muy grande)
            lblTitulo.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            
            // Subtítulo del sistema
            lblSubtitulo.Font = FontHelper.FuenteSubtitulo;
            
            // Título de bienvenida
            lblBienvenido.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            
            // Etiquetas de campos
            lblUserName.Font = FontHelper.FuenteEtiqueta;
            lblPassword.Font = FontHelper.FuenteEtiqueta;
            
            // Campos de texto
            txtUserName.Font = FontHelper.FuenteSubtitulo;
            txtPassword.Font = FontHelper.FuenteSubtitulo;
            
            // Botón de ingresar
            btnIngresar.Font = FontHelper.FuenteBoton;
            
            // Mensaje de error
            lblMensaje.Font = FontHelper.FuenteBase;
            
            // Versión (pequeña)
            lblVersion.Font = FontHelper.FuentePequena;
        }

        private void ConfigurarFormulario()
        {
            // Sombra del formulario (opcional, requiere más código para implementar)
            this.DoubleBuffered = true;

            // Botón de cerrar
            btnCerrar = new Label
            {
                Text = "✕",
                Font = FontHelper.FuenteSubtitulo,
                ForeColor = Color.FromArgb(150, 150, 150),
                BackColor = Color.Transparent,
                Size = new Size(30, 30),
                Location = new Point(this.Width - 40, 10),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btnCerrar.Click += (s, e) => this.Close();
            btnCerrar.MouseEnter += (s, e) => btnCerrar.ForeColor = Color.FromArgb(220, 53, 69);
            btnCerrar.MouseLeave += (s, e) => btnCerrar.ForeColor = Color.FromArgb(150, 150, 150);
            this.Controls.Add(btnCerrar);
            btnCerrar.BringToFront();
        }

        private void ConfigurarControles()
        {
            // Limpiar textos por defecto
            txtUserName.Text = "";
            txtPassword.Text = "";

            // Placeholder del usuario
            txtUserName.ForeColor = Color.Gray;
            txtUserName.Text = "Ingrese su usuario";
            txtUserName.GotFocus += (s, e) =>
            {
                if (txtUserName.Text == "Ingrese su usuario")
                {
                    txtUserName.Text = "";
                    txtUserName.ForeColor = Color.FromArgb(64, 64, 64);
                }
            };
            txtUserName.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    txtUserName.ForeColor = Color.Gray;
                    txtUserName.Text = "Ingrese su usuario";
                }
            };

            // Placeholder de contraseña
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = "Ingrese su contraseña";
            txtPassword.GotFocus += (s, e) =>
            {
                if (txtPassword.Text == "Ingrese su contraseña")
                {
                    txtPassword.Text = "";
                    txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
                    txtPassword.UseSystemPasswordChar = true;
                }
            };
            txtPassword.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.ForeColor = Color.Gray;
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.Text = "Ingrese su contraseña";
                }
            };

            // Línea bajo el campo de usuario
            lineaUserName = new Panel
            {
                BackColor = colorLinea,
                Size = new Size(290, 2),
                Location = new Point(txtUserName.Left, txtUserName.Bottom + 5)
            };
            pnlDerecho.Controls.Add(lineaUserName);

            // Línea bajo el campo de contraseña
            lineaPassword = new Panel
            {
                BackColor = colorLinea,
                Size = new Size(290, 2),
                Location = new Point(txtPassword.Left, txtPassword.Bottom + 5)
            };
            pnlDerecho.Controls.Add(lineaPassword);

            // Efectos de foco en las líneas
            txtUserName.Enter += (s, e) => lineaUserName.BackColor = colorLineaActiva;
            txtUserName.Leave += (s, e) => lineaUserName.BackColor = colorLinea;
            txtPassword.Enter += (s, e) => lineaPassword.BackColor = colorLineaActiva;
            txtPassword.Leave += (s, e) => lineaPassword.BackColor = colorLinea;

            // Efecto hover en el botón
            btnIngresar.MouseEnter += (s, e) => btnIngresar.BackColor = colorPrimarioHover;
            btnIngresar.MouseLeave += (s, e) => btnIngresar.BackColor = colorPrimario;
        }

        private void ConfigurarEventos()
        {
            // Arrastrar ventana desde el panel izquierdo
            pnlIzquierdo.MouseDown += Formulario_MouseDown;
            pnlIzquierdo.MouseMove += Formulario_MouseMove;
            pnlIzquierdo.MouseUp += Formulario_MouseUp;
            lblTitulo.MouseDown += Formulario_MouseDown;
            lblTitulo.MouseMove += Formulario_MouseMove;
            lblTitulo.MouseUp += Formulario_MouseUp;
            lblSubtitulo.MouseDown += Formulario_MouseDown;
            lblSubtitulo.MouseMove += Formulario_MouseMove;
            lblSubtitulo.MouseUp += Formulario_MouseUp;

            // Arrastrar ventana desde el panel derecho (área superior)
            pnlDerecho.MouseDown += Formulario_MouseDown;
            pnlDerecho.MouseMove += Formulario_MouseMove;
            pnlDerecho.MouseUp += Formulario_MouseUp;
            lblBienvenido.MouseDown += Formulario_MouseDown;
            lblBienvenido.MouseMove += Formulario_MouseMove;
            lblBienvenido.MouseUp += Formulario_MouseUp;
        }

        private void Formulario_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastrando = true;
                puntoInicio = new Point(e.X, e.Y);
            }
        }

        private void Formulario_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - puntoInicio.X - ((Control)sender).Left,
                                    p.Y - puntoInicio.Y - ((Control)sender).Top);
            }
        }

        private void Formulario_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validar que no sean placeholders
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (username == "Ingrese su usuario" || string.IsNullOrWhiteSpace(username))
            {
                MostrarError("Por favor ingrese su usuario");
                txtUserName.Focus();
                return;
            }

            if (password == "Ingrese su contraseña" || string.IsNullOrWhiteSpace(password))
            {
                MostrarError("Por favor ingrese su contraseña");
                txtPassword.Focus();
                return;
            }

            // Cambiar texto del botón mientras procesa
            btnIngresar.Text = "Verificando...";
            btnIngresar.Enabled = false;
            Application.DoEvents();

            try
            {
                var response = RequestService.Current.GetResponse(
                    new ReqUsuarioLogin
                    {
                        Username = username,
                        Password = CryptographyService.Hash(password)
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
                    MostrarError((response as ResUsuarioLogin)?.Message.Translate() ?? "Error en login.");
                }
            }
            finally
            {
                btnIngresar.Text = "Iniciar Sesión";
                btnIngresar.Enabled = true;
            }
        }

        private void MostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;

            // Efecto de sacudida en el formulario
            var posOriginal = this.Location;
            for (int i = 0; i < 3; i++)
            {
                this.Location = new Point(posOriginal.X - 5, posOriginal.Y);
                System.Threading.Thread.Sleep(30);
                Application.DoEvents();
                this.Location = new Point(posOriginal.X + 5, posOriginal.Y);
                System.Threading.Thread.Sleep(30);
                Application.DoEvents();
            }
            this.Location = posOriginal;
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
#if DEBUG
            if ((Control.ModifierKeys == Keys.Shift) && (e.KeyChar == '_' || e.KeyChar == '-'))
            {
                txtUserName.Text = "emajaime073@gmail.com";
                txtUserName.ForeColor = Color.FromArgb(64, 64, 64);
                txtPassword.Text = "1234";
                txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
                txtPassword.UseSystemPasswordChar = true;
                btnIngresar.PerformClick();
            }
#endif

            // ESC para cerrar
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Borde sutil alrededor del formulario
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
