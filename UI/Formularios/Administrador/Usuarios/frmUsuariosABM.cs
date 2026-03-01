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

namespace UI.Formularios.Administrador.Usuarios
{
    public partial class frmUsuariosABM : frmBaseABM
    {
        #region "PROPIEDADES"

        private Usuario UsuarioActual { get; set; }
        private List<Familia> TodasFamilias { get; set; }
        private List<Patente> TodasPatentes { get; set; }

        private List<Familia> FamiliasGrilla
        {
            get => (List<Familia>)gcFamilias.DataSource;
            set => gcFamilias.DataSource = value;
        }

        private List<Patente> PatentesGrilla
        {
            get => (List<Patente>)gcPatentes.DataSource;
            set => gcPatentes.DataSource = value;
        }

        #endregion

        #region "CONSTRUCTOR"

        public frmUsuariosABM(Guid id = default) : base(id)
        {
            InitializeComponent();
            InicializarFormulario();
        }

        #endregion

        #region "MÉTODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Usuario".Translate() : "Detalle Usuario".Translate();
            lblUserName.Text = "Usuario".Translate();
            lblPassword.Text = "Contraseña".Translate();
            lblFamilias.Text = "Familias".Translate();
            lblPatentes.Text = "Patentes".Translate();

            ActualizarCaptionsColumnas();
        }

        protected override void ConfigurarGrillas()
        {
            gvFamilias.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            // Columnas de Familias
            gvFamilias.Columns.AddRange(new GridColumn[]
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
            GridStyleHelper.AplicarEstilo(gvFamilias);
            GridStyleHelper.AplicarEstilo(gvPatentes);

            // Evento de grilla
            gvFamilias.CellValueChanged += gvFamilias_CellValueChanged;
        }

        protected override void CargarDatos()
        {
            var res = UsuarioBLL.Current.Obtener(new ReqUsuarioObtener { Id = Id });

            TodasFamilias = res.ListaFamilias ?? new List<Familia>();
            TodasPatentes = res.ListaPatentes ?? new List<Patente>();
            UsuarioActual = res.Usuario;

            if (UsuarioActual != null)
            {
                txtUserName.Text = UsuarioActual.UserName;
                txtPassword.Text = "";

                TipoPantalla = UsuarioActual.Estado == E_Estados.Activo
                    ? E_TipoPantalla.Visualizar
                    : E_TipoPantalla.VisualizarEliminado;

                CargarGrillasConUsuarioExistente();
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
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                XtraMessageBox.Show(
                    "El nombre de usuario es requerido".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }

            if (EsNuevo && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show(
                    "La contraseña es requerida para nuevos usuarios".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            var familiasIds = FamiliasGrilla?
                .Where(f => f.Temp_Seleccionado)
                .Select(f => f.Id)
                .ToList() ?? new List<Guid>();

            var patentesIds = PatentesGrilla?
                .Where(p => p.Temp_Seleccionado)
                .Select(p => p.Id)
                .ToList() ?? new List<Guid>();

            if (EsNuevo)
            {
                var usuario = new Usuario
                {
                    UserName = txtUserName.Text.Trim(),
                    Password = txtPassword.Text,
                    Estado = E_Estados.Activo
                };

                var res = UsuarioBLL.Current.Insertar(new ReqUsuarioInsertar
                {
                    Usuario = usuario,
                    FamiliasIds = familiasIds,
                    PatentesIds = patentesIds
                });

                return res.Success;
            }
            else
            {
                UsuarioActual.UserName = txtUserName.Text.Trim();
                UsuarioActual.Password = !string.IsNullOrWhiteSpace(txtPassword.Text)
                    ? txtPassword.Text
                    : null;

                var res = UsuarioBLL.Current.Modificar(new ReqUsuarioModificar
                {
                    Usuario = UsuarioActual,
                    FamiliasIds = familiasIds,
                    PatentesIds = patentesIds
                });

                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = UsuarioBLL.Current.Eliminar(new ReqUsuarioEliminar { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = UsuarioBLL.Current.Restaurar(new ReqUsuarioRestaurar { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            bool esEditable = EsModoEdicion;

            txtUserName.Properties.ReadOnly = !esEditable;
            txtPassword.Properties.ReadOnly = !esEditable;
            gvFamilias.OptionsBehavior.Editable = esEditable;
            gvPatentes.OptionsBehavior.Editable = esEditable;

            ControlFactory.AplicarModo(
                esEditable,
                new[] { txtUserName, txtPassword },
                new[] { lblUserName, lblPassword, lblFamilias, lblPatentes },
                new[] { gvFamilias, gvPatentes }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Usuario;
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void ActualizarCaptionsColumnas()
        {
            if (gvFamilias.Columns.Count > 0)
            {
                var colDesc = gvFamilias.Columns[nameof(Familia.Descripcion)];
                var colSel = gvFamilias.Columns[nameof(Familia.Temp_Seleccionado)];
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

        private void CargarGrillasConUsuarioExistente()
        {
            FamiliasGrilla = new List<Familia>(TodasFamilias);
            var familiasDirectas = UsuarioActual.Accesos.OfType<Familia>().ToList();
            FamiliasGrilla.ForEach(f => f.Temp_Seleccionado = familiasDirectas.Any(fd => fd.Id == f.Id));

            PatentesGrilla = new List<Patente>(TodasPatentes);
            var patentesDirectas = UsuarioActual.Accesos.OfType<Patente>().ToList();
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = patentesDirectas.Any(pd => pd.Id == p.Id));

            ActualizarPatentesSegunFamiliasSeleccionadas();
        }

        private void CargarGrillasParaNuevo()
        {
            FamiliasGrilla = new List<Familia>(TodasFamilias);
            FamiliasGrilla.ForEach(f => f.Temp_Seleccionado = false);

            PatentesGrilla = new List<Patente>(TodasPatentes);
            PatentesGrilla.ForEach(p => p.Temp_Seleccionado = false);
        }

        private void ActualizarPatentesSegunFamiliasSeleccionadas()
        {
            if (PatentesGrilla == null) return;

            var familiasSeleccionadas = FamiliasGrilla?.Where(f => f.Temp_Seleccionado).ToList() ?? new List<Familia>();
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
            gcFamilias.RefreshDataSource();
            gcPatentes.RefreshDataSource();
        }

        private void gvFamilias_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
