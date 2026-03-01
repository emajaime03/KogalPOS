using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Proveedores
{
    partial class frmProveedoresABM
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblCelular;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtCelular;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();

            // Crear controles con el factory (estilos estandarizados)
            lblDescripcion = ControlFactory.CrearLabel("lblDescripcion", "Descripción");
            txtDescripcion = ControlFactory.CrearTextEdit("txtDescripcion", 50);

            lblEmail = ControlFactory.CrearLabel("lblEmail", "Email");
            txtEmail = ControlFactory.CrearTextEdit("txtEmail", 50);

            lblCelular = ControlFactory.CrearLabel("lblCelular", "Celular");
            txtCelular = ControlFactory.CrearTextEdit("txtCelular", 20);

            // Posicionar campos de forma consistente
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblDescripcion, txtDescripcion),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblEmail, txtEmail),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblCelular, txtCelular)
            );

            // Agregar al panel de contenido del base
            this.panelContenido.Controls.Add(this.lblDescripcion);
            this.panelContenido.Controls.Add(this.txtDescripcion);
            this.panelContenido.Controls.Add(this.lblEmail);
            this.panelContenido.Controls.Add(this.txtEmail);
            this.panelContenido.Controls.Add(this.lblCelular);
            this.panelContenido.Controls.Add(this.txtCelular);

            // frmProveedoresABM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmProveedoresABM";
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
