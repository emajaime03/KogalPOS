namespace UI.Formularios.Catalogos
{
    partial class frmCatalogosABM
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
            this.gcArticulos = new DevExpress.XtraGrid.GridControl();
            this.gvArticulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciArticulos = new DevExpress.XtraLayout.LayoutControlItem();

            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciArticulos)).BeginInit();
            this.SuspendLayout();

            this.txtDescripcion.Location = new System.Drawing.Point(12, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(953, 20);
            this.txtDescripcion.TabIndex = 4;

            this.gcArticulos.Location = new System.Drawing.Point(12, 55);
            this.gcArticulos.MainView = this.gvArticulos;
            this.gcArticulos.Name = "gcArticulos";
            this.gcArticulos.TabIndex = 5;
            this.gcArticulos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArticulos});

            this.gvArticulos.GridControl = this.gcArticulos;
            this.gvArticulos.Name = "gvArticulos";
            this.gvArticulos.OptionsView.ShowGroupPanel = false;

            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.gcArticulos);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.TabIndex = 0;

            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciArticulos});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(65, 13);
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Size = new System.Drawing.Size(957, 24);

            this.lciArticulos.Control = this.gcArticulos;
            this.lciArticulos.Name = "lciArticulos";
            this.lciArticulos.Text = "Artículos Asignados";
            this.lciArticulos.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciArticulos.TextSize = new System.Drawing.Size(65, 13);
            this.lciArticulos.Location = new System.Drawing.Point(0, 24);
            this.lciArticulos.MinSize = new System.Drawing.Size(100, 150);
            this.lciArticulos.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            this.panelContenido.Controls.Add(this.layoutControlHijo);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Name = "frmCatalogosABM";
            this.Text = "Catálogos";

            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciArticulos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraGrid.GridControl gcArticulos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArticulos;
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciArticulos;
    }
}
