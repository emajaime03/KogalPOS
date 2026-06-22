namespace UI.Formularios.Ventas
{
    partial class frmCobro
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
            this.lblTotalTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblTipoComprobante = new DevExpress.XtraEditors.LabelControl();
            this.cmbTipoComprobante = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFormaPago = new DevExpress.XtraEditors.LabelControl();
            this.cmbFormaPago = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblMontoRecibido = new DevExpress.XtraEditors.LabelControl();
            this.spnMontoRecibido = new DevExpress.XtraEditors.SpinEdit();
            this.lblVueltoTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblVuelto = new DevExpress.XtraEditors.LabelControl();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoComprobante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMontoRecibido.Properties)).BeginInit();
            this.SuspendLayout();

            this.lblTotalTitulo.Location = new System.Drawing.Point(24, 20);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(57, 13);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "Total:";

            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Location = new System.Drawing.Point(24, 40);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 33);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0,00";

            this.lblTipoComprobante.Location = new System.Drawing.Point(24, 96);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(100, 13);
            this.lblTipoComprobante.TabIndex = 2;
            this.lblTipoComprobante.Text = "Tipo de Comprobante:";

            this.cmbTipoComprobante.Location = new System.Drawing.Point(180, 92);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoComprobante.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTipoComprobante.Size = new System.Drawing.Size(170, 20);
            this.cmbTipoComprobante.TabIndex = 3;

            this.lblFormaPago.Location = new System.Drawing.Point(24, 134);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(73, 13);
            this.lblFormaPago.TabIndex = 4;
            this.lblFormaPago.Text = "Forma de Pago:";

            this.cmbFormaPago.Location = new System.Drawing.Point(180, 130);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFormaPago.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFormaPago.Size = new System.Drawing.Size(170, 20);
            this.cmbFormaPago.TabIndex = 5;

            this.lblMontoRecibido.Location = new System.Drawing.Point(24, 172);
            this.lblMontoRecibido.Name = "lblMontoRecibido";
            this.lblMontoRecibido.Size = new System.Drawing.Size(82, 13);
            this.lblMontoRecibido.TabIndex = 6;
            this.lblMontoRecibido.Text = "Monto Recibido:";

            this.spnMontoRecibido.Location = new System.Drawing.Point(180, 168);
            this.spnMontoRecibido.Name = "spnMontoRecibido";
            this.spnMontoRecibido.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.spnMontoRecibido.Properties.DisplayFormat.FormatString = "N2";
            this.spnMontoRecibido.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnMontoRecibido.Properties.EditFormat.FormatString = "N2";
            this.spnMontoRecibido.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnMontoRecibido.Size = new System.Drawing.Size(170, 20);
            this.spnMontoRecibido.TabIndex = 7;

            this.lblVueltoTitulo.Location = new System.Drawing.Point(24, 210);
            this.lblVueltoTitulo.Name = "lblVueltoTitulo";
            this.lblVueltoTitulo.Size = new System.Drawing.Size(40, 13);
            this.lblVueltoTitulo.TabIndex = 8;
            this.lblVueltoTitulo.Text = "Vuelto:";

            this.lblVuelto.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblVuelto.Appearance.Options.UseFont = true;
            this.lblVuelto.Location = new System.Drawing.Point(180, 206);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(40, 19);
            this.lblVuelto.TabIndex = 9;
            this.lblVuelto.Text = "0,00";

            this.btnConfirmar.Location = new System.Drawing.Point(180, 250);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(80, 30);
            this.btnConfirmar.TabIndex = 10;
            this.btnConfirmar.Text = "Aceptar";

            this.btnCancelar.Location = new System.Drawing.Point(270, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.lblVueltoTitulo);
            this.Controls.Add(this.spnMontoRecibido);
            this.Controls.Add(this.lblMontoRecibido);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cmbTipoComprobante);
            this.Controls.Add(this.lblTipoComprobante);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobrar";
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoComprobante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMontoRecibido.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTotalTitulo;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl lblTipoComprobante;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoComprobante;
        private DevExpress.XtraEditors.LabelControl lblFormaPago;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFormaPago;
        private DevExpress.XtraEditors.LabelControl lblMontoRecibido;
        private DevExpress.XtraEditors.SpinEdit spnMontoRecibido;
        private DevExpress.XtraEditors.LabelControl lblVueltoTitulo;
        private DevExpress.XtraEditors.LabelControl lblVuelto;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}
