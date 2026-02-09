using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Formularios.Administrador.BackupRestore
{
    partial class frmBackupRestore
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
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.lblInstrucciones = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.Location = new System.Drawing.Point(30, 100);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(200, 60);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "Generar Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestore.Appearance.Options.UseFont = true;
            this.btnRestore.Location = new System.Drawing.Point(250, 100);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(200, 60);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restaurar Backup";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstrucciones.Appearance.Options.UseFont = true;
            this.lblInstrucciones.Appearance.Options.UseTextOptions = true;
            this.lblInstrucciones.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblInstrucciones.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInstrucciones.Location = new System.Drawing.Point(30, 20);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(420, 60);
            this.lblInstrucciones.TabIndex = 0;
            this.lblInstrucciones.Text = "Seleccione una opción para gestionar la copia de seguridad de la base de datos.";
            // 
            // frmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 191);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.lblInstrucciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackupRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copias de Seguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.LabelControl lblInstrucciones;
    }
}
