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

namespace UI.Formularios.Ventas
{
    /// <summary>
    /// Punto de Venta (POS). Tablero de catálogos/artículos (tiles) con breadcrumb a la izquierda,
    /// carrito a la derecha.
    /// </summary>
    public partial class frmVentas : XtraForm, IObserver
    {
        #region "PROPIEDADES"
        public GlobalCliente Sesion { get; private set; }

        private BindingList<VentaItemDTO> CarritoBinding { get; set; }
        private List<Catalogo> _catalogos = new List<Catalogo>();
        private Dictionary<Guid, decimal> _precios = new Dictionary<Guid, decimal>();
        private Catalogo _catalogoActual;

        // Paleta para los círculos de iniciales.
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

        private Guid ListaSeleccionadaId =>
            lkpListaPrecio.EditValue is Guid g ? g : Guid.Empty;
        #endregion

        #region "CONSTRUCTOR"
        public frmVentas(GlobalCliente sesion)
        {
            InitializeComponent();
            Sesion = sesion;

            FormSubject.Current.Attach(this);

            ConfigurarGrillaCarrito();
            ConfigurarDescuento();
            ConfigurarEventos();
            ConfigurarIconos();

            ConfigurarTextos();
            CargarClientes();
            CargarListasPrecios();
            CargarCatalogos();
        }
        #endregion

        #region "CONFIGURACION"

        private void ConfigurarEventos()
        {
            this.Load += (s, e) => this.WindowState = FormWindowState.Maximized;
            lkpListaPrecio.EditValueChanged += LkpListaPrecio_EditValueChanged;
            gvCarrito.CellValueChanged += GvCarrito_CellValueChanged;
            gvCarrito.RowStyle += GvCarrito_RowStyle;
            btnNuevoCliente.Click += (s, e) => FormulariosManager.ClientesABM();
            btnActualizar.Click += (s, e) => ActualizarPantalla();
            btnLimpiar.Click += (s, e) => LimpiarCarrito();
            btnCobrar.Click += BtnCobrar_Click;
        }

