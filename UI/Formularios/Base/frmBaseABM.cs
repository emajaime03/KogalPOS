using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Helpers;

namespace UI.Formularios.Base
{
    /// <summary>
    /// Formulario base para pantallas ABM (Alta/Baja/Modificación).
    /// Proporciona funcionalidad común: botones de acción, manejo de estados y estilos.
    /// Los formularios derivados deben agregar sus propios controles de datos.
    /// </summary>
    public partial class frmBaseABM : XtraForm, IObserver
    {
        #region "PROPIEDADES"

        /// <summary>
        /// Identificador del registro actual (Guid.Empty para nuevo)
        /// </summary>
        protected Guid Id { get; set; }

        /// <summary>
        /// Tipo de pantalla actual (Visualizar, Modificar, Nuevo, etc.)
        /// </summary>
        private E_TipoPantalla _tipoPantalla;
        protected E_TipoPantalla TipoPantalla
        {
            get => _tipoPantalla;
            set
            {
                _tipoPantalla = value;
                ActualizarEstadoBotones(value);
                OnTipoPantallaCambiado(value);
            }
        }

        /// <summary>
        /// Indica si la pantalla está en modo edición (Modificar o Nuevo)
        /// </summary>
        protected bool EsModoEdicion => TipoPantalla == E_TipoPantalla.Modificar || TipoPantalla == E_TipoPantalla.Nuevo;

        /// <summary>
        /// Indica si es un registro nuevo
        /// </summary>
        protected bool EsNuevo => Id == Guid.Empty;

        #endregion

        #region "CONSTRUCTOR"

        public frmBaseABM()
        {
            InitializeComponent();
            ConfigurarEventosBase();
            FormSubject.Current.Attach(this);
        }

        public frmBaseABM(Guid id) : this()
        {
            Id = id;
        }

        #endregion

        #region "MÉTODOS VIRTUALES - PARA SOBRESCRIBIR"

        /// <summary>
        /// Configura los textos de la pantalla (títulos, labels, etc.)
        /// Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void ConfigurarTextos()
        {
            // Textos base de los botones
            btnModificar.Text = "Modificar".Translate();
            btnEliminar.Text = "Eliminar".Translate();
            btnRestaurar.Text = "Restaurar".Translate();
            btnAceptar.Text = "Aceptar".Translate();
            btnCancelar.Text = "Cancelar".Translate();
        }

        /// <summary>
        /// Configura las grillas y columnas del formulario.
        /// Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void ConfigurarGrillas()
        {
            // Implementar en clases derivadas
        }

        /// <summary>
        /// Carga los datos de la pantalla desde el servicio.
        /// Sobrescribir en clases derivadas.
        /// </summary>
        protected virtual void CargarDatos()
        {
            // Implementar en clases derivadas
        }

        /// <summary>
        /// Valida los datos antes de guardar.
        /// Sobrescribir en clases derivadas.
        /// </summary>
        /// <returns>True si la validación es exitosa</returns>
        protected virtual bool ValidarDatos()
        {
            return true;
        }

        /// <summary>
        /// Guarda los datos (insertar o modificar).
        /// Sobrescribir en clases derivadas.
        /// </summary>
        /// <returns>True si se guardó correctamente</returns>
        protected virtual bool GuardarDatos()
        {
            return true;
        }

        /// <summary>
        /// Elimina el registro actual (eliminación lógica).
        /// Sobrescribir en clases derivadas.
        /// </summary>
        /// <returns>True si se eliminó correctamente</returns>
        protected virtual bool EliminarRegistro()
        {
            return true;
        }

        /// <summary>
        /// Restaura el registro eliminado.
        /// Sobrescribir en clases derivadas.
        /// </summary>
        /// <returns>True si se restauró correctamente</returns>
        protected virtual bool RestaurarRegistro()
        {
            return true;
        }

        /// <summary>
        /// Se ejecuta cuando cambia el tipo de pantalla.
        /// Sobrescribir para aplicar estilos o lógica adicional.
        /// </summary>
        protected virtual void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            // Implementar en clases derivadas si se necesita
        }

        /// <summary>
        /// Obtiene el valor del enum E_FormsServicesValues que corresponde a esta entidad.
        /// Sobrescribir en clases derivadas para notificar cambios.
        /// </summary>
        protected virtual E_FormsServicesValues? GetFormServiceValue()
        {
            return null;
        }

        #endregion

        #region "MÉTODOS PROTEGIDOS - HELPERS"

        /// <summary>
        /// Inicializa el formulario. Llamar desde el constructor de la clase derivada.
        /// </summary>
        protected void InicializarFormulario()
        {
            ConfigurarEstiloBotones();
            ConfigurarTextos();
            ConfigurarGrillas();
            CargarDatos();
        }

