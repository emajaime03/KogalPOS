namespace UI.Formularios.Administrador.ConfiguracionLocal
{
    partial class frmConfiguracionLocal
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
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.numPuntosOtorgados = new DevExpress.XtraEditors.SpinEdit();
            this.numMontoRequerido = new DevExpress.XtraEditors.SpinEdit();
            this.numMontoMinimo = new DevExpress.XtraEditors.SpinEdit();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciFidelizacion = new DevExpress.XtraLayout.SimpleLabelItem();
            this.lciMontoRequerido = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMontoMinimo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPuntosOtorgados = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntosOtorgados.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoRequerido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoMinimo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFidelizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMontoRequerido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMontoMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPuntosOtorgados)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.numPuntosOtorgados);
            this.layoutControlHijo.Controls.Add(this.numMontoRequerido);
            this.layoutControlHijo.Controls.Add(this.numMontoMinimo);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 263, 812, 500);
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(1140, 525);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // numPuntosOtorgados
            // 
            this.numPuntosOtorgados.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numPuntosOtorgados.Location = new System.Drawing.Point(679, 32);
            this.numPuntosOtorgados.Name = "numPuntosOtorgados";
            this.numPuntosOtorgados.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numPuntosOtorgados.Size = new System.Drawing.Size(449, 22);
            this.numPuntosOtorgados.StyleController = this.layoutControlHijo;
            this.numPuntosOtorgados.TabIndex = 10;
            // 
            // numMontoRequerido
            // 
            this.numMontoRequerido.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMontoRequerido.Location = new System.Drawing.Point(119, 32);
            this.numMontoRequerido.Name = "numMontoRequerido";
            // 
            // numMontoRequerido
            // 
            this.numMontoRequerido.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numMontoRequerido.Properties.Name = "numMontoRequerido";
            this.numMontoRequerido.Size = new System.Drawing.Size(449, 22);
            this.numMontoRequerido.StyleController = this.layoutControlHijo;
            this.numMontoRequerido.TabIndex = 9;
            // 
            // numMontoMinimo
            // 
            this.numMontoMinimo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMontoMinimo.Location = new System.Drawing.Point(119, 58);
            this.numMontoMinimo.Name = "numMontoMinimo";
            this.numMontoMinimo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numMontoMinimo.Size = new System.Drawing.Size(449, 22);
            this.numMontoMinimo.StyleController = this.layoutControlHijo;
            this.numMontoMinimo.TabIndex = 8;
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciFidelizacion,
            this.lciMontoRequerido,
            this.lciMontoMinimo,
            this.lciPuntosOtorgados});
            this.RootHijo.Name = "Root";
            this.RootHijo.Size = new System.Drawing.Size(1140, 525);
            this.RootHijo.TextVisible = false;
            // 
            // lciFidelizacion
            // 
            this.lciFidelizacion.AllowHotTrack = false;
            this.lciFidelizacion.Location = new System.Drawing.Point(0, 0);
            this.lciFidelizacion.Name = "lciFidelizacion";
            this.lciFidelizacion.Size = new System.Drawing.Size(1120, 20);
            this.lciFidelizacion.Text = "Fidelización";
            this.lciFidelizacion.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciMontoRequerido
            // 
            this.lciMontoRequerido.Control = this.numMontoRequerido;
            this.lciMontoRequerido.Location = new System.Drawing.Point(0, 20);
            this.lciMontoRequerido.Name = "lciMontoRequerido";
            this.lciMontoRequerido.Size = new System.Drawing.Size(560, 26);
            this.lciMontoRequerido.Text = "Monto Requerido:";
            this.lciMontoRequerido.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciMontoMinimo
            // 
            this.lciMontoMinimo.Control = this.numMontoMinimo;
            this.lciMontoMinimo.Location = new System.Drawing.Point(0, 46);
            this.lciMontoMinimo.Name = "lciMontoMinimo";
            this.lciMontoMinimo.Size = new System.Drawing.Size(560, 459);
            this.lciMontoMinimo.Text = "Monto Mínimo:";
            this.lciMontoMinimo.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciPuntosOtorgados
            // 
            this.lciPuntosOtorgados.Control = this.numPuntosOtorgados;
            this.lciPuntosOtorgados.Location = new System.Drawing.Point(560, 20);
            this.lciPuntosOtorgados.Name = "lciPuntosOtorgados";
            this.lciPuntosOtorgados.Size = new System.Drawing.Size(560, 485);
            this.lciPuntosOtorgados.Text = "Puntos Otorgados:";
            this.lciPuntosOtorgados.TextSize = new System.Drawing.Size(104, 16);
            // 
            // frmConfiguracionLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 661);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConfiguracionLocal";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPuntosOtorgados.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoRequerido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoMinimo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFidelizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMontoRequerido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMontoMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPuntosOtorgados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraEditors.SpinEdit numMontoMinimo;
        private DevExpress.XtraLayout.LayoutControlItem lciMontoMinimo;
        private DevExpress.XtraEditors.SpinEdit numPuntosOtorgados;
        private DevExpress.XtraEditors.SpinEdit numMontoRequerido;
        private DevExpress.XtraLayout.SimpleLabelItem lciFidelizacion;
        private DevExpress.XtraLayout.LayoutControlItem lciMontoRequerido;
        private DevExpress.XtraLayout.LayoutControlItem lciPuntosOtorgados;
    }
}