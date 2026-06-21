using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Proveedores
{
    partial class frmProveedoresABM
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
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtCelular = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCelular = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCelular.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCelular)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(87, 14);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(1039, 22);
            this.txtDescripcion.StyleController = this.layoutControlHijo;
            this.txtDescripcion.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(87, 66);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.MaxLength = 50;
            this.txtEmail.Size = new System.Drawing.Size(1039, 22);
            this.txtEmail.StyleController = this.layoutControlHijo;
            this.txtEmail.TabIndex = 5;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(87, 40);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Properties.MaxLength = 20;
            this.txtCelular.Size = new System.Drawing.Size(1039, 22);
            this.txtCelular.StyleController = this.layoutControlHijo;
            this.txtCelular.TabIndex = 6;
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.txtEmail);
            this.layoutControlHijo.Controls.Add(this.txtCelular);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(1140, 525);
            this.layoutControlHijo.TabIndex = 0;
            this.layoutControlHijo.Text = "layoutControl1";
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciEmail,
            this.lciCelular});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(1140, 525);
            this.RootHijo.TextVisible = false;
            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Size = new System.Drawing.Size(1116, 26);
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(70, 16);
            // 
            // lciEmail
            // 
            this.lciEmail.Control = this.txtEmail;
            this.lciEmail.Location = new System.Drawing.Point(0, 52);
            this.lciEmail.Name = "lciEmail";
            this.lciEmail.Size = new System.Drawing.Size(1116, 449);
            this.lciEmail.Text = "Email:";
            this.lciEmail.TextSize = new System.Drawing.Size(70, 16);
            // 
            // lciCelular
            // 
            this.lciCelular.Control = this.txtCelular;
            this.lciCelular.Location = new System.Drawing.Point(0, 26);
            this.lciCelular.Name = "lciCelular";
            this.lciCelular.Size = new System.Drawing.Size(1116, 26);
            this.lciCelular.Text = "Celular:";
            this.lciCelular.TextSize = new System.Drawing.Size(70, 16);
            // 
            // frmProveedoresABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 661);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MostrarBotonEliminar = true;
            this.MostrarBotonModificar = true;
            this.MostrarBotonRestaurar = true;
            this.Name = "frmProveedoresABM";
            this.Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCelular.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCelular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtCelular;

        // Variables del LayoutControl
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciEmail;
        private DevExpress.XtraLayout.LayoutControlItem lciCelular;
    }
}