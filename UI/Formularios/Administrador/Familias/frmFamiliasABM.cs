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

namespace UI.Formularios.Administrador.Familias
{
    public partial class frmFamiliasABM : XtraForm, IObserver
    {
        #region "PROPIEDADES"
        private Guid Id { get; set; }
        private Familia FamiliaActual { get; set; }
        private List<Familia> TodasFamilias { get; set; }
        private List<Patente> TodasPatentes { get; set; }

        private List<Familia> FamiliasHijosGrilla
        {
            get => (List<Familia>)gcFamiliasHijos.DataSource;
            set => gcFamiliasHijos.DataSource = value;
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
        public frmFamiliasABM(Guid id)
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
                this.Text = "Detalle Familia".Translate();
            }
            else
            {
                this.Text = "Nueva Familia".Translate();
            }

            btnModificar.Text = "Modificar".Translate();
            btnEliminar.Text = "Eliminar".Translate();
            btnRestaurar.Text = "Restaurar".Translate();
            btnAceptar.Text = "Aceptar".Translate();
            btnCancelar.Text = "Cancelar".Translate();
            lblFamiliasHijos.Text = "Familias Hijos".Translate();
            lblPatentes.Text = "Patentes".Translate();

            // Actualizar captions de las columnas de grillas
            ActualizarCaptionsColumnas();
        }

        private void ActualizarCaptionsColumnas()
        {
            // Columnas de gvFamiliasHijos
            if (gvFamiliasHijos.Columns.Count > 0)
            {
                var colDescripcion = gvFamiliasHijos.Columns[nameof(Familia.Descripcion)];
                var colSeleccionado = gvFamiliasHijos.Columns[nameof(Familia.Temp_Seleccionado)];

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
            gvFamiliasHijos.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            // Configurar columnas de Familias Hijos
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
            gvFamiliasHijos.Columns.AddRange(columnsFamilias.ToArray());

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
            GridStyleHelper.AplicarEstilo(gvFamiliasHijos);
            GridStyleHelper.AplicarEstilo(gvPatentes);

            // Configurar fuentes de etiquetas de sección
            lblFamiliasHijos.Font = FontHelper.FuenteSubtituloSemibold;
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
            gvFamiliasHijos.CellValueChanged += gvFamiliasHijos_CellValueChanged;
        }

        private void CargarPantalla()
        {
            var res = FamiliasBLL.Current.Obtener(new ReqFamiliaObtener { Id = Id });

            TodasFamilias = res.ListaFamilias ?? new List<Familia>();
            TodasPatentes = res.ListaPatentes ?? new List<Patente>();
            FamiliaActual = res.Familia;

            if (FamiliaActual != null)
            {
                // Modo visualización/edición de familia existente
                txtDescripcion.Text = FamiliaActual.Descripcion;

                // Determinar tipo de pantalla según estado
                TipoPantalla = FamiliaActual.Estado == E_Estados.Activo
                    ? E_TipoPantalla.Visualizar
                    : E_TipoPantalla.VisualizarEliminado;

                CargarGrillasConFamiliaExistente();
            }
            else
            {
                // Modo nuevo
                TipoPantalla = E_TipoPantalla.Nuevo;
                CargarGrillasParaNuevo();
            }

            RefrescarGrillas();
        }

        private void CargarGrillasConFamiliaExistente()
        {
            // Cargar lista de familias disponibles (excluyendo la actual y evitando ciclos)
            FamiliasHijosGrilla = new List<Familia>(TodasFamilias);

            // Obtener familias hijas directas de la familia actual
            var familiasHijasDirectas = FamiliaActual.GetFamilias(true);

            // Marcar las familias que ya son hijas
            FamiliasHijosGrilla.ForEach(f => f.Temp_Seleccionado = familiasHijasDirectas.Any(fh => fh.Id == f.Id));

            // Filtrar familias que crearían ciclos (familias que contienen a la actual)
            FamiliasHijosGrilla = FamiliasHijosGrilla
                .Where(f => !CreariaCicloRecursivo(f, FamiliaActual.Id))
                .ToList();

            // Cargar patentes
            PatentesGrilla = new List<Patente>(TodasPatentes);

            // Obtener patentes directas de la familia actual
            var patentesDirectas = FamiliaActual.GetPatentes(true);

            // Marcar las patentes que ya están asignadas directamente
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = patentesDirectas.Any(pd => pd.Id == p.Id));

            ActualizarPatentesSegunFamiliasSeleccionadas();
        }