        /// <summary>
        /// Aplica estilo de visualización a una grilla (solo lectura)
        /// </summary>
        protected void AplicarEstiloGrillaVisualizacion(GridView gridView)
        {
            // Header con fondo gris claro y texto oscuro (legible)
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(222, 226, 230);
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(73, 80, 87);
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

        /// <summary>
        /// Aplica estilo de edición a una grilla
        /// </summary>
        protected void AplicarEstiloGrillaEdicion(GridView gridView)
        {
            // Header con fondo azul claro y texto azul oscuro (legible y activo)
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(209, 231, 251);
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 60, 114);
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
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(248, 251, 255);
            gridView.Appearance.OddRow.BackColor = Color.White;
            gridView.Appearance.EvenRow.ForeColor = Color.Black;
            gridView.Appearance.OddRow.ForeColor = Color.Black;
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.OddRow.Options.UseForeColor = true;

            // Fila seleccionada con color azul (indica selección activa)
            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(189, 215, 238);
            gridView.Appearance.FocusedRow.ForeColor = Color.FromArgb(31, 64, 104);
            gridView.Appearance.FocusedRow.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;
        }

        /// <summary>
        /// Aplica estilo a un TextEdit según el modo (edición o visualización)
        /// </summary>
        protected void AplicarEstiloTextEdit(TextEdit textEdit, bool esEditable)
        {
            // Colores para modo visualización
            var colorFondoVisualizacion = Color.FromArgb(240, 240, 240);
            var colorTextoVisualizacion = Color.FromArgb(60, 60, 60);
            var colorBordeVisualizacion = Color.FromArgb(200, 200, 200);

            // Colores para modo edición
            var colorFondoEdicion = Color.White;
            var colorTextoEdicion = Color.Black;
            var colorBordeEdicion = Color.FromArgb(100, 149, 237);

            if (!esEditable)
            {
                textEdit.Properties.Appearance.BackColor = colorFondoVisualizacion;
                textEdit.Properties.Appearance.ForeColor = colorTextoVisualizacion;
                textEdit.Properties.Appearance.BorderColor = colorBordeVisualizacion;
            }
            else
            {
                textEdit.Properties.Appearance.BackColor = colorFondoEdicion;
                textEdit.Properties.Appearance.ForeColor = colorTextoEdicion;
                textEdit.Properties.Appearance.BorderColor = colorBordeEdicion;
            }

            textEdit.Properties.Appearance.Options.UseBackColor = true;
            textEdit.Properties.Appearance.Options.UseForeColor = true;
            textEdit.Properties.Appearance.Options.UseBorderColor = true;
            textEdit.Properties.ReadOnly = !esEditable;
        }

        /// <summary>
        /// Aplica estilo a un LabelControl según el modo
        /// </summary>
        protected void AplicarEstiloLabel(LabelControl label, bool esEditable)
        {
            var colorTituloVisualizacion = Color.FromArgb(80, 80, 80);
            var colorTituloEdicion = Color.FromArgb(52, 73, 94);

            if (!esEditable)
            {
                label.ForeColor = colorTituloVisualizacion;
                label.Font = FontHelper.FuenteSubtitulo;
            }
            else
            {
                label.ForeColor = colorTituloEdicion;
                label.Font = FontHelper.FuenteSubtituloSemibold;
            }
        }

        /// <summary>
        /// Notifica a los observadores que hubo un cambio
        /// </summary>
        protected void NotificarCambio()
        {
            var formServiceValue = GetFormServiceValue();
            if (formServiceValue.HasValue)
            {
                FormSubject.Current.Notify(formServiceValue.Value);
            }
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void ConfigurarEventosBase()
        {
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnRestaurar.Click += BtnRestaurar_Click;
            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void ConfigurarEstiloBotones()
        {
            ButtonStyleHelper.ConfigurarBotonesABM(
                btnModificar: btnModificar,
                btnEliminar: btnEliminar,
                btnRestaurar: btnRestaurar,
                btnAceptar: btnAceptar,
                btnCancelar: btnCancelar
            );
        }

        private void ActualizarEstadoBotones(E_TipoPantalla tipoPantalla)
        {
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
        }

        #endregion

        #region "EVENTOS DE BOTONES"

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            TipoPantalla = E_TipoPantalla.Modificar;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "¿Está seguro que desea eliminar este registro?".Translate(),
                "Confirmar eliminación".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            if (EliminarRegistro())
            {
                XtraMessageBox.Show(
                    "Registro eliminado exitosamente".Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                NotificarCambio();
                TipoPantalla = E_TipoPantalla.VisualizarEliminado;
            }
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "¿Está seguro que desea restaurar este registro?".Translate(),
                "Confirmar restauración".Translate(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            if (RestaurarRegistro())
            {
                XtraMessageBox.Show(
                    "Registro restaurado exitosamente".Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                NotificarCambio();
                TipoPantalla = E_TipoPantalla.Visualizar;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            if (GuardarDatos())
            {
                XtraMessageBox.Show(
                    TipoPantalla == E_TipoPantalla.Nuevo
                        ? "Registro creado exitosamente".Translate()
                        : "Registro modificado exitosamente".Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                NotificarCambio();

                if (TipoPantalla == E_TipoPantalla.Nuevo)
                {
                    this.Close();
                }
                else
                {
                    CargarDatos();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (TipoPantalla == E_TipoPantalla.Nuevo)
            {
                this.Close();
            }
            else
            {
                CargarDatos();
            }
        }

        #endregion

        #region "IMPLEMENTACIÓN IOBSERVER"

        public virtual void Update<T>(T value, object data = null)
        {
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
