using DevExpress.XtraEditors;
using Domain.BLL;
using Domain.DTOs;
using Domain.Enums;
using Services.Facade.Extensions;
using System;
using System.Windows.Forms;

namespace UI.Formularios.Ventas
{
    /// <summary>
    /// Popup modal de cobro. Devuelve un CobroDTO en la propiedad Resultado cuando DialogResult == OK.
    /// </summary>
    public partial class frmCobro : XtraForm
    {
        public CobroDTO Resultado { get; private set; }

        private readonly decimal _total;

        public frmCobro(decimal total)
        {
            InitializeComponent();
            _total = total;
            ConfigurarTextos();
            ConfigurarControles();
        }

        private void ConfigurarTextos()
        {
            this.Text = "Cobrar".Translate();
            lblTotalTitulo.Text = "Total".Translate() + ":";
            lblTotal.Text = "$ " + _total.ToString("N2");
            lblTipoComprobante.Text = "Tipo de Comprobante".Translate() + ":";
            lblFormaPago.Text = "Forma de Pago".Translate() + ":";
            lblMontoRecibido.Text = "Monto Recibido".Translate() + ":";
            lblVueltoTitulo.Text = "Vuelto".Translate() + ":";
            btnConfirmar.Text = "Aceptar".Translate();
            btnCancelar.Text = "Cancelar".Translate();
        }

        private void ConfigurarControles()
        {
            cmbTipoComprobante.Properties.Items.Clear();
            cmbTipoComprobante.Properties.Items.Add("Tique".Translate());
            cmbTipoComprobante.Properties.Items.Add("Tique No Fiscal".Translate());
            cmbTipoComprobante.SelectedIndex = 0;

            cmbFormaPago.Properties.Items.Clear();
            cmbFormaPago.Properties.Items.Add("Efectivo".Translate());
            cmbFormaPago.Properties.Items.Add("Tarjeta".Translate());
            cmbFormaPago.Properties.Items.Add("MercadoPago".Translate());
            cmbFormaPago.SelectedIndex = 0;

            spnMontoRecibido.Properties.MinValue = 0;
            spnMontoRecibido.Properties.MaxValue = 9999999;
            spnMontoRecibido.Properties.IsFloatValue = true;
            spnMontoRecibido.EditValue = _total;

            cmbFormaPago.SelectedIndexChanged += (s, e) => ActualizarEstadoPago();
            spnMontoRecibido.EditValueChanged += (s, e) => CalcularVuelto();

            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            ActualizarEstadoPago();
        }

        private bool EsEfectivo => cmbFormaPago.SelectedIndex == 0;

        private void ActualizarEstadoPago()
        {
            spnMontoRecibido.Enabled = EsEfectivo;
            if (!EsEfectivo)
                spnMontoRecibido.EditValue = _total;
            CalcularVuelto();
        }

        private void CalcularVuelto()
        {
            decimal recibido = Convert.ToDecimal(spnMontoRecibido.EditValue ?? 0);
            decimal vuelto = recibido - _total;
            lblVuelto.Text = "$ " + (vuelto > 0 ? vuelto : 0).ToString("N2");
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            decimal recibido = Convert.ToDecimal(spnMontoRecibido.EditValue ?? 0);

            if (EsEfectivo && recibido < _total)
            {
                XtraMessageBox.Show(
                    "El monto recibido es insuficiente".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Resultado = new CobroDTO
            {
                TipoComprobante = cmbTipoComprobante.SelectedIndex == 0
                    ? E_TipoComprobante.Tique
                    : E_TipoComprobante.TiqueNoFiscal,
                FormaPago = (E_FormaPago)(cmbFormaPago.SelectedIndex + 1),
                MontoRecibido = EsEfectivo ? recibido : _total,
                Vuelto = EsEfectivo ? Math.Max(0, recibido - _total) : 0
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
