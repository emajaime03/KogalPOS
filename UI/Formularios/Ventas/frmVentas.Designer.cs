namespace UI.Formularios.Ventas
{
    partial class frmVentas
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
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuevoCliente = new DevExpress.XtraEditors.SimpleButton();
            this.lkpCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.lkpListaPrecio = new DevExpress.XtraEditors.LookUpEdit();
            this.lblListaPrecio = new DevExpress.XtraEditors.LabelControl();
            this.pnlCarrito = new DevExpress.XtraEditors.PanelControl();
            this.gcCarrito = new DevExpress.XtraGrid.GridControl();
            this.gvCarrito = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlCarritoBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCobrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblDescuentoValor = new DevExpress.XtraEditors.LabelControl();
            this.cmbTipoDescuento = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spnDescuento = new DevExpress.XtraEditors.SpinEdit();
            this.lblDescuentoTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblSubtotal = new DevExpress.XtraEditors.LabelControl();
            this.lblSubtotalTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblCarritoTitulo = new DevExpress.XtraEditors.LabelControl();
            this.pnlCentro = new DevExpress.XtraEditors.PanelControl();
            this.flpTablero = new System.Windows.Forms.FlowLayoutPanel();
            this.flpBreadcrumb = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpListaPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCarrito)).BeginInit();
            this.pnlCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCarritoBottom)).BeginInit();
            this.pnlCarritoBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCentro)).BeginInit();
            this.pnlCentro.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.btnActualizar);
            this.pnlTop.Controls.Add(this.btnNuevoCliente);
            this.pnlTop.Controls.Add(this.lkpCliente);
            this.pnlTop.Controls.Add(this.lblCliente);
            this.pnlTop.Controls.Add(this.lkpListaPrecio);
            this.pnlTop.Controls.Add(this.lblListaPrecio);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 50);
            this.pnlTop.TabIndex = 0;

            this.lblListaPrecio.Location = new System.Drawing.Point(12, 18);
            this.lblListaPrecio.Name = "lblListaPrecio";
            this.lblListaPrecio.Size = new System.Drawing.Size(72, 13);
            this.lblListaPrecio.TabIndex = 0;
            this.lblListaPrecio.Text = "Lista de Precios:";

            this.lkpListaPrecio.Location = new System.Drawing.Point(110, 14);
            this.lkpListaPrecio.Name = "lkpListaPrecio";
            this.lkpListaPrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpListaPrecio.Size = new System.Drawing.Size(240, 20);
            this.lkpListaPrecio.TabIndex = 1;

            this.lblCliente.Location = new System.Drawing.Point(390, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";

            this.lkpCliente.Location = new System.Drawing.Point(445, 14);
            this.lkpCliente.Name = "lkpCliente";
            this.lkpCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCliente.Size = new System.Drawing.Size(240, 20);
            this.lkpCliente.TabIndex = 3;

            this.btnNuevoCliente.Location = new System.Drawing.Point(691, 14);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(30, 20);
            this.btnNuevoCliente.TabIndex = 4;
            this.btnNuevoCliente.Text = "+";

            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(978, 13);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 24);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";

            // pnlCarrito
            this.pnlCarrito.Controls.Add(this.gcCarrito);
            this.pnlCarrito.Controls.Add(this.pnlCarritoBottom);
            this.pnlCarrito.Controls.Add(this.lblCarritoTitulo);
            this.pnlCarrito.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCarrito.Location = new System.Drawing.Point(580, 50);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Size = new System.Drawing.Size(520, 550);
            this.pnlCarrito.TabIndex = 2;

            this.lblCarritoTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCarritoTitulo.Appearance.Options.UseFont = true;
            this.lblCarritoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCarritoTitulo.Location = new System.Drawing.Point(2, 2);
            this.lblCarritoTitulo.Name = "lblCarritoTitulo";
            this.lblCarritoTitulo.Padding = new System.Windows.Forms.Padding(6);
            this.lblCarritoTitulo.Size = new System.Drawing.Size(516, 29);
            this.lblCarritoTitulo.TabIndex = 0;
            this.lblCarritoTitulo.Text = "Carrito";

            this.gcCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCarrito.Location = new System.Drawing.Point(2, 31);
            this.gcCarrito.MainView = this.gvCarrito;
            this.gcCarrito.Name = "gcCarrito";
            this.gcCarrito.Size = new System.Drawing.Size(516, 337);
            this.gcCarrito.TabIndex = 1;
            this.gcCarrito.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCarrito});

            this.gvCarrito.GridControl = this.gcCarrito;
            this.gvCarrito.Name = "gvCarrito";
            this.gvCarrito.OptionsView.ShowGroupPanel = false;

            // pnlCarritoBottom
            this.pnlCarritoBottom.Controls.Add(this.btnCobrar);
            this.pnlCarritoBottom.Controls.Add(this.btnLimpiar);
            this.pnlCarritoBottom.Controls.Add(this.lblTotal);
            this.pnlCarritoBottom.Controls.Add(this.lblTotalTitulo);
            this.pnlCarritoBottom.Controls.Add(this.lblDescuentoValor);
            this.pnlCarritoBottom.Controls.Add(this.cmbTipoDescuento);
            this.pnlCarritoBottom.Controls.Add(this.spnDescuento);
            this.pnlCarritoBottom.Controls.Add(this.lblDescuentoTitulo);
            this.pnlCarritoBottom.Controls.Add(this.lblSubtotal);
            this.pnlCarritoBottom.Controls.Add(this.lblSubtotalTitulo);
            this.pnlCarritoBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCarritoBottom.Location = new System.Drawing.Point(2, 368);
            this.pnlCarritoBottom.Name = "pnlCarritoBottom";
            this.pnlCarritoBottom.Size = new System.Drawing.Size(516, 180);
            this.pnlCarritoBottom.TabIndex = 2;

            this.lblSubtotalTitulo.Location = new System.Drawing.Point(16, 14);
            this.lblSubtotalTitulo.Name = "lblSubtotalTitulo";
            this.lblSubtotalTitulo.Size = new System.Drawing.Size(46, 13);
            this.lblSubtotalTitulo.TabIndex = 0;
            this.lblSubtotalTitulo.Text = "Subtotal:";

            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSubtotal.Appearance.Options.UseTextOptions = true;
            this.lblSubtotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSubtotal.Location = new System.Drawing.Point(300, 14);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(200, 16);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "$ 0,00";

            this.lblDescuentoTitulo.Location = new System.Drawing.Point(16, 46);
            this.lblDescuentoTitulo.Name = "lblDescuentoTitulo";
            this.lblDescuentoTitulo.Size = new System.Drawing.Size(58, 13);
            this.lblDescuentoTitulo.TabIndex = 2;
            this.lblDescuentoTitulo.Text = "Descuento:";

            this.spnDescuento.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spnDescuento.Location = new System.Drawing.Point(96, 42);
            this.spnDescuento.Name = "spnDescuento";
            this.spnDescuento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.spnDescuento.Properties.DisplayFormat.FormatString = "N2";
            this.spnDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnDescuento.Properties.EditFormat.FormatString = "N2";
            this.spnDescuento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnDescuento.Size = new System.Drawing.Size(78, 20);
            this.spnDescuento.TabIndex = 3;

            this.cmbTipoDescuento.Location = new System.Drawing.Point(180, 42);
            this.cmbTipoDescuento.Name = "cmbTipoDescuento";
            this.cmbTipoDescuento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoDescuento.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTipoDescuento.Size = new System.Drawing.Size(50, 20);
            this.cmbTipoDescuento.TabIndex = 4;

            this.lblDescuentoValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescuentoValor.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescuentoValor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDescuentoValor.Appearance.Options.UseForeColor = true;
            this.lblDescuentoValor.Appearance.Options.UseTextOptions = true;
            this.lblDescuentoValor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescuentoValor.Location = new System.Drawing.Point(300, 46);
            this.lblDescuentoValor.Name = "lblDescuentoValor";
            this.lblDescuentoValor.Size = new System.Drawing.Size(200, 16);
            this.lblDescuentoValor.TabIndex = 5;
            this.lblDescuentoValor.Text = "- $ 0,00";

            this.lblTotalTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitulo.Appearance.Options.UseFont = true;
            this.lblTotalTitulo.Location = new System.Drawing.Point(16, 86);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(64, 23);
            this.lblTotalTitulo.TabIndex = 6;
            this.lblTotalTitulo.Text = "TOTAL:";

            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Appearance.Options.UseTextOptions = true;
            this.lblTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotal.Location = new System.Drawing.Point(240, 80);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(260, 34);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "$ 0,00";

            this.btnLimpiar.Location = new System.Drawing.Point(16, 130);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";

            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnCobrar.Appearance.Options.UseFont = true;
            this.btnCobrar.Location = new System.Drawing.Point(336, 124);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(164, 46);
            this.btnCobrar.TabIndex = 9;
            this.btnCobrar.Text = "Cobrar";

            // pnlCentro
            this.pnlCentro.Controls.Add(this.flpTablero);
            this.pnlCentro.Controls.Add(this.flpBreadcrumb);
            this.pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentro.Location = new System.Drawing.Point(0, 50);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(580, 550);
            this.pnlCentro.TabIndex = 3;

            this.flpBreadcrumb.BackColor = System.Drawing.Color.White;
            this.flpBreadcrumb.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpBreadcrumb.Location = new System.Drawing.Point(2, 2);
            this.flpBreadcrumb.Name = "flpBreadcrumb";
            this.flpBreadcrumb.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.flpBreadcrumb.Size = new System.Drawing.Size(576, 40);
            this.flpBreadcrumb.TabIndex = 0;
            this.flpBreadcrumb.WrapContents = false;

            this.flpTablero.AutoScroll = true;
            this.flpTablero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.flpTablero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTablero.Location = new System.Drawing.Point(2, 42);
            this.flpTablero.Name = "flpTablero";
            this.flpTablero.Padding = new System.Windows.Forms.Padding(8);
            this.flpTablero.Size = new System.Drawing.Size(576, 506);
            this.flpTablero.TabIndex = 1;

            // frmVentas
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.pnlCarrito);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmVentas";
            this.Text = "Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpListaPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCarrito)).EndInit();
            this.pnlCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCarritoBottom)).EndInit();
            this.pnlCarritoBottom.ResumeLayout(false);
            this.pnlCarritoBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCentro)).EndInit();
            this.pnlCentro.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LabelControl lblListaPrecio;
        private DevExpress.XtraEditors.LookUpEdit lkpListaPrecio;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.LookUpEdit lkpCliente;
        private DevExpress.XtraEditors.SimpleButton btnNuevoCliente;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.PanelControl pnlCarrito;
        private DevExpress.XtraEditors.LabelControl lblCarritoTitulo;
        private DevExpress.XtraGrid.GridControl gcCarrito;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCarrito;
        private DevExpress.XtraEditors.PanelControl pnlCarritoBottom;
        private DevExpress.XtraEditors.LabelControl lblSubtotalTitulo;
        private DevExpress.XtraEditors.LabelControl lblSubtotal;
        private DevExpress.XtraEditors.LabelControl lblDescuentoTitulo;
        private DevExpress.XtraEditors.SpinEdit spnDescuento;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoDescuento;
        private DevExpress.XtraEditors.LabelControl lblDescuentoValor;
        private DevExpress.XtraEditors.LabelControl lblTotalTitulo;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.SimpleButton btnCobrar;
        private DevExpress.XtraEditors.PanelControl pnlCentro;
        private System.Windows.Forms.FlowLayoutPanel flpTablero;
        private System.Windows.Forms.FlowLayoutPanel flpBreadcrumb;
    }
}
