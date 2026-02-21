using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using Services.BLL.Services;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Helpers;

namespace UI.Formularios.Administrador.Usuarios
{
    public partial class frmUsuarios : XtraForm, IObserver
    {
        #region "CONSTRUCTOR"
        public frmUsuarios()
        {
            InitializeComponent();

            FormSubject.Current.Attach(this);

            ControlesInicializar();
        }
        #endregion

        #region "PROCEDIMIENTOS"
        private void ControlesInicializar()
        {
            gvUsuarios.FocusedRowChanged += gvUsuarios_FocusedRowChanged;
            gvUsuarios.DoubleClick += gvUsuarios_DoubleClick;

            gvUsuarios.OptionsDetail.EnableMasterViewMode = false;
            gvFamilias.OptionsDetail.EnableMasterViewMode = false;
            gvPatentes.OptionsDetail.EnableMasterViewMode = false;

            ConfigurarTextos();
            ConfigurarColumnas();
            
            // Aplicar estilos automáticamente (grilla principal + grillas compactas de detalle)
            FormStyleHelper.AplicarEstilosListado(this, "gcUsuarios");
            ButtonStyleHelper.ConfigurarBarraHerramientas(btnNuevo, btnDetalle, btnRefresh, btnExport);
            
            CargarPantalla();
        }

        private void ConfigurarTextos()
        {
            this.Text = "Usuarios".Translate();
            labelControl3.Text = "Usuarios".Translate();
            labelControl1.Text = "Familias".Translate();
            labelControl2.Text = "Patentes".Translate();

            // Actualizar textos de los botones de la barra de herramientas
            btnNuevo.Text = "Nuevo".Translate();
            btnDetalle.Text = "Ver Detalle".Translate();
            btnRefresh.Text = "Actualizar".Translate();
            btnExport.Text = "Exportar".Translate();

            // Actualizar captions de las columnas de grillas
            ActualizarCaptionsColumnas();
        }

        private void ActualizarCaptionsColumnas()
        {
            // Columnas de gvUsuarios
            if (gvUsuarios.Columns.Count > 0)
            {
                var colEstado = gvUsuarios.Columns[nameof(Usuario.Estado)];
                var colUserName = gvUsuarios.Columns[nameof(Usuario.UserName)];

                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
                if (colUserName != null) colUserName.Caption = "NOMBRE DE USUARIO".Translate();
            }

            // Columnas de gvFamilias
            if (gvFamilias.Columns.Count > 0)
            {
                var colDescripcion = gvFamilias.Columns[nameof(Familia.Descripcion)];
                var colEstado = gvFamilias.Columns[nameof(Familia.Estado)];

                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
            }

            // Columnas de gvPatentes
            if (gvPatentes.Columns.Count > 0)
            {
                var colDescripcion = gvPatentes.Columns[nameof(Patente.Descripcion)];
                var colEstado = gvPatentes.Columns[nameof(Patente.Estado)];

                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
            }
        }

        private void ConfigurarColumnas()
        {
            List<GridColumn> gridColumnsUsuarios = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Usuario.IdUsuario),
                    Caption = "ID",
                    Visible = false,
                },
                new GridColumn
                {
                    FieldName = nameof(Usuario.Estado),
                    Caption = "ESTADO".Translate(),
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Usuario.UserName),
                    Caption = "NOMBRE DE USUARIO".Translate(),
                    Visible = true,
                },
            };

            gvUsuarios.Columns.AddRange(gridColumnsUsuarios.ToArray());
            
            // Columnas para familias
            List<GridColumn> gridColumnsFamilias = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Familia.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Familia.Estado),
                    Caption = "ESTADO".Translate(),
                    Visible = true,
                },
            };
            
            gvFamilias.Columns.AddRange(gridColumnsFamilias.ToArray());

            // Columnas para patentes
            List<GridColumn> gridColumnsPatentes = new List<GridColumn>
            {
                new GridColumn
                {
                    FieldName = nameof(Patente.Descripcion),
                    Caption = "DESCRIPCIÓN".Translate(),
                    Visible = true,
                },
                new GridColumn
                {
                    FieldName = nameof(Patente.Estado),
                    Caption = "ESTADO".Translate(),
                    Visible = true,
                }
            };

            gvPatentes.Columns.AddRange(gridColumnsPatentes.ToArray());
        }

        private void CargarPantalla()
        {
            var res = UsuarioBLL.Current.ObtenerLista(new ReqUsuariosObtener());
            this.gcUsuarios.DataSource = res.Usuarios;
        }

        private void CargarDetallesUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                this.gcFamilias.DataSource = usuario.GetFamilias();
                this.gcPatentes.DataSource = usuario.GetPatentes();

                this.gcFamilias.RefreshDataSource();
                this.gcPatentes.RefreshDataSource();
            }
            else
            {
                this.gcFamilias.DataSource = null;
                this.gcPatentes.DataSource = null;
            }
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Usuario.Equals(value))
            {
                CargarPantalla();
            }
            else if (E_FormsServicesValues.Idioma.Equals(value))
            {
                ConfigurarTextos();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            FormSubject.Current.Detach(this);
            base.OnFormClosed(e);
        }
        #endregion

        #region "EVENTOS"
        private void gvUsuarios_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowHandle = e.FocusedRowHandle;

            if (rowHandle >= 0)
            {
                Usuario usuario = gvUsuarios.GetRow(rowHandle) as Usuario;
                CargarDetallesUsuario(usuario);
            }
            else
            {
                CargarDetallesUsuario(null);
            }

            btnDetalle.Enabled = rowHandle >= 0;
        }

        private void gvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (gcUsuarios.MainView is DevExpress.XtraGrid.Views.Grid.GridView gridView)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo Excel".Translate();
                    saveFileDialog.FileName = "Usuarios.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        gridView.ExportToXlsx(saveFileDialog.FileName);
                        XtraMessageBox.Show("Exportación completada exitosamente.".Translate(), "Éxito".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("El GridControl no contiene un GridView válido.".Translate(), "Error".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormulariosManager.UsuariosABM();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        private void AbrirDetalle()
        {
            int rowHandle = gvUsuarios.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                Usuario usuarioSeleccionado = gvUsuarios.GetRow(rowHandle) as Usuario;

                if (usuarioSeleccionado != null)
                {
                    FormulariosManager.UsuariosABM(usuarioSeleccionado.IdUsuario);
                }
            }
        }
        #endregion
    }
}
