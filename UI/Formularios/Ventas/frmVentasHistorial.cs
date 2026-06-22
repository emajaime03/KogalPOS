using BLL.Services;
using Domain.BLL;
using Domain.DTOs;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Ventas
{
    public partial class frmVentasHistorial : frmBaseGrilla
    {
        public frmVentasHistorial(Services.Domain.GlobalCliente sesion) : base(sesion)
        {
            // Solo se puede abrir el Punto de Venta si se tiene la patente correspondiente.
            MostrarBotonNuevo = sesion.UsuarioLogin.CheckPatente(E_Patentes.PuntoDeVenta);
        }

        protected override void ConfigurarTextos()
        {
            base.ConfigurarTextos();
            this.Text = "Ventas".Translate();
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(VentaDTO.IdVenta), "ID", visible: false),
                CrearColumna(nameof(VentaDTO.NroVenta), "Nº Venta".Translate()),
                CrearColumna(nameof(VentaDTO.Fecha), "Fecha".Translate()),
                CrearColumna(nameof(VentaDTO.DescripcionCliente), "Cliente".Translate()),
                CrearColumna(nameof(VentaDTO.Total), "Total".Translate()),
                CrearColumna(nameof(VentaDTO.Estado), "Estado".Translate())
            );
        }

        protected override void CargarPantalla()
        {
            var res = VentasBLL.Current.ObtenerLista(new ReqVentasObtener(this.Sesion));
            EstablecerDataSource(res.Ventas);
        }

        protected override void OnNuevoClick()
        {
            if (!Sesion.UsuarioLogin.CheckPatente(E_Patentes.PuntoDeVenta))
                return;

            FormulariosManager.PuntoDeVenta();
        }

        protected override void OnDetalleClick()
        {
            var venta = ObtenerFilaSeleccionada<VentaDTO>();
            if (venta != null)
            {
                FormulariosManager.VentaVista(venta.IdVenta);
            }
        }

        public override void Update<T>(T value, object data = null)
        {
            base.Update(value, data);

            if (E_FormsServicesValues.Venta.Equals(value))
            {
                CargarPantalla();
            }
        }
    }
}
