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
            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.dtVigenciaDesde = new DevExpress.XtraEditors.DateEdit();
            this.dtVigenciaHasta = new DevExpress.XtraEditors.DateEdit();
            this.chkEsPredeterminada = new DevExpress.XtraEditors.CheckEdit();
            this.btnAgregarFila = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitarFila = new DevExpress.XtraEditors.SimpleButton();
            this.gridItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVigenciaDesde = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVigenciaHasta = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEsPredeterminada = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGridItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnQuitar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnAgregar = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEsPredeterminada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEsPredeterminada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInferior
            // 
            this.pnlInferior.Location = new System.Drawing.Point(0, 702);
            this.pnlInferior.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlInferior.Size = new System.Drawing.Size(1342, 68);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelContenido.Size = new System.Drawing.Size(1342, 634);
            // 
            // sepSuperior
            // 
            this.sepSuperior.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sepSuperior.Size = new System.Drawing.Size(1342, 1);
            // 
            // sepInferior
            // 
            this.sepInferior.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sepInferior.Size = new System.Drawing.Size(1342, 1);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(122, 14);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(1206, 22);
            this.txtDescripcion.StyleController = this.layoutControlHijo;
            this.txtDescripcion.TabIndex = 4;
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
            this.layoutControlHijo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(1342, 634);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // dtVigenciaDesde
            // 
            this.dtVigenciaDesde.EditValue = null;
            this.dtVigenciaDesde.Location = new System.Drawing.Point(122, 598);
            this.dtVigenciaDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtVigenciaDesde.Name = "dtVigenciaDesde";
            this.dtVigenciaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaDesde.Size = new System.Drawing.Size(1206, 22);
            this.dtVigenciaDesde.StyleController = this.layoutControlHijo;
            this.dtVigenciaDesde.TabIndex = 5;
            // 
            // dtVigenciaHasta
            // 
            this.dtVigenciaHasta.EditValue = null;
            this.dtVigenciaHasta.Location = new System.Drawing.Point(122, 572);
            this.dtVigenciaHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtVigenciaHasta.Name = "dtVigenciaHasta";
            this.dtVigenciaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaHasta.Size = new System.Drawing.Size(1206, 22);
            this.dtVigenciaHasta.StyleController = this.layoutControlHijo;
            this.dtVigenciaHasta.TabIndex = 6;
            // 
            // chkEsPredeterminada
            // 
            this.chkEsPredeterminada.Location = new System.Drawing.Point(14, 548);
            this.chkEsPredeterminada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEsPredeterminada.Name = "chkEsPredeterminada";
            this.chkEsPredeterminada.Properties.Caption = "Es Predeterminada";
            this.chkEsPredeterminada.Size = new System.Drawing.Size(1314, 20);
            this.chkEsPredeterminada.StyleController = this.layoutControlHijo;
            this.chkEsPredeterminada.TabIndex = 7;
            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Location = new System.Drawing.Point(14, 506);
            this.btnAgregarFila.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(171, 38);
            this.btnAgregarFila.StyleController = this.layoutControlHijo;
            this.btnAgregarFila.TabIndex = 8;
            this.btnAgregarFila.Text = "Agregar Artículo";
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(189, 506);
            this.btnQuitarFila.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(171, 38);
            this.btnQuitarFila.StyleController = this.layoutControlHijo;
            this.btnQuitarFila.TabIndex = 9;
            this.btnQuitarFila.Text = "Quitar Artículo";
            // 
            // gridItems
            // 
            this.gridItems.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridItems.Location = new System.Drawing.Point(14, 60);
            this.gridItems.MainView = this.gridViewItems;
            this.gridItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(1314, 442);
            this.gridItems.TabIndex = 10;
            this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
            // 
            // gridViewItems
            // 
            this.gridViewItems.DetailHeight = 431;
            this.gridViewItems.GridControl = this.gridItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
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
            this.RootHijo.Size = new System.Drawing.Size(1342, 634);
            this.RootHijo.TextVisible = false;
            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Size = new System.Drawing.Size(1318, 26);
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciVigenciaDesde
            // 
            this.lciVigenciaDesde.Control = this.dtVigenciaDesde;
            this.lciVigenciaDesde.Location = new System.Drawing.Point(0, 584);
            this.lciVigenciaDesde.Name = "lciVigenciaDesde";
            this.lciVigenciaDesde.Size = new System.Drawing.Size(1318, 26);
            this.lciVigenciaDesde.Text = "Vigencia Desde:";
            this.lciVigenciaDesde.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciVigenciaHasta
            // 
            this.lciVigenciaHasta.Control = this.dtVigenciaHasta;
            this.lciVigenciaHasta.Location = new System.Drawing.Point(0, 558);
            this.lciVigenciaHasta.Name = "lciVigenciaHasta";
            this.lciVigenciaHasta.Size = new System.Drawing.Size(1318, 26);
            this.lciVigenciaHasta.Text = "Vigencia Hasta:";
            this.lciVigenciaHasta.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciEsPredeterminada
            // 
            this.lciEsPredeterminada.Control = this.chkEsPredeterminada;
            this.lciEsPredeterminada.Location = new System.Drawing.Point(0, 534);
            this.lciEsPredeterminada.Name = "lciEsPredeterminada";
            this.lciEsPredeterminada.Size = new System.Drawing.Size(1318, 24);
            this.lciEsPredeterminada.TextSize = new System.Drawing.Size(0, 0);
            this.lciEsPredeterminada.TextVisible = false;
            // 
            // lciGridItems
            // 
            this.lciGridItems.Control = this.gridItems;
            this.lciGridItems.Location = new System.Drawing.Point(0, 26);
            this.lciGridItems.MinSize = new System.Drawing.Size(117, 185);
            this.lciGridItems.Name = "lciGridItems";
            this.lciGridItems.Size = new System.Drawing.Size(1318, 466);
            this.lciGridItems.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGridItems.Text = "Artículos y Precios";
            this.lciGridItems.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciGridItems.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciBtnQuitar
            // 
            this.lciBtnQuitar.Control = this.btnQuitarFila;
            this.lciBtnQuitar.Location = new System.Drawing.Point(175, 492);
            this.lciBtnQuitar.MaxSize = new System.Drawing.Size(175, 42);
            this.lciBtnQuitar.MinSize = new System.Drawing.Size(175, 42);
            this.lciBtnQuitar.Name = "lciBtnQuitar";
            this.lciBtnQuitar.Size = new System.Drawing.Size(1143, 42);
            this.lciBtnQuitar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnQuitar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnQuitar.TextVisible = false;
            // 
            // lciBtnAgregar
            // 
            this.lciBtnAgregar.Control = this.btnAgregarFila;
            this.lciBtnAgregar.Location = new System.Drawing.Point(0, 492);
            this.lciBtnAgregar.MaxSize = new System.Drawing.Size(175, 42);
            this.lciBtnAgregar.MinSize = new System.Drawing.Size(175, 42);
            this.lciBtnAgregar.Name = "lciBtnAgregar";
            this.lciBtnAgregar.Size = new System.Drawing.Size(175, 42);
            this.lciBtnAgregar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnAgregar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnAgregar.TextVisible = false;
            // 
            // frmListaPreciosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 770);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmListaPreciosABM";
            this.Text = "Listas de Precios";
            this.Controls.SetChildIndex(this.pnlInferior, 0);
            this.Controls.SetChildIndex(this.panelContenido, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVigenciaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEsPredeterminada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVigenciaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEsPredeterminada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAgregar)).EndInit();
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