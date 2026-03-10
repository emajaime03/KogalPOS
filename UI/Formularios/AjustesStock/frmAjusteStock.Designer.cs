using UI.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace UI.Formularios.AjustesStock
{
    partial class frmAjusteStock
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();

            // ── Tipo Movimiento ──
            lblTipoMovimiento = ControlFactory.CrearLabel("lblTipoMovimiento", "Tipo Movimiento");
            cmbTipoMovimiento = ControlFactory.CrearComboBox("cmbTipoMovimiento");

            // ── Fecha ──
            lblFecha = ControlFactory.CrearLabel("lblFecha", "Fecha");
            txtFecha = ControlFactory.CrearTextEdit("txtFecha");
            txtFecha.Properties.ReadOnly = true;

            // ── Título Ítems ──
            lblTituloItems = ControlFactory.CrearLabelTitulo("lblTituloItems", "Artículos del Ajuste");

            // ── Grilla de ítems ──
            gridItems = new DevExpress.XtraGrid.GridControl();
            gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewItems)).BeginInit();

            gridItems.Name = "gridItems";
            gridItems.MainView = gridViewItems;
            gridItems.Size = new Size(700, 250);

            gridViewItems.GridControl = gridItems;
            gridViewItems.OptionsView.ShowGroupPanel = false;
            gridViewItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            ((System.ComponentModel.ISupportInitialize)(gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewItems)).EndInit();

            // ── Botón Agregar Fila ──
            btnAgregarFila = new DevExpress.XtraEditors.SimpleButton();
            btnAgregarFila.Name = "btnAgregarFila";
            btnAgregarFila.Text = "Agregar Artículo";
            btnAgregarFila.Size = new Size(140, 30);

            // ── Botón Quitar Fila ──
            btnQuitarFila = new DevExpress.XtraEditors.SimpleButton();
            btnQuitarFila.Name = "btnQuitarFila";
            btnQuitarFila.Text = "Quitar Artículo";
            btnQuitarFila.Size = new Size(140, 30);

            // ── Posicionar campos de cabecera ──
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblTipoMovimiento, cmbTipoMovimiento),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblFecha, txtFecha)
            );

            // ── Posicionar título y grilla manualmente ──
            int yGrilla = txtFecha.Location.Y + txtFecha.Height + 20;
            lblTituloItems.Location = new Point(20, yGrilla);
            yGrilla += lblTituloItems.Height + 8;

            // Botones Agregar/Quitar
            btnAgregarFila.Location = new Point(20, yGrilla);
            btnQuitarFila.Location = new Point(170, yGrilla);
            yGrilla += btnAgregarFila.Height + 8;

            gridItems.Location = new Point(20, yGrilla);

            // Agregar al panelContenido del base
            this.panelContenido.Controls.Add(this.lblTipoMovimiento);
            this.panelContenido.Controls.Add(this.cmbTipoMovimiento);
            this.panelContenido.Controls.Add(this.lblFecha);
            this.panelContenido.Controls.Add(this.txtFecha);
            this.panelContenido.Controls.Add(this.lblTituloItems);
            this.panelContenido.Controls.Add(this.btnAgregarFila);
            this.panelContenido.Controls.Add(this.btnQuitarFila);
            this.panelContenido.Controls.Add(this.gridItems);

            // frmAjusteStock
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmAjusteStock";
            this.ClientSize = new Size(780, 550);
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTipoMovimiento;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoMovimiento;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.TextEdit txtFecha;
        private DevExpress.XtraEditors.LabelControl lblTituloItems;
        private DevExpress.XtraGrid.GridControl gridItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraEditors.SimpleButton btnAgregarFila;
        private DevExpress.XtraEditors.SimpleButton btnQuitarFila;
    }
}
