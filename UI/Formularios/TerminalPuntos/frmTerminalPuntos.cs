using BLL.Services;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Domain;
using Domain.BLL;
using Domain.DTOs;
using Domain.Enums;
using Services.Domain;
using Services.Domain.Enums;
using Services.Facade.Extensions;
using Services.Facade.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using UI.Helpers;

namespace UI.Formularios.TerminalPuntos
{
    /// <summary>
    /// Terminal de Fidelización. Permite, para un cliente, canjear premios (descuenta puntos)
    /// y/o acumular puntos por un monto pagado, en una única operación.
    /// </summary>
    public partial class frmTerminalPuntos : XtraForm, IObserver
    {
        #region "PROPIEDADES"
        public GlobalCliente Sesion { get; private set; }

        private BindingList<PremioCanjeDTO> CarritoBinding { get; set; }
        private List<PremioDTO> _premios = new List<PremioDTO>();

        private int _puntosDisponibles = 0;

        // Paleta para los círculos de iniciales (consistente con el Punto de Venta).
        private static readonly Color[] _paleta =
        {
            Color.FromArgb(0, 123, 255),  Color.FromArgb(40, 167, 69),  Color.FromArgb(220, 53, 69),
            Color.FromArgb(255, 153, 0),  Color.FromArgb(111, 66, 193), Color.FromArgb(23, 162, 184),
            Color.FromArgb(232, 62, 140), Color.FromArgb(253, 126, 20), Color.FromArgb(32, 201, 151),
            Color.FromArgb(108, 117, 125)
        };

        private static readonly Color CardBase = Color.White;
        private static readonly Color CardHover = Color.FromArgb(232, 240, 254);

        private Guid? ClienteSeleccionadoId =>
            lkpCliente.EditValue is Guid g && g != Guid.Empty ? g : (Guid?)null;
        #endregion

        #region "CONSTRUCTOR"
        public frmTerminalPuntos(GlobalCliente sesion)
        {
            InitializeComponent();
            Sesion = sesion;

            FormSubject.Current.Attach(this);

            ConfigurarGrillaCarrito();
            ConfigurarMonto();
            ConfigurarEstilos();
            ConfigurarIconos();
            ConfigurarEventos();

            ConfigurarTextos();
            CargarClientes();
            CargarPremios();
            ActualizarTotales();
        }
        #endregion

        #region "CONFIGURACION"

        private void ConfigurarEventos()
        {
            this.Load += (s, e) => this.WindowState = FormWindowState.Maximized;
            lkpCliente.EditValueChanged += (s, e) => CargarPuntosCliente();
            spnMonto.EditValueChanged += (s, e) => ActualizarTotales();
            btnActualizar.Click += (s, e) => ActualizarPantalla();
            btnLimpiar.Click += (s, e) => LimpiarOperacion();
            btnConfirmar.Click += BtnConfirmar_Click;
        }

        private void ConfigurarIconos()
        {
            // Reutiliza el mismo ícono de "Actualizar" de la barra de grillas (igual que el Punto de Venta).
            try
            {
                var rm = new System.ComponentModel.ComponentResourceManager(typeof(UI.Formularios.Base.frmBaseGrilla));
                if (rm.GetObject("btnRefresh.ImageOptions.Image") is System.Drawing.Image img)
                {
                    btnActualizar.ImageOptions.Image = img;
                    btnActualizar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
                }
            }
            catch { /* si no se encuentra el recurso, el botón queda sin ícono */ }
        }

        private void ConfigurarMonto()
        {
            spnMonto.Properties.MinValue = 0;
            spnMonto.Properties.MaxValue = 99999999;
            spnMonto.Properties.IsFloatValue = true;
            spnMonto.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            spnMonto.Properties.DisplayFormat.FormatString = "$ #,##0.00";
            spnMonto.EditValue = 0m;
        }

