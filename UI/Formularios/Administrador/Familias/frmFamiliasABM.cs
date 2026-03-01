using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.BLL.Services;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Administrador.Familias
{
    public partial class frmFamiliasABM : frmBaseABM
    {
        #region "PROPIEDADES"

        private Familia FamiliaActual { get; set; }
        private List<Familia> TodasFamilias { get; set; }
        private List<Patente> TodasPatentes { get; set; }

        private List<Familia> FamiliasHijosGrilla
        {
            get => (List<Familia>)gcFamiliasHijos.DataSource;
            set => gcFamiliasHijos.DataSource = value;
        }

        private List<Patente> PatentesGrilla
        {
            get => (List<Patente>)gcPatentes.DataSource;
            set => gcPatentes.DataSource = value;
        }

        #endregion

        #region "CONSTRUCTOR"

        public frmFamiliasABM(Guid id = default) : base(id)
        {
            InitializeComponent();
            InicializarFormulario();
        }

        #endregion

        #region "MÉTODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nueva Familia".Translate() : "Detalle Familia".Translate();
            lblDescripcion.Text = "Descripción".Translate();
            lblFamiliasHijos.Text = "Familias Hijos".Translate();
            lblPatentes.Text = "Patentes".Translate();

            ActualizarCaptionsColumnas();
        }

        protected override void ConfigurarGrillas()
        {
            gvFamiliasHijos.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            // Columnas de Familias Hijos
            gvFamiliasHijos.Columns.AddRange(new GridColumn[]
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Temp_Seleccionado),
                    Caption = "SELECCIONADO".Translate(),
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean,
                    ColumnEdit = new RepositoryItemCheckEdit()
                }
            });

            // Columnas de Patentes
            gvPatentes.Columns.AddRange(new GridColumn[]
            {
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Temp_Seleccionado),
                    Caption = "SELECCIONADO".Translate(),
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean,
                    ColumnEdit = new RepositoryItemCheckEdit()
                }
            });

            // Estilos
            GridStyleHelper.AplicarEstilo(gvFamiliasHijos);
            GridStyleHelper.AplicarEstilo(gvPatentes);

            // Evento de grilla
            gvFamiliasHijos.CellValueChanged += gvFamiliasHijos_CellValueChanged;
        }

        protected override void CargarDatos()
        {
            var res = FamiliasBLL.Current.Obtener(new ReqFamiliaObtener { Id = Id });

            TodasFamilias = res.ListaFamilias ?? new List<Familia>();
            TodasPatentes = res.ListaPatentes ?? new List<Patente>();
            FamiliaActual = res.Familia;

            if (FamiliaActual != null)
            {
                txtDescripcion.Text = FamiliaActual.Descripcion;

                TipoPantalla = FamiliaActual.Estado == E_Estados.Activo
                    ? E_TipoPantalla.Visualizar
                    : E_TipoPantalla.VisualizarEliminado;

                CargarGrillasConFamiliaExistente();
            }
            else
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
                CargarGrillasParaNuevo();
            }

            RefrescarGrillas();
        }

        protected override bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                XtraMessageBox.Show(
                    "La descripción es requerida".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            var familiasHijosIds = FamiliasHijosGrilla?
                .Where(f => f.Temp_Seleccionado)
                .Select(f => f.Id)
                .ToList() ?? new List<Guid>();

            var patentesIds = PatentesGrilla?
                .Where(p => p.Temp_Seleccionado)
                .Select(p => p.Id)
                .ToList() ?? new List<Guid>();

            if (EsNuevo)
            {
                var familia = new Familia
                {
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = E_Estados.Activo
                };

                var res = FamiliasBLL.Current.Insertar(new ReqFamiliaInsertar
                {
                    Familia = familia,
                    FamiliasHijosIds = familiasHijosIds,
                    PatentesIds = patentesIds
                });

                return res.Success;
            }
            else
            {
                FamiliaActual.Descripcion = txtDescripcion.Text.Trim();

                var res = FamiliasBLL.Current.Modificar(new ReqFamiliaModificar
                {
                    Familia = FamiliaActual,
                    FamiliasHijosIds = familiasHijosIds,
                    PatentesIds = patentesIds
                });

                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = FamiliasBLL.Current.Eliminar(new ReqFamiliaEliminar { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = FamiliasBLL.Current.Restaurar(new ReqFamiliaRestaurar { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            bool esEditable = EsModoEdicion;

            txtDescripcion.Properties.ReadOnly = !esEditable;
            gvFamiliasHijos.OptionsBehavior.Editable = esEditable;
            gvPatentes.OptionsBehavior.Editable = esEditable;

            ControlFactory.AplicarModo(
                esEditable,
                new[] { txtDescripcion },
                new[] { lblDescripcion, lblFamiliasHijos, lblPatentes },
                new[] { gvFamiliasHijos, gvPatentes }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Familia;
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void ActualizarCaptionsColumnas()
        {
            if (gvFamiliasHijos.Columns.Count > 0)
            {
                var colDesc = gvFamiliasHijos.Columns[nameof(Familia.Descripcion)];
                var colSel = gvFamiliasHijos.Columns[nameof(Familia.Temp_Seleccionado)];
                if (colDesc != null) colDesc.Caption = "DESCRIPCIÓN".Translate();
                if (colSel != null) colSel.Caption = "SELECCIONADO".Translate();
            }

            if (gvPatentes.Columns.Count > 0)
            {
                var colDesc = gvPatentes.Columns[nameof(Patente.Descripcion)];
                var colSel = gvPatentes.Columns[nameof(Patente.Temp_Seleccionado)];
                if (colDesc != null) colDesc.Caption = "DESCRIPCIÓN".Translate();
                if (colSel != null) colSel.Caption = "SELECCIONADO".Translate();
            }
        }

        private void CargarGrillasConFamiliaExistente()
        {
            FamiliasHijosGrilla = new List<Familia>(TodasFamilias);

            var familiasHijasDirectas = FamiliaActual.GetFamilias(true);
            FamiliasHijosGrilla.ForEach(f => f.Temp_Seleccionado = familiasHijasDirectas.Any(fh => fh.Id == f.Id));

            FamiliasHijosGrilla = FamiliasHijosGrilla
                .Where(f => !CreariaCicloRecursivo(f, FamiliaActual.Id))
                .ToList();

            PatentesGrilla = new List<Patente>(TodasPatentes);
            var patentesDirectas = FamiliaActual.GetPatentes(true);
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = patentesDirectas.Any(pd => pd.Id == p.Id));

            ActualizarPatentesSegunFamiliasSeleccionadas();
        }

        private void CargarGrillasParaNuevo()
        {
            FamiliasHijosGrilla = new List<Familia>(TodasFamilias);
            FamiliasHijosGrilla.ForEach(f => f.Temp_Seleccionado = false);

            PatentesGrilla = new List<Patente>(TodasPatentes);
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = false);
        }

        private bool CreariaCicloRecursivo(Familia familiaCandidata, Guid familiaActualId)
        {
            return ContieneEnArbol(familiaCandidata, familiaActualId, new HashSet<Guid>());
        }

        private bool ContieneEnArbol(Familia familia, Guid idBuscado, HashSet<Guid> visitados)
        {
            if (visitados.Contains(familia.Id))
                return false;

            visitados.Add(familia.Id);

            foreach (var acceso in familia.Accesos)
            {
                if (acceso.Id == idBuscado)
                    return true;

                if (acceso is Familia familiaHija && ContieneEnArbol(familiaHija, idBuscado, visitados))
                    return true;
            }

            return false;
        }

        private void ActualizarPatentesSegunFamiliasSeleccionadas()
        {
            if (PatentesGrilla == null) return;

            var familiasSeleccionadas = FamiliasHijosGrilla?.Where(f => f.Temp_Seleccionado).ToList() ?? new List<Familia>();
            var patentesHeredadas = new HashSet<Guid>();

            foreach (var familia in familiasSeleccionadas)
            {
                foreach (var patente in familia.GetPatentes())
                {
                    patentesHeredadas.Add(patente.Id);
                }
            }
        }

        private void RefrescarGrillas()
        {
            gcFamiliasHijos.RefreshDataSource();
            gcPatentes.RefreshDataSource();
        }

        private void gvFamiliasHijos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == nameof(Familia.Temp_Seleccionado))
            {
                ActualizarPatentesSegunFamiliasSeleccionadas();
                gcPatentes.RefreshDataSource();
            }
        }

        #endregion
    }
}