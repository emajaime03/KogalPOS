﻿
using UI.Formularios.Base;

namespace UI.Formularios.Administrador.Patentes
{
    partial class frmPatentes : frmGrillaBase
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
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Size = new System.Drawing.Size(699, 22);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Size = new System.Drawing.Size(699, 22);
            // 
            // frmPatentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 430);
            this.Name = "frmPatentes";
            this.Text = "frmPatentes";
            this.ResumeLayout(false);

        }

        #endregion
    }
}