        private void ConfigurarIconos()
        {
            // Reutiliza el mismo ícono de "Actualizar" de la barra de grillas para mantener consistencia.
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

        private void ConfigurarDescuento()
        {
            spnDescuento.Properties.MinValue = 0;
            spnDescuento.Properties.MaxValue = 9999999;
            spnDescuento.Properties.IsFloatValue = true;
            spnDescuento.EditValue = 0m;

            cmbTipoDescuento.Properties.Items.Clear();
            cmbTipoDescuento.Properties.Items.Add("$");
            cmbTipoDescuento.Properties.Items.Add("%");
            cmbTipoDescuento.SelectedIndex = 0;

            spnDescuento.EditValueChanged += (s, e) => ActualizarTotal();
            cmbTipoDescuento.SelectedIndexChanged += (s, e) => ActualizarTotal();
        }

        private void ConfigurarTextos()
        {
            this.Text = "Punto de Venta".Translate();
            lblListaPrecio.Text = "Lista de Precios".Translate() + ":";
            lblCliente.Text = "Cliente".Translate() + ":";
            lblCarritoTitulo.Text = "Carrito".Translate();
            lblSubtotalTitulo.Text = "Subtotal".Translate() + ":";
            lblDescuentoTitulo.Text = "Descuento".Translate() + ":";
            lblTotalTitulo.Text = "Total".Translate().ToUpper() + ":";
            btnLimpiar.Text = "Limpiar".Translate();
            btnCobrar.Text = "Cobrar".Translate();
            btnActualizar.Text = "Actualizar".Translate();
            ActualizarBreadcrumb(_catalogoActual);
        }

        private const string FmtMoneda = "$ #,##0.00";

        private void ConfigurarGrillaCarrito()
        {
            gvCarrito.OptionsBehavior.Editable = true;
            gvCarrito.OptionsView.ShowGroupPanel = false;
            gvCarrito.OptionsView.ColumnAutoWidth = true;
            gvCarrito.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gvCarrito.Columns.Clear();

            var colDescripcion = CrearCol(nameof(VentaItemDTO.Descripcion), "Descripción".Translate(), 170);
            colDescripcion.OptionsColumn.AllowEdit = false;

            // Botón "-"
            var repoMenos = new RepositoryItemButtonEdit();
            repoMenos.TextEditStyle = TextEditStyles.HideTextEditor;
            repoMenos.Buttons.Clear();
            repoMenos.Buttons.Add(new EditorButton(ButtonPredefines.Minus));
            repoMenos.ButtonClick += (s, e) => AjustarCantidad(-1);
            gcCarrito.RepositoryItems.Add(repoMenos);
            var colMenos = CrearCol(nameof(VentaItemDTO.Codigo), "", 36);
            colMenos.ColumnEdit = repoMenos;
            colMenos.OptionsColumn.ShowCaption = false;
            colMenos.OptionsColumn.FixedWidth = true;

            // Cantidad (solo lectura, centrada)
            var colCantidad = CrearColNum(nameof(VentaItemDTO.Cantidad), "Cant.".Translate(), 48, "0.##");
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
            var colMas = CrearCol(nameof(VentaItemDTO.Codigo), "", 36); // campo cualquiera de solo lectura; el botón usa la fila enfocada
            colMas.ColumnEdit = repoMas;
            colMas.OptionsColumn.ShowCaption = false;
            colMas.OptionsColumn.FixedWidth = true;

            var colPrecio = CrearColNum(nameof(VentaItemDTO.PrecioUnitario), "Precio".Translate(), 80, FmtMoneda);
            colPrecio.OptionsColumn.AllowEdit = false;

            var colSubtotal = CrearColNum(nameof(VentaItemDTO.Subtotal), "Subtotal".Translate(), 90, FmtMoneda);
            colSubtotal.OptionsColumn.AllowEdit = false;

            gvCarrito.Columns.AddRange(new GridColumn[]
            {
                colDescripcion, colMenos, colCantidad, colMas, colPrecio, colSubtotal
            });
            GridStyleHelper.AplicarEstilo(gvCarrito);

            CarritoBinding = new BindingList<VentaItemDTO>();
            gcCarrito.DataSource = CarritoBinding;
        }

        private GridColumn CrearCol(string fieldName, string caption, int width)
        {
            return new GridColumn { FieldName = fieldName, Caption = caption, Visible = true, Width = width };
        }

        private GridColumn CrearColNum(string fieldName, string caption, int width, string formato)
        {
            var col = CrearCol(fieldName, caption, width);
            col.DisplayFormat.FormatType = FormatType.Numeric;
            col.DisplayFormat.FormatString = formato;
            return col;
        }

        #endregion

        #region "CARGA DE DATOS"

        private void CargarClientes()
        {
            var clientes = ClientesBLL.Current.ObtenerLista(new ReqClientesObtener(Sesion)).Clientes
                ?.Where(c => c.Estado == E_Estados.Activo).ToList() ?? new List<Cliente>();

            lkpCliente.Properties.DataSource = clientes;
            lkpCliente.Properties.ValueMember = nameof(Cliente.IdCliente);
            lkpCliente.Properties.DisplayMember = nameof(Cliente.Descripcion);
            lkpCliente.Properties.NullText = "Consumidor Final".Translate();
            lkpCliente.Properties.Columns.Clear();
            lkpCliente.Properties.Columns.Add(new LookUpColumnInfo(nameof(Cliente.Descripcion), "Cliente".Translate()));
            lkpCliente.EditValue = null;
        }

        private void CargarListasPrecios()
        {
            var listas = ListasPreciosBLL.Current
                .ObtenerVigentes(new ReqListaPreciosVigentes(Sesion))
                .ListaPrecios ?? new List<ListaPrecioDTO>();

            lkpListaPrecio.Properties.DataSource = listas;
            lkpListaPrecio.Properties.ValueMember = nameof(ListaPrecioDTO.IdListaPrecio);
            lkpListaPrecio.Properties.DisplayMember = nameof(ListaPrecioDTO.Descripcion);
            lkpListaPrecio.Properties.Columns.Clear();
            lkpListaPrecio.Properties.Columns.Add(new LookUpColumnInfo(nameof(ListaPrecioDTO.Descripcion), "Lista de Precios".Translate()));

            var predeterminada = listas.FirstOrDefault(l => l.EsPredeterminada) ?? listas.FirstOrDefault();
            if (predeterminada != null)
                lkpListaPrecio.EditValue = predeterminada.IdListaPrecio; // dispara EditValueChanged -> carga precios
        }

        private void CargarPrecios(Guid idLista)
        {
            if (idLista == Guid.Empty)
            {
                _precios = new Dictionary<Guid, decimal>();
                return;
            }

            var lista = ListasPreciosBLL.Current
                .Obtener(new ReqListaPrecioObtener(Sesion) { Id = idLista })
                .ListaPrecio;

            _precios = (lista?.Items ?? new List<ListaPrecioArticuloDTO>())
                .GroupBy(i => i.IdArticulo)
                .ToDictionary(g => g.Key, g => g.First().Precio);
        }

        private void CargarCatalogos()
        {
            _catalogos = CatalogosBLL.Current.ObtenerLista(new ReqCatalogosObtener(Sesion)).Catalogos
                ?.Where(c => c.Estado == E_Estados.Activo).ToList() ?? new List<Catalogo>();

            MostrarCatalogos();
        }

        #endregion

        #region "TABLERO (TILES)"

        private void MostrarCatalogos()
        {
            _catalogoActual = null;
            ActualizarBreadcrumb(null);
            LimpiarTablero();

            flpTablero.SuspendLayout();
            foreach (var c in _catalogos)
            {
                var catalogo = c;
                var card = CrearCard(c.Descripcion, Iniciales(c.Descripcion), ColorPara(c.Descripcion), null, Color.Empty);
                ConfigurarInteraccion(card, () => MostrarArticulos(catalogo));
                flpTablero.Controls.Add(card);
            }
            flpTablero.ResumeLayout();
        }

        private void MostrarArticulos(Catalogo catalogo)
        {
            _catalogoActual = catalogo;
            ActualizarBreadcrumb(catalogo);
            LimpiarTablero();

            var ids = CatalogosBLL.Current
                .ObtenerArticulosAsignados(new ReqCatalogoObtenerArticulos(Sesion) { IdCatalogo = catalogo.IdCatalogo })
                .IdsArticulos ?? new List<Guid>();

            var articulos = ArticulosBLL.Current
                .ObtenerPorIds(new ReqArticulosObtenerPorIds(Sesion) { Ids = ids })
                .Articulos ?? new List<Articulo>();

            flpTablero.SuspendLayout();

            // Tile de "volver" como primer cuadro.
            var volver = CrearCardVolver();
            ConfigurarInteraccion(volver, () => MostrarCatalogos());
            flpTablero.Controls.Add(volver);

            foreach (var a in articulos)
            {
                decimal precio = _precios.TryGetValue(a.IdArticulo, out var p) ? p : 0;
                bool sinStock = a.StockActual <= 0;
                string subtitulo = sinStock
                    ? string.Format("$ {0:N2} · {1}", precio, "Sin stock".Translate())
                    : string.Format("$ {0:N2}", precio);

                var card = CrearCard(a.Descripcion, Iniciales(a.Descripcion), ColorPara(a.Descripcion),
                    subtitulo, sinStock ? Color.Red : Color.Gray);

                var articulo = a;
                ConfigurarInteraccion(card, () => AgregarAlCarrito(articulo, precio));
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

            // El círculo se dibuja directamente sobre la tarjeta (sin panel de fondo).
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
                lblSub.Appearance.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
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

        #region "BREADCRUMB"

        private void ActualizarBreadcrumb(Catalogo actual)
        {
            while (flpBreadcrumb.Controls.Count > 0)
            {
                var ctl = flpBreadcrumb.Controls[0];
                flpBreadcrumb.Controls.Remove(ctl);
                ctl.Dispose();
            }

            var raiz = CrearSegmento("Catálogos".Translate(), actual != null);
            if (actual != null)
                raiz.Click += (s, e) => MostrarCatalogos();
            flpBreadcrumb.Controls.Add(raiz);

            if (actual != null)
            {
                flpBreadcrumb.Controls.Add(CrearSeparador());
                flpBreadcrumb.Controls.Add(CrearSegmento(actual.Descripcion, false));
            }
        }

        private PanelControl CrearCardVolver()
        {
            // Distinto a las demás: sin círculo, solo la flecha centrada.
            var card = new PanelControl
            {
                Width = 132,
                Height = 132,
                Margin = new Padding(5)
            };
            card.Appearance.BackColor = CardBase;
            card.Appearance.Options.UseBackColor = true;

            var lbl = new LabelControl();
            lbl.Text = "❮";
            lbl.Dock = DockStyle.Fill;
            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            lbl.Appearance.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            lbl.Appearance.ForeColor = Color.FromArgb(108, 117, 125);
            lbl.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            lbl.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseForeColor = true;
            lbl.Appearance.Options.UseTextOptions = true;
            card.Controls.Add(lbl);

            return card;
        }

        private LabelControl CrearSegmento(string texto, bool clickable)
        {
            var lbl = new LabelControl();
            lbl.Text = texto;
            lbl.Appearance.ForeColor = Color.FromArgb(60, 60, 60);
            lbl.Appearance.Options.UseForeColor = true;
            lbl.Appearance.Options.UseFont = true;
            lbl.Margin = new Padding(2, 4, 2, 4);

            if (clickable)
            {
                var normal = new Font("Segoe UI", 11F, FontStyle.Regular);
                var hover = new Font("Segoe UI", 11F, FontStyle.Underline);
                lbl.Appearance.Font = normal;
                lbl.Cursor = Cursors.Hand;
                lbl.MouseEnter += (s, e) => { lbl.Appearance.Font = hover; };
                lbl.MouseLeave += (s, e) => { lbl.Appearance.Font = normal; };
            }
            else
            {
                lbl.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }

            return lbl;
        }

        private LabelControl CrearSeparador()
        {
            var lbl = new LabelControl { Text = "›" };
            lbl.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbl.Appearance.ForeColor = Color.FromArgb(140, 140, 140);
            lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseForeColor = true;
            lbl.Margin = new Padding(2, 4, 2, 4);
            return lbl;
        }

        #endregion

        #region "EVENTOS"

        private void LkpListaPrecio_EditValueChanged(object sender, EventArgs e)
        {
            CargarPrecios(ListaSeleccionadaId);

            foreach (var item in CarritoBinding)
                item.PrecioUnitario = _precios.TryGetValue(item.IdArticulo, out var p) ? p : 0;
            gvCarrito.RefreshData();
            ActualizarTotal();

            // Si estoy viendo artículos, refresco los precios mostrados en los tiles.
            if (_catalogoActual != null)
                MostrarArticulos(_catalogoActual);
        }

        private void GvCarrito_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (gvCarrito.GetRow(e.RowHandle) is VentaItemDTO item && item.Cantidad > item.StockActual)
            {
                e.Appearance.BackColor = Color.MistyRose;
                e.Appearance.ForeColor = Color.Red;
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseForeColor = true;
            }
        }

        private void GvCarrito_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gvCarrito.RefreshRow(e.RowHandle);
            ActualizarTotal();
        }

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            if (CarritoBinding.Count == 0)
            {
                XtraMessageBox.Show(
                    "El carrito está vacío".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de stock contra la BD (lado BLL), no contra el stock cacheado en el carrito.
            var cantidades = CarritoBinding
                .GroupBy(i => i.IdArticulo)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Cantidad));
            var resStock = ArticulosBLL.Current.VerificarStock(
                new ReqArticulosVerificarStock(Sesion) { Cantidades = cantidades });
            if (resStock.Faltantes != null && resStock.Faltantes.Count > 0)
            {
                var r = XtraMessageBox.Show(
                    "Hay artículos sin stock suficiente. ¿Desea continuar?".Translate(),
                    "Validación".Translate(),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes) return;
            }

            decimal subtotal = CarritoBinding.Sum(i => i.Subtotal);
            decimal descuento = CalcularDescuento(subtotal);
            decimal total = subtotal - descuento;

            using (var dlg = new frmCobro(total))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                var req = new ReqVentaConfirmar(Sesion)
                {
                    Items = CarritoBinding.ToList(),
                    IdCliente = ClienteSeleccionadoId,
                    IdListaPrecio = ListaSeleccionadaId,
                    Descuento = descuento,
                    Cobro = dlg.Resultado
                };

                var res = VentasBLL.Current.ConfirmarVenta(req);

                if (res.Success)
                {
                    XtraMessageBox.Show(
                        "Venta confirmada".Translate() + $" (N° {res.NroVenta})",
                        "Éxito".Translate(),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCarrito();
                    FormSubject.Current.Notify(E_FormsServicesValues.Venta);

                    // Refrescar stock visible si estoy dentro de un catálogo.
                    if (_catalogoActual != null)
                        MostrarArticulos(_catalogoActual);
                }
                else
                {
                    XtraMessageBox.Show(
                        res.Message.Translate(),
                        "Error".Translate(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "CARRITO"

        private void AgregarAlCarrito(Articulo articulo, decimal precio)
        {
            var existente = CarritoBinding.FirstOrDefault(i => i.IdArticulo == articulo.IdArticulo);
            if (existente != null)
            {
                existente.Cantidad += 1;
                gvCarrito.RefreshData();
            }
            else
            {
                CarritoBinding.Add(new VentaItemDTO
                {
                    IdArticulo = articulo.IdArticulo,
                    Codigo = articulo.Codigo,
                    Descripcion = articulo.Descripcion,
                    PrecioUnitario = precio,
                    StockActual = articulo.StockActual,
                    Cantidad = 1,
                    Descuento = 0
                });
            }
            ActualizarTotal();
        }

        private void LimpiarCarrito()
        {
            CarritoBinding.Clear();
            spnDescuento.EditValue = 0m;
            ActualizarTotal();
        }

        private decimal CalcularDescuento(decimal subtotal)
        {
            decimal valor = Convert.ToDecimal(spnDescuento.EditValue ?? 0);
            if (valor <= 0) return 0;

            decimal desc = cmbTipoDescuento.SelectedIndex == 1
                ? subtotal * (valor / 100m)   // porcentaje
                : valor;                       // monto

            if (desc < 0) desc = 0;
            if (desc > subtotal) desc = subtotal;
            return decimal.Round(desc, 2);
        }

        private void AjustarCantidad(int delta)
        {
            if (gvCarrito.GetFocusedRow() is VentaItemDTO item)
            {
                decimal nueva = item.Cantidad + delta;
                if (nueva < 1)
                {
                    CarritoBinding.Remove(item);
                }
                else
                {
                    item.Cantidad = nueva;
                    gvCarrito.RefreshData();
                }
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            decimal subtotal = CarritoBinding.Sum(i => i.Subtotal);
            decimal descuento = CalcularDescuento(subtotal);
            decimal total = subtotal - descuento;

            lblSubtotal.Text = "$ " + subtotal.ToString("N2");
            lblDescuentoValor.Text = "- $ " + descuento.ToString("N2");
            lblTotal.Text = "$ " + total.ToString("N2");
        }

        private void ActualizarPantalla()
        {
            var clienteSel = lkpCliente.EditValue;
            var listaSel = ListaSeleccionadaId;

            CargarClientes();
            lkpCliente.EditValue = clienteSel;

            CargarPrecios(listaSel);
            RefrescarStockCarrito();

            _catalogos = CatalogosBLL.Current.ObtenerLista(new ReqCatalogosObtener(Sesion)).Catalogos
                ?.Where(c => c.Estado == E_Estados.Activo).ToList() ?? new List<Catalogo>();

            if (_catalogoActual != null)
            {
                var actualizado = _catalogos.FirstOrDefault(c => c.IdCatalogo == _catalogoActual.IdCatalogo);
                if (actualizado != null)
                {
                    MostrarArticulos(actualizado);
                    return;
                }
            }
            MostrarCatalogos();
        }

        private void RefrescarStockCarrito()
        {
            if (CarritoBinding.Count == 0) return;

            var ids = CarritoBinding.Select(i => i.IdArticulo).Distinct().ToList();
            var arts = ArticulosBLL.Current
                .ObtenerPorIds(new ReqArticulosObtenerPorIds(Sesion) { Ids = ids })
                .Articulos ?? new List<Articulo>();
            var dict = arts.ToDictionary(a => a.IdArticulo, a => a.StockActual);

            foreach (var it in CarritoBinding)
                if (dict.TryGetValue(it.IdArticulo, out var st))
                    it.StockActual = st;

            gvCarrito.RefreshData();
        }

        #endregion

        #region "OBSERVER"

        public void Update<T>(T value, object data = null)
        {
            if (E_FormsServicesValues.Idioma.Equals(value))
            {
                ConfigurarTextos();
            }
            else if (E_FormsServicesValues.Cliente.Equals(value))
            {
                var seleccionado = lkpCliente.EditValue;
                CargarClientes();
                lkpCliente.EditValue = seleccionado;
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
    }
}
