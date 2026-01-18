using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Helpers
{
    /// <summary>
    /// Helper centralizado para aplicar estilos consistentes a todos los controles de un formulario.
    /// Elimina la necesidad de configurar estilos manualmente en cada pantalla.
    /// </summary>
    public static class FormStyleHelper
    {
        /// <summary>
        /// Aplica estilos automáticamente a todos los controles del formulario.
        /// Llamar este método una sola vez en el Load del formulario.
        /// </summary>
        public static void AplicarEstilos(Control contenedor)
        {
            if (contenedor == null) return;

            AplicarEstilosRecursivo(contenedor);
        }

        /// <summary>
        /// Aplica estilos recursivamente a todos los controles hijos.
        /// </summary>
        private static void AplicarEstilosRecursivo(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                // Aplicar estilo según el tipo de control
                switch (control)
                {
                    case GridControl gridControl:
                        AplicarEstiloGridControl(gridControl);
                        break;

                    case LabelControl labelControl:
                        AplicarEstiloLabel(labelControl);
                        break;

                    case SimpleButton simpleButton:
                        // Los botones se configuran por ButtonStyleHelper según su rol
                        // No aplicamos estilo genérico aquí
                        break;

                    case TextEdit textEdit:
                        AplicarEstiloTextEdit(textEdit);
                        break;

                    case GroupControl groupControl:
                        AplicarEstiloGroupControl(groupControl);
                        // Procesar controles internos
                        AplicarEstilosRecursivo(groupControl);
                        break;

                    case PanelControl panelControl:
                        AplicarEstilosRecursivo(panelControl);
                        break;

                    default:
                        // Para contenedores genéricos, procesar sus hijos
                        if (control.HasChildren)
                        {
                            AplicarEstilosRecursivo(control);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Aplica estilos a un GridControl y su GridView principal.
        /// </summary>
        private static void AplicarEstiloGridControl(GridControl gridControl)
        {
            if (gridControl.MainView is GridView gridView)
            {
                // Determinar si es una grilla principal o secundaria por su tamaño/ubicación
                // Por defecto aplicamos el estilo normal
                GridStyleHelper.AplicarEstilo(gridView);
            }
        }

        /// <summary>
        /// Aplica estilos a un LabelControl.
        /// Detecta automáticamente si es un título de sección por su contexto.
        /// </summary>
        private static void AplicarEstiloLabel(LabelControl labelControl)
        {
            // Si el label está justo encima de un GridControl, es un título de sección
            if (EsTituloSeccion(labelControl))
            {
                labelControl.Font = FontHelper.FuenteSubtituloSemibold;
                labelControl.ForeColor = Color.FromArgb(52, 73, 94);
            }
            // Los labels normales no se modifican para respetar el diseño del formulario
        }

        /// <summary>
        /// Determina si un label es un título de sección (está encima de una grilla).
        /// </summary>
        private static bool EsTituloSeccion(LabelControl labelControl)
        {
            if (labelControl.Parent == null) return false;

            // Buscar si hay un GridControl cercano debajo del label
            int labelBottom = labelControl.Bottom;
            int tolerancia = 30; // Píxeles de tolerancia

            foreach (Control sibling in labelControl.Parent.Controls)
            {
                if (sibling is GridControl gridControl)
                {
                    // Si el GridControl está justo debajo del label
                    if (gridControl.Top >= labelBottom && gridControl.Top <= labelBottom + tolerancia)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Aplica estilos a un TextEdit.
        /// </summary>
        private static void AplicarEstiloTextEdit(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.Font = FontHelper.FuenteBase;
            textEdit.Properties.Appearance.Options.UseFont = true;
        }

        /// <summary>
        /// Aplica estilos a un GroupControl.
        /// </summary>
        private static void AplicarEstiloGroupControl(GroupControl groupControl)
        {
            groupControl.AppearanceCaption.Font = FontHelper.FuenteSubtituloSemibold;
            groupControl.AppearanceCaption.ForeColor = Color.FromArgb(52, 73, 94);
            groupControl.AppearanceCaption.Options.UseFont = true;
            groupControl.AppearanceCaption.Options.UseForeColor = true;
        }

        /// <summary>
        /// Aplica estilo compacto a todas las grillas de un contenedor.
        /// Útil para paneles de detalle con grillas secundarias.
        /// </summary>
        public static void AplicarEstiloCompactoAGrillas(Control contenedor)
        {
            if (contenedor == null) return;

            foreach (Control control in contenedor.Controls)
            {
                if (control is GridControl gridControl && gridControl.MainView is GridView gridView)
                {
                    GridStyleHelper.AplicarEstiloCompacto(gridView);
                }
                else if (control.HasChildren)
                {
                    AplicarEstiloCompactoAGrillas(control);
                }
            }
        }

        /// <summary>
        /// Aplica estilos específicos para formularios de listado (grilla principal + grillas de detalle).
        /// La grilla principal tiene estilo normal, las secundarias estilo compacto.
        /// </summary>
        /// <param name="contenedor">Contenedor del formulario</param>
        /// <param name="grillaPrincipal">Nombre del GridControl principal</param>
        public static void AplicarEstilosListado(Control contenedor, string nombreGrillaPrincipal = null)
        {
            if (contenedor == null) return;

            AplicarEstilosListadoRecursivo(contenedor, nombreGrillaPrincipal, true);
        }

        private static void AplicarEstilosListadoRecursivo(Control contenedor, string nombreGrillaPrincipal, bool esPrimerNivel)
        {
            bool grillaPrincipalEncontrada = false;

            foreach (Control control in contenedor.Controls)
            {
                switch (control)
                {
                    case GridControl gridControl:
                        if (gridControl.MainView is GridView gridView)
                        {
                            // Si se especificó nombre, usarlo; sino, la primera grilla es la principal
                            bool esGrillaPrincipal = !string.IsNullOrEmpty(nombreGrillaPrincipal)
                                ? gridControl.Name == nombreGrillaPrincipal
                                : !grillaPrincipalEncontrada && esPrimerNivel;

                            if (esGrillaPrincipal)
                            {
                                GridStyleHelper.AplicarEstilo(gridView);
                                grillaPrincipalEncontrada = true;
                            }
                            else
                            {
                                GridStyleHelper.AplicarEstiloCompacto(gridView);
                            }
                        }
                        break;

                    case LabelControl labelControl:
                        AplicarEstiloLabel(labelControl);
                        break;

                    default:
                        if (control.HasChildren)
                        {
                            AplicarEstilosListadoRecursivo(control, nombreGrillaPrincipal, false);
                        }
                        break;
                }
            }
        }
    }
}
