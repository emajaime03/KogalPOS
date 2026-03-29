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
            this.cmbTipoMovimiento = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtFecha = new DevExpress.XtraEditors.TextEdit();
            this.gridItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAgregarFila = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitarFila = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciTipoMovimiento = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFecha = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnAgregar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnQuitar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGridItems = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoMovimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Size = new System.Drawing.Size(910, 68);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Location = new System.Drawing.Point(0, 609);
            this.pnlInferior.Size = new System.Drawing.Size(910, 68);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            this.panelContenido.Size = new System.Drawing.Size(910, 541);
            // 
            // sepSuperior
            // 
            this.sepSuperior.Size = new System.Drawing.Size(910, 1);
            // 
            // sepInferior
            // 
            this.sepInferior.Size = new System.Drawing.Size(910, 1);
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(128, 14);
            this.cmbTipoMovimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoMovimiento.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(325, 22);
            this.cmbTipoMovimiento.StyleController = this.layoutControlHijo;
            this.cmbTipoMovimiento.TabIndex = 4;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(571, 14);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(325, 22);
            this.txtFecha.StyleController = this.layoutControlHijo;
            this.txtFecha.TabIndex = 5;
            // 
            // gridItems
            // 
            this.gridItems.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridItems.Location = new System.Drawing.Point(14, 60);
            this.gridItems.MainView = this.gridViewItems;
            this.gridItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(882, 425);
            this.gridItems.TabIndex = 8;
            this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
            // 
            // gridViewItems
            // 
            this.gridViewItems.DetailHeight = 431;
            this.gridViewItems.GridControl = this.gridItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Location = new System.Drawing.Point(14, 489);
            this.btnAgregarFila.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(171, 38);
            this.btnAgregarFila.StyleController = this.layoutControlHijo;
            this.btnAgregarFila.TabIndex = 6;
            this.btnAgregarFila.Text = "Agregar Artículo";
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(189, 489);
            this.btnQuitarFila.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(171, 38);
            this.btnQuitarFila.StyleController = this.layoutControlHijo;
            this.btnQuitarFila.TabIndex = 7;
            this.btnQuitarFila.Text = "Quitar Artículo";
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.cmbTipoMovimiento);
            this.layoutControlHijo.Controls.Add(this.txtFecha);
            this.layoutControlHijo.Controls.Add(this.btnAgregarFila);
            this.layoutControlHijo.Controls.Add(this.btnQuitarFila);
            this.layoutControlHijo.Controls.Add(this.gridItems);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(910, 541);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTipoMovimiento,
            this.lciGridItems,
            this.lciBtnQuitar,
            this.lciBtnAgregar,
            this.lciFecha});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(910, 541);
            this.RootHijo.TextVisible = false;
            // 
            // lciTipoMovimiento
            // 
            this.lciTipoMovimiento.Control = this.cmbTipoMovimiento;
            this.lciTipoMovimiento.Location = new System.Drawing.Point(0, 0);
            this.lciTipoMovimiento.Name = "lciTipoMovimiento";
            this.lciTipoMovimiento.Size = new System.Drawing.Size(443, 26);
            this.lciTipoMovimiento.Text = "Tipo Movimiento:";
            this.lciTipoMovimiento.TextSize = new System.Drawing.Size(110, 16);
            // 
            // lciFecha
            // 
            this.lciFecha.Control = this.txtFecha;
            this.lciFecha.Location = new System.Drawing.Point(443, 0);
            this.lciFecha.Name = "lciFecha";
            this.lciFecha.Size = new System.Drawing.Size(443, 26);
            this.lciFecha.Text = "Fecha:";
            this.lciFecha.TextSize = new System.Drawing.Size(110, 16);
            // 
            // lciBtnAgregar
            // 
            this.lciBtnAgregar.Control = this.btnAgregarFila;
            this.lciBtnAgregar.Location = new System.Drawing.Point(0, 475);
            this.lciBtnAgregar.MaxSize = new System.Drawing.Size(175, 42);
            this.lciBtnAgregar.MinSize = new System.Drawing.Size(175, 42);
            this.lciBtnAgregar.Name = "lciBtnAgregar";
            this.lciBtnAgregar.Size = new System.Drawing.Size(175, 42);
            this.lciBtnAgregar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnAgregar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnAgregar.TextVisible = false;
            // 
            // lciBtnQuitar
            // 
            this.lciBtnQuitar.Control = this.btnQuitarFila;
            this.lciBtnQuitar.Location = new System.Drawing.Point(175, 475);
            this.lciBtnQuitar.MaxSize = new System.Drawing.Size(175, 42);
            this.lciBtnQuitar.MinSize = new System.Drawing.Size(175, 42);
            this.lciBtnQuitar.Name = "lciBtnQuitar";
            this.lciBtnQuitar.Size = new System.Drawing.Size(711, 42);
            this.lciBtnQuitar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnQuitar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnQuitar.TextVisible = false;
            // 
            // lciGridItems
            // 
            this.lciGridItems.Control = this.gridItems;
            this.lciGridItems.Location = new System.Drawing.Point(0, 26);
            this.lciGridItems.Name = "lciGridItems";
            this.lciGridItems.Size = new System.Drawing.Size(886, 449);
            this.lciGridItems.Text = "Artículos del Ajuste";
            this.lciGridItems.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciGridItems.TextSize = new System.Drawing.Size(110, 16);
            // 
            // frmAjusteStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 677);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmAjusteStock";
            this.Text = "Ajustes de Stock";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoMovimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoMovimiento;
        private DevExpress.XtraEditors.TextEdit txtFecha;
        private DevExpress.XtraGrid.GridControl gridItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraEditors.SimpleButton btnAgregarFila;
        private DevExpress.XtraEditors.SimpleButton btnQuitarFila;

        // Variables del LayoutControl
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciTipoMovimiento;
        private DevExpress.XtraLayout.LayoutControlItem lciFecha;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnAgregar;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnQuitar;
        private DevExpress.XtraLayout.LayoutControlItem lciGridItems;
    }
}