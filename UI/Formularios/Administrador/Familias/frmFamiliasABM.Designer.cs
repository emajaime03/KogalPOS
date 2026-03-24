using System.Collections.Generic;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Administrador.Familias
{
    partial class frmFamiliasABM
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
            this.gcFamiliasHijos = new DevExpress.XtraGrid.GridControl();
            this.gvFamiliasHijos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPatentes = new DevExpress.XtraGrid.GridControl();
            this.gvPatentes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();

            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFamiliasHijos = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPatentes = new DevExpress.XtraLayout.LayoutControlItem();

            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPatentes)).BeginInit();
            this.SuspendLayout();

            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(953, 20);
            this.txtDescripcion.TabIndex = 4;

            // 
            // gcFamiliasHijos
            // 
            this.gcFamiliasHijos.Location = new System.Drawing.Point(12, 52);
            this.gcFamiliasHijos.MainView = this.gvFamiliasHijos;
            this.gcFamiliasHijos.Name = "gcFamiliasHijos";
            this.gcFamiliasHijos.TabIndex = 5;
            this.gcFamiliasHijos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFamiliasHijos});

            // 
            // gvFamiliasHijos
            // 
            this.gvFamiliasHijos.GridControl = this.gcFamiliasHijos;
            this.gvFamiliasHijos.Name = "gvFamiliasHijos";
            this.gvFamiliasHijos.OptionsView.ShowGroupPanel = false;

            // 
            // gcPatentes
            // 
            this.gcPatentes.Location = new System.Drawing.Point(12, 226);
            this.gcPatentes.MainView = this.gvPatentes;
            this.gcPatentes.Name = "gcPatentes";
            this.gcPatentes.TabIndex = 6;
            this.gcPatentes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatentes});

            // 
            // gvPatentes
            // 
            this.gvPatentes.GridControl = this.gcPatentes;
            this.gvPatentes.Name = "gvPatentes";
            this.gvPatentes.OptionsView.ShowGroupPanel = false;

            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.gcFamiliasHijos);
            this.layoutControlHijo.Controls.Add(this.gcPatentes);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.TabIndex = 0;
            this.layoutControlHijo.Text = "layoutControl1";

            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciFamiliasHijos,
            this.lciPatentes});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(58, 13);

            // 
            // lciFamiliasHijos
            // 
            this.lciFamiliasHijos.Control = this.gcFamiliasHijos;
            this.lciFamiliasHijos.Name = "lciFamiliasHijos";
            this.lciFamiliasHijos.Text = "Familias Hijos";
            this.lciFamiliasHijos.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciFamiliasHijos.TextSize = new System.Drawing.Size(58, 13);
            this.lciFamiliasHijos.MinSize = new System.Drawing.Size(100, 150);
            this.lciFamiliasHijos.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            // 
            // lciPatentes
            // 
            this.lciPatentes.Control = this.gcPatentes;
            this.lciPatentes.Name = "lciPatentes";
            this.lciPatentes.Text = "Patentes";
            this.lciPatentes.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciPatentes.TextSize = new System.Drawing.Size(58, 13);
            this.lciPatentes.MinSize = new System.Drawing.Size(100, 150);
            this.lciPatentes.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            // 
            // panelContenido (Heredado del Base)
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);

            // 
            // frmFamiliasABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Name = "frmFamiliasABM";
            this.Text = "Familias";

            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPatentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraGrid.GridControl gcFamiliasHijos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFamiliasHijos;
        private DevExpress.XtraGrid.GridControl gcPatentes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatentes;

        // Variables del LayoutControl
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciFamiliasHijos;
        private DevExpress.XtraLayout.LayoutControlItem lciPatentes;
    }
}