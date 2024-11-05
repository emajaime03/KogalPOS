using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Services.BLL;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Formularios.Base;

namespace UI.Formularios.Administrador.Patentes
{
    public partial class frmPatentes : frmGrillaBase
    {
        public frmPatentes()
        {
            InitializeComponent();

            ControlesInicializar();
        }

        private void ControlesInicializar()
        {
            this.Text = "Patentes";

            this.btnNuevo.Enabled = false;
            this.btnDetalle.Enabled = false;

            List<GridColumn> gridColumns = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN",
                    Visible = true,
                }
            };

            // Agregar columnas al GridView
            gridView.Columns.AddRange(gridColumns.ToArray());

            CargarPantalla();
        }

        protected override void CargarPantalla()
        {
            ResPatentesObtener res = (ResPatentesObtener)RequestBLL.Current.GetResponse(new ReqPatentesObtener());
                    
            this.gridControl.DataSource = res.Patentes;
        }
    }
}