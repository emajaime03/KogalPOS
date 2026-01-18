
namespace UI.Formularios.Administrador.Usuarios
{
    partial class frmUsuariosABM
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
            this.gcFamilias = new DevExpress.XtraGrid.GridControl();
            this.gvFamilias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblFamilias = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
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
            this.lcUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcModificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPassword)).BeginInit();
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
            this.layoutControl1.Controls.Add(this.gcFamilias);
            this.layoutControl1.Controls.Add(this.lblFamilias);
            this.layoutControl1.Controls.Add(this.txtUserName);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.btnCancelar);
            this.layoutControl1.Controls.Add(this.btnAceptar);
            this.layoutControl1.Controls.Add(this.btnRestaurar);
            this.layoutControl1.Controls.Add(this.btnEliminar);
            this.layoutControl1.Controls.Add(this.btnModificar);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(977, 587);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcPatentes
            // 
            this.gcPatentes.Location = new System.Drawing.Point(12, 329);
            this.gcPatentes.MainView = this.gvPatentes;
            this.gcPatentes.Name = "gcPatentes";
            this.gcPatentes.Size = new System.Drawing.Size(953, 206);
            this.gcPatentes.TabIndex = 15;
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
            this.lblPatentes.Location = new System.Drawing.Point(12, 312);
            this.lblPatentes.Name = "lblPatentes";
            this.lblPatentes.Size = new System.Drawing.Size(43, 13);
            this.lblPatentes.StyleController = this.layoutControl1;
            this.lblPatentes.TabIndex = 14;
            this.lblPatentes.Text = "Patentes";
            // 
            // gcFamilias
            // 
            this.gcFamilias.Location = new System.Drawing.Point(12, 105);
            this.gcFamilias.MainView = this.gvFamilias;
            this.gcFamilias.Name = "gcFamilias";
            this.gcFamilias.Size = new System.Drawing.Size(953, 203);
            this.gcFamilias.TabIndex = 13;
            this.gcFamilias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFamilias});
            // 
            // gvFamilias
            // 
            this.gvFamilias.GridControl = this.gcFamilias;
            this.gvFamilias.Name = "gvFamilias";
            this.gvFamilias.OptionsView.ShowGroupPanel = false;
            // 
            // lblFamilias
            // 
            this.lblFamilias.Location = new System.Drawing.Point(12, 88);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(37, 13);
            this.lblFamilias.StyleController = this.layoutControl1;
            this.lblFamilias.TabIndex = 12;
            this.lblFamilias.Text = "Familias";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(69, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(450, 20);
            this.txtUserName.StyleController = this.layoutControl1;
            this.txtUserName.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(576, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(389, 20);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(490, 539);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(475, 36);
            this.btnCancelar.StyleController = this.layoutControl1;
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 539);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(474, 36);
            this.btnAceptar.StyleController = this.layoutControl1;
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(222, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(101, 32);
            this.btnRestaurar.StyleController = this.layoutControl1;
            this.btnRestaurar.TabIndex = 6;
            this.btnRestaurar.Text = "Restaurar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(117, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 32);
            this.btnEliminar.StyleController = this.layoutControl1;
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 32);
            this.btnModificar.StyleController = this.layoutControl1;
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
            this.lcUserName,
            this.lcPassword,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(977, 587);
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
            this.lcAceptar.Location = new System.Drawing.Point(0, 527);
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
            this.lcCancelar.Location = new System.Drawing.Point(478, 527);
            this.lcCancelar.MaxSize = new System.Drawing.Size(0, 40);
            this.lcCancelar.MinSize = new System.Drawing.Size(50, 40);
            this.lcCancelar.Name = "lcCancelar";
            this.lcCancelar.Size = new System.Drawing.Size(479, 40);
            this.lcCancelar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcCancelar.TextSize = new System.Drawing.Size(0, 0);
            this.lcCancelar.TextVisible = false;
            // 
            // lcUserName
            // 
            this.lcUserName.Control = this.txtUserName;
            this.lcUserName.Location = new System.Drawing.Point(0, 36);
            this.lcUserName.Name = "lcUserName";
            this.lcUserName.Size = new System.Drawing.Size(507, 24);
            this.lcUserName.Text = "Usuario";
            this.lcUserName.TextSize = new System.Drawing.Size(54, 13);
            // 
            // lcPassword
            // 
            this.lcPassword.Control = this.txtPassword;
            this.lcPassword.Location = new System.Drawing.Point(507, 36);
            this.lcPassword.Name = "lcPassword";
            this.lcPassword.Size = new System.Drawing.Size(450, 24);
            this.lcPassword.Text = "Contraseña";
            this.lcPassword.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblFamilias;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(957, 17);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcFamilias;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 93);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(957, 207);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblPatentes;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 300);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(957, 17);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcPatentes;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 317);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(957, 210);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmUsuariosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 587);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmUsuariosABM";
            this.Text = "frmUsuariosABM";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcModificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPassword)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcFamilias;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFamilias;
        private DevExpress.XtraEditors.LabelControl lblFamilias;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlItem lcUserName;
        private DevExpress.XtraLayout.LayoutControlItem lcPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
