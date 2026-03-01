using UI.Helpers;
using System.Collections.Generic;

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

        private void InitializeComponent()
        {
            this.gcFamiliasHijos = new DevExpress.XtraGrid.GridControl();
            this.gvFamiliasHijos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPatentes = new DevExpress.XtraGrid.GridControl();
            this.gvPatentes = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamiliasHijos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).BeginInit();
            this.SuspendLayout();

            // Crear controles con ControlFactory (estilos estandarizados)
            lblDescripcion = ControlFactory.CrearLabel("lblDescripcion", "Descripción");
            txtDescripcion = ControlFactory.CrearTextEdit("txtDescripcion", 50);

            lblFamiliasHijos = ControlFactory.CrearLabelTitulo("lblFamiliasHijos", "Familias Hijos");
            lblPatentes = ControlFactory.CrearLabelTitulo("lblPatentes", "Patentes");

            // Posicionar campo Descripción
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblDescripcion, txtDescripcion)
            );

            // lblFamiliasHijos debajo del campo descripción
            this.lblFamiliasHijos.Location = new System.Drawing.Point(20, 70);
            // 
            // gcFamiliasHijos
            // 
            this.gcFamiliasHijos.Location = new System.Drawing.Point(20, 90);
            this.gcFamiliasHijos.MainView = this.gvFamiliasHijos;
            this.gcFamiliasHijos.Name = "gcFamiliasHijos";
            this.gcFamiliasHijos.Size = new System.Drawing.Size(910, 150);
            this.gcFamiliasHijos.TabIndex = 3;
            this.gcFamiliasHijos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFamiliasHijos});
            // 
            // gvFamiliasHijos
            // 
            this.gvFamiliasHijos.GridControl = this.gcFamiliasHijos;
            this.gvFamiliasHijos.Name = "gvFamiliasHijos";
            this.gvFamiliasHijos.OptionsView.ShowGroupPanel = false;

            // lblPatentes
            this.lblPatentes.Location = new System.Drawing.Point(20, 248);
            // 
            // gcPatentes
            // 
            this.gcPatentes.Location = new System.Drawing.Point(20, 268);
            this.gcPatentes.MainView = this.gvPatentes;
            this.gcPatentes.Name = "gcPatentes";
            this.gcPatentes.Size = new System.Drawing.Size(910, 150);
            this.gcPatentes.TabIndex = 5;
            this.gcPatentes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatentes});
            // 
            // gvPatentes
            // 
            this.gvPatentes.GridControl = this.gcPatentes;
            this.gvPatentes.Name = "gvPatentes";
            this.gvPatentes.OptionsView.ShowGroupPanel = false;

            // Agregar al panelContenido del base
            this.panelContenido.Controls.Add(this.lblDescripcion);
            this.panelContenido.Controls.Add(this.txtDescripcion);
            this.panelContenido.Controls.Add(this.lblFamiliasHijos);
            this.panelContenido.Controls.Add(this.gcFamiliasHijos);
            this.panelContenido.Controls.Add(this.lblPatentes);
            this.panelContenido.Controls.Add(this.gcPatentes);

            // frmFamiliasABM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmFamiliasABM";
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFamiliasHijos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatentes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblFamiliasHijos;
        private DevExpress.XtraGrid.GridControl gcFamiliasHijos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFamiliasHijos;
        private DevExpress.XtraEditors.LabelControl lblPatentes;
        private DevExpress.XtraGrid.GridControl gcPatentes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatentes;
    }
}