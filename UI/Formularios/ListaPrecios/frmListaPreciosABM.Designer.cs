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
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(953, 20);
            this.txtDescripcion.TabIndex = 4;

            // 
            // dtVigenciaDesde
            // 
            this.dtVigenciaDesde.EditValue = null;
            this.dtVigenciaDesde.Location = new System.Drawing.Point(12, 36);
            this.dtVigenciaDesde.Name = "dtVigenciaDesde";
            this.dtVigenciaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaDesde.Size = new System.Drawing.Size(953, 20);
            this.dtVigenciaDesde.TabIndex = 5;

            // 
            // dtVigenciaHasta
            // 
            this.dtVigenciaHasta.EditValue = null;
            this.dtVigenciaHasta.Location = new System.Drawing.Point(12, 60);
            this.dtVigenciaHasta.Name = "dtVigenciaHasta";
            this.dtVigenciaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVigenciaHasta.Size = new System.Drawing.Size(953, 20);
            this.dtVigenciaHasta.TabIndex = 6;

            // 
            // chkEsPredeterminada
            // 
            this.chkEsPredeterminada.Location = new System.Drawing.Point(12, 84);
            this.chkEsPredeterminada.Name = "chkEsPredeterminada";
            this.chkEsPredeterminada.Properties.Caption = "Es Predeterminada";
            this.chkEsPredeterminada.Size = new System.Drawing.Size(953, 20);
            this.chkEsPredeterminada.TabIndex = 7;

            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Location = new System.Drawing.Point(12, 138);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(146, 30);
            this.btnAgregarFila.TabIndex = 8;
            this.btnAgregarFila.Text = "Agregar Artículo";

            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(162, 138);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(146, 30);
            this.btnQuitarFila.TabIndex = 9;
            this.btnQuitarFila.Text = "Quitar Artículo";

            // 
            // gridItems
            // 
            this.gridItems.Location = new System.Drawing.Point(12, 193);
            this.gridItems.MainView = this.gridViewItems;
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(953, 227);
            this.gridItems.TabIndex = 10;
            this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});

            // 
            // gridViewItems
            // 
            this.gridViewItems.GridControl = this.gridItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            this.gridViewItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

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
            this.lciBtnAgregar,
            this.lciBtnQuitar,
            this.lciGridItems});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Text = "Descripción:";

            // 
            // lciVigenciaDesde
            // 
            this.lciVigenciaDesde.Control = this.dtVigenciaDesde;
            this.lciVigenciaDesde.Name = "lciVigenciaDesde";
            this.lciVigenciaDesde.Text = "Vigencia Desde:";

            // 
            // lciVigenciaHasta
            // 
            this.lciVigenciaHasta.Control = this.dtVigenciaHasta;
            this.lciVigenciaHasta.Name = "lciVigenciaHasta";
            this.lciVigenciaHasta.Text = "Vigencia Hasta:";

            // 
            // lciEsPredeterminada
            // 
            this.lciEsPredeterminada.Control = this.chkEsPredeterminada;
            this.lciEsPredeterminada.Name = "lciEsPredeterminada";
            this.lciEsPredeterminada.TextVisible = false; // El checkbox ya tiene su propio texto

            // 
            // lciBtnAgregar
            // 
            this.lciBtnAgregar.Control = this.btnAgregarFila;
            this.lciBtnAgregar.Name = "lciBtnAgregar";
            this.lciBtnAgregar.TextVisible = false;
            this.lciBtnAgregar.MaxSize = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.MinSize = new System.Drawing.Size(150, 34);
            this.lciBtnAgregar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            // 
            // lciBtnQuitar
            // 
            this.lciBtnQuitar.Control = this.btnQuitarFila;
            this.lciBtnQuitar.Name = "lciBtnQuitar";
            this.lciBtnQuitar.TextVisible = false;
            this.lciBtnQuitar.MaxSize = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.MinSize = new System.Drawing.Size(150, 34);
            this.lciBtnQuitar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            // 
            // lciGridItems
            // 
            this.lciGridItems.Control = this.gridItems;
            this.lciGridItems.Name = "lciGridItems";
            this.lciGridItems.Text = "Artículos y Precios";
            this.lciGridItems.TextLocation = DevExpress.Utils.Locations.Top;

            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);

            // 
            // frmListaPreciosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 620);
            this.Name = "frmListaPreciosABM";
            this.Text = "Listas de Precios";

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