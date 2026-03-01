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
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();

            // Crear controles con ControlFactory (estilos estandarizados)
            lblCodigo = ControlFactory.CrearLabel("lblCodigo", "Código");
            txtCodigo = ControlFactory.CrearTextEdit("txtCodigo", 50);

            lblDescripcion = ControlFactory.CrearLabel("lblDescripcion", "Descripción");
            txtDescripcion = ControlFactory.CrearTextEdit("txtDescripcion", 200);

            lblStockActual = ControlFactory.CrearLabel("lblStockActual", "Stock Actual");
            txtStockActual = ControlFactory.CrearTextEdit("txtStockActual");

            // Posicionar campos
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblCodigo, txtCodigo),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblDescripcion, txtDescripcion),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblStockActual, txtStockActual)
            );

            // Agregar al panelContenido del base
            this.panelContenido.Controls.Add(this.lblCodigo);
            this.panelContenido.Controls.Add(this.txtCodigo);
            this.panelContenido.Controls.Add(this.lblDescripcion);
            this.panelContenido.Controls.Add(this.txtDescripcion);
            this.panelContenido.Controls.Add(this.lblStockActual);
            this.panelContenido.Controls.Add(this.txtStockActual);

            // frmArticulosABM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmArticulosABM";
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCodigo;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblStockActual;
        private DevExpress.XtraEditors.TextEdit txtStockActual;
    }
}
