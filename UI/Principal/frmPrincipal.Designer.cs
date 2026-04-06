
namespace UI.Principal
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbpAdmin = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpVentas = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpCompras = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpInventario = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpFidelizacion = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 542);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(938, 27);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpAdmin,
            this.rbpVentas,
            this.rbpCompras,
            this.rbpInventario,
            this.rbpFidelizacion});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbon.Size = new System.Drawing.Size(938, 121);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // rbpAdmin
            // 
            this.rbpAdmin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("rbpAdmin.ImageOptions.Image")));
            this.rbpAdmin.Name = "rbpAdmin";
            this.rbpAdmin.Text = "Admin";
            // 
            // rbpVentas
            // 
            this.rbpVentas.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("rbpVentas.ImageOptions.SvgImage")));
            this.rbpVentas.Name = "rbpVentas";
            this.rbpVentas.Text = "Ventas";
            // 
            // rbpCompras
            // 
            this.rbpCompras.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("rbpCompras.ImageOptions.SvgImage")));
            this.rbpCompras.Name = "rbpCompras";
            this.rbpCompras.Text = "Compras";
            // 
            // rbpInventario
            // 
            this.rbpInventario.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("rbpInventario.ImageOptions.SvgImage")));
            this.rbpInventario.Name = "rbpInventario";
            this.rbpInventario.Text = "Inventario";
            // 
            // rbpFidelizacion
            // 
            this.rbpFidelizacion.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("rbpFidelizacion.ImageOptions.SvgImage")));
            this.rbpFidelizacion.Name = "rbpFidelizacion";
            this.rbpFidelizacion.Text = "Fidelizacion";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentProperties.AllowFloat = false;
            // 
            // frmPrincipal
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 569);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPrincipal";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpAdmin;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpCompras;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpInventario;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpVentas;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpFidelizacion;
    }
}