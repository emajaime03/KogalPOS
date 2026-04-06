using BLL.Services;
using Domain;
using Domain.BLL;
using Domain.DTOs;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Premios
{
    public partial class frmPremios : frmBaseGrilla
    {
        public frmPremios(Services.Domain.GlobalCliente sesion) : base(sesion)
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Premios".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(PremioDTO.IdPremio), "ID", visible: false),
                CrearColumna(nameof(PremioDTO.Estado), "Estado".Translate()),
                CrearColumna(nameof(PremioDTO.Descripcion), "Descripción".Translate()),
                CrearColumna(nameof(PremioDTO.PuntosRequeridos), "Puntos requeridos".Translate()),
                CrearColumna(nameof(PremioDTO.Articulo), "Artículo".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = PremiosBLL.Current.ObtenerLista(new ReqPremiosObtener(this.Sesion));
            EstablecerDataSource(res.Premios);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.PremiosABM();
        }

        protected override void OnDetalleClick()
        {
            var premio = ObtenerFilaSeleccionada<PremioDTO>();
            if (premio != null)
            {
                FormulariosManager.PremiosABM(premio.IdPremio);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.Premio.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
