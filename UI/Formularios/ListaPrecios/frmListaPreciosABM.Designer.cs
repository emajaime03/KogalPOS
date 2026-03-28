using UI.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace UI.Formularios.ListaPrecios
{
    partial class frmListaPreciosABM
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
            this.dtVigenciaDesde = new DevExpress.XtraEditors.DateEdit();
            this.dtVigenciaHasta = new DevExpress.XtraEditors.DateEdit();
            this.chkEsPredeterminada = new DevExpress.XtraEditors.CheckEdit();
            this.gridItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAgregarFila = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitarFila = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVigenciaDesde = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVigenciaHasta = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEsPredeterminada = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnAgregar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnQuitar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGridItems = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEsPredeterminada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEsPredeterminada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Size = new System.Drawing.Size(1150, 55);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Location = new System.Drawing.Point(0, 571);
            this.pnlInferior.Size = new System.Drawing.Size(1150, 55);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            this.panelContenido.Size = new System.Drawing.Size(1150, 516);
            // 
            // sepSuperior
            // 
            this.sepSuperior.Size = new System.Drawing.Size(1150, 1);
            // 
            // sepInferior
            // 
            this.sepInferior.Size = new System.Drawing.Size(1150, 1);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(102, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(1036, 20);
            this.txtDescripcion.StyleController = this.layoutControlHijo;
            this.txtDescripcion.TabIndex = 4;
            // 
            // dtVigenciaDesde
            // 
            this.dtVigenciaDesde.EditValue = null;
            this.dtVigenciaDesde.Location = new System.Drawing.Point(102, 484);
            this.dtVigenciaDesde.Name = "dtVigenciaDesde";
            this.dtVigenciaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaDesde.Size = new System.Drawing.Size(1036, 20);
            this.dtVigenciaDesde.StyleController = this.layoutControlHijo;
            this.dtVigenciaDesde.TabIndex = 5;
            // 
            // dtVigenciaHasta
            // 
            this.dtVigenciaHasta.EditValue = null;
            this.dtVigenciaHasta.Location = new System.Drawing.Point(102, 460);
            this.dtVigenciaHasta.Name = "dtVigenciaHasta";
            this.dtVigenciaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaHasta.Size = new System.Drawing.Size(1036, 20);
            this.dtVigenciaHasta.StyleController = this.layoutControlHijo;
            this.dtVigenciaHasta.TabIndex = 6;
            // 
            // chkEsPredeterminada
            // 
            this.chkEsPredeterminada.Location = new System.Drawing.Point(12, 437);
            this.chkEsPredeterminada.Name = "chkEsPredeterminada";
            this.chkEsPredeterminada.Properties.Caption = "Es Predeterminada";
            this.chkEsPredeterminada.Size = new System.Drawing.Size(1126, 19);
            this.chkEsPredeterminada.StyleController = this.layoutControlHijo;
            this.chkEsPredeterminada.TabIndex = 7;
            // 
            // gridItems
            // 
            this.gridItems.Location = new System.Drawing.Point(12, 86);
            this.gridItems.MainView = this.gridViewItems;
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(1126, 347);
            this.gridItems.TabIndex = 10;
            this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
            // 
            // gridViewItems
            // 
            this.gridViewItems.GridControl = this.gridItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Location = new System.Drawing.Point(992, 36);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(146, 30);
            this.btnAgregarFila.StyleController = this.layoutControlHijo;
            this.btnAgregarFila.TabIndex = 8;
            this.btnAgregarFila.Text = "Agregar Artículo";
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(842, 36);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(146, 30);
            this.btnQuitarFila.StyleController = this.layoutControlHijo;
            this.btnQuitarFila.TabIndex = 9;
            this.btnQuitarFila.Text = "Quitar Artículo";
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.dtVigenciaDesde);
            this.layoutControlHijo.Controls.Add(this.dtVigenciaHasta);
            this.layoutControlHijo.Controls.Add(this.chkEsPredeterminada);
            this.layoutControlHijo.Controls.Add(this.btnAgregarFila);
            this.layoutControlHijo.Controls.Add(this.btnQuitarFila);
            this.layoutControlHijo.Controls.Add(this.gridItems);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(1150, 516);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciVigenciaDesde,
            this.lciVigenciaHasta,
            this.lciEsPredeterminada,
            this.lciGridItems,
            this.lciBtnQuitar,
            this.lciBtnAgregar});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(1150, 516);
            this.RootHijo.TextVisible = false;
            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Size = new System.Drawing.Size(1130, 24);
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(87, 13);
            // 
            // lciVigenciaDesde
            // 
            this.lciVigenciaDesde.Control = this.dtVigenciaDesde;
            this.lciVigenciaDesde.Location = new System.Drawing.Point(0, 472);
            this.lciVigenciaDesde.Name = "lciVigenciaDesde";
            this.lciVigenciaDesde.Size = new System.Drawing.Size(1130, 24);
            this.lciVigenciaDesde.Text = "Vigencia Desde:";
            this.lciVigenciaDesde.TextSize = new System.Drawing.Size(87, 13);
            // 
            // lciVigenciaHasta
            // 
            this.lciVigenciaHasta.Control = this.dtVigenciaHasta;
            this.lciVigenciaHasta.Location = new System.Drawing.Point(0, 448);
            this.lciVigenciaHasta.Name = "lciVigenciaHasta";
            this.lciVigenciaHasta.Size = new System.Drawing.Size(1130, 24);
            this.lciVigenciaHasta.Text = "Vigencia Hasta:";
            this.lciVigenciaHasta.TextSize = new System.Drawing.Size(87, 13);
            // 
            // lciEsPredeterminada
            // 
            this.lciEsPredeterminada.Control = this.chkEsPredeterminada;
            this.lciEsPredeterminada.Location = new System.Drawing.Point(0, 425);
            this.lciEsPredeterminada.Name = "lciEsPredeterminada";
            this.lciEsPredeterminada.Size = new System.Drawing.Size(1130, 23);
            this.lciEsPredeterminada.TextSize = new System.Drawing.Size(0, 0);
            this.lciEsPredeterminada.TextVisible = false;
            // 
            // lciBtnAgregar
            // 
            this.lciBtnAgregar.Control = this.btnAgregarFila;
            this.lciBtnAgregar.Location = new System.Drawing.Point(980, 24);
            this.lciBtnAgregar.MaxSize = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.MinSize = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.Name = "lciBtnAgregar";
            this.lciBtnAgregar.Size = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnAgregar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnAgregar.TextVisible = false;
            // 
            // lciBtnQuitar
            // 
            this.lciBtnQuitar.Control = this.btnQuitarFila;
            this.lciBtnQuitar.Location = new System.Drawing.Point(830, 24);
            this.lciBtnQuitar.MaxSize = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.MinSize = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.Name = "lciBtnQuitar";
            this.lciBtnQuitar.Size = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnQuitar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnQuitar.TextVisible = false;
            // 
            // lciGridItems
            // 
            this.lciGridItems.Control = this.gridItems;
            this.lciGridItems.Location = new System.Drawing.Point(0, 58);
            this.lciGridItems.MinSize = new System.Drawing.Size(100, 150);
            this.lciGridItems.Name = "lciGridItems";
            this.lciGridItems.Size = new System.Drawing.Size(1130, 367);
            this.lciGridItems.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGridItems.Text = "Artículos y Precios";
            this.lciGridItems.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciGridItems.TextSize = new System.Drawing.Size(87, 13);
            // 
            // frmListaPreciosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 626);
            this.Name = "frmListaPreciosABM";
            this.Text = "Listas de Precios";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEsPredeterminada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEsPredeterminada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.DateEdit dtVigenciaDesde;
        private DevExpress.XtraEditors.DateEdit dtVigenciaHasta;
        private DevExpress.XtraEditors.CheckEdit chkEsPredeterminada;
        private DevExpress.XtraGrid.GridControl gridItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraEditors.SimpleButton btnAgregarFila;
        private DevExpress.XtraEditors.SimpleButton btnQuitarFila;

        // Variables del LayoutControl
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciVigenciaDesde;
        private DevExpress.XtraLayout.LayoutControlItem lciVigenciaHasta;
        private DevExpress.XtraLayout.LayoutControlItem lciEsPredeterminada;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnAgregar;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnQuitar;
        private DevExpress.XtraLayout.LayoutControlItem lciGridItems;
    }
}   