        private void ConfigurarEstilos()
        {
            // Panel de puntos disponibles: sin recuadro, el número queda flotando.
            pnlPuntos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            lblPuntosTitulo.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblPuntosTitulo.Appearance.ForeColor = Color.FromArgb(80, 80, 80);
            lblPuntosTitulo.Appearance.Options.UseFont = true;
            lblPuntosTitulo.Appearance.Options.UseForeColor = true;

            lblPuntosValor.Appearance.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblPuntosValor.Appearance.ForeColor = Color.FromArgb(0, 123, 255);
            lblPuntosValor.Appearance.Options.UseFont = true;
            lblPuntosValor.Appearance.Options.UseForeColor = true;

            // Títulos de secciones.
            foreach (var lbl in new[] { lblTablero, lblPremiosTitulo })
            {
                lbl.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lbl.Appearance.ForeColor = Color.FromArgb(45, 45, 45);
                lbl.Appearance.Options.UseFont = true;
                lbl.Appearance.Options.UseForeColor = true;
            }

            // Etiquetas de totales.
            foreach (var lbl in new[] { lblCanjearTitulo, lblGanarTitulo, lblMonto })
            {
                lbl.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                lbl.Appearance.ForeColor = Color.FromArgb(70, 70, 70);
                lbl.Appearance.Options.UseFont = true;
                lbl.Appearance.Options.UseForeColor = true;
            }

            lblCanjearValor.Appearance.ForeColor = Color.FromArgb(220, 53, 69);
            lblCanjearValor.Appearance.Options.UseForeColor = true;
            lblGanarValor.Appearance.ForeColor = Color.FromArgb(40, 167, 69);
            lblGanarValor.Appearance.Options.UseForeColor = true;

            // Saldo resultante destacado.
            lblSaldoTitulo.Appearance.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSaldoTitulo.Appearance.Options.UseFont = true;
            lblSaldoValor.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSaldoValor.Appearance.ForeColor = Color.FromArgb(45, 45, 45);
            lblSaldoValor.Appearance.Options.UseFont = true;
            lblSaldoValor.Appearance.Options.UseForeColor = true;

            // Botón confirmar prominente.
            btnConfirmar.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirmar.Appearance.BackColor = Color.FromArgb(0, 123, 255);
            btnConfirmar.Appearance.ForeColor = Color.White;
            btnConfirmar.Appearance.Options.UseFont = true;
            btnConfirmar.Appearance.Options.UseBackColor = true;
            btnConfirmar.Appearance.Options.UseForeColor = true;
        }

        private void ConfigurarTextos()
        {
            this.Text = "Terminal de Puntos".Translate();
            lblCliente.Text = "Cliente".Translate() + ":";
            btnActualizar.Text = "Actualizar".Translate();
            lblPuntosTitulo.Text = "Puntos disponibles".Translate();
            lblTablero.Text = "Premios disponibles".Translate();
            lblPremiosTitulo.Text = "Premios a canjear".Translate();
            lblMonto.Text = "Monto a pagar".Translate() + ":";
            lblCanjearTitulo.Text = "Puntos a canjear".Translate() + ":";
            lblGanarTitulo.Text = "Puntos a ganar".Translate() + ":";
            lblSaldoTitulo.Text = "Saldo resultante".Translate() + ":";
            btnLimpiar.Text = "Limpiar".Translate();
            btnConfirmar.Text = "Confirmar operación".Translate();
        }

        private void ConfigurarGrillaCarrito()
        {
            gvCarrito.OptionsBehavior.Editable = true;
            gvCarrito.OptionsView.ShowGroupPanel = false;
            gvCarrito.OptionsView.ColumnAutoWidth = true;
            gvCarrito.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gvCarrito.Columns.Clear();

            var colDescripcion = CrearCol(nameof(PremioCanjeDTO.Descripcion), "Premio".Translate(), 150);
            colDescripcion.OptionsColumn.AllowEdit = false;

            // Botón "-"
            var repoMenos = new RepositoryItemButtonEdit();
            repoMenos.TextEditStyle = TextEditStyles.HideTextEditor;
            repoMenos.Buttons.Clear();
            repoMenos.Buttons.Add(new EditorButton(ButtonPredefines.Minus));
            repoMenos.ButtonClick += (s, e) => AjustarCantidad(-1);
            gcCarrito.RepositoryItems.Add(repoMenos);
            var colMenos = CrearCol(nameof(PremioCanjeDTO.Descripcion), "", 32);
            colMenos.ColumnEdit = repoMenos;
            colMenos.OptionsColumn.ShowCaption = false;
            colMenos.OptionsColumn.FixedWidth = true;

            // Cantidad (solo lectura, centrada)
            var colCantidad = CrearCol(nameof(PremioCanjeDTO.Cantidad), "Cant.".Translate(), 44);
            colCantidad.OptionsColumn.AllowEdit = false;
            colCantidad.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            colCantidad.AppearanceCell.Options.UseTextOptions = true;

            // Botón "+"
            var repoMas = new RepositoryItemButtonEdit();
            repoMas.TextEditStyle = TextEditStyles.HideTextEditor;
            repoMas.Buttons.Clear();
            repoMas.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            repoMas.ButtonClick += (s, e) => AjustarCantidad(+1);
            gcCarrito.RepositoryItems.Add(repoMas);
            var colMas = CrearCol(nameof(PremioCanjeDTO.Descripcion), "", 32);
            colMas.ColumnEdit = repoMas;
            colMas.OptionsColumn.ShowCaption = false;
            colMas.OptionsColumn.FixedWidth = true;

            var colSubtotal = CrearCol(nameof(PremioCanjeDTO.SubtotalPuntos), "Puntos".Translate(), 70);
            colSubtotal.OptionsColumn.AllowEdit = false;
            colSubtotal.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            colSubtotal.AppearanceCell.Options.UseTextOptions = true;

            gvCarrito.Columns.AddRange(new GridColumn[]
            {
                colDescripcion, colMenos, colCantidad, colMas, colSubtotal
            });
            GridStyleHelper.AplicarEstilo(gvCarrito);

            CarritoBinding = new BindingList<PremioCanjeDTO>();
            gcCarrito.DataSource = CarritoBinding;
        }

