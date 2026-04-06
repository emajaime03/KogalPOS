using BLL.Services;
using DevExpress.XtraEditors;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Premios
{
    public partial class frmPremiosABM : frmBaseABM
    {
        private List<Articulo> ArticulosDisponibles { get; set; }

        public frmPremiosABM(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            ConfigurarComboArticulos();
            InicializarFormulario();

            ControlFactory.ConfigurarLayoutItem(this.lciDescripcion, false);
            ControlFactory.ConfigurarLayoutItem(this.lciArticulo, false);
            ControlFactory.ConfigurarLayoutItem(this.lciPuntosRequeridos, false);
        }

        #region "METODOS PRIVADOS"

        private void ConfigurarComboArticulos()
        {
            var res = ArticulosBLL.Current.ObtenerLista(new ReqArticulosObtener(this.Sesion));
            ArticulosDisponibles = res.Articulos ?? new List<Articulo>();
            
            lkpArticulo.Properties.DataSource = ArticulosDisponibles;
            lkpArticulo.Properties.ValueMember = nameof(Articulo.IdArticulo);
            lkpArticulo.Properties.DisplayMember = nameof(Articulo.Descripcion);
            lkpArticulo.Properties.NullText = "Seleccione un artículo...".Translate();
            lkpArticulo.Properties.Columns.Clear();
            lkpArticulo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Articulo.Codigo), "Código".Translate(), 80));
            lkpArticulo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Articulo.Descripcion), "Descripción".Translate(), 200));
        }

        #endregion

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = EsNuevo ? "Nuevo Premio".Translate() : "Detalle de Premio".Translate();
            lciDescripcion.Text = "Descripción".Translate();
            lciArticulo.Text = "Artículo asociado".Translate();
            lciPuntosRequeridos.Text = "Puntos requeridos".Translate();
        }

        protected override void CargarDatos()
        {
            if (EsNuevo)
            {
                TipoPantalla = E_TipoPantalla.Nuevo;
                lkpArticulo.EditValue = null;
                spnPuntosRequeridos.Value = 0;
            }
            else
            {
                var res = PremiosBLL.Current.Obtener(new ReqPremioObtener(this.Sesion) { Id = Id });

                if (res.Success && res.Premio != null)
                {
                    txtDescripcion.Text = res.Premio.Descripcion;
                    lkpArticulo.EditValue = res.Premio.IdArticulo;
                    spnPuntosRequeridos.Value = res.Premio.PuntosRequeridos;

                    TipoPantalla = res.Premio.Estado == E_Estados.Activo
                        ? E_TipoPantalla.Visualizar
                        : E_TipoPantalla.VisualizarEliminado;
                }
            }
        }

        protected override bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                XtraMessageBox.Show(
                    "La Descripción es obligatoria.".Translate(),
                    "Validación".Translate(),
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (lkpArticulo.EditValue == null || (Guid)lkpArticulo.EditValue == Guid.Empty)
            {
                XtraMessageBox.Show(
                    "Debe seleccionar un artículo asociado.".Translate(),
                    "Validación".Translate(),
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                lkpArticulo.Focus();
                return false;
            }

            if (spnPuntosRequeridos.Value <= 0)
            {
                XtraMessageBox.Show(
                    "Los puntos requeridos deben ser mayor a cero.".Translate(),
                    "Validación".Translate(),
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                spnPuntosRequeridos.Focus();
                return false;
            }

            return true;
        }

        protected override bool GuardarDatos()
        {
            if (EsNuevo)
            {
                var req = new ReqPremiosInsertar(this.Sesion)
                {
                    Premio = new Premio
                    {
                        Descripcion = txtDescripcion.Text.Trim(),
                        IdArticulo = (Guid)lkpArticulo.EditValue,
                        PuntosRequeridos = spnPuntosRequeridos.Value
                    }
                };

                var res = PremiosBLL.Current.Insertar(req);
                return res.Success;
            }
            else
            {
                var req = new ReqPremiosModificar(this.Sesion)
                {
                    Premio = new Premio
                    {
                        IdPremio = Id,
                        Descripcion = txtDescripcion.Text.Trim(),
                        IdArticulo = (Guid)lkpArticulo.EditValue,
                        PuntosRequeridos = spnPuntosRequeridos.Value
                    }
                };

                var res = PremiosBLL.Current.Modificar(req);
                return res.Success;
            }
        }

        protected override bool EliminarRegistro()
        {
            var res = PremiosBLL.Current.Eliminar(new ReqPremiosEliminar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override bool RestaurarRegistro()
        {
            var res = PremiosBLL.Current.Restaurar(new ReqPremiosRestaurar(this.Sesion) { Id = Id });
            return res.Success;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new DevExpress.XtraEditors.TextEdit[] { this.txtDescripcion, this.lkpArticulo, this.spnPuntosRequeridos },
                itemsLayout: new[] { this.lciDescripcion, this.lciArticulo, this.lciPuntosRequeridos }
            );

            if(EsModoEdicion)
            {
                lkpArticulo.Properties.ReadOnly = false;
            }
            else
            {
                lkpArticulo.Properties.ReadOnly = true;
            }
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Premio;
        }

        #endregion
    }
}
