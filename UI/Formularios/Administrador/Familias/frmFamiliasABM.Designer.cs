
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcPatentes = new DevExpress.XtraGrid.GridControl();
            this.gvPatentes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblPatentes = new DevExpress.XtraEditors.LabelControl();
            this.gcFamiliasHijos = new DevExpress.XtraGrid.GridControl();
            this.gvFamiliasHijos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblFamiliasHijos = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestaurar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnModificar = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcModificar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcEliminar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcRestaurar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcAceptar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcCancelar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcModificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcPatentes);
            this.layoutControl1.Controls.Add(this.lblPatentes);
            this.layoutControl1.Controls.Add(this.gcFamiliasHijos);
            this.layoutControl1.Controls.Add(this.lblFamiliasHijos);
            this.layoutControl1.Controls.Add(this.txtDescripcion);
            this.layoutControl1.Controls.Add(this.btnCancelar);
            this.layoutControl1.Controls.Add(this.btnAceptar);
            this.layoutControl1.Controls.Add(this.btnRestaurar);
            this.layoutControl1.Controls.Add(this.btnEliminar);
            this.layoutControl1.Controls.Add(this.btnModificar);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(977, 537);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcPatentes
            // 
            this.gcPatentes.Location = new System.Drawing.Point(12, 279);
            this.gcPatentes.MainView = this.gvPatentes;
            this.gcPatentes.Name = "gcPatentes";
            this.gcPatentes.Size = new System.Drawing.Size(953, 220);
            this.gcPatentes.TabIndex = 13;
            this.gcPatentes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatentes});
            // 
            // gvPatentes
            // 
            this.gvPatentes.GridControl = this.gcPatentes;
            this.gvPatentes.Name = "gvPatentes";
            this.gvPatentes.OptionsView.ShowGroupPanel = false;
            // 
            // lblPatentes
            // 
            this.lblPatentes.Location = new System.Drawing.Point(12, 262);
            this.lblPatentes.Name = "lblPatentes";
            this.lblPatentes.Size = new System.Drawing.Size(43, 13);
            this.lblPatentes.StyleController = this.layoutControl1;
            this.lblPatentes.TabIndex = 12;
            this.lblPatentes.Text = "Patentes";
            // 
            // gcFamiliasHijos
            // 
            this.gcFamiliasHijos.Location = new System.Drawing.Point(12, 79);
            this.gcFamiliasHijos.MainView = this.gvFamiliasHijos;
            this.gcFamiliasHijos.Name = "gcFamiliasHijos";
            this.gcFamiliasHijos.Size = new System.Drawing.Size(953, 179);
            this.gcFamiliasHijos.TabIndex = 11;
            this.gcFamiliasHijos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFamiliasHijos});
            // 
            // gvFamiliasHijos
            // 
            this.gvFamiliasHijos.GridControl = this.gcFamiliasHijos;
            this.gvFamiliasHijos.Name = "gvFamiliasHijos";
            this.gvFamiliasHijos.OptionsView.ShowGroupPanel = false;
            // 
            // lblFamiliasHijos
            // 
            this.lblFamiliasHijos.Location = new System.Drawing.Point(12, 62);
            this.lblFamiliasHijos.Name = "lblFamiliasHijos";
            this.lblFamiliasHijos.Size = new System.Drawing.Size(63, 13);
            this.lblFamiliasHijos.StyleController = this.layoutControl1;
            this.lblFamiliasHijos.TabIndex = 10;
            this.lblFamiliasHijos.Text = "Familias Hijos";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(69, 38);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(896, 20);
            this.txtDescripcion.StyleController = this.layoutControl1;
            this.txtDescripcion.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(490, 503);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(475, 22);
            this.btnCancelar.StyleController = this.layoutControl1;
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 503);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(474, 22);
            this.btnAceptar.StyleController = this.layoutControl1;
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(649, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(316, 22);
            this.btnRestaurar.StyleController = this.layoutControl1;
            this.btnRestaurar.TabIndex = 6;
            this.btnRestaurar.Text = "Restaurar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(331, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(314, 22);
            this.btnEliminar.StyleController = this.layoutControl1;
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(315, 22);
            this.btnModificar.StyleController = this.layoutControl1;
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcModificar,
            this.lcEliminar,
            this.lcRestaurar,
            this.lcAceptar,
            this.lcCancelar,
            this.lcDescripcion,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(977, 537);
            this.Root.TextVisible = false;
            // 
            // lcModificar
            // 
            this.lcModificar.Control = this.btnModificar;
            this.lcModificar.Location = new System.Drawing.Point(0, 0);
            this.lcModificar.Name = "lcModificar";
            this.lcModificar.Size = new System.Drawing.Size(319, 26);
            this.lcModificar.TextSize = new System.Drawing.Size(0, 0);
            this.lcModificar.TextVisible = false;
            // 
            // lcEliminar
            // 
            this.lcEliminar.Control = this.btnEliminar;
            this.lcEliminar.Location = new System.Drawing.Point(319, 0);
            this.lcEliminar.Name = "lcEliminar";
            this.lcEliminar.Size = new System.Drawing.Size(318, 26);
            this.lcEliminar.TextSize = new System.Drawing.Size(0, 0);
            this.lcEliminar.TextVisible = false;
            // 
            // lcRestaurar
            // 
            this.lcRestaurar.Control = this.btnRestaurar;
            this.lcRestaurar.Location = new System.Drawing.Point(637, 0);
            this.lcRestaurar.Name = "lcRestaurar";
            this.lcRestaurar.Size = new System.Drawing.Size(320, 26);
            this.lcRestaurar.TextSize = new System.Drawing.Size(0, 0);
            this.lcRestaurar.TextVisible = false;
            // 
            // lcAceptar
            // 
            this.lcAceptar.Control = this.btnAceptar;
            this.lcAceptar.Location = new System.Drawing.Point(0, 491);
            this.lcAceptar.Name = "lcAceptar";
            this.lcAceptar.Size = new System.Drawing.Size(478, 26);
            this.lcAceptar.TextSize = new System.Drawing.Size(0, 0);
            this.lcAceptar.TextVisible = false;
            // 
            // lcCancelar
            // 
            this.lcCancelar.Control = this.btnCancelar;
            this.lcCancelar.Location = new System.Drawing.Point(478, 491);
            this.lcCancelar.Name = "lcCancelar";
            this.lcCancelar.Size = new System.Drawing.Size(479, 26);
            this.lcCancelar.TextSize = new System.Drawing.Size(0, 0);
            this.lcCancelar.TextVisible = false;
            // 
            // lcDescripcion
            // 
            this.lcDescripcion.Control = this.txtDescripcion;
            this.lcDescripcion.Location = new System.Drawing.Point(0, 26);
            this.lcDescripcion.Name = "lcDescripcion";
            this.lcDescripcion.Size = new System.Drawing.Size(957, 24);
            this.lcDescripcion.Text = "Descripción";
            this.lcDescripcion.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblFamiliasHijos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(957, 17);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcFamiliasHijos;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(957, 183);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblPatentes;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 250);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(957, 17);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcPatentes;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 267);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(957, 224);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmFamiliasABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmFamiliasABM";
            this.Text = "frmFamiliasABM";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcModificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnRestaurar;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private DevExpress.XtraEditors.SimpleButton btnModificar;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lcModificar;
        private DevExpress.XtraLayout.LayoutControlItem lcEliminar;
        private DevExpress.XtraLayout.LayoutControlItem lcRestaurar;
        private DevExpress.XtraLayout.LayoutControlItem lcAceptar;
        private DevExpress.XtraLayout.LayoutControlItem lcCancelar;
        private DevExpress.XtraGrid.GridControl gcPatentes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatentes;
        private DevExpress.XtraEditors.LabelControl lblPatentes;
        private DevExpress.XtraGrid.GridControl gcFamiliasHijos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFamiliasHijos;
        private DevExpress.XtraEditors.LabelControl lblFamiliasHijos;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}