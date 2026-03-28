using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Services.Domain;
using Services.Domain.Enums;
using Services.Facade;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Formularios;

namespace UI.Principal
{
    public partial class frmPrincipal : RibbonForm, IObserver
    {
        #region "PROPIEDADES"
        public GlobalCliente Sesion { get; private set; }
        // Items de la barra de estado
        private BarStaticItem lblUsuario;
        private BarStaticItem lblIdioma;
        private BarButtonItem btnEspanol;
        private BarButtonItem btnIngles;
        private BarButtonItem btnCerrarSesion;
        private BarButtonItem btnSalir;
        #endregion

        #region "CONSTRUCTOR"
        public frmPrincipal(GlobalCliente sesion)
        {
            this.Sesion = sesion;
            InitializeComponent();

            FormSubject.Current.Attach(this);

            ControlesInicializar();
            ConfigurarBarraEstado();
            ConfigurarTextos();
        }
        #endregion

        #region "INICIALIZACIÓN"

        /// Configuración declarativa de un item de menú
        private class MenuItemConfig
        {
            public E_Patentes Patente { get; set; }
            public string CaptionKey { get; set; }
            public Func<RibbonPage> GetPage { get; set; }
            public Action OnClick { get; set; }
            public BarButtonItem Button { get; set; } // se asigna al crear
        }

        /// Fuente única de verdad: agregar un módulo nuevo = agregar UNA línea
        private MenuItemConfig[] _menuItems;

        private MenuItemConfig[] CrearMenuItems()
        {
            return new[]
            {
                // ── Admin ──
                new MenuItemConfig { Patente = E_Patentes.Admin, CaptionKey = "Patentes",           GetPage = () => rbpAdmin,   OnClick = () => FormulariosManager.Patentes() },
                new MenuItemConfig { Patente = E_Patentes.Admin, CaptionKey = "Familias",           GetPage = () => rbpAdmin,   OnClick = () => FormulariosManager.Familias() },
                new MenuItemConfig { Patente = E_Patentes.Admin, CaptionKey = "Usuarios",           GetPage = () => rbpAdmin,   OnClick = () => FormulariosManager.Usuarios() },
                new MenuItemConfig { Patente = E_Patentes.Admin, CaptionKey = "Copias de Seguridad", GetPage = () => rbpAdmin,   OnClick = () => FormulariosManager.CopiasSeguridad() },

                // ── Compras ──
                new MenuItemConfig { Patente = E_Patentes.Proveedores, CaptionKey = "Proveedores",  GetPage = () => rbpCompras, OnClick = () => FormulariosManager.Proveedores() },
                
                // ── Inventario ──
                new MenuItemConfig { Patente = E_Patentes.Articulos, CaptionKey = "Artículos",  GetPage = () => rbpInventario, OnClick = () => FormulariosManager.Articulos() },
                new MenuItemConfig { Patente = E_Patentes.AjustesStock, CaptionKey = "Ajustes de Stock",  GetPage = () => rbpInventario, OnClick = () => FormulariosManager.AjustesStock() },

                // ── Ventas ──
                new MenuItemConfig { Patente = E_Patentes.Clientes, CaptionKey = "Clientes",  GetPage = () => rbpVentas, OnClick = () => FormulariosManager.Clientes() },
                new MenuItemConfig { Patente = E_Patentes.ListasDePrecios, CaptionKey = "Listas de Precios",  GetPage = () => rbpVentas, OnClick = () => FormulariosManager.ListaPrecios() },
            };
        }

        private void ControlesInicializar()
        {
            _menuItems = CrearMenuItems();

            foreach (var item in _menuItems)
            {
                if (this.Sesion.UsuarioLogin.CheckPatente(item.Patente))
                {
                    AgregarItem(item);
                }
            }

            // Ocultar RibbonPages que quedaron vacías (sin permisos para ningún item)
            foreach (RibbonPage page in ribbon.Pages)
            {
                if (page.Groups.Count == 0)
                {
                    page.Visible = false;
                }
            }
        }

        private void AgregarItem(MenuItemConfig item)
        {
            var btn = new BarButtonItem
            {
                Caption = item.CaptionKey.Translate(),
                Id = ribbon.Items.Count + 1,
                Name = $"barButtonItem_{item.CaptionKey}"
            };

            btn.ItemClick += (s, e) =>
            {
                FormulariosManager.frmPrincipal = this;
                item.OnClick();
            };

            item.Button = btn;

            var group = new RibbonPageGroup();
            group.ItemLinks.Add(btn);
            item.GetPage().Groups.Add(group);
        }

