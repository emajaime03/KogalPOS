using BLL.Services;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using System;
using System.Configuration;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Administrador.ConfiguracionLocal
{
    public partial class frmConfiguracionLocal : frmBaseABM
    {
        public frmConfiguracionLocal(Services.Domain.GlobalCliente sesion, Guid id = default) : base(sesion, id)
        {
            InitializeComponent();
            InicializarFormulario();

            this.MostrarBotonEliminar = false;
            this.MostrarBotonRestaurar = false;
            
            ControlFactory.ConfigurarLayoutItem(this.lciFidelizacion, true);
            ControlFactory.ConfigurarLayoutItem(this.lciMontoRequerido, false);
            ControlFactory.ConfigurarLayoutItem(this.lciPuntosOtorgados, false);
            ControlFactory.ConfigurarLayoutItem(this.lciMontoMinimo, false);
        }

        #region "METODOS PRIVADOS"

        #endregion

        #region "METODOS OVERRIDE"

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Configuración local".Translate();
            lciFidelizacion.Text = "Fidelización".Translate();
            lciMontoRequerido.Text = "Monto Requerido".Translate();
            lciPuntosOtorgados.Text = "Puntos Otorgados".Translate();
            lciMontoMinimo.Text = "Monto Mínimo".Translate();
        }

        protected override void CargarDatos()
        {
            var configuracionLocal = ConfiguracionApp.Current.configuracionLocal;

            numMontoMinimo.Value = configuracionLocal.Loyalty_MontoMinimo;
            numMontoRequerido.Value = configuracionLocal.Loyalty_MontoRequerido;
            numPuntosOtorgados.Value = configuracionLocal.Loyalty_PuntosOtorgados;

            TipoPantalla = E_TipoPantalla.Visualizar;
        }

        protected override bool ValidarDatos()
        {
            return true;
        }

        protected override bool GuardarDatos()
        {
            var req = new ReqConfiguracionLocalModificar(this.Sesion)
            {
                configuracionLocal = ConfiguracionApp.Current.configuracionLocal                
            };

            req.configuracionLocal.Loyalty_MontoMinimo = numMontoMinimo.Value;
            req.configuracionLocal.Loyalty_MontoRequerido = numMontoRequerido.Value;
            req.configuracionLocal.Loyalty_PuntosOtorgados = numPuntosOtorgados.Value;

            var res = ConfiguracionLocalBLL.Current.Modificar(req);
            return res.Success;
        }

        protected override bool EliminarRegistro()
        {
            return true;
        }

        protected override bool RestaurarRegistro()
        {
            return true;
        }

        protected override void OnTipoPantallaCambiado(E_TipoPantalla tipoPantalla)
        {
            ControlFactory.AplicarModo(
                esEditable: EsModoEdicion,
                textEdits: new[] { this.numMontoMinimo, this.numMontoRequerido, this.numPuntosOtorgados },
                itemsLayout: new[] { this.lciFidelizacion, this.lciMontoMinimo, this.lciMontoRequerido,
                    this.lciPuntosOtorgados }
            );
        }

        protected override E_FormsServicesValues? GetFormServiceValue()
        {
            return E_FormsServicesValues.Cliente;
        }

        #endregion
    }
}
