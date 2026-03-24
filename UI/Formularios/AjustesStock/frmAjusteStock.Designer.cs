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
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(12, 12);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(953, 20);
            this.cmbTipoMovimiento.TabIndex = 4;

            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(12, 36);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(953, 20);
            this.txtFecha.TabIndex = 5;

            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Location = new System.Drawing.Point(12, 90);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(146, 30);
            this.btnAgregarFila.TabIndex = 6;
            this.btnAgregarFila.Text = "Agregar Artículo";

            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(162, 90);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(146, 30);
            this.btnQuitarFila.TabIndex = 7;
            this.btnQuitarFila.Text = "Quitar Artículo";

            // 
            // gridItems
            // 
            this.gridItems.Location = new System.Drawing.Point(12, 145);
            this.gridItems.MainView = this.gridViewItems;
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(953, 275);
            this.gridItems.TabIndex = 8;
            this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});

            // 
            // gridViewItems
            // 
            this.gridViewItems.GridControl = this.gridItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            this.gridViewItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

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
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.TabIndex = 0;

            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTipoMovimiento,
            this.lciFecha,
            this.lciBtnAgregar,
            this.lciBtnQuitar,
            this.lciGridItems});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            // 
            // lciTipoMovimiento
            // 
            this.lciTipoMovimiento.Control = this.cmbTipoMovimiento;
            this.lciTipoMovimiento.Name = "lciTipoMovimiento";
            this.lciTipoMovimiento.Text = "Tipo Movimiento:";
            this.lciTipoMovimiento.Location = new System.Drawing.Point(0, 0);

            // 
            // lciFecha
            // 
            this.lciFecha.Control = this.txtFecha;
            this.lciFecha.Name = "lciFecha";
            this.lciFecha.Text = "Fecha:";
            this.lciFecha.Location = new System.Drawing.Point(0, 24);

            // 
            // lciBtnAgregar
            // 
            this.lciBtnAgregar.Control = this.btnAgregarFila;
            this.lciBtnAgregar.Name = "lciBtnAgregar";
            this.lciBtnAgregar.TextVisible = false;
            this.lciBtnAgregar.MaxSize = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.MinSize = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnAgregar.Location = new System.Drawing.Point(0, 78);

            // 
            // lciBtnQuitar
            // 
            this.lciBtnQuitar.Control = this.btnQuitarFila;
            this.lciBtnQuitar.Name = "lciBtnQuitar";
            this.lciBtnQuitar.TextVisible = false;
            this.lciBtnQuitar.MaxSize = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.MinSize = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnQuitar.Location = new System.Drawing.Point(150, 78);

            // 
            // lciGridItems
            // 
            this.lciGridItems.Control = this.gridItems;
            this.lciGridItems.Name = "lciGridItems";
            this.lciGridItems.Text = "Artículos del Ajuste";
            this.lciGridItems.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciGridItems.Location = new System.Drawing.Point(0, 112);

            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);

            // 
            // frmAjusteStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 550);
            this.Name = "frmAjusteStock";
            this.Text = "Ajustes de Stock";

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