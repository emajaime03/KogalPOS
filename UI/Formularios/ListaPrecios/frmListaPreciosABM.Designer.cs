using UI.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace UI.Formularios.ListaPrecios
{
    partial class frmListaPreciosABM
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
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();

            // ── Descripción ──
            lblDescripcion = ControlFactory.CrearLabel("lblDescripcion", "Descripción");
            txtDescripcion = ControlFactory.CrearTextEdit("txtDescripcion", 200);

            // ── Es Predeterminada ──
            chkEsPredeterminada = new DevExpress.XtraEditors.CheckEdit();
            chkEsPredeterminada.Name = "chkEsPredeterminada";
            chkEsPredeterminada.Text = "Es Predeterminada";
            chkEsPredeterminada.Size = new Size(400, 22);
            chkEsPredeterminada.Properties.Appearance.Font = FontHelper.FuenteBase;
            chkEsPredeterminada.Properties.Appearance.Options.UseFont = true;

            // ── Vigencia Desde ──
            lblVigenciaDesde = ControlFactory.CrearLabel("lblVigenciaDesde", "Vigencia Desde");
            dtVigenciaDesde = new DevExpress.XtraEditors.DateEdit();
            dtVigenciaDesde.Name = "dtVigenciaDesde";
            dtVigenciaDesde.Size = new Size(400, 22);
            dtVigenciaDesde.Properties.Appearance.Font = FontHelper.FuenteBase;
            dtVigenciaDesde.Properties.Appearance.Options.UseFont = true;
            dtVigenciaDesde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            dtVigenciaDesde.Properties.NullText = "";

            // ── Vigencia Hasta ──
            lblVigenciaHasta = ControlFactory.CrearLabel("lblVigenciaHasta", "Vigencia Hasta");
            dtVigenciaHasta = new DevExpress.XtraEditors.DateEdit();
            dtVigenciaHasta.Name = "dtVigenciaHasta";
            dtVigenciaHasta.Size = new Size(400, 22);
            dtVigenciaHasta.Properties.Appearance.Font = FontHelper.FuenteBase;
            dtVigenciaHasta.Properties.Appearance.Options.UseFont = true;
            dtVigenciaHasta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            dtVigenciaHasta.Properties.NullText = "";

            // ── Título Ítems ──
            lblTituloItems = ControlFactory.CrearLabelTitulo("lblTituloItems", "Artículos y Precios");

            // ── Grilla de ítems ──
            gridItems = new DevExpress.XtraGrid.GridControl();
            gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewItems)).BeginInit();

            gridItems.Name = "gridItems";
            gridItems.MainView = gridViewItems;
            gridItems.Size = new Size(700, 250);

            gridViewItems.GridControl = gridItems;
            gridViewItems.OptionsView.ShowGroupPanel = false;
            gridViewItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            ((System.ComponentModel.ISupportInitialize)(gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewItems)).EndInit();

            // ── Botón Agregar Fila ──
            btnAgregarFila = new DevExpress.XtraEditors.SimpleButton();
            btnAgregarFila.Name = "btnAgregarFila";
            btnAgregarFila.Text = "Agregar Artículo";
            btnAgregarFila.Size = new Size(140, 30);

            // ── Botón Quitar Fila ──
            btnQuitarFila = new DevExpress.XtraEditors.SimpleButton();
            btnQuitarFila.Name = "btnQuitarFila";
            btnQuitarFila.Text = "Quitar Artículo";
            btnQuitarFila.Size = new Size(140, 30);

            // ── Posicionar campos de cabecera ──
            ControlFactory.PosicionarCampos(20, 15, 16,
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblDescripcion, txtDescripcion),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblVigenciaDesde, dtVigenciaDesde),
                new KeyValuePair<DevExpress.XtraEditors.LabelControl, DevExpress.XtraEditors.BaseEdit>(lblVigenciaHasta, dtVigenciaHasta)
            );

            // ── Posicionar checkbox después de los campos ──
            int yCheckbox = dtVigenciaHasta.Location.Y + dtVigenciaHasta.Height + 16;
            chkEsPredeterminada.Location = new Point(20, yCheckbox);

            // ── Posicionar título y grilla manualmente ──
            int yGrilla = chkEsPredeterminada.Location.Y + chkEsPredeterminada.Height + 20;
            lblTituloItems.Location = new Point(20, yGrilla);
            yGrilla += lblTituloItems.Height + 8;

            // Botones Agregar/Quitar
            btnAgregarFila.Location = new Point(20, yGrilla);
            btnQuitarFila.Location = new Point(170, yGrilla);
            yGrilla += btnAgregarFila.Height + 8;

            gridItems.Location = new Point(20, yGrilla);

            // Agregar al panelContenido del base
            this.panelContenido.Controls.Add(this.lblDescripcion);
            this.panelContenido.Controls.Add(this.txtDescripcion);
            this.panelContenido.Controls.Add(this.chkEsPredeterminada);
            this.panelContenido.Controls.Add(this.lblVigenciaDesde);
            this.panelContenido.Controls.Add(this.dtVigenciaDesde);
            this.panelContenido.Controls.Add(this.lblVigenciaHasta);
            this.panelContenido.Controls.Add(this.dtVigenciaHasta);
            this.panelContenido.Controls.Add(this.lblTituloItems);
            this.panelContenido.Controls.Add(this.btnAgregarFila);
            this.panelContenido.Controls.Add(this.btnQuitarFila);
            this.panelContenido.Controls.Add(this.gridItems);

            // frmListaPreciosABM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmListaPreciosABM";
            this.ClientSize = new Size(780, 620);
            ((System.ComponentModel.ISupportInitialize)(this.panelContenido)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.CheckEdit chkEsPredeterminada;
        private DevExpress.XtraEditors.LabelControl lblVigenciaDesde;
        private DevExpress.XtraEditors.DateEdit dtVigenciaDesde;
        private DevExpress.XtraEditors.LabelControl lblVigenciaHasta;
        private DevExpress.XtraEditors.DateEdit dtVigenciaHasta;
        private DevExpress.XtraEditors.LabelControl lblTituloItems;
        private DevExpress.XtraGrid.GridControl gridItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraEditors.SimpleButton btnAgregarFila;
        private DevExpress.XtraEditors.SimpleButton btnQuitarFila;
    }
}
