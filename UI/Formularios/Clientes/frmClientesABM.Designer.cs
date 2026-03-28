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
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
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
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(96, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 100;
            this.txtDescripcion.Size = new System.Drawing.Size(869, 20);
            this.txtDescripcion.StyleController = this.layoutControlHijo;
            this.txtDescripcion.TabIndex = 4;
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(574, 36);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Properties.MaxLength = 50;
            this.txtNroDocumento.Size = new System.Drawing.Size(391, 20);
            this.txtNroDocumento.StyleController = this.layoutControlHijo;
            this.txtNroDocumento.TabIndex = 5;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Location = new System.Drawing.Point(96, 36);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoDocumento.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTipoDocumento.Size = new System.Drawing.Size(390, 20);
            this.cmbTipoDocumento.StyleController = this.layoutControlHijo;
            this.cmbTipoDocumento.TabIndex = 6;
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.txtNroDocumento);
            this.layoutControlHijo.Controls.Add(this.cmbTipoDocumento);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(977, 427);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciTipoDocumento,
            this.lciNroDocumento});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 427);
            this.RootHijo.TextVisible = false;
            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Size = new System.Drawing.Size(957, 24);
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(81, 13);
            // 
            // lciNroDocumento
            // 
            this.lciNroDocumento.Control = this.txtNroDocumento;
            this.lciNroDocumento.Location = new System.Drawing.Point(478, 24);
            this.lciNroDocumento.Name = "lciNroDocumento";
            this.lciNroDocumento.Size = new System.Drawing.Size(479, 383);
            this.lciNroDocumento.Text = "Nro Documento:";
            this.lciNroDocumento.TextSize = new System.Drawing.Size(81, 13);
            // 
            // lciTipoDocumento
            // 
            this.lciTipoDocumento.Control = this.cmbTipoDocumento;
            this.lciTipoDocumento.Location = new System.Drawing.Point(0, 24);
            this.lciTipoDocumento.Name = "lciTipoDocumento";
            this.lciTipoDocumento.Size = new System.Drawing.Size(478, 383);
            this.lciTipoDocumento.Text = "Tipo Documento:";
            this.lciTipoDocumento.TextSize = new System.Drawing.Size(81, 13);
            // 
            // frmClientesABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Name = "frmClientesABM";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
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