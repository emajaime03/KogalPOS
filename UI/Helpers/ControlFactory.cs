using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Drawing;

namespace UI.Helpers
{
    /// <summary>
    /// Fábrica centralizada de controles UI.
    /// Fuente única de verdad para estilos de campos de formulario.
    /// Agregar un tipo de control nuevo = agregar UN método.
    /// </summary>
    public static class ControlFactory
    {
        #region "COLORES"

        // ── Modo Edición ──
        private static readonly Color FondoEdicion = Color.White;
        private static readonly Color TextoEdicion = Color.Black;
        private static readonly Color BordeEdicion = Color.FromArgb(100, 149, 237);   // Azul "activo"

        // ── Modo Visualización ──
        private static readonly Color FondoVisualizacion = Color.FromArgb(240, 240, 240);
        private static readonly Color TextoVisualizacion = Color.FromArgb(60, 60, 60);
        private static readonly Color BordeVisualizacion = Color.FromArgb(200, 200, 200);

        // ── Labels ──
        private static readonly Color LabelEdicion = Color.FromArgb(52, 73, 94);       // Azul oscuro
        private static readonly Color LabelVisualizacion = Color.FromArgb(80, 80, 80);  // Gris oscuro

        // ── Grillas Edición ──
        private static readonly Color GrillaHeaderEdicionBg = Color.FromArgb(209, 231, 251);
        private static readonly Color GrillaHeaderEdicionFg = Color.FromArgb(30, 60, 114);
        private static readonly Color GrillaEvenRowEdicion = Color.FromArgb(248, 251, 255);
        private static readonly Color GrillaFocusedEdicionBg = Color.FromArgb(189, 215, 238);
        private static readonly Color GrillaFocusedEdicionFg = Color.FromArgb(31, 64, 104);

        // ── Grillas Visualización ──
        private static readonly Color GrillaHeaderVisualizacionBg = Color.FromArgb(222, 226, 230);
        private static readonly Color GrillaHeaderVisualizacionFg = Color.FromArgb(73, 80, 87);
        private static readonly Color GrillaRowVisualizacionBg = Color.FromArgb(245, 245, 245);
        private static readonly Color GrillaEvenRowVisualizacion = Color.FromArgb(240, 240, 240);
        private static readonly Color GrillaOddRowVisualizacion = Color.FromArgb(248, 248, 248);
        private static readonly Color GrillaFocusedVisualizacionBg = Color.FromArgb(220, 220, 220);
        private static readonly Color GrillaFocusedVisualizacionFg = Color.FromArgb(40, 40, 40);

        #endregion

        #region "CREACIÓN DE CONTROLES"

        /// <summary>
        /// Crea un TextEdit con estilo estandarizado.
        /// </summary>
        public static TextEdit CrearTextEdit(string name, int maxLength = 0)
        {
            var txt = new TextEdit
            {
                Name = name,
                Size = new Size(400, 22),
            };

            txt.Properties.Appearance.Font = FontHelper.FuenteBase;
            txt.Properties.Appearance.Options.UseFont = true;

            if (maxLength > 0)
                txt.Properties.MaxLength = maxLength;

            return txt;
        }

        /// <summary>
        /// Crea un LabelControl para campo de formulario (estilo Semibold).
        /// </summary>
        public static LabelControl CrearLabel(string name, string texto)
        {
            return new LabelControl
            {
                Name = name,
                Text = texto,
                Font = FontHelper.FuenteEtiqueta,
                ForeColor = LabelEdicion,
                AutoSizeMode = LabelAutoSizeMode.Default
            };
        }

        /// <summary>
        /// Crea un LabelControl para título de sección (más grande, bold).
        /// </summary>
        public static LabelControl CrearLabelTitulo(string name, string texto)
        {
            return new LabelControl
            {
                Name = name,
                Text = texto,
                Font = FontHelper.FuenteSubtituloSemibold,
                ForeColor = LabelEdicion,
                AutoSizeMode = LabelAutoSizeMode.Default
            };
        }

