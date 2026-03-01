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
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).BeginInit();
            this.SuspendLayout();

            // Crear controles con ControlFactory (estilos estandarizados)
            lblUserName = ControlFactory.CrearLabel("lblUserName", "Usuario");
            txtUserName = ControlFactory.CrearTextEdit("txtUserName", 50);

            lblPassword = ControlFactory.CrearLabel("lblPassword", "Contraseña");
            txtPassword = ControlFactory.CrearTextEdit("txtPassword");
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Properties.UseSystemPasswordChar = true;

            lblFamilias = ControlFactory.CrearLabelTitulo("lblFamilias", "Familias");
            lblPatentes = ControlFactory.CrearLabelTitulo("lblPatentes", "Patentes");

            // Posicionar campos de texto
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblUserName, txtUserName),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblPassword, txtPassword)
            );

            // lblFamilias debajo de los campos de texto
            this.lblFamilias.Location = new System.Drawing.Point(20, 110);
            // 
            // gcFamilias
            // 
            this.gcFamilias.Location = new System.Drawing.Point(20, 130);
            this.gcFamilias.MainView = this.gvFamilias;
            this.gcFamilias.Name = "gcFamilias";
            this.gcFamilias.Size = new System.Drawing.Size(910, 130);
            this.gcFamilias.TabIndex = 5;
            this.gcFamilias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFamilias});
            // 
            // gvFamilias
            // 
            this.gvFamilias.GridControl = this.gcFamilias;
            this.gvFamilias.Name = "gvFamilias";
            this.gvFamilias.OptionsView.ShowGroupPanel = false;

            // lblPatentes
            this.lblPatentes.Location = new System.Drawing.Point(20, 268);
            // 
            // gcPatentes
            // 
            this.gcPatentes.Location = new System.Drawing.Point(20, 288);
            this.gcPatentes.MainView = this.gvPatentes;
            this.gcPatentes.Name = "gcPatentes";
            this.gcPatentes.Size = new System.Drawing.Size(910, 130);
            this.gcPatentes.TabIndex = 7;
            this.gcPatentes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatentes});
            // 
            // gvPatentes
            // 
            this.gvPatentes.GridControl = this.gcPatentes;
            this.gvPatentes.Name = "gvPatentes";
            this.gvPatentes.OptionsView.ShowGroupPanel = false;

            // Agregar al panelContenido del base
            this.panelContenido.Controls.Add(this.lblUserName);
            this.panelContenido.Controls.Add(this.txtUserName);
            this.panelContenido.Controls.Add(this.lblPassword);
            this.panelContenido.Controls.Add(this.txtPassword);
            this.panelContenido.Controls.Add(this.lblFamilias);
            this.panelContenido.Controls.Add(this.gcFamilias);
            this.panelContenido.Controls.Add(this.lblPatentes);
            this.panelContenido.Controls.Add(this.gcPatentes);

            // frmUsuariosABM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmUsuariosABM";
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblFamilias;
        private DevExpress.XtraGrid.GridControl gcFamilias;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFamilias;
        private DevExpress.XtraEditors.LabelControl lblPatentes;
        private DevExpress.XtraGrid.GridControl gcPatentes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatentes;
    }
}