        private GridColumn CrearCol(string fieldName, string caption, int width)
        {
            return new GridColumn { FieldName = fieldName, Caption = caption, Visible = true, Width = width };
        }

        #endregion

        #region "CARGA DE DATOS"

        private void CargarClientes()
        {
            // El cliente es obligatorio en esta terminal: sin opción "Consumidor Final".
            var clientes = ClientesBLL.Current.ObtenerLista(new ReqClientesObtener(Sesion)).Clientes
                ?.Where(c => c.Estado == E_Estados.Activo).ToList() ?? new List<Cliente>();

            lkpCliente.Properties.DataSource = clientes;
            lkpCliente.Properties.ValueMember = nameof(Cliente.IdCliente);
            lkpCliente.Properties.DisplayMember = nameof(Cliente.Descripcion);
            lkpCliente.Properties.NullText = "Seleccione un cliente".Translate();
            lkpCliente.Properties.Columns.Clear();
            lkpCliente.Properties.Columns.Add(new LookUpColumnInfo(nameof(Cliente.Descripcion), "Cliente".Translate()));
            lkpCliente.Properties.Columns.Add(new LookUpColumnInfo(nameof(Cliente.NroDocumento), "Documento".Translate()));
            lkpCliente.EditValue = null;
        }

        private void CargarPuntosCliente()
        {
            var id = ClienteSeleccionadoId;
            if (id == null)
            {
                _puntosDisponibles = 0;
            }
            else
            {
                var res = ClientesBLL.Current.Obtener(new ReqClienteObtener(Sesion) { Id = id.Value });
                _puntosDisponibles = res.Success && res.Cliente != null ? res.Cliente.Puntos : 0;
            }

            lblPuntosValor.Text = _puntosDisponibles.ToString("N0");
            ActualizarTotales();
        }

        private void CargarPremios()
        {
            _premios = PremiosBLL.Current.ObtenerLista(new ReqPremiosObtener(Sesion)).Premios
                ?.Where(p => p.Estado == E_Estados.Activo).ToList() ?? new List<PremioDTO>();

            MostrarPremios();
        }

        #endregion

        #region "TABLERO (TILES)"

        private void MostrarPremios()
        {
            LimpiarTablero();

            flpTablero.SuspendLayout();
            foreach (var p in _premios)
            {
                var premio = p;
                int puntos = (int)Math.Round(p.PuntosRequeridos);
                string subtitulo = string.Format("{0} {1}", puntos.ToString("N0"), "Pts".Translate());

                var card = CrearCard(p.Descripcion, Iniciales(p.Descripcion), ColorPara(p.Descripcion),
                    subtitulo, Color.FromArgb(0, 123, 255));
                ConfigurarInteraccion(card, () => AgregarAlCarrito(premio));
                flpTablero.Controls.Add(card);
            }
            flpTablero.ResumeLayout();
        }

        private void LimpiarTablero()
        {
            while (flpTablero.Controls.Count > 0)
            {
                var ctl = flpTablero.Controls[0];
                flpTablero.Controls.Remove(ctl);
                ctl.Dispose();
            }
        }

