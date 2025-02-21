using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Services.BLL;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using Services.Facade.Observer;
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

namespace UI.Formularios.Administrador.Familias
{
    public partial class frmFamiliasABM : DevExpress.XtraEditors.XtraForm, IObserver
    {
        #region "PROPIEDADES"
        private Guid Id { get; set; }
        private List<Familia> TodasFamilias { get; set; }
        private List<Patente> TodasPatentes { get; set; }
        private List<Familia> FamiliasHijosGrilla
        {
            get
            {
                return (List<Familia>)gcFamiliasHijos.DataSource;
            } set 
            {
                gcFamiliasHijos.DataSource = value;
            }
        }
        private List<Patente> PatentesGrilla
        {
            get
            {
                return (List<Patente>)gcPatentes.DataSource;
            } set 
            {
                gcPatentes.DataSource = value;
            }
        }
        private E_TipoPantalla _tipoPantalla;

        private E_TipoPantalla tipoPantalla
        {
            get
            {
                return _tipoPantalla; 
            }
            set
            {
                _tipoPantalla = value;
                ControlesHabilitar(value);
            }
        }
        #endregion

        #region "CONSTRUCTOR"
        public frmFamiliasABM(Guid id)
        {
            Id = id;

            InitializeComponent();

            FormSubject.Current.Attach(this);

            ControlesInicializar();
        }
        #endregion

        #region "PROCEDIMIENTOS"
        private void ControlesInicializar()
        {
            if (this.Id != null && this.Id != Guid.Empty)
            {
                this.Text = "Detalle Familia".Translate();

                tipoPantalla = E_TipoPantalla.Visualizar;
            }
            else
            {
                this.Text = "Nueva Familia".Translate();

                tipoPantalla = E_TipoPantalla.Nuevo;
            }

            this.btnModificar.Text = "Modificar".Translate();
            this.btnEliminar.Text = "Eliminar".Translate();
            this.btnRestaurar.Text = "Restaurar".Translate();
            this.btnAceptar.Text = "Aceptar".Translate();
            this.btnCancelar.Text = "Cancelar".Translate();

            gvFamiliasHijos.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            List<GridColumn> gridColumnsFamilias = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN",
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Temp_Seleccionado), // Nombre de la propiedad para el checkbox
                    Caption = "SELECCIONADO",
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean, // Especifica que es un campo booleano
                    ColumnEdit = new RepositoryItemCheckEdit() // Añade un editor de tipo CheckEdit
                }
            };

            // Agregar columnas al GridView
            gvFamiliasHijos.Columns.AddRange(gridColumnsFamilias.ToArray());

            List<GridColumn> gridColumnspatentes = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN",
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Temp_Seleccionado), // Nombre de la propiedad para el checkbox
                    Caption = "SELECCIONADO",
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean, // Especifica que es un campo booleano
                    ColumnEdit = new RepositoryItemCheckEdit() // Añade un editor de tipo CheckEdit
                }
            };

            gvPatentes.Columns.AddRange(gridColumnspatentes.ToArray());

            CargarPantalla();
            gcFamiliasHijos.RefreshDataSource();
            gcPatentes.RefreshDataSource();
        }

        private void CargarPantalla()
        {

            ResFamiliaObtener res = (ResFamiliaObtener)RequestBLL.Current.GetResponse(new ReqFamiliaObtener { Id = this.Id });

            TodasFamilias = res.ListaFamilias;
            TodasPatentes = res.ListaPatentes;

            FamiliasHijosGrilla = new List<Familia>(TodasFamilias);
            PatentesGrilla = new List<Patente>(TodasPatentes);

            if (res.Familia != null)
            {
                txtDescripcion.Text = res.Familia.Descripcion;
                
                FamiliasHijosGrilla.ForEach(f => f.Temp_Seleccionado = res.Familia.GetFamilias(true).Any(fs => fs.Id == f.Id));
                FamiliasHijosGrilla.RemoveAll(f =>
                    FamiliasHijosGrilla.Where(ff => ff.Temp_Seleccionado).Any(ff => ff.GetFamilias().Contains(f)) ||
                    f.GetFamilias().Any(fam => FamiliasHijosGrilla.Where(ff => ff.Temp_Seleccionado).Any(selectedFam => selectedFam == fam))
                );

                PatentesGrilla.ForEach(p => p.Temp_Seleccionado = res.Familia.GetPatentes(true).Any(fs => fs.Id == p.Id));
                PatentesGrilla.RemoveAll(p => FamiliasHijosGrilla.Where(f => f.Temp_Seleccionado).Any(f => f.GetPatentes().Any(pp => pp.Id == p.Id)));
                                
            } else
            {
                FamiliasHijosGrilla = new List<Familia>(TodasFamilias);
            }

            ////selecciono x familia
            ////se seleccionan x patentes (no las puedo modificar)
            ////puedo seleccionar el resto de las patentes

            ////selecciono otra familia
            ////se seleccionan x patentes
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Familia.Equals(value))
            {

            }
        }
        #endregion

        #region "EVENTOS"
        private void btnModificar_Click(object sender, EventArgs e)
        {
            tipoPantalla = E_TipoPantalla.Modificar;
        }
        #endregion

        #region "FUNCIONES INTERNAS"
        private void ControlesHabilitar(E_TipoPantalla tipoPantalla)
        {
            switch (tipoPantalla)
            {
                case E_TipoPantalla.Visualizar:
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnRestaurar.Enabled = false;

                    this.lcDescripcion.Enabled = false;
                    this.gcFamiliasHijos.Enabled = false;
                    this.gcPatentes.Enabled = false;

                    this.btnAceptar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    break;
                case E_TipoPantalla.VisualizarEliminado:
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnRestaurar.Enabled = true;

                    this.lcDescripcion.Enabled = false;
                    this.gcFamiliasHijos.Enabled = false;
                    this.gcPatentes.Enabled = false;

                    this.btnAceptar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    break;
                case E_TipoPantalla.Modificar:
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnRestaurar.Enabled = false;

                    this.lcDescripcion.Enabled = true;
                    this.gcFamiliasHijos.Enabled = true;
                    this.gcPatentes.Enabled = true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    break;
                case E_TipoPantalla.Nuevo:
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnRestaurar.Enabled = false;

                    this.lcDescripcion.Enabled = true;
                    this.gcFamiliasHijos.Enabled = true;
                    this.gcPatentes.Enabled = true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    break;
            }

        }
        #endregion
    }
}