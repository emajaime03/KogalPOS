using BLL.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Domain.BLL;
using Domain.DTOs;
using Domain.Enums;
using Services.Domain;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Windows.Forms;
using UI.Formularios.Base;
using UI.Helpers;

namespace UI.Formularios.Ventas
{
    /// <summary>
    /// Vista de solo lectura del detalle de una venta, con opción de anular (Nota de Crédito).
    /// </summary>
    public partial class frmVentaVista : XtraForm
    {
        private readonly GlobalCliente _sesion;
        private readonly Guid _idVenta;
        private VentaDTO _venta;

        public frmVentaVista(GlobalCliente sesion, Guid idVenta)
        {
            InitializeComponent();
            _sesion = sesion;
            _idVenta = idVenta;

            ConfigurarGrilla();
            ConfigurarEventos();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();
            btnAnular.Click += BtnAnular_Click;
        }

        private void ConfigurarGrilla()
        {
            gvItems.OptionsBehavior.Editable = false;
            gvItems.OptionsView.ShowGroupPanel = false;
            gvItems.Columns.Clear();
            gvItems.Columns.AddRange(new GridColumn[]
            {
                Col(nameof(VentaItemDTO.Codigo), "Código".Translate(), 80, null),
                Col(nameof(VentaItemDTO.Descripcion), "Descripción".Translate(), 220, null),
                Col(nameof(VentaItemDTO.Cantidad), "Cantidad".Translate(), 80, "0.##"),
                Col(nameof(VentaItemDTO.PrecioUnitario), "Precio".Translate(), 90, "$ #,##0.00"),
                Col(nameof(VentaItemDTO.Subtotal), "Subtotal".Translate(), 100, "$ #,##0.00")
            });
            GridStyleHelper.AplicarEstilo(gvItems);
        }

        private GridColumn Col(string fieldName, string caption, int width, string formato)
        {
            var col = new GridColumn { FieldName = fieldName, Caption = caption, Visible = true, Width = width };
            if (!string.IsNullOrEmpty(formato))
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = formato;
            }
            return col;
        }

        private void CargarDatos()
        {
            var res = VentasBLL.Current.Obtener(new ReqVentaObtener(_sesion) { Id = _idVenta });
            if (!res.Success || res.Venta == null)
            {
                XtraMessageBox.Show(res.Message.Translate(), "Error".Translate(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _venta = res.Venta;

            this.Text = "Detalle de Venta".Translate();
            lblNroVenta.Text = "Nº Venta".Translate() + ": " + _venta.NroVenta;
            lblFecha.Text = "Fecha".Translate() + ": " + _venta.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblEstado.Text = "Estado".Translate() + ": " + TraducirEstado(_venta.Estado);
            lblCliente.Text = "Cliente".Translate() + ": " + _venta.DescripcionCliente;
            lblLista.Text = "Lista de Precios".Translate() + ": " + _venta.DescripcionListaPrecio;
            lblComprobante.Text = "Comprobante".Translate() + ": " + TraducirComprobante(_venta.TipoComprobante) + " N° " + _venta.NroDocumento;
            lblFormaPago.Text = "Forma de Pago".Translate() + ": " + TraducirFormaPago(_venta.FormaPago);
            lblTotalTitulo.Text = "Total".Translate() + ":";
            lblTotal.Text = "$ " + _venta.Total.ToString("N2");
            lblDescuento.Text = "Descuento".Translate() + ": $ " + _venta.Descuento.ToString("N2");
            lblDescuento.Visible = _venta.Descuento > 0;

            btnAnular.Text = "Anular".Translate();
            btnCerrar.Text = "Cerrar".Translate();
            btnAnular.Visible = _venta.Estado == E_EstadoVenta.Cobrada;

            gcItems.DataSource = _venta.Items;
            gvItems.RefreshData();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            var r = XtraMessageBox.Show(
                "¿Está seguro que desea anular esta venta? Se emitirá una Nota de Crédito.".Translate(),
                "Anular".Translate(),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            var res = VentasBLL.Current.Anular(new ReqVentaAnular(_sesion) { Id = _idVenta });

            if (res.Success)
            {
                XtraMessageBox.Show(res.Message.Translate(), "Éxito".Translate(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormSubject.Current.Notify(E_FormsServicesValues.Venta);
                CargarDatos();
            }
            else
            {
                XtraMessageBox.Show(res.Message.Translate(), "Error".Translate(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region "TRADUCCIONES"

        private string TraducirEstado(E_EstadoVenta estado)
        {
            return estado == E_EstadoVenta.Cobrada ? "Cobrada".Translate() : "Anulada".Translate();
        }

        private string TraducirComprobante(E_TipoComprobante tipo)
        {
            switch (tipo)
            {
                case E_TipoComprobante.Tique: return "Tique".Translate();
                case E_TipoComprobante.TiqueNoFiscal: return "Tique No Fiscal".Translate();
                case E_TipoComprobante.NotaCredito: return "Nota de Crédito".Translate();
                case E_TipoComprobante.NotaCreditoNoFiscal: return "Nota de Crédito No Fiscal".Translate();
                default: return string.Empty;
            }
        }

        private string TraducirFormaPago(E_FormaPago forma)
        {
            switch (forma)
            {
                case E_FormaPago.Efectivo: return "Efectivo".Translate();
                case E_FormaPago.Tarjeta: return "Tarjeta".Translate();
                case E_FormaPago.MercadoPago: return "MercadoPago".Translate();
                default: return string.Empty;
            }
        }

        #endregion
    }
}
