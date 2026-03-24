using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Clientes
{
    partial class frmClientesABM
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.txtNroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.cmbTipoDocumento = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNroDocumento = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTipoDocumento = new DevExpress.XtraLayout.LayoutControlItem();

            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNroDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoDocumento)).BeginInit();
            this.SuspendLayout();

            this.txtDescripcion.Location = new System.Drawing.Point(12, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 100;
            this.txtDescripcion.Size = new System.Drawing.Size(953, 20);
            this.txtDescripcion.TabIndex = 4;

            this.txtNroDocumento.Location = new System.Drawing.Point(12, 36);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Properties.MaxLength = 50;
            this.txtNroDocumento.Size = new System.Drawing.Size(953, 20);
            this.txtNroDocumento.TabIndex = 5;

            this.cmbTipoDocumento.Location = new System.Drawing.Point(12, 60);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(953, 20);
            this.cmbTipoDocumento.TabIndex = 6;

            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.txtNroDocumento);
            this.layoutControlHijo.Controls.Add(this.cmbTipoDocumento);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.TabIndex = 0;

            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciNroDocumento,
            this.lciTipoDocumento});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(85, 13);

            this.lciNroDocumento.Control = this.txtNroDocumento;
            this.lciNroDocumento.Name = "lciNroDocumento";
            this.lciNroDocumento.Text = "Nro Documento:";
            this.lciNroDocumento.TextSize = new System.Drawing.Size(85, 13);

            this.lciTipoDocumento.Control = this.cmbTipoDocumento;
            this.lciTipoDocumento.Name = "lciTipoDocumento";
            this.lciTipoDocumento.Text = "Tipo Documento:";
            this.lciTipoDocumento.TextSize = new System.Drawing.Size(85, 13);

            this.panelContenido.Controls.Add(this.layoutControlHijo);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Name = "frmClientesABM";
            this.Text = "Clientes";

            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNroDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoDocumento)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtNroDocumento;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoDocumento;
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciNroDocumento;
        private DevExpress.XtraLayout.LayoutControlItem lciTipoDocumento;
    }
}