        private void CargarGrillasParaNuevo()
        {
            // Para nuevo, mostrar todas las familias y patentes disponibles
            FamiliasHijosGrilla = new List<Familia>(TodasFamilias);
            FamiliasHijosGrilla.ForEach(f => f.Temp_Seleccionado = false);

            PatentesGrilla = new List<Patente>(TodasPatentes);
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = false);
        }

        /// <summary>
        /// Verifica si agregar una familia como hija crearía un ciclo recursivo.
        /// Una familia no puede ser hija si ella contiene a la familia actual en su árbol.
        /// </summary>
        private bool CreariaCicloRecursivo(Familia familiaCandidata, Guid familiaActualId)
        {
            return ContieneEnArbol(familiaCandidata, familiaActualId, new HashSet<Guid>());
        }

        private bool ContieneEnArbol(Familia familia, Guid idBuscado, HashSet<Guid> visitados)
        {
            if (visitados.Contains(familia.Id))
                return false;

            visitados.Add(familia.Id);

            foreach (var acceso in familia.Accesos)
            {
                if (acceso.Id == idBuscado)
                    return true;

                if (acceso is Familia familiaHija && ContieneEnArbol(familiaHija, idBuscado, visitados))
                    return true;
            }

            return false;
        }

        private void ActualizarPatentesSegunFamiliasSeleccionadas()
        {
            if (PatentesGrilla == null) return;

            // Obtener todas las patentes que vienen de familias hijas seleccionadas
            var familiasSeleccionadas = FamiliasHijosGrilla?.Where(f => f.Temp_Seleccionado).ToList() ?? new List<Familia>();
            var patentesHeredadas = new HashSet<Guid>();

            foreach (var familia in familiasSeleccionadas)
            {
                foreach (var patente in familia.GetPatentes())
                {
                    patentesHeredadas.Add(patente.Id);
                }
            }

            // Marcar patentes heredadas como no editables (las mostraremos pero no se pueden deseleccionar)
            foreach (var patente in PatentesGrilla)
            {
                // Si la patente viene de una familia hija, la marcamos como seleccionada automáticamente
                // Esto se maneja visualmente pero no se guarda como relación directa
            }
        }

        private void RefrescarGrillas()
        {
            gcFamiliasHijos.RefreshDataSource();
            gcPatentes.RefreshDataSource();
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Familia.Equals(value))
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
                "¿Está seguro que desea eliminar esta familia?".Translate(),
                "Confirmar eliminación".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var res = FamiliasBLL.Current.Eliminar(new ReqFamiliaEliminar { Id = Id });

            if (res.Success)
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FormSubject.Current.Notify(E_FormsServicesValues.Familia);
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
                "¿Está seguro que desea restaurar esta familia?".Translate(),
                "Confirmar restauración".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var res = FamiliasBLL.Current.Restaurar(new ReqFamiliaRestaurar { Id = Id });

            if (res.Success)
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FormSubject.Current.Notify(E_FormsServicesValues.Familia);
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
            // Validar descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                XtraMessageBox.Show(
                    "La descripción es requerida".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            // Obtener IDs seleccionados
            var familiasHijosIds = FamiliasHijosGrilla?
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
                // Insertar nueva familia
                var familia = new Familia
                {
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = E_Estados.Activo
                };

                res = FamiliasBLL.Current.Insertar(new ReqFamiliaInsertar
                {
                    Familia = familia,
                    FamiliasHijosIds = familiasHijosIds,
                    PatentesIds = patentesIds
                });
            }
            else
            {
                // Modificar familia existente
                FamiliaActual.Descripcion = txtDescripcion.Text.Trim();

                res = FamiliasBLL.Current.Modificar(new ReqFamiliaModificar
                {
                    Familia = FamiliaActual,
                    FamiliasHijosIds = familiasHijosIds,
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

                FormSubject.Current.Notify(E_FormsServicesValues.Familia);

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

        private void gvFamiliasHijos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
            txtDescripcion.Properties.ReadOnly = !esEditable;
            gvFamiliasHijos.OptionsBehavior.Editable = esEditable;
            gvPatentes.OptionsBehavior.Editable = esEditable;

            // Cambiar apariencia visual para indicar modo solo lectura
            AplicarEstiloSegunModo(esEditable);
        }

        private void AplicarEstiloSegunModo(bool esEditable)
        {
            // === COLORES PARA MODO VISUALIZACIÓN (solo lectura) ===
            // Fondo gris claro que indica "información, no editable"
            var colorFondoVisualizacion = Color.FromArgb(240, 240, 240);
            var colorTextoVisualizacion = Color.FromArgb(60, 60, 60);
            var colorBordeVisualizacion = Color.FromArgb(200, 200, 200);

            // === COLORES PARA MODO EDICIÓN ===
            var colorFondoEdicion = Color.White;
            var colorTextoEdicion = Color.Black;
            var colorBordeEdicion = Color.FromArgb(100, 149, 237); // Azul que indica "activo"

            // === COLORES PARA LABELS/TÍTULOS ===
            var colorTituloVisualizacion = Color.FromArgb(80, 80, 80);
            var colorTituloEdicion = Color.FromArgb(52, 73, 94); // Azul oscuro

            if (!esEditable)
            {
                // *** MODO VISUALIZACIÓN ***
                
                // TextBox - aspecto de "información mostrada"
                txtDescripcion.Properties.Appearance.BackColor = colorFondoVisualizacion;
                txtDescripcion.Properties.Appearance.ForeColor = colorTextoVisualizacion;
                txtDescripcion.Properties.Appearance.BorderColor = colorBordeVisualizacion;
                txtDescripcion.Properties.Appearance.Options.UseBackColor = true;
                txtDescripcion.Properties.Appearance.Options.UseForeColor = true;
                txtDescripcion.Properties.Appearance.Options.UseBorderColor = true;

                // Labels - color más suave, sin negrita
                lblFamiliasHijos.ForeColor = colorTituloVisualizacion;
                lblPatentes.ForeColor = colorTituloVisualizacion;
                lblFamiliasHijos.Font = FontHelper.FuenteSubtitulo;
                lblPatentes.Font = FontHelper.FuenteSubtitulo;

                // Grillas - estilo de consulta (sin resaltado de edición)
                AplicarEstiloGrillaVisualizacion(gvFamiliasHijos);
                AplicarEstiloGrillaVisualizacion(gvPatentes);
            }
            else
            {
                // *** MODO EDICIÓN ***
                
                // TextBox - aspecto de campo editable activo
                txtDescripcion.Properties.Appearance.BackColor = colorFondoEdicion;
                txtDescripcion.Properties.Appearance.ForeColor = colorTextoEdicion;
                txtDescripcion.Properties.Appearance.BorderColor = colorBordeEdicion;
                txtDescripcion.Properties.Appearance.Options.UseBackColor = true;
                txtDescripcion.Properties.Appearance.Options.UseForeColor = true;
                txtDescripcion.Properties.Appearance.Options.UseBorderColor = true;

                // Labels - color más destacado
                lblFamiliasHijos.ForeColor = colorTituloEdicion;
                lblPatentes.ForeColor = colorTituloEdicion;
                lblFamiliasHijos.Font = FontHelper.FuenteSubtituloSemibold;
                lblPatentes.Font = FontHelper.FuenteSubtituloSemibold;

                // Grillas - estilo de edición activa
                AplicarEstiloGrillaEdicion(gvFamiliasHijos);
                AplicarEstiloGrillaEdicion(gvPatentes);
            }
        }

        private void AplicarEstiloGrillaVisualizacion(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            // Header con fondo gris claro y texto oscuro (legible)
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(222, 226, 230); // Gris claro
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(73, 80, 87);    // Gris oscuro
            gridView.Appearance.HeaderPanel.Font = FontHelper.FuenteEncabezadoGrilla;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;

            // Filas con fondo gris claro (indica solo lectura)
            gridView.Appearance.Row.BackColor = Color.FromArgb(245, 245, 245);
            gridView.Appearance.Row.ForeColor = Color.FromArgb(60, 60, 60);
            gridView.Appearance.Row.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;

            // Filas alternadas sutiles
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

            // Fila seleccionada más sutil
            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(220, 220, 220);
            gridView.Appearance.FocusedRow.ForeColor = Color.FromArgb(40, 40, 40);
            gridView.Appearance.FocusedRow.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;
        }

        private void AplicarEstiloGrillaEdicion(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            // Header con fondo azul claro y texto azul oscuro (legible y activo)
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(209, 231, 251); // Azul claro
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 60, 114);   // Azul oscuro
            gridView.Appearance.HeaderPanel.Font = FontHelper.FuenteEncabezadoGrilla;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;

            // Filas con fondo blanco (indica editable)
            gridView.Appearance.Row.BackColor = Color.White;
            gridView.Appearance.Row.ForeColor = Color.Black;
            gridView.Appearance.Row.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;

            // Filas alternadas más visibles
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(248, 251, 255); // Toque azul muy sutil
            gridView.Appearance.OddRow.BackColor = Color.White;
            gridView.Appearance.EvenRow.ForeColor = Color.Black;
            gridView.Appearance.OddRow.ForeColor = Color.Black;
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.OddRow.Options.UseForeColor = true;

            // Fila seleccionada con color azul (indica selección activa)
            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(189, 215, 238); // Azul claro
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