        /// <summary>
        /// Crea un ComboBoxEdit con estilo estandarizado.
        /// </summary>
        public static ComboBoxEdit CrearComboBox(string name)
        {
            var cmb = new ComboBoxEdit
            {
                Name = name,
                Size = new Size(400, 22),
            };

            cmb.Properties.Appearance.Font = FontHelper.FuenteBase;
            cmb.Properties.Appearance.Options.UseFont = true;
            cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            return cmb;
        }

        /// <summary>
        /// Crea un LookUpEdit con estilo estandarizado (combo con búsqueda).
        /// </summary>
        public static LookUpEdit CrearLookUpEdit(string name)
        {
            var lkp = new LookUpEdit
            {
                Name = name,
                Size = new Size(400, 22),
            };

            lkp.Properties.Appearance.Font = FontHelper.FuenteBase;
            lkp.Properties.Appearance.Options.UseFont = true;
            lkp.Properties.NullText = string.Empty;

            return lkp;
        }

        #endregion

        #region "MODOS (EDICIÓN / VISUALIZACIÓN)"

        /// <summary>
        /// Aplica modo edición a uno o más TextEdit: fondo blanco, borde azul, editable.
        /// </summary>
        public static void AplicarModoEdicion(params TextEdit[] controles)
        {
            foreach (var txt in controles)
                AplicarEstiloBaseEditor(txt, FondoEdicion, TextoEdicion, BordeEdicion, false);
        }

        /// <summary>
        /// Aplica modo visualización a uno o más TextEdit: fondo gris, borde gris, solo lectura.
        /// </summary>
        public static void AplicarModoVisualizacion(params TextEdit[] controles)
        {
            foreach (var txt in controles)
                AplicarEstiloBaseEditor(txt, FondoVisualizacion, TextoVisualizacion, BordeVisualizacion, true);
        }

        /// <summary>
        /// Aplica modo edición a labels de campo.
        /// </summary>
        public static void AplicarModoEdicionLabels(params LabelControl[] labels)
        {
            foreach (var lbl in labels)
            {
                lbl.ForeColor = LabelEdicion;
                lbl.Font = FontHelper.FuenteEtiqueta;
            }
        }

        /// <summary>
        /// Aplica modo visualización a labels de campo.
        /// </summary>
        public static void AplicarModoVisualizacionLabels(params LabelControl[] labels)
        {
            foreach (var lbl in labels)
            {
                lbl.ForeColor = LabelVisualizacion;
                lbl.Font = FontHelper.FuenteSubtitulo;
            }
        }

        /// <summary>
        /// Aplica estilo de edición a una o más grillas.
        /// </summary>
        public static void AplicarModoGrillaEdicion(params GridView[] gridViews)
        {
            foreach (var gv in gridViews)
                AplicarEstiloGrillaBase(gv,
                    GrillaHeaderEdicionBg, GrillaHeaderEdicionFg,
                    Color.White, Color.Black,
                    GrillaEvenRowEdicion, Color.White,
                    Color.Black, Color.Black,
                    GrillaFocusedEdicionBg, GrillaFocusedEdicionFg);
        }

        /// <summary>
        /// Aplica estilo de visualización a una o más grillas.
        /// </summary>
        public static void AplicarModoGrillaVisualizacion(params GridView[] gridViews)
        {
            foreach (var gv in gridViews)
                AplicarEstiloGrillaBase(gv,
                    GrillaHeaderVisualizacionBg, GrillaHeaderVisualizacionFg,
                    GrillaRowVisualizacionBg, TextoVisualizacion,
                    GrillaEvenRowVisualizacion, GrillaOddRowVisualizacion,
                    TextoVisualizacion, TextoVisualizacion,
                    GrillaFocusedVisualizacionBg, GrillaFocusedVisualizacionFg);
        }

