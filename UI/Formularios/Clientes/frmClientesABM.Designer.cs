using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Clientes
{
    partial class frmClientesABM
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.LabelControl lblNroDocumento;
        private DevExpress.XtraEditors.LabelControl lblTipoDocumento;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtNroDocumento;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoDocumento;

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
            txtDescripcion = ControlFactory.CrearTextEdit("txtDescripcion", 100);

            lblNroDocumento = ControlFactory.CrearLabel("lblNroDocumento", "Nro Documento");
            txtNroDocumento = ControlFactory.CrearTextEdit("txtNroDocumento", 50);

            lblTipoDocumento = ControlFactory.CrearLabel("lblTipoDocumento", "Tipo Documento");
            cmbTipoDocumento = ControlFactory.CrearComboBox("cmbTipoDocumento");

            // Posicionar campos de forma consistente
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblDescripcion, txtDescripcion),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblNroDocumento, txtNroDocumento),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblTipoDocumento, cmbTipoDocumento)
            );

            // Agregar al panel de contenido del base
            this.panelContenido.Controls.Add(this.lblDescripcion);
            this.panelContenido.Controls.Add(this.txtDescripcion);
            this.panelContenido.Controls.Add(this.lblNroDocumento);
            this.panelContenido.Controls.Add(this.txtNroDocumento);
            this.panelContenido.Controls.Add(this.lblTipoDocumento);
            this.panelContenido.Controls.Add(this.cmbTipoDocumento);

            // frmClientesABM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmClientesABM";
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
