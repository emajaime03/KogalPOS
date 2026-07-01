namespace UI.Formularios.TerminalPuntos
{
    partial class frmTerminalPuntos
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
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.pnlPuntos = new DevExpress.XtraEditors.PanelControl();
            this.lblPuntosValor = new DevExpress.XtraEditors.LabelControl();
            this.lblPuntosTitulo = new DevExpress.XtraEditors.LabelControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.lkpCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.pnlResumen = new DevExpress.XtraEditors.PanelControl();
            this.gcCarrito = new DevExpress.XtraGrid.GridControl();
            this.gvCarrito = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlAccionResumen = new DevExpress.XtraEditors.PanelControl();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.lblSaldoValor = new DevExpress.XtraEditors.LabelControl();
            this.lblSaldoTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblGanarValor = new DevExpress.XtraEditors.LabelControl();
            this.lblGanarTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblCanjearValor = new DevExpress.XtraEditors.LabelControl();
            this.lblCanjearTitulo = new DevExpress.XtraEditors.LabelControl();
            this.spnMonto = new DevExpress.XtraEditors.SpinEdit();
            this.lblMonto = new DevExpress.XtraEditors.LabelControl();
            this.lblPremiosTitulo = new DevExpress.XtraEditors.LabelControl();
            this.pnlCentro = new DevExpress.XtraEditors.PanelControl();
            this.flpTablero = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTablero = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPuntos)).BeginInit();
            this.pnlPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResumen)).BeginInit();
            this.pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccionResumen)).BeginInit();
            this.pnlAccionResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCentro)).BeginInit();
            this.pnlCentro.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.pnlPuntos);
            this.pnlTop.Controls.Add(this.btnActualizar);
            this.pnlTop.Controls.Add(this.lkpCliente);
            this.pnlTop.Controls.Add(this.lblCliente);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(984, 80);
            this.pnlTop.TabIndex = 0;
            //
            // pnlPuntos
            //
            this.pnlPuntos.Controls.Add(this.lblPuntosValor);
            this.pnlPuntos.Controls.Add(this.lblPuntosTitulo);
            this.pnlPuntos.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPuntos.Location = new System.Drawing.Point(674, 2);
            this.pnlPuntos.Name = "pnlPuntos";
            this.pnlPuntos.Size = new System.Drawing.Size(308, 76);
            this.pnlPuntos.TabIndex = 3;
            //
            // lblPuntosValor
            //
            this.lblPuntosValor.Location = new System.Drawing.Point(18, 34);
            this.lblPuntosValor.Name = "lblPuntosValor";
            this.lblPuntosValor.Size = new System.Drawing.Size(12, 25);
            this.lblPuntosValor.TabIndex = 1;
            this.lblPuntosValor.Text = "0";
            //
            // lblPuntosTitulo
            //
            this.lblPuntosTitulo.Location = new System.Drawing.Point(18, 13);
            this.lblPuntosTitulo.Name = "lblPuntosTitulo";
            this.lblPuntosTitulo.Size = new System.Drawing.Size(95, 13);
            this.lblPuntosTitulo.TabIndex = 0;
            this.lblPuntosTitulo.Text = "Puntos disponibles";
            //
            // btnActualizar
            //
            this.btnActualizar.Location = new System.Drawing.Point(470, 29);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 26);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            //
            // lkpCliente
            //
            this.lkpCliente.Location = new System.Drawing.Point(70, 29);
            this.lkpCliente.Name = "lkpCliente";
            this.lkpCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCliente.Size = new System.Drawing.Size(380, 26);
            this.lkpCliente.TabIndex = 1;
            //
            // lblCliente
            //
            this.lblCliente.Location = new System.Drawing.Point(18, 35);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            //
            // pnlResumen
            //
            this.pnlResumen.Controls.Add(this.gcCarrito);
            this.pnlResumen.Controls.Add(this.pnlAccionResumen);
            this.pnlResumen.Controls.Add(this.lblPremiosTitulo);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResumen.Location = new System.Drawing.Point(644, 80);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(340, 581);
            this.pnlResumen.TabIndex = 1;
            //
            // gcCarrito
            //
            this.gcCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCarrito.Location = new System.Drawing.Point(2, 34);
            this.gcCarrito.MainView = this.gvCarrito;
            this.gcCarrito.Name = "gcCarrito";
            this.gcCarrito.Size = new System.Drawing.Size(336, 305);
            this.gcCarrito.TabIndex = 1;
            this.gcCarrito.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCarrito});
            //
            // gvCarrito
            //
            this.gvCarrito.GridControl = this.gcCarrito;
            this.gvCarrito.Name = "gvCarrito";
            this.gvCarrito.OptionsView.ShowGroupPanel = false;
            //
            // pnlAccionResumen
            //
            this.pnlAccionResumen.Controls.Add(this.btnConfirmar);
            this.pnlAccionResumen.Controls.Add(this.btnLimpiar);
            this.pnlAccionResumen.Controls.Add(this.lblSaldoValor);
            this.pnlAccionResumen.Controls.Add(this.lblSaldoTitulo);
            this.pnlAccionResumen.Controls.Add(this.lblGanarValor);
            this.pnlAccionResumen.Controls.Add(this.lblGanarTitulo);
            this.pnlAccionResumen.Controls.Add(this.lblCanjearValor);
            this.pnlAccionResumen.Controls.Add(this.lblCanjearTitulo);
            this.pnlAccionResumen.Controls.Add(this.spnMonto);
            this.pnlAccionResumen.Controls.Add(this.lblMonto);
            this.pnlAccionResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccionResumen.Location = new System.Drawing.Point(2, 339);
            this.pnlAccionResumen.Name = "pnlAccionResumen";
            this.pnlAccionResumen.Size = new System.Drawing.Size(336, 240);
            this.pnlAccionResumen.TabIndex = 2;
            //
            // btnConfirmar
            //
            this.btnConfirmar.Location = new System.Drawing.Point(13, 196);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(310, 36);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar operación";
            //
            // btnLimpiar
            //
            this.btnLimpiar.Location = new System.Drawing.Point(13, 162);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(310, 28);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            //
            // lblSaldoValor
            //
            this.lblSaldoValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoValor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSaldoValor.Appearance.Options.UseTextOptions = true;
            this.lblSaldoValor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSaldoValor.Location = new System.Drawing.Point(123, 122);
            this.lblSaldoValor.Name = "lblSaldoValor";
            this.lblSaldoValor.Size = new System.Drawing.Size(200, 16);
            this.lblSaldoValor.TabIndex = 9;
            this.lblSaldoValor.Text = "0";
            //
            // lblSaldoTitulo
            //
            this.lblSaldoTitulo.Location = new System.Drawing.Point(13, 122);
            this.lblSaldoTitulo.Name = "lblSaldoTitulo";
            this.lblSaldoTitulo.Size = new System.Drawing.Size(85, 13);
            this.lblSaldoTitulo.TabIndex = 8;
            this.lblSaldoTitulo.Text = "Saldo resultante:";
            //
            // lblGanarValor
            //
            this.lblGanarValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGanarValor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblGanarValor.Appearance.Options.UseTextOptions = true;
            this.lblGanarValor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGanarValor.Location = new System.Drawing.Point(123, 96);
            this.lblGanarValor.Name = "lblGanarValor";
            this.lblGanarValor.Size = new System.Drawing.Size(200, 16);
            this.lblGanarValor.TabIndex = 7;
            this.lblGanarValor.Text = "0";
            //
            // lblGanarTitulo
            //
            this.lblGanarTitulo.Location = new System.Drawing.Point(13, 96);
            this.lblGanarTitulo.Name = "lblGanarTitulo";
            this.lblGanarTitulo.Size = new System.Drawing.Size(75, 13);
            this.lblGanarTitulo.TabIndex = 6;
            this.lblGanarTitulo.Text = "Puntos a ganar:";
            //
            // lblCanjearValor
            //
            this.lblCanjearValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCanjearValor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCanjearValor.Appearance.Options.UseTextOptions = true;
            this.lblCanjearValor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCanjearValor.Location = new System.Drawing.Point(123, 74);
            this.lblCanjearValor.Name = "lblCanjearValor";
            this.lblCanjearValor.Size = new System.Drawing.Size(200, 16);
            this.lblCanjearValor.TabIndex = 5;
            this.lblCanjearValor.Text = "0";
            //
            // lblCanjearTitulo
            //
            this.lblCanjearTitulo.Location = new System.Drawing.Point(13, 74);
            this.lblCanjearTitulo.Name = "lblCanjearTitulo";
            this.lblCanjearTitulo.Size = new System.Drawing.Size(86, 13);
            this.lblCanjearTitulo.TabIndex = 4;
            this.lblCanjearTitulo.Text = "Puntos a canjear:";
            //
            // spnMonto
            //
            this.spnMonto.Location = new System.Drawing.Point(123, 27);
            this.spnMonto.Name = "spnMonto";
            this.spnMonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.spnMonto.Size = new System.Drawing.Size(200, 24);
            this.spnMonto.TabIndex = 1;
            //
            // lblMonto
            //
            this.lblMonto.Location = new System.Drawing.Point(13, 32);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(71, 13);
            this.lblMonto.TabIndex = 0;
            this.lblMonto.Text = "Monto a pagar:";
            //
            // lblPremiosTitulo
            //
            this.lblPremiosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPremiosTitulo.Location = new System.Drawing.Point(2, 2);
            this.lblPremiosTitulo.Name = "lblPremiosTitulo";
            this.lblPremiosTitulo.Padding = new System.Windows.Forms.Padding(10, 8, 0, 8);
            this.lblPremiosTitulo.Size = new System.Drawing.Size(106, 32);
            this.lblPremiosTitulo.TabIndex = 0;
            this.lblPremiosTitulo.Text = "Premios a canjear";
            //
            // pnlCentro
            //
            this.pnlCentro.Controls.Add(this.flpTablero);
            this.pnlCentro.Controls.Add(this.lblTablero);
            this.pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentro.Location = new System.Drawing.Point(0, 80);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(644, 581);
            this.pnlCentro.TabIndex = 2;
            //
            // flpTablero
            //
            this.flpTablero.AutoScroll = true;
            this.flpTablero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTablero.Location = new System.Drawing.Point(2, 34);
            this.flpTablero.Name = "flpTablero";
            this.flpTablero.Padding = new System.Windows.Forms.Padding(6);
            this.flpTablero.Size = new System.Drawing.Size(640, 545);
            this.flpTablero.TabIndex = 1;
            //
            // lblTablero
            //
            this.lblTablero.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTablero.Location = new System.Drawing.Point(2, 2);
            this.lblTablero.Name = "lblTablero";
            this.lblTablero.Padding = new System.Windows.Forms.Padding(10, 8, 0, 8);
            this.lblTablero.Size = new System.Drawing.Size(118, 32);
            this.lblTablero.TabIndex = 0;
            this.lblTablero.Text = "Premios disponibles";
            //
            // frmTerminalPuntos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmTerminalPuntos";
            this.Text = "Terminal de Puntos";
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPuntos)).EndInit();
            this.pnlPuntos.ResumeLayout(false);
            this.pnlPuntos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResumen)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccionResumen)).EndInit();
            this.pnlAccionResumen.ResumeLayout(false);
            this.pnlAccionResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCentro)).EndInit();
            this.pnlCentro.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.LookUpEdit lkpCliente;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.PanelControl pnlPuntos;
        private DevExpress.XtraEditors.LabelControl lblPuntosValor;
        private DevExpress.XtraEditors.LabelControl lblPuntosTitulo;
        private DevExpress.XtraEditors.PanelControl pnlResumen;
        private DevExpress.XtraEditors.LabelControl lblPremiosTitulo;
        private DevExpress.XtraGrid.GridControl gcCarrito;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCarrito;
        private DevExpress.XtraEditors.PanelControl pnlAccionResumen;
        private DevExpress.XtraEditors.LabelControl lblMonto;
        private DevExpress.XtraEditors.SpinEdit spnMonto;
        private DevExpress.XtraEditors.LabelControl lblCanjearTitulo;
        private DevExpress.XtraEditors.LabelControl lblCanjearValor;
        private DevExpress.XtraEditors.LabelControl lblGanarTitulo;
        private DevExpress.XtraEditors.LabelControl lblGanarValor;
        private DevExpress.XtraEditors.LabelControl lblSaldoTitulo;
        private DevExpress.XtraEditors.LabelControl lblSaldoValor;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private DevExpress.XtraEditors.PanelControl pnlCentro;
        private DevExpress.XtraEditors.LabelControl lblTablero;
        private System.Windows.Forms.FlowLayoutPanel flpTablero;
    }
}
