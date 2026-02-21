using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.BLL.Base;
using Services.Domain.Enums;
using Services.BLL.Services;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Administrador.Usuarios
{
    public partial class frmUsuariosABM : XtraForm, IObserver
    {
        #region "PROPIEDADES"
        private Guid Id { get; set; }
        private Usuario UsuarioActual { get; set; }
        private List<Familia> TodasFamilias { get; set; }
        private List<Patente> TodasPatentes { get; set; }

        private List<Familia> FamiliasGrilla
        {
            get => (List<Familia>)gcFamilias.DataSource;
            set => gcFamilias.DataSource = value;
        }

        private List<Patente> PatentesGrilla
        {
            get => (List<Patente>)gcPatentes.DataSource;
            set => gcPatentes.DataSource = value;
        }

        private E_TipoPantalla _tipoPantalla;
        private E_TipoPantalla TipoPantalla
        {
            get => _tipoPantalla;
            set
            {
                _tipoPantalla = value;
                ControlesHabilitar(value);
            }
        }
        #endregion

        #region "CONSTRUCTOR"
        public frmUsuariosABM(Guid id)
        {
            Id = id;

            InitializeComponent();

            FormSubject.Current.Attach(this);

            ControlesInicializar();
        }
        #endregion

        #region "PROCEDIMIENTOS"
        private void ControlesInicializar()
        {
            ConfigurarTextos();
            ConfigurarGrillas();
            ConfigurarEventos();
            CargarPantalla();
        }

        private void ConfigurarTextos()
        {
            if (Id != Guid.Empty)
            {
                this.Text = "Detalle Usuario".Translate();
            }
            else
            {
                this.Text = "Nuevo Usuario".Translate();
            }

            btnModificar.Text = "Modificar".Translate();
            btnEliminar.Text = "Eliminar".Translate();
            btnRestaurar.Text = "Restaurar".Translate();
            btnAceptar.Text = "Aceptar".Translate();
            btnCancelar.Text = "Cancelar".Translate();
            lblFamilias.Text = "Familias".Translate();
            lblPatentes.Text = "Patentes".Translate();
            lcUserName.Text = "Usuario".Translate();
            lcPassword.Text = "Contraseña".Translate();

            // Actualizar captions de las columnas de grillas
            ActualizarCaptionsColumnas();
        }

        private void ActualizarCaptionsColumnas()
        {
            // Columnas de gvFamilias
            if (gvFamilias.Columns.Count > 0)
            {
                var colDescripcion = gvFamilias.Columns[nameof(Familia.Descripcion)];
                var colSeleccionado = gvFamilias.Columns[nameof(Familia.Temp_Seleccionado)];

                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
                if (colSeleccionado != null) colSeleccionado.Caption = "SELECCIONADO".Translate();
            }

            // Columnas de gvPatentes
            if (gvPatentes.Columns.Count > 0)
            {
                var colDescripcion = gvPatentes.Columns[nameof(Patente.Descripcion)];
                var colSeleccionado = gvPatentes.Columns[nameof(Patente.Temp_Seleccionado)];

                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
                if (colSeleccionado != null) colSeleccionado.Caption = "SELECCIONADO".Translate();
            }
        }

        private void ConfigurarGrillas()
        {
            gvFamilias.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            // Configurar columnas de Familias
            var columnsFamilias = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Temp_Seleccionado),
                    Caption = "SELECCIONADO".Translate(),
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean,
                    ColumnEdit = new RepositoryItemCheckEdit()
                }
            };
            gvFamilias.Columns.AddRange(columnsFamilias.ToArray());

            // Configurar columnas de Patentes
            var columnsPatentes = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Temp_Seleccionado),
                    Caption = "SELECCIONADO".Translate(),
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean,
                    ColumnEdit = new RepositoryItemCheckEdit()
                }
            };
            gvPatentes.Columns.AddRange(columnsPatentes.ToArray());

            // Aplicar estilos visuales
            GridStyleHelper.AplicarEstilo(gvFamilias);
            GridStyleHelper.AplicarEstilo(gvPatentes);

            // Configurar fuentes de etiquetas de sección
            lblFamilias.Font = FontHelper.FuenteSubtituloSemibold;
            lblPatentes.Font = FontHelper.FuenteSubtituloSemibold;

            // Aplicar estilos a los botones del ABM
            ButtonStyleHelper.ConfigurarBotonesABM(
                btnModificar: btnModificar,
                btnEliminar: btnEliminar,
                btnRestaurar: btnRestaurar,
                btnAceptar: btnAceptar,
                btnCancelar: btnCancelar
            );
        }

        private void ConfigurarEventos()
        {
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnRestaurar.Click += btnRestaurar_Click;
            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
            gvFamilias.CellValueChanged += gvFamilias_CellValueChanged;
        }

        private void CargarPantalla()
        {
            var res = UsuarioBLL.Current.Obtener(new ReqUsuarioObtener { Id = Id });

            TodasFamilias = res.ListaFamilias ?? new List<Familia>();
            TodasPatentes = res.ListaPatentes ?? new List<Patente>();
            UsuarioActual = res.Usuario;

            if (UsuarioActual != null)
            {
                // Modo visualización/edición de usuario existente
                txtUserName.Text = UsuarioActual.UserName;
                txtPassword.Text = ""; // No mostramos la contraseña por seguridad

                // Determinar tipo de pantalla según estado
                TipoPantalla = UsuarioActual.Estado == E_Estados.Activo
                    ? E_TipoPantalla.Visualizar
                    : E_TipoPantalla.VisualizarEliminado;

                CargarGrillasConUsuarioExistente();
            }
            else
            {
                // Modo nuevo
                TipoPantalla = E_TipoPantalla.Nuevo;
                CargarGrillasParaNuevo();
            }

            RefrescarGrillas();
        }

        private void CargarGrillasConUsuarioExistente()
        {
            // Cargar lista de familias disponibles
            FamiliasGrilla = new List<Familia>(TodasFamilias);

            // Obtener familias directas del usuario
            var familiasDirectas = UsuarioActual.Accesos
                .OfType<Familia>()
                .ToList();

            // Marcar las familias que ya están asignadas
            FamiliasGrilla.ForEach(f => f.Temp_Seleccionado = familiasDirectas.Any(fd => fd.Id == f.Id));

            // Cargar patentes
            PatentesGrilla = new List<Patente>(TodasPatentes);

            // Obtener patentes directas del usuario (no heredadas de familias)
            var patentesDirectas = UsuarioActual.Accesos
                .OfType<Patente>()
                .ToList();

            // Marcar las patentes que ya están asignadas directamente
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = patentesDirectas.Any(pd => pd.Id == p.Id));

            ActualizarPatentesSegunFamiliasSeleccionadas();
        }

        private void CargarGrillasParaNuevo()
        {
            // Para nuevo, mostrar todas las familias y patentes disponibles
            FamiliasGrilla = new List<Familia>(TodasFamilias);
            FamiliasGrilla.ForEach(f => f.Temp_Seleccionado = false);

            PatentesGrilla = new List<Patente>(TodasPatentes);
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = false);
        }

        private void ActualizarPatentesSegunFamiliasSeleccionadas()
        {
            if (PatentesGrilla == null) return;

            // Obtener todas las patentes que vienen de familias seleccionadas
            var familiasSeleccionadas = FamiliasGrilla?.Where(f => f.Temp_Seleccionado).ToList() ?? new List<Familia>();
            var patentesHeredadas = new HashSet<Guid>();

            foreach (var familia in familiasSeleccionadas)
            {
                foreach (var patente in familia.GetPatentes())
                {
                    patentesHeredadas.Add(patente.Id);
                }
            }

            // Las patentes heredadas se muestran pero el usuario puede elegir si quiere
            // asignarlas también directamente (para cuando se desasignen las familias)
        }

        private void RefrescarGrillas()
        {
            gcFamilias.RefreshDataSource();
            gcPatentes.RefreshDataSource();
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Usuario.Equals(value))
            {
                CargarPantalla();
            }
            else if (E_FormsServicesValues.Idioma.Equals(value))
            {
                ConfigurarTextos();
            }
        }
        #endregion

        #region "EVENTOS"
        private void btnModificar_Click(object sender, EventArgs e)
        {
            TipoPantalla = E_TipoPantalla.Modificar;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "¿Está seguro que desea eliminar este usuario?".Translate(),
                "Confirmar eliminación".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var res = UsuarioBLL.Current.Eliminar(new ReqUsuarioEliminar { Id = Id });

            if (res.Success)
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FormSubject.Current.Notify(E_FormsServicesValues.Usuario);
                TipoPantalla = E_TipoPantalla.VisualizarEliminado;
            }
            else
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Error".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "¿Está seguro que desea restaurar este usuario?".Translate(),
                "Confirmar restauración".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var res = UsuarioBLL.Current.Restaurar(new ReqUsuarioRestaurar { Id = Id });

            if (res.Success)
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FormSubject.Current.Notify(E_FormsServicesValues.Usuario);
                TipoPantalla = E_TipoPantalla.Visualizar;
            }
            else
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Error".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar nombre de usuario
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                XtraMessageBox.Show(
                    "El nombre de usuario es requerido".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            // Validar contraseña para nuevo usuario
            if (TipoPantalla == E_TipoPantalla.Nuevo && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show(
                    "La contraseña es requerida para nuevos usuarios".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Obtener IDs seleccionados
            var familiasIds = FamiliasGrilla?
                .Where(f => f.Temp_Seleccionado)
                .Select(f => f.Id)
                .ToList() ?? new List<Guid>();

            var patentesIds = PatentesGrilla?
                .Where(p => p.Temp_Seleccionado)
                .Select(p => p.Id)
                .ToList() ?? new List<Guid>();

            ResBase res;

            if (TipoPantalla == E_TipoPantalla.Nuevo)
            {
                // Insertar nuevo usuario
                var usuario = new Usuario
                {
                    UserName = txtUserName.Text.Trim(),
                    Password = txtPassword.Text,
                    Estado = E_Estados.Activo
                };

                res = UsuarioBLL.Current.Insertar(new ReqUsuarioInsertar
                {
                    Usuario = usuario,
                    FamiliasIds = familiasIds,
                    PatentesIds = patentesIds
                });
            }
            else
            {
                // Modificar usuario existente
                UsuarioActual.UserName = txtUserName.Text.Trim();
                
                // Si se ingresó nueva contraseña, asignarla; si no, enviar null para mantener la actual
                UsuarioActual.Password = !string.IsNullOrWhiteSpace(txtPassword.Text) 
                    ? txtPassword.Text 
                    : null;

                res = UsuarioBLL.Current.Modificar(new ReqUsuarioModificar
                {
                    Usuario = UsuarioActual,
                    FamiliasIds = familiasIds,
                    PatentesIds = patentesIds
                });
            }

            if (res.Success)
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FormSubject.Current.Notify(E_FormsServicesValues.Usuario);

                if (TipoPantalla == E_TipoPantalla.Nuevo)
                {
                    this.Close();
                }
                else
                {
                    CargarPantalla();
                }
            }
            else
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Error".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (TipoPantalla == E_TipoPantalla.Nuevo)
            {
                this.Close();
            }
            else
            {
                CargarPantalla();
            }
        }

        private void gvFamilias_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == nameof(Familia.Temp_Seleccionado))
            {
                ActualizarPatentesSegunFamiliasSeleccionadas();
                gcPatentes.RefreshDataSource();
            }
        }
        #endregion

        #region "FUNCIONES INTERNAS"
        private void ControlesHabilitar(E_TipoPantalla tipoPantalla)
        {
            bool esEditable = tipoPantalla == E_TipoPantalla.Modificar || tipoPantalla == E_TipoPantalla.Nuevo;

            switch (tipoPantalla)
            {
                case E_TipoPantalla.Visualizar:
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRestaurar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;

                case E_TipoPantalla.VisualizarEliminado:
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnRestaurar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;

                case E_TipoPantalla.Modificar:
                case E_TipoPantalla.Nuevo:
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnRestaurar.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
            }

            // Usar ReadOnly en lugar de Enabled para mantener legibilidad
            txtUserName.Properties.ReadOnly = !esEditable;
            txtPassword.Properties.ReadOnly = !esEditable;
            gvFamilias.OptionsBehavior.Editable = esEditable;
            gvPatentes.OptionsBehavior.Editable = esEditable;

            // Cambiar apariencia visual para indicar modo solo lectura
            AplicarEstiloSegunModo(esEditable);
        }

        private void AplicarEstiloSegunModo(bool esEditable)
        {
            // === COLORES PARA MODO VISUALIZACIÓN (solo lectura) ===
            var colorFondoVisualizacion = Color.FromArgb(240, 240, 240);
            var colorTextoVisualizacion = Color.FromArgb(60, 60, 60);
            var colorBordeVisualizacion = Color.FromArgb(200, 200, 200);

            // === COLORES PARA MODO EDICIÓN ===
            var colorFondoEdicion = Color.White;
            var colorTextoEdicion = Color.Black;
            var colorBordeEdicion = Color.FromArgb(100, 149, 237);

            // === COLORES PARA LABELS/TÍTULOS ===
            var colorTituloVisualizacion = Color.FromArgb(80, 80, 80);
            var colorTituloEdicion = Color.FromArgb(52, 73, 94);

            if (!esEditable)
            {
                // *** MODO VISUALIZACIÓN ***
                
                // TextBoxes - aspecto de "información mostrada"
                txtUserName.Properties.Appearance.BackColor = colorFondoVisualizacion;
                txtUserName.Properties.Appearance.ForeColor = colorTextoVisualizacion;
                txtUserName.Properties.Appearance.BorderColor = colorBordeVisualizacion;
                txtUserName.Properties.Appearance.Options.UseBackColor = true;
                txtUserName.Properties.Appearance.Options.UseForeColor = true;
                txtUserName.Properties.Appearance.Options.UseBorderColor = true;

                txtPassword.Properties.Appearance.BackColor = colorFondoVisualizacion;
                txtPassword.Properties.Appearance.ForeColor = colorTextoVisualizacion;
                txtPassword.Properties.Appearance.BorderColor = colorBordeVisualizacion;
                txtPassword.Properties.Appearance.Options.UseBackColor = true;
                txtPassword.Properties.Appearance.Options.UseForeColor = true;
                txtPassword.Properties.Appearance.Options.UseBorderColor = true;

                // Labels - color más suave
                lblFamilias.ForeColor = colorTituloVisualizacion;
                lblPatentes.ForeColor = colorTituloVisualizacion;
                lblFamilias.Font = FontHelper.FuenteSubtitulo;
                lblPatentes.Font = FontHelper.FuenteSubtitulo;

                // Grillas - estilo de consulta
                AplicarEstiloGrillaVisualizacion(gvFamilias);
                AplicarEstiloGrillaVisualizacion(gvPatentes);
            }
            else
            {
                // *** MODO EDICIÓN ***
                
                // TextBoxes - aspecto de campo editable activo
                txtUserName.Properties.Appearance.BackColor = colorFondoEdicion;
                txtUserName.Properties.Appearance.ForeColor = colorTextoEdicion;
                txtUserName.Properties.Appearance.BorderColor = colorBordeEdicion;
                txtUserName.Properties.Appearance.Options.UseBackColor = true;
                txtUserName.Properties.Appearance.Options.UseForeColor = true;
                txtUserName.Properties.Appearance.Options.UseBorderColor = true;

                txtPassword.Properties.Appearance.BackColor = colorFondoEdicion;
                txtPassword.Properties.Appearance.ForeColor = colorTextoEdicion;
                txtPassword.Properties.Appearance.BorderColor = colorBordeEdicion;
                txtPassword.Properties.Appearance.Options.UseBackColor = true;
                txtPassword.Properties.Appearance.Options.UseForeColor = true;
                txtPassword.Properties.Appearance.Options.UseBorderColor = true;

                // Labels - color más destacado
                lblFamilias.ForeColor = colorTituloEdicion;
                lblPatentes.ForeColor = colorTituloEdicion;
                lblFamilias.Font = FontHelper.FuenteSubtituloSemibold;
                lblPatentes.Font = FontHelper.FuenteSubtituloSemibold;

                // Grillas - estilo de edición activa
                AplicarEstiloGrillaEdicion(gvFamilias);
                AplicarEstiloGrillaEdicion(gvPatentes);
            }
        }

        private void AplicarEstiloGrillaVisualizacion(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(222, 226, 230);
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(73, 80, 87);
            gridView.Appearance.HeaderPanel.Font = FontHelper.FuenteEncabezadoGrilla;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;

            gridView.Appearance.Row.BackColor = Color.FromArgb(245, 245, 245);
            gridView.Appearance.Row.ForeColor = Color.FromArgb(60, 60, 60);
            gridView.Appearance.Row.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;

            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.OddRow.BackColor = Color.FromArgb(248, 248, 248);
            gridView.Appearance.EvenRow.ForeColor = Color.FromArgb(60, 60, 60);
            gridView.Appearance.OddRow.ForeColor = Color.FromArgb(60, 60, 60);
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.OddRow.Options.UseForeColor = true;

            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(220, 220, 220);
            gridView.Appearance.FocusedRow.ForeColor = Color.FromArgb(40, 40, 40);
            gridView.Appearance.FocusedRow.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;
        }

        private void AplicarEstiloGrillaEdicion(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(209, 231, 251);
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 60, 114);
            gridView.Appearance.HeaderPanel.Font = FontHelper.FuenteEncabezadoGrilla;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;

            gridView.Appearance.Row.BackColor = Color.White;
            gridView.Appearance.Row.ForeColor = Color.Black;
            gridView.Appearance.Row.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;

            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(248, 251, 255);
            gridView.Appearance.OddRow.BackColor = Color.White;
            gridView.Appearance.EvenRow.ForeColor = Color.Black;
            gridView.Appearance.OddRow.ForeColor = Color.Black;
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.OddRow.Options.UseForeColor = true;

            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(189, 215, 238);
            gridView.Appearance.FocusedRow.ForeColor = Color.FromArgb(31, 64, 104);
            gridView.Appearance.FocusedRow.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;
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
