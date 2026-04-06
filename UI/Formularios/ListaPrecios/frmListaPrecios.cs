using BLL.Services;
using Domain;
using Domain.DTOs;
using Domain.BLL;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.ListaPrecios
{
    public partial class frmListaPrecios : frmBaseGrilla
    {
        public frmListaPrecios(Services.Domain.GlobalCliente sesion) : base(sesion)
        {
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Listas de Precios".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(ListaPrecioDTO.IdListaPrecio), "ID", visible: false),
                CrearColumna(nameof(ListaPrecioDTO.Estado), "Estado".Translate()),
                CrearColumna(nameof(ListaPrecioDTO.Descripcion), "Descripción".Translate()),
                CrearColumna(nameof(ListaPrecioDTO.EsPredeterminada), "Es Predeterminada".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = ListasPreciosBLL.Current.ObtenerLista(new ReqListaPreciosObtener(this.Sesion));
            EstablecerDataSource(res.ListaPrecios);
        }

        protected override void OnNuevoClick()
        {
            FormulariosManager.ListaPreciosABM();
        }

        protected override void OnDetalleClick()
        {
            var lista = ObtenerFilaSeleccionada<ListaPrecioDTO>();
            if (lista != null)
            {
                FormulariosManager.ListaPreciosABM(lista.IdListaPrecio);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.ListaPrecio.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
