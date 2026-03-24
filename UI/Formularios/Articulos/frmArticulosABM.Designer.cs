using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Articulos
{
    partial class frmArticulosABM
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
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.txtStockActual = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCodigo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStockActual = new DevExpress.XtraLayout.LayoutControlItem();

            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStockActual)).BeginInit();
            this.SuspendLayout();

            this.txtCodigo.Location = new System.Drawing.Point(12, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Size = new System.Drawing.Size(953, 20);
            this.txtCodigo.TabIndex = 4;

            this.txtDescripcion.Location = new System.Drawing.Point(12, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(953, 20);
            this.txtDescripcion.TabIndex = 5;

            this.txtStockActual.Location = new System.Drawing.Point(12, 60);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(953, 20);
            this.txtStockActual.TabIndex = 6;

            this.layoutControlHijo.Controls.Add(this.txtCodigo);
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.txtStockActual);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.TabIndex = 0;

            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCodigo,
            this.lciDescripcion,
            this.lciStockActual});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            this.lciCodigo.Control = this.txtCodigo;
            this.lciCodigo.Name = "lciCodigo";
            this.lciCodigo.Text = "Código:";
            this.lciCodigo.TextSize = new System.Drawing.Size(65, 13);

            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(65, 13);

            this.lciStockActual.Control = this.txtStockActual;
            this.lciStockActual.Name = "lciStockActual";
            this.lciStockActual.Text = "Stock Actual:";
            this.lciStockActual.TextSize = new System.Drawing.Size(65, 13);

            this.panelContenido.Controls.Add(this.layoutControlHijo);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Name = "frmArticulosABM";
            this.Text = "Artículos";

            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStockActual)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtStockActual;
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciCodigo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciStockActual;
    }
}