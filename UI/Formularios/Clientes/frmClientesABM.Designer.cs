using UI.Helpers;
using System.Collections.Generic;

namespace UI.Formularios.Clientes
{
    partial class frmClientesABM
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
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.txtNroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.cmbTipoDocumento = new DevExpress.XtraEditors.ComboBoxEdit();
            this.RootHijo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTipoDocumento = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNroDocumento = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciPuntosActuales = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).BeginInit();
            this.layoutControlHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNroDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPuntosActuales)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.layoutControlHijo);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(113, 12);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 100;
            this.txtDescripcion.Size = new System.Drawing.Size(1015, 22);
            this.txtDescripcion.StyleController = this.layoutControlHijo;
            this.txtDescripcion.TabIndex = 4;
            // 
            // layoutControlHijo
            // 
            this.layoutControlHijo.Controls.Add(this.spinEdit1);
            this.layoutControlHijo.Controls.Add(this.txtDescripcion);
            this.layoutControlHijo.Controls.Add(this.txtNroDocumento);
            this.layoutControlHijo.Controls.Add(this.cmbTipoDocumento);
            this.layoutControlHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlHijo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControlHijo.Name = "layoutControlHijo";
            this.layoutControlHijo.Root = this.RootHijo;
            this.layoutControlHijo.Size = new System.Drawing.Size(1140, 525);
            this.layoutControlHijo.TabIndex = 0;
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(113, 471);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.spinEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.spinEdit1.Properties.Appearance.Options.UseFont = true;
            this.spinEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.spinEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spinEdit1.Properties.Mask.EditMask = "n0";
            this.spinEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEdit1.Properties.ReadOnly = true;
            this.spinEdit1.Size = new System.Drawing.Size(455, 42);
            this.spinEdit1.StyleController = this.layoutControlHijo;
            this.spinEdit1.TabIndex = 10;
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(673, 38);
            this.txtNroDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Properties.MaxLength = 50;
            this.txtNroDocumento.Size = new System.Drawing.Size(455, 22);
            this.txtNroDocumento.StyleController = this.layoutControlHijo;
            this.txtNroDocumento.TabIndex = 5;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Location = new System.Drawing.Point(113, 38);
            this.cmbTipoDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoDocumento.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTipoDocumento.Size = new System.Drawing.Size(455, 22);
            this.cmbTipoDocumento.StyleController = this.layoutControlHijo;
            this.cmbTipoDocumento.TabIndex = 6;
            // 
            // RootHijo
            // 
            this.RootHijo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootHijo.GroupBordersVisible = false;
            this.RootHijo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescripcion,
            this.lciTipoDocumento,
            this.lciNroDocumento,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.lciPuntosActuales});
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
            this.lciDescripcion.TextSize = new System.Drawing.Size(98, 16);
            // 
            // lciTipoDocumento
            // 
            this.lciTipoDocumento.Control = this.cmbTipoDocumento;
            this.lciTipoDocumento.Location = new System.Drawing.Point(0, 26);
            this.lciTipoDocumento.Name = "lciTipoDocumento";
            this.lciTipoDocumento.Size = new System.Drawing.Size(560, 26);
            this.lciTipoDocumento.Text = "Tipo Documento:";
            this.lciTipoDocumento.TextSize = new System.Drawing.Size(98, 16);
            // 
            // lciNroDocumento
            // 
            this.lciNroDocumento.Control = this.txtNroDocumento;
            this.lciNroDocumento.Location = new System.Drawing.Point(560, 26);
            this.lciNroDocumento.Name = "lciNroDocumento";
            this.lciNroDocumento.Size = new System.Drawing.Size(560, 26);
            this.lciNroDocumento.Text = "Nro Documento:";
            this.lciNroDocumento.TextSize = new System.Drawing.Size(98, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(560, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(560, 453);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(560, 407);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciPuntosActuales
            // 
            this.lciPuntosActuales.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciPuntosActuales.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lciPuntosActuales.Control = this.spinEdit1;
            this.lciPuntosActuales.Location = new System.Drawing.Point(0, 459);
            this.lciPuntosActuales.Name = "lciPuntosActuales";
            this.lciPuntosActuales.Size = new System.Drawing.Size(560, 46);
            this.lciPuntosActuales.Text = "Puntos:";
            this.lciPuntosActuales.TextLocation = DevExpress.Utils.Locations.Left;
            this.lciPuntosActuales.TextSize = new System.Drawing.Size(98, 16);
            // 
            // frmClientesABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 661);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MostrarBotonEliminar = true;
            this.MostrarBotonModificar = true;
            this.MostrarBotonRestaurar = true;
            this.Name = "frmClientesABM";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHijo)).EndInit();
            this.layoutControlHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootHijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNroDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPuntosActuales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtNroDocumento;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipoDocumento;
        private DevExpress.XtraLayout.LayoutControl layoutControlHijo;
        private DevExpress.XtraLayout.LayoutControlGroup RootHijo;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciNroDocumento;
        private DevExpress.XtraLayout.LayoutControlItem lciTipoDocumento;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem lciPuntosActuales;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}