        /// <summary>
        /// Aplica modo completo según booleano: TextEdits + Labels + Grillas.
        /// </summary>
        public static void AplicarModo(bool esEditable, TextEdit[] textEdits = null, LabelControl[] labels = null, GridView[] grillas = null)
        {
            if (esEditable)
            {
                if (textEdits != null) AplicarModoEdicion(textEdits);
                if (labels != null) AplicarModoEdicionLabels(labels);
                if (grillas != null) AplicarModoGrillaEdicion(grillas);
            }
            else
            {
                if (textEdits != null) AplicarModoVisualizacion(textEdits);
                if (labels != null) AplicarModoVisualizacionLabels(labels);
                if (grillas != null) AplicarModoGrillaVisualizacion(grillas);
            }
        }

        #endregion

        #region "POSICIONAMIENTO"

        /// <summary>
        /// Posiciona pares Label + Control verticalmente dentro de un contenedor.
        /// </summary>
        public static void PosicionarCampos(int xInicio, int yInicio, int espacioEntreCampos, params KeyValuePair<LabelControl, BaseEdit>[] campos)
        {
            int y = yInicio;

            foreach (var campo in campos)
            {
                campo.Key.Location = new Point(xInicio, y);
                y += campo.Key.Height + 4;

                campo.Value.Location = new Point(xInicio, y);
                y += campo.Value.Height + espacioEntreCampos;
            }
        }

        #endregion

        #region "PRIVADO"

        private static void AplicarEstiloBaseEditor(TextEdit textEdit, Color fondo, Color texto, Color borde, bool readOnly)
        {
            textEdit.Properties.Appearance.BackColor = fondo;
            textEdit.Properties.Appearance.ForeColor = texto;
            textEdit.Properties.Appearance.BorderColor = borde;
            textEdit.Properties.Appearance.Options.UseBackColor = true;
            textEdit.Properties.Appearance.Options.UseForeColor = true;
            textEdit.Properties.Appearance.Options.UseBorderColor = true;
            textEdit.Properties.ReadOnly = readOnly;
        }

        private static void AplicarEstiloGrillaBase(GridView gv,
            Color headerBg, Color headerFg,
            Color rowBg, Color rowFg,
            Color evenBg, Color oddBg,
            Color evenFg, Color oddFg,
            Color focusedBg, Color focusedFg)
        {
            // Header
            gv.Appearance.HeaderPanel.BackColor = headerBg;
            gv.Appearance.HeaderPanel.ForeColor = headerFg;
            gv.Appearance.HeaderPanel.Font = FontHelper.FuenteEncabezadoGrilla;
            gv.Appearance.HeaderPanel.Options.UseBackColor = true;
            gv.Appearance.HeaderPanel.Options.UseForeColor = true;
            gv.Appearance.HeaderPanel.Options.UseFont = true;

            // Filas
            gv.Appearance.Row.BackColor = rowBg;
            gv.Appearance.Row.ForeColor = rowFg;
            gv.Appearance.Row.Font = FontHelper.FuenteFilaGrilla;
            gv.Appearance.Row.Options.UseBackColor = true;
            gv.Appearance.Row.Options.UseForeColor = true;
            gv.Appearance.Row.Options.UseFont = true;

            // Filas alternadas
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.OptionsView.EnableAppearanceOddRow = true;
            gv.Appearance.EvenRow.BackColor = evenBg;
            gv.Appearance.OddRow.BackColor = oddBg;
            gv.Appearance.EvenRow.ForeColor = evenFg;
            gv.Appearance.OddRow.ForeColor = oddFg;
            gv.Appearance.EvenRow.Options.UseBackColor = true;
            gv.Appearance.OddRow.Options.UseBackColor = true;
            gv.Appearance.EvenRow.Options.UseForeColor = true;
            gv.Appearance.OddRow.Options.UseForeColor = true;

            // Fila enfocada
            gv.Appearance.FocusedRow.BackColor = focusedBg;
            gv.Appearance.FocusedRow.ForeColor = focusedFg;
            gv.Appearance.FocusedRow.Font = FontHelper.FuenteFilaGrilla;
            gv.Appearance.FocusedRow.Options.UseBackColor = true;
            gv.Appearance.FocusedRow.Options.UseForeColor = true;
            gv.Appearance.FocusedRow.Options.UseFont = true;
        }

        #endregion
    }
}
