using UI.Helpers;
using System.Collections.Generic;

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

        private void InitializeComponent()
        {
            this.gcFamilias = new DevExpress.XtraGrid.GridControl();
            this.gvFamilias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPatentes = new DevExpress.XtraGrid.GridControl();
            this.gvPatentes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();

            this.layoutControlHijo = new DevExpress.XtraLayout.LayoutControl();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFamilias = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPatentes = new DevExpress.XtraLayout.LayoutControlItem();

            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPatentes)).BeginInit();
            this.SuspendLayout();

            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(953, 20);
            this.txtUserName.TabIndex = 4;

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(953, 20);
            this.txtPassword.TabIndex = 5;

            // 
            // gcFamilias
            // 
            this.gcFamilias.Location = new System.Drawing.Point(12, 100);
            this.gcFamilias.MainView = this.gvFamilias;
            this.gcFamilias.Name = "gcFamilias";
            this.gcFamilias.TabIndex = 6;
            this.gcFamilias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFamilias});

            // 
            // gvFamilias
            // 
            this.gvFamilias.GridControl = this.gcFamilias;
            this.gvFamilias.Name = "gvFamilias";
            this.gvFamilias.OptionsView.ShowGroupPanel = false;

            // 
            // gcPatentes
            // 
            this.gcPatentes.Location = new System.Drawing.Point(12, 260);
            this.gcPatentes.MainView = this.gvPatentes;
            this.gcPatentes.Name = "gcPatentes";
            this.gcPatentes.TabIndex = 7;
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
            this.layoutControlHijo.Controls.Add(this.txtUserName);
            this.layoutControlHijo.Controls.Add(this.txtPassword);
            this.layoutControlHijo.Controls.Add(this.gcFamilias);
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
            this.lciUserName,
            this.lciPassword,
            this.lciFamilias,
            this.lciPatentes});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(977, 432);
            this.RootHijo.TextVisible = false;

            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.txtUserName;
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Text = "Usuario:";
            this.lciUserName.TextSize = new System.Drawing.Size(65, 13);

            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.txtPassword;
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Text = "Contraseña:";
            this.lciPassword.TextSize = new System.Drawing.Size(65, 13);

            // 
            // lciFamilias
            // 
            this.lciFamilias.Control = this.gcFamilias;
            this.lciFamilias.Name = "lciFamilias";
            this.lciFamilias.Text = "Familias";
            this.lciFamilias.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciFamilias.TextSize = new System.Drawing.Size(65, 13);
            this.lciFamilias.MinSize = new System.Drawing.Size(100, 150);
            this.lciFamilias.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            // 
            // lciPatentes
            // 
            this.lciPatentes.Control = this.gcPatentes;
            this.lciPatentes.Name = "lciPatentes";
            this.lciPatentes.Text = "Patentes";
            this.lciPatentes.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciPatentes.TextSize = new System.Drawing.Size(65, 13);
            this.lciPatentes.MinSize = new System.Drawing.Size(100, 150);
            this.lciPatentes.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);

            // 
            // frmUsuariosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Name = "frmUsuariosABM";
            this.Text = "Usuarios";

            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPatentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraGrid.GridControl gcFamilias;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFamilias;
        private DevExpress.XtraGrid.GridControl gcPatentes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatentes;

        // Variables del LayoutControl
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciFamilias;
        private DevExpress.XtraLayout.LayoutControlItem lciPatentes;
    }
}