        private PanelControl CrearCard(string titulo, string iniciales, Color color, string subtitulo, Color subColor)
        {
            var card = new PanelControl
            {
                Width = 132,
                Height = 132,
                Margin = new Padding(5)
            };
            card.Appearance.BackColor = CardBase;
            card.Appearance.Options.UseBackColor = true;

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                const int d = 50;
                int cx = (card.Width - d) / 2;
                const int cy = 12;
                using (var b = new SolidBrush(color))
                    e.Graphics.FillEllipse(b, cx, cy, d, d);
                using (var f = new Font("Segoe UI", 16F, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var tb = new SolidBrush(Color.White))
                    e.Graphics.DrawString(iniciales, f, tb, new RectangleF(cx, cy, d, d), sf);
            };

            var lblNombre = new LabelControl();
            lblNombre.Text = titulo;
            lblNombre.AutoSizeMode = LabelAutoSizeMode.None;
            lblNombre.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.Appearance.ForeColor = Color.FromArgb(45, 45, 45);
            lblNombre.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            lblNombre.Appearance.TextOptions.VAlignment = VertAlignment.Top;
            lblNombre.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            lblNombre.Appearance.Options.UseFont = true;
            lblNombre.Appearance.Options.UseForeColor = true;
            lblNombre.Appearance.Options.UseTextOptions = true;
            lblNombre.Location = new Point(4, 68);
            lblNombre.Size = new Size(124, 30);
            card.Controls.Add(lblNombre);

            if (!string.IsNullOrEmpty(subtitulo))
            {
                var lblSub = new LabelControl();
                lblSub.Text = subtitulo;
                lblSub.AutoSizeMode = LabelAutoSizeMode.None;
                lblSub.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lblSub.Appearance.ForeColor = subColor == Color.Empty ? Color.Gray : subColor;
                lblSub.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                lblSub.Appearance.Options.UseFont = true;
                lblSub.Appearance.Options.UseForeColor = true;
                lblSub.Appearance.Options.UseTextOptions = true;
                lblSub.Location = new Point(4, 100);
                lblSub.Size = new Size(124, 16);
                card.Controls.Add(lblSub);
            }

            return card;
        }

        private void ConfigurarInteraccion(PanelControl card, Action onClick)
        {
            void SetColor(Color col)
            {
                card.Appearance.BackColor = col;
                card.Invalidate();
            }

            void Attach(Control ctl)
            {
                ctl.Cursor = Cursors.Hand;
                ctl.Click += (s, e) => onClick();
                ctl.MouseEnter += (s, e) => SetColor(CardHover);
                ctl.MouseLeave += (s, e) =>
                {
                    var p = card.PointToClient(Cursor.Position);
                    if (!card.ClientRectangle.Contains(p)) SetColor(CardBase);
                };
                foreach (Control ch in ctl.Controls) Attach(ch);
            }

            Attach(card);
        }

        private string Iniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "?";
            var partes = nombre.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
                return (partes[0][0].ToString() + partes[1][0]).ToUpper();
            var limpio = nombre.Trim();
            return limpio.Substring(0, Math.Min(2, limpio.Length)).ToUpper();
        }

        private Color ColorPara(string texto)
        {
            int hash = 0;
            foreach (char c in texto ?? string.Empty)
                hash = (hash * 31) + c;
            return _paleta[Math.Abs(hash) % _paleta.Length];
        }

        #endregion

        #region "CARRITO"

        private void AgregarAlCarrito(PremioDTO premio)
        {
            var existente = CarritoBinding.FirstOrDefault(i => i.IdPremio == premio.IdPremio);
            if (existente != null)
            {
                existente.Cantidad += 1;
                gvCarrito.RefreshData();
            }
            else
            {
                CarritoBinding.Add(new PremioCanjeDTO
                {
                    IdPremio = premio.IdPremio,
                    Descripcion = premio.Descripcion,
                    PuntosRequeridos = (int)Math.Round(premio.PuntosRequeridos),
                    Cantidad = 1
                });
            }
            ActualizarTotales();
        }

        private void AjustarCantidad(int delta)
        {
            if (gvCarrito.GetFocusedRow() is PremioCanjeDTO item)
            {
                int nueva = item.Cantidad + delta;
                if (nueva < 1)
                    CarritoBinding.Remove(item);
                else
                {
                    item.Cantidad = nueva;
                    gvCarrito.RefreshData();
                }
                ActualizarTotales();
            }
        }

        private void LimpiarOperacion()
        {
            CarritoBinding.Clear();
            spnMonto.EditValue = 0m;
            ActualizarTotales();
        }

        #endregion

        #region "TOTALES"

        private decimal MontoIngresado => Convert.ToDecimal(spnMonto.EditValue ?? 0m);

        private int PuntosACanjear => CarritoBinding.Sum(i => i.SubtotalPuntos);

        private int PuntosAGanar => MovimientosPuntosBLL.Current.CalcularPuntosPorMonto(MontoIngresado);

        private void ActualizarTotales()
        {
            int canjear = PuntosACanjear;
            int ganar = PuntosAGanar;
            int saldo = _puntosDisponibles - canjear + ganar;

            lblCanjearValor.Text = "- " + canjear.ToString("N0");
            lblGanarValor.Text = "+ " + ganar.ToString("N0");
            lblSaldoValor.Text = saldo.ToString("N0");
            lblSaldoValor.Appearance.ForeColor = saldo < 0
                ? Color.FromArgb(220, 53, 69)
                : Color.FromArgb(45, 45, 45);
        }

