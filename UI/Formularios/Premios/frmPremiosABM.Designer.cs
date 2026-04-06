using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Premios
{
    partial class frmPremiosABM
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
            this.spnPuntosRequeridos = new DevExpress.XtraEditors.SpinEdit();
            this.lkpArticulo = new DevExpress.XtraEditors.LookUpEdit();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciArticulo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPuntosRequeridos = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnPuntosRequeridos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPuntosRequeridos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(123, 12);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 100;
            this.txtDescripcion.Size = new System.Drawing.Size(1005, 22);
            this.txtDescripcion.StyleController = this.layoutControlHijo;
            this.txtDescripcion.TabIndex = 4;
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.spnPuntosRequeridos);
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.lkpArticulo);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(1140, 525);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // spnPuntosRequeridos
            // 
            this.spnPuntosRequeridos.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnPuntosRequeridos.Location = new System.Drawing.Point(683, 38);
            this.spnPuntosRequeridos.Name = "spnPuntosRequeridos";
            this.spnPuntosRequeridos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnPuntosRequeridos.Properties.Mask.EditMask = "n0";
            this.spnPuntosRequeridos.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spnPuntosRequeridos.Size = new System.Drawing.Size(445, 22);
            this.spnPuntosRequeridos.StyleController = this.layoutControlHijo;
            this.spnPuntosRequeridos.TabIndex = 10;
            // 
            // lkpArticulo
            // 
            this.lkpArticulo.Location = new System.Drawing.Point(123, 38);
            this.lkpArticulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpArticulo.Name = "lkpArticulo";
            this.lkpArticulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpArticulo.Properties.NullText = "";
            this.lkpArticulo.Size = new System.Drawing.Size(445, 22);
            this.lkpArticulo.StyleController = this.layoutControlHijo;
            this.lkpArticulo.TabIndex = 5;
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciArticulo,
            this.lciPuntosRequeridos});
            this.RootHijo.Name = "RootHijo";
            this.RootHijo.Size = new System.Drawing.Size(1140, 525);
            this.RootHijo.TextVisible = false;
            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Size = new System.Drawing.Size(1120, 26);
            this.lciDescripcion.Text = "Descripción:";
            this.lciDescripcion.TextSize = new System.Drawing.Size(108, 16);
            // 
            // lciArticulo
            // 
            this.lciArticulo.Control = this.lkpArticulo;
            this.lciArticulo.Location = new System.Drawing.Point(0, 26);
            this.lciArticulo.Name = "lciArticulo";
            this.lciArticulo.Size = new System.Drawing.Size(560, 479);
            this.lciArticulo.Text = "Artículo asociado:";
            this.lciArticulo.TextSize = new System.Drawing.Size(108, 16);
            // 
            // lciPuntosRequeridos
            // 
            this.lciPuntosRequeridos.Control = this.spnPuntosRequeridos;
            this.lciPuntosRequeridos.Location = new System.Drawing.Point(560, 26);
            this.lciPuntosRequeridos.Name = "lciPuntosRequeridos";
            this.lciPuntosRequeridos.Size = new System.Drawing.Size(560, 479);
            this.lciPuntosRequeridos.Text = "Puntos requeridos:";
            this.lciPuntosRequeridos.TextSize = new System.Drawing.Size(108, 16);
            // 
            // frmPremiosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 661);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MostrarBotonEliminar = true;
            this.MostrarBotonModificar = true;
            this.MostrarBotonRestaurar = true;
            this.Name = "frmPremiosABM";
            this.Text = "Premios";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnPuntosRequeridos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPuntosRequeridos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LookUpEdit lkpArticulo;
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciArticulo;
        private DevExpress.XtraEditors.SpinEdit spnPuntosRequeridos;
        private DevExpress.XtraLayout.LayoutControlItem lciPuntosRequeridos;
    }
}