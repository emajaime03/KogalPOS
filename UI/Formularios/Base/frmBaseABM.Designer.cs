
namespace UI.Formularios.Base
{
    partial class frmBaseABM
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.panelContenido = new DevExpress.XtraEditors.PanelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestaurar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnModificar = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcModificar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcEliminar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcRestaurar = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcAceptar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcCancelar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcContenido = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcModificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcContenido)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.panelContenido);
            this.layoutControl.Controls.Add(this.btnCancelar);
            this.layoutControl.Controls.Add(this.btnAceptar);
            this.layoutControl.Controls.Add(this.btnRestaurar);
            this.layoutControl.Controls.Add(this.btnEliminar);
            this.layoutControl.Controls.Add(this.btnModificar);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(977, 537);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl";
            // 
            // panelContenido
            // 
            this.panelContenido.Location = new System.Drawing.Point(12, 48);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(953, 437);
            this.panelContenido.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(490, 489);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(475, 36);
            this.btnCancelar.StyleController = this.layoutControl;
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 489);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(474, 36);
            this.btnAceptar.StyleController = this.layoutControl;
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(222, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(101, 32);
            this.btnRestaurar.StyleController = this.layoutControl;
            this.btnRestaurar.TabIndex = 6;
            this.btnRestaurar.Text = "Restaurar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(117, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 32);
            this.btnEliminar.StyleController = this.layoutControl;
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 32);
            this.btnModificar.StyleController = this.layoutControl;
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcModificar,
            this.lcEliminar,
            this.lcRestaurar,
            this.emptySpaceItem1,
            this.lcAceptar,
            this.lcCancelar,
            this.lcContenido});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(977, 537);
            this.Root.TextVisible = false;
            // 
            // lcModificar
            // 
            this.lcModificar.Control = this.btnModificar;
            this.lcModificar.Location = new System.Drawing.Point(0, 0);
            this.lcModificar.MaxSize = new System.Drawing.Size(105, 36);
            this.lcModificar.MinSize = new System.Drawing.Size(105, 36);
            this.lcModificar.Name = "lcModificar";
            this.lcModificar.Size = new System.Drawing.Size(105, 36);
            this.lcModificar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcModificar.TextSize = new System.Drawing.Size(0, 0);
            this.lcModificar.TextVisible = false;
            // 
            // lcEliminar
            // 
            this.lcEliminar.Control = this.btnEliminar;
            this.lcEliminar.Location = new System.Drawing.Point(105, 0);
            this.lcEliminar.MaxSize = new System.Drawing.Size(105, 36);
            this.lcEliminar.MinSize = new System.Drawing.Size(105, 36);
            this.lcEliminar.Name = "lcEliminar";
            this.lcEliminar.Size = new System.Drawing.Size(105, 36);
            this.lcEliminar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcEliminar.TextSize = new System.Drawing.Size(0, 0);
            this.lcEliminar.TextVisible = false;
            // 
            // lcRestaurar
            // 
            this.lcRestaurar.Control = this.btnRestaurar;
            this.lcRestaurar.Location = new System.Drawing.Point(210, 0);
            this.lcRestaurar.MaxSize = new System.Drawing.Size(105, 36);
            this.lcRestaurar.MinSize = new System.Drawing.Size(105, 36);
            this.lcRestaurar.Name = "lcRestaurar";
            this.lcRestaurar.Size = new System.Drawing.Size(105, 36);
            this.lcRestaurar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcRestaurar.TextSize = new System.Drawing.Size(0, 0);
            this.lcRestaurar.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(315, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(642, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcAceptar
            // 
            this.lcAceptar.Control = this.btnAceptar;
            this.lcAceptar.Location = new System.Drawing.Point(0, 477);
            this.lcAceptar.MaxSize = new System.Drawing.Size(0, 40);
            this.lcAceptar.MinSize = new System.Drawing.Size(50, 40);
            this.lcAceptar.Name = "lcAceptar";
            this.lcAceptar.Size = new System.Drawing.Size(478, 40);
            this.lcAceptar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcAceptar.TextSize = new System.Drawing.Size(0, 0);
            this.lcAceptar.TextVisible = false;
            // 
            // lcCancelar
            // 
            this.lcCancelar.Control = this.btnCancelar;
            this.lcCancelar.Location = new System.Drawing.Point(478, 477);
            this.lcCancelar.MaxSize = new System.Drawing.Size(0, 40);
            this.lcCancelar.MinSize = new System.Drawing.Size(50, 40);
            this.lcCancelar.Name = "lcCancelar";
            this.lcCancelar.Size = new System.Drawing.Size(479, 40);
            this.lcCancelar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcCancelar.TextSize = new System.Drawing.Size(0, 0);
            this.lcCancelar.TextVisible = false;
            // 
            // lcContenido
            // 
            this.lcContenido.Control = this.panelContenido;
            this.lcContenido.Location = new System.Drawing.Point(0, 36);
            this.lcContenido.Name = "lcContenido";
            this.lcContenido.Size = new System.Drawing.Size(957, 441);
            this.lcContenido.TextSize = new System.Drawing.Size(0, 0);
            this.lcContenido.TextVisible = false;
            // 
            // frmBaseABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Controls.Add(this.layoutControl);
            this.Name = "frmBaseABM";
            this.Text = "frmBaseABM";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcModificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcContenido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraLayout.LayoutControl layoutControl;
        protected DevExpress.XtraEditors.SimpleButton btnCancelar;
        protected DevExpress.XtraEditors.SimpleButton btnAceptar;
        protected DevExpress.XtraEditors.SimpleButton btnRestaurar;
        protected DevExpress.XtraEditors.SimpleButton btnEliminar;
        protected DevExpress.XtraEditors.SimpleButton btnModificar;
        protected DevExpress.XtraLayout.LayoutControlGroup Root;
        protected DevExpress.XtraLayout.LayoutControlItem lcModificar;
        protected DevExpress.XtraLayout.LayoutControlItem lcEliminar;
        protected DevExpress.XtraLayout.LayoutControlItem lcRestaurar;
        protected DevExpress.XtraLayout.LayoutControlItem lcAceptar;
        protected DevExpress.XtraLayout.LayoutControlItem lcCancelar;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        protected DevExpress.XtraEditors.PanelControl panelContenido;
        protected DevExpress.XtraLayout.LayoutControlItem lcContenido;
    }
}