        private void ConfigurarBarraEstado()
        {
            // Limpiar items existentes
            ribbonStatusBar.ItemLinks.Clear();

            // === SECCIÓN IZQUIERDA: Usuario actual ===
            lblUsuario = new BarStaticItem
            {
                Caption = $"👤 {this.Sesion.UsuarioLogin?.UserName ?? "Usuario"}",
                Id = ribbon.Items.Count + 1,
                Alignment = BarItemLinkAlignment.Left
            };
            ribbon.Items.Add(lblUsuario);
            ribbonStatusBar.ItemLinks.Add(lblUsuario);

            // Separador
            var separador1 = new BarStaticItem { Caption = "|", Alignment = BarItemLinkAlignment.Left };
            ribbon.Items.Add(separador1);
            ribbonStatusBar.ItemLinks.Add(separador1);

            // === SECCIÓN CENTRAL: Idioma ===
            lblIdioma = new BarStaticItem
            {
                Caption = "🌐 Idioma:",
                Id = ribbon.Items.Count + 1,
                Alignment = BarItemLinkAlignment.Left
            };
            ribbon.Items.Add(lblIdioma);
            ribbonStatusBar.ItemLinks.Add(lblIdioma);

            // Botón Español
            btnEspanol = new BarButtonItem
            {
                Caption = "ES",
                Id = ribbon.Items.Count + 1,
                Hint = "Español (México)",
                Tag = "es-MX",
                Alignment = BarItemLinkAlignment.Left
            };
            btnEspanol.ItemClick += BtnIdioma_ItemClick;
            ribbon.Items.Add(btnEspanol);
            ribbonStatusBar.ItemLinks.Add(btnEspanol);

            // Botón Inglés
            btnIngles = new BarButtonItem
            {
                Caption = "EN",
                Id = ribbon.Items.Count + 1,
                Hint = "English (US)",
                Tag = "en-US",
                Alignment = BarItemLinkAlignment.Left
            };
            btnIngles.ItemClick += BtnIdioma_ItemClick;
            ribbon.Items.Add(btnIngles);
            ribbonStatusBar.ItemLinks.Add(btnIngles);

            // Actualizar apariencia de botones de idioma
            ActualizarBotonesIdioma();

            // === SECCIÓN DERECHA: Cerrar Sesión y Salir ===
            // Separador
            var separador2 = new BarStaticItem { Caption = "", Alignment = BarItemLinkAlignment.Right };
            ribbon.Items.Add(separador2);
            ribbonStatusBar.ItemLinks.Add(separador2);

            // Botón Cerrar Sesión
            btnCerrarSesion = new BarButtonItem
            {
                Caption = "🔄 Cerrar Sesión",
                Id = ribbon.Items.Count + 1,
                Hint = "Cerrar sesión y volver al login",
                Alignment = BarItemLinkAlignment.Right
            };
            btnCerrarSesion.ItemClick += BtnCerrarSesion_ItemClick;
            ribbon.Items.Add(btnCerrarSesion);
            ribbonStatusBar.ItemLinks.Add(btnCerrarSesion);

            // Botón Salir
            btnSalir = new BarButtonItem
            {
                Caption = "❌ Salir",
                Id = ribbon.Items.Count + 1,
                Hint = "Salir del sistema",
                Alignment = BarItemLinkAlignment.Right
            };
            btnSalir.ItemClick += BtnSalir_ItemClick;
            ribbon.Items.Add(btnSalir);
            ribbonStatusBar.ItemLinks.Add(btnSalir);
        }

        private void ConfigurarTextos()
        {
            this.Text = $"KogalPOS - {this.Sesion.UsuarioLogin?.UserName}";

            // Traducir captions de las páginas del ribbon
            rbpAdmin.Text = "Administración".Translate();
            rbpCompras.Text = "Compras".Translate();
            rbpInventario.Text = "Inventario".Translate();
            rbpVentas.Text = "Ventas".Translate();

            // Actualizar textos de la barra de estado
            if (lblIdioma != null) lblIdioma.Caption = "🌐 " + "Idioma".Translate() + ":";
            if (btnCerrarSesion != null) 
            {
                btnCerrarSesion.Caption = "🔄 " + "Cerrar Sesión".Translate();
                btnCerrarSesion.Hint = "Cerrar sesión y volver al login".Translate();
            }
            if (btnSalir != null) 
            {
                btnSalir.Caption = "❌ " + "Salir".Translate();
                btnSalir.Hint = "Salir del sistema".Translate();
            }

            // Actualizar captions de los items del menú
            ActualizarCaptionsMenu();
        }

        private void ActualizarCaptionsMenu()
        {
            if (_menuItems == null) return;

            foreach (var item in _menuItems)
            {
                if (item.Button != null)
                    item.Button.Caption = item.CaptionKey.Translate();
            }
        }

        private void ActualizarBotonesIdioma()
        {
            string idiomaActual = LanguageService.IdiomaActual;

            if (idiomaActual == "es-MX" || idiomaActual.StartsWith("es"))
            {
                btnEspanol.Caption = "🇲🇽 ES";
                btnIngles.Caption = "EN";
            }
            else
            {
                btnEspanol.Caption = "ES";
                btnIngles.Caption = "🇺🇸 EN";
            }
        }
        #endregion

        #region "EVENTOS BARRA DE ESTADO"
        private void BtnIdioma_ItemClick(object sender, ItemClickEventArgs e)
        {
            string codigoIdioma = e.Item.Tag?.ToString();
            
            if (!string.IsNullOrEmpty(codigoIdioma) && codigoIdioma != LanguageService.IdiomaActual)
            {
                // Cambiar idioma
                LanguageService.CambiarIdioma(codigoIdioma);
                
                // Actualizar apariencia de botones
                ActualizarBotonesIdioma();
                
                // Notificar a todos los formularios
                FormSubject.Current.Notify(E_FormsServicesValues.Idioma);
                
                // Actualizar textos de este formulario
                ConfigurarTextos();

                XtraMessageBox.Show(
                    codigoIdioma == "es-MX" ? "Idioma cambiado a Español" : "Language changed to English",
                    codigoIdioma == "es-MX" ? "Idioma" : "Language",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void BtnCerrarSesion_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show(
                "¿Está seguro que desea cerrar sesión?".Translate(),
                "Cerrar Sesión".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Program.CerrarSesion = true;
                this.Sesion.UsuarioLogin = null;
                this.Close();
            }
        }

        private void BtnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show(
                "¿Está seguro que desea salir del sistema?".Translate(),
                "Salir".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Program.CerrarSesion = false;
                Application.Exit();
            }
        }
        #endregion

        #region "OBSERVER"
        public void Update<T>(T value, object data = null)
        {
            // Si cambia el idioma, actualizar textos de este formulario
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
