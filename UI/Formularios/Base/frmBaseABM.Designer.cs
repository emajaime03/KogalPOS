
using DevExpress.XtraEditors;

namespace UI.Formularios.Base
{
    partial class frmBaseABM : XtraForm
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
            this.pnlSuperior = new DevExpress.XtraEditors.PanelControl();
            this.sepSuperior = new System.Windows.Forms.Label();
            this.btnRestaurar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnModificar = new DevExpress.XtraEditors.SimpleButton();

            this.pnlInferior = new DevExpress.XtraEditors.PanelControl();
            this.sepInferior = new System.Windows.Forms.Label();
            this.tlpBotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();

            this.panelContenido = new DevExpress.XtraEditors.XtraScrollableControl();

            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.tlpBotones.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSuperior.Controls.Add(this.sepSuperior);
            this.pnlSuperior.Controls.Add(this.btnRestaurar);
            this.pnlSuperior.Controls.Add(this.btnEliminar);
            this.pnlSuperior.Controls.Add(this.btnModificar);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(977, 55); // Ajustado a 55 para que tus botones entren perfectos
            this.pnlSuperior.TabIndex = 0;
            // 
            // sepSuperior
            // 
            this.sepSuperior.BackColor = System.Drawing.Color.Gray;
            this.sepSuperior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sepSuperior.Location = new System.Drawing.Point(0, 54);
            this.sepSuperior.Name = "sepSuperior";
            this.sepSuperior.Size = new System.Drawing.Size(977, 1);
            this.sepSuperior.TabIndex = 7;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 32); // TU TAMAÑO ORIGINAL
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(117, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 32); // TU TAMAÑO ORIGINAL
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(222, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(101, 32); // TU TAMAÑO ORIGINAL
            this.btnRestaurar.TabIndex = 6;
            this.btnRestaurar.Text = "Restaurar";
            // 
            // pnlInferior
            // 
            this.pnlInferior.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlInferior.Controls.Add(this.tlpBotones);
            this.pnlInferior.Controls.Add(this.sepInferior);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 482);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(977, 55);
            this.pnlInferior.TabIndex = 1;
            // 
            // sepInferior
            // 
            this.sepInferior.BackColor = System.Drawing.Color.Gray;
            this.sepInferior.Dock = System.Windows.Forms.DockStyle.Top;
            this.sepInferior.Location = new System.Drawing.Point(0, 0);
            this.sepInferior.Name = "sepInferior";
            this.sepInferior.Size = new System.Drawing.Size(977, 1);
            this.sepInferior.TabIndex = 9;
            // 
            // tlpBotones
            // 
            this.tlpBotones.ColumnCount = 2;
            this.tlpBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotones.Controls.Add(this.btnAceptar, 0, 0);
            this.tlpBotones.Controls.Add(this.btnCancelar, 1, 0);
            this.tlpBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBotones.Location = new System.Drawing.Point(0, 1);
            this.tlpBotones.Name = "tlpBotones";
            this.tlpBotones.Padding = new System.Windows.Forms.Padding(12);
            this.tlpBotones.RowCount = 1;
            this.tlpBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBotones.Size = new System.Drawing.Size(977, 54);
            this.tlpBotones.TabIndex = 10;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAceptar.Location = new System.Drawing.Point(12, 12);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(471, 30);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.Location = new System.Drawing.Point(493, 12);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(472, 30);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            // 
            // panelContenido
            // 
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 50);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(977, 432);
            this.panelContenido.TabIndex = 2;
            // 
            // frmBaseABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 537);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "frmBaseABM";
            this.Text = "frmBaseABM";

            ((System.ComponentModel.ISupportInitialize)(this.pnlSuperior)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.tlpBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl pnlSuperior;
        protected DevExpress.XtraEditors.PanelControl pnlInferior;
        protected DevExpress.XtraEditors.SimpleButton btnCancelar;
        protected DevExpress.XtraEditors.SimpleButton btnAceptar;
        protected DevExpress.XtraEditors.SimpleButton btnRestaurar;
        protected DevExpress.XtraEditors.SimpleButton btnEliminar;
        protected DevExpress.XtraEditors.SimpleButton btnModificar;
        protected DevExpress.XtraEditors.XtraScrollableControl panelContenido;
        protected System.Windows.Forms.Label sepSuperior;
        protected System.Windows.Forms.Label sepInferior;
        protected System.Windows.Forms.TableLayoutPanel tlpBotones;
    }
}