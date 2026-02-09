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
        // Items de la barra de estado
        private BarStaticItem lblUsuario;
        private BarStaticItem lblIdioma;
        private BarButtonItem btnEspanol;
        private BarButtonItem btnIngles;
        private BarButtonItem btnCerrarSesion;
        private BarButtonItem btnSalir;
        #endregion

        #region "CONSTRUCTOR"
        public frmPrincipal()
        {
            InitializeComponent();

            FormSubject.Current.Attach(this);

            ControlesInicializar();
            ConfigurarBarraEstado();
            ConfigurarTextos();
        }
        #endregion

        #region "INICIALIZACIÓN"
        private void ControlesInicializar()
        {
            if (GlobalCliente.UsuarioLogin.CheckPatente(E_Patentes.Admin))
            {
                AgregarItem(E_MenuItems.Patentes, this.rbpAdmin);
                AgregarItem(E_MenuItems.Familias, this.rbpAdmin);
                AgregarItem(E_MenuItems.Usuarios, this.rbpAdmin);
                AgregarItem(E_MenuItems.BackupRestore, this.rbpAdmin);
            }
        }

        private void ConfigurarBarraEstado()
        {
            // Limpiar items existentes
            ribbonStatusBar.ItemLinks.Clear();

            // === SECCIÓN IZQUIERDA: Usuario actual ===
            lblUsuario = new BarStaticItem
            {
                Caption = $"👤 {GlobalCliente.UsuarioLogin?.UserName ?? "Usuario"}",
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
            this.Text = $"KogalPOS - {GlobalCliente.UsuarioLogin?.UserName}";
            rbpAdmin.Text = "Administración".Translate();

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
            foreach (RibbonPageGroup group in rbpAdmin.Groups)
            {
                foreach (BarItemLink link in group.ItemLinks)
                {
                    if (link.Item is BarButtonItem btn)
                    {
                        // Obtener el nombre del item del menú desde el Name del botón
                        if (btn.Name == "barButtonItem_Patentes")
                            btn.Caption = "Patentes".Translate();
                        else if (btn.Name == "barButtonItem_Familias")
                            btn.Caption = "Familias".Translate();
                        else if (btn.Name == "barButtonItem_Usuarios")
                            btn.Caption = "Usuarios".Translate();
                        else if (btn.Name == "barButtonItem_BackupRestore")
                            btn.Caption = "Copias de Seguridad".Translate();
                    }
                }
            }
        }

        private void ActualizarBotonesIdioma()
        {
            string idiomaActual = LanguageService.IdiomaActual;

            // Estilo para botón activo vs inactivo
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

        #region "MENÚ ITEMS"
        enum E_MenuItems
        {
            Patentes,
            Familias,
            Usuarios,
            BackupRestore
        }

        private void BarButtonItem_ItemClick(E_MenuItems item)
        {
            FormulariosManager.frmPrincipal = this;

            switch (item)
            {
                case E_MenuItems.Patentes:
                    FormulariosManager.Patentes();
                    break;

                case E_MenuItems.Familias:
                    FormulariosManager.Familias();
                    break;

                case E_MenuItems.Usuarios:
                    FormulariosManager.Usuarios();
                    break;

                case E_MenuItems.BackupRestore:
                    FormulariosManager.CopiasSeguridad();
                    break;
            }
        }

        private void AgregarItem(E_MenuItems item, RibbonPage padre)
        {
            BarButtonItem barButtonItem = new BarButtonItem();

            barButtonItem.Caption = item.ToString();
            barButtonItem.Id = ribbon.Items.Count + 1;
            barButtonItem.Name = $"barButtonItem_{item}";

            barButtonItem.ItemClick += (s, e) => BarButtonItem_ItemClick(item);

            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup();

            ribbonPageGroup.ItemLinks.Add(barButtonItem);
            ribbonPageGroup.Name = $"ribbonPageGroup{item}";

            padre.Groups.Add(ribbonPageGroup);
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
                GlobalCliente.UsuarioLogin = null;
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