        #endregion

        #region "CONFIRMACION"

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            var idCliente = ClienteSeleccionadoId;
            if (idCliente == null)
            {
                Aviso("Seleccione un cliente".Translate());
                return;
            }

            int canjear = PuntosACanjear;
            decimal monto = MontoIngresado;
            int ganar = PuntosAGanar;

            // Debe haber al menos una acción: canje de premios o un monto a acumular.
            if (CarritoBinding.Count == 0 && monto <= 0)
            {
                Aviso("Debe canjear un premio o ingresar un monto".Translate());
                return;
            }

            // El saldo resultante no puede quedar negativo.
            if (_puntosDisponibles - canjear + ganar < 0)
            {
                Aviso("Puntos insuficientes para el canje".Translate());
                return;
            }

            // Aviso si el monto no alcanza para generar puntos.
            if (monto > 0 && ganar == 0)
            {
                var r = XtraMessageBox.Show(
                    "El monto ingresado no genera puntos. ¿Desea continuar?".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes) return;
            }

            var movimientos = ConstruirMovimientos(idCliente.Value, monto, ganar);

            var res = MovimientosPuntosBLL.Current.Insertar(
                new ReqMovimientosPuntosInsertar(Sesion) { MovimientosPuntos = movimientos });

            if (res.Success)
            {
                XtraMessageBox.Show(
                    "Operación registrada".Translate(),
                    "Éxito".Translate(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarOperacion();
                CargarPuntosCliente();               // refresca saldo desde la nube
                FormSubject.Current.Notify(E_FormsServicesValues.Cliente);
            }
            else
            {
                XtraMessageBox.Show(
                    res.Message.Translate(),
                    "Error".Translate(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<MovimientoPuntos> ConstruirMovimientos(Guid idCliente, decimal monto, int puntosGanar)
        {
            var movimientos = new List<MovimientoPuntos>();

            // Un movimiento de canje por cada unidad de premio.
            foreach (var item in CarritoBinding)
            {
                for (int i = 0; i < item.Cantidad; i++)
                {
                    movimientos.Add(new MovimientoPuntos
                    {
                        IdCliente = idCliente,
                        IdPremio = item.IdPremio,
                        TipoMovimiento = E_TipoMovimientoPuntos.CanjePremio,
                        Puntos = -item.PuntosRequeridos,
                        MontoOperacion = 0,
                        Observaciones = "Canje:".Translate() + " " + item.Descripcion,
                        Fecha = DateTime.Now
                    });
                }
            }

            // Movimiento de acumulación por el monto pagado.
            if (monto > 0 && puntosGanar > 0)
            {
                movimientos.Add(new MovimientoPuntos
                {
                    IdCliente = idCliente,
                    IdPremio = null,
                    TipoMovimiento = E_TipoMovimientoPuntos.AcumulacionVenta,
                    Puntos = puntosGanar,
                    MontoOperacion = monto,
                    Observaciones = "Acumulación por monto".Translate(),
                    Fecha = DateTime.Now
                });
            }

            return movimientos;
        }

        private void Aviso(string mensaje)
        {
            XtraMessageBox.Show(mensaje, "Validación".Translate(),
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region "ACTUALIZAR / OBSERVER"

        private void ActualizarPantalla()
        {
            var clienteSel = lkpCliente.EditValue;
            CargarClientes();
            lkpCliente.EditValue = clienteSel;

            CargarPremios();
            CargarPuntosCliente();
        }

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Idioma.Equals(value))
            {
                ConfigurarTextos();
                MostrarPremios();
            }
            else if (E_FormsServicesValues.Cliente.Equals(value))
            {
                var seleccionado = lkpCliente.EditValue;
                CargarClientes();
                lkpCliente.EditValue = seleccionado;
            }
            else if (E_FormsServicesValues.Premio.Equals(value))
            {
                CargarPremios();
            }
        }

        #endregion

        #region "DISPOSE"

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            FormSubject.Current.Detach(this);
            base.OnFormClosed(e);
        }

        #endregion

        #region "DTO INTERNO"

        /// <summary>Línea del carrito de premios a canjear.</summary>
        private class PremioCanjeDTO
        {
            public Guid IdPremio { get; set; }
            public string Descripcion { get; set; }
            public int PuntosRequeridos { get; set; }
            public int Cantidad { get; set; }
            public int SubtotalPuntos => PuntosRequeridos * Cantidad;
        }

        #endregion
    }
}
