namespace UI.Formularios.Ventas
{
    partial class frmVentaVista
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
            this.gcItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblNroVenta = new DevExpress.XtraEditors.LabelControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.lblEstado = new DevExpress.XtraEditors.LabelControl();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.lblLista = new DevExpress.XtraEditors.LabelControl();
            this.lblComprobante = new DevExpress.XtraEditors.LabelControl();
            this.lblFormaPago = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnular = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblDescuento = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.gcItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItems.Location = new System.Drawing.Point(0, 110);
            this.gcItems.MainView = this.gvItems;
            this.gcItems.Name = "gcItems";
            this.gcItems.Size = new System.Drawing.Size(720, 350);
            this.gcItems.TabIndex = 0;
            this.gcItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});

            this.gvItems.GridControl = this.gcItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsBehavior.Editable = false;
            this.gvItems.OptionsView.ShowGroupPanel = false;

            this.pnlHeader.Controls.Add(this.lblFormaPago);
            this.pnlHeader.Controls.Add(this.lblComprobante);
            this.pnlHeader.Controls.Add(this.lblLista);
            this.pnlHeader.Controls.Add(this.lblCliente);
            this.pnlHeader.Controls.Add(this.lblEstado);
            this.pnlHeader.Controls.Add(this.lblFecha);
            this.pnlHeader.Controls.Add(this.lblNroVenta);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(720, 110);
            this.pnlHeader.TabIndex = 1;

            this.lblNroVenta.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblNroVenta.Appearance.Options.UseFont = true;
            this.lblNroVenta.Location = new System.Drawing.Point(16, 14);
            this.lblNroVenta.Name = "lblNroVenta";
            this.lblNroVenta.Size = new System.Drawing.Size(64, 18);
            this.lblNroVenta.TabIndex = 0;
            this.lblNroVenta.Text = "Nº Venta:";

            this.lblFecha.Location = new System.Drawing.Point(16, 44);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(34, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";

            this.lblEstado.Location = new System.Drawing.Point(16, 70);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(38, 13);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";

            this.lblCliente.Location = new System.Drawing.Point(360, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";

            this.lblLista.Location = new System.Drawing.Point(360, 40);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(72, 13);
            this.lblLista.TabIndex = 4;
            this.lblLista.Text = "Lista de Precios:";

            this.lblComprobante.Location = new System.Drawing.Point(360, 64);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(70, 13);
            this.lblComprobante.TabIndex = 5;
            this.lblComprobante.Text = "Comprobante:";

            this.lblFormaPago.Location = new System.Drawing.Point(360, 88);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(73, 13);
            this.lblFormaPago.TabIndex = 6;
            this.lblFormaPago.Text = "Forma de Pago:";

            this.pnlBottom.Controls.Add(this.btnCerrar);
            this.pnlBottom.Controls.Add(this.btnAnular);
            this.pnlBottom.Controls.Add(this.lblDescuento);
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalTitulo);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 460);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(720, 60);
            this.pnlBottom.TabIndex = 2;

            this.lblTotalTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitulo.Appearance.Options.UseFont = true;
            this.lblTotalTitulo.Location = new System.Drawing.Point(16, 20);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(48, 19);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "Total:";

            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Location = new System.Drawing.Point(90, 18);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 23);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0,00";

            this.lblDescuento.Location = new System.Drawing.Point(260, 24);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(60, 13);
            this.lblDescuento.TabIndex = 4;
            this.lblDescuento.Text = "Descuento:";

            this.btnAnular.Location = new System.Drawing.Point(500, 16);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(100, 30);
            this.btnAnular.TabIndex = 2;
            this.btnAnular.Text = "Anular";

            this.btnCerrar.Location = new System.Drawing.Point(606, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 520);
            this.Controls.Add(this.gcItems);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmVentaVista";
            this.Text = "Detalle de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.gcItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblNroVenta;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblEstado;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.LabelControl lblLista;
        private DevExpress.XtraEditors.LabelControl lblComprobante;
        private DevExpress.XtraEditors.LabelControl lblFormaPago;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.LabelControl lblTotalTitulo;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl lblDescuento;
        private DevExpress.XtraEditors.SimpleButton btnAnular;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
    }
}
