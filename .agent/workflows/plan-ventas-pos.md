---
description: Plan de implementación de la pantalla compleja de Ventas (POS), historial de ventas y anulación por nota de crédito en KogalPOS.
---

# Plan: Pantalla de Ventas (POS) + Historial + Anulación

## Context

Ya están todas las pantallas ABM básicas. Ahora se construye la primera pantalla **compleja**: el flujo de Ventas, que es el más pesado del sistema. No es un ABM estándar — es un **punto de venta (POS)**: a la izquierda los catálogos para navegar, en el centro los artículos del catálogo elegido para agregarlos, y a la derecha el carrito con subtotales y botón de cobro. El cobro abre un **popup modal** donde se elige tipo de comprobante, forma de pago y (si es efectivo) se calcula el vuelto.

La facturación es **simulada** (no se va a AFIP): al cobrar se genera un `Documento` (comprobante) con un número correlativo y un `Pago`. Las notas de crédito (anulación) también son simuladas.

Decisiones tomadas con el usuario:
- **Stock insuficiente**: se permite agregar, la fila se marca en **rojo** si la cantidad supera el stock, y al **Cobrar** se pide confirmación explícita.
- **Alcance**: completo (POS + historial + anulación), pero el **historial es una pantalla separada** del POS (otro menú/formulario).
- **Cliente**: combo opcional con default **"Consumidor Final"**; botón **"+"** que abre el ABM de clientes y, al aceptar, recarga el combo (vía Observer). **Sin** integración de loyalty/puntos.
- **Pago**: un solo medio (Efectivo / Tarjeta / MercadoPago) con cálculo de **vuelto** en efectivo.
- **Estados de venta**: flujo simple → `Cobrada` / `Anulada` (se cobra y factura junto en el POS; sin cuenta corriente ni facturación diferida).
- **DocumentoDetalle**: se omite (el detalle vive en `VentaDetalle`; el `Documento` referencia a la `Venta`). La Nota de Crédito anula la venta completa.
- **Descuento**: por línea (columna en el carrito); el `Subtotal` y el `Total` lo reflejan.
- **Listas de precios**: en el POS solo se ofrecen las **vigentes** (filtro por `VigenciaDesde`/`VigenciaHasta` + `Estado` activo).

---

## Modelo de dominio (decisión)

Se modela el núcleo transaccional y se **omite `DocumentoDetalle`** del diagrama (es redundante con `VentaDetalle`): el detalle de líneas vive en la Venta y el `Documento` referencia a la `Venta`. Esto simplifica sin perder el concepto.

- **Venta** (cabecera): `IdVenta` (Guid PK), `NroVenta` (int correlativo), `Fecha`, `Estado` (`E_EstadoVenta`), `Total` (decimal), `IdCliente` (Guid? nullable → null = Consumidor Final), `IdListaPrecio` (Guid). Contiene `List<VentaDetalle>`.
- **VentaDetalle**: `IdVentaDetalle` (PK), `IdVenta`, `IdArticulo`, `Cantidad`, `PrecioUnitario`, `Descuento` (decimal, monto), `Subtotal` (= `Cantidad * PrecioUnitario - Descuento`).
- **Documento**: `IdDocumento` (PK), `NroDocumento` (int correlativo), `Fecha`, `TipoComprobante` (`E_TipoComprobante`), `IdVenta` (FK), `Total`. Se emite al cobrar (Tique/TiqueNoFiscal) y al anular (NotaCredito/NotaCreditoNoFiscal).
- **Pago**: `IdPago` (PK), `IdDocumento` (FK), `FormaPago` (`E_FormaPago`), `Importe`, `Fecha`.

**Stock**: al confirmar la venta se genera, **en la misma transacción**, un `MovimientoStock` tipo **Baja** reutilizando `MovimientoStockRepository.Add` (ya descuenta `Articulo.StockActual`). Al anular, se genera un movimiento **Alta** que reintegra el stock. Esto honra el "Venta → Genera MovimientoStock" del diagrama y deja trazabilidad en el ledger de stock.

**Precios**: siempre vienen de la `ListaPrecio` seleccionada (el `Articulo` no tiene precio propio). Default = la lista `EsPredeterminada`. Al cambiar de lista, se recalculan los precios del carrito. Artículo sin precio en la lista elegida → precio 0 (editable manualmente en el carrito).

**Numeración**: no existe generador de correlativos. Se calcula `NroVenta`/`NroDocumento` como `ISNULL(MAX(...),0)+1` dentro de la transacción del repositorio.

---

## Archivos a CREAR

### Services — Enums nuevos
- `Services/Domain/Enums/E_FormaPago.cs` — `Efectivo = 1, Tarjeta = 2, MercadoPago = 3`.
- `Services/Domain/Enums/E_TipoComprobante.cs` — `Tique = 1, TiqueNoFiscal = 2, NotaCredito = 3, NotaCreditoNoFiscal = 4`.
- `Services/Domain/Enums/E_EstadoVenta.cs` — `Cobrada = 1, Anulada = 2`.

### Domain — Entidades + DTOs
- `Domain/Venta.cs`, `Domain/VentaDetalle.cs`, `Domain/Documento.cs`, `Domain/Pago.cs` — POCOs (Guid PK, constructor que inicializa, listas inicializadas).
- `Domain/BLL/ReqResVentas.cs` — DTOs y pares Req/Res:
  - `VentaItemDTO` (carrito y selección): `IdArticulo, Codigo, Descripcion, Cantidad, PrecioUnitario, Descuento, Subtotal, StockActual`.
  - `VentaDTO` (lectura/historial): cabecera + `List<VentaItemDTO>` + `DescripcionCliente`, `DescripcionListaPrecio`, `NroVenta`, `Estado`, `Total`, datos del `Documento`/`Pago`.
  - `CobroDTO` (resultado del popup): `TipoComprobante`, `FormaPago`, `MontoRecibido`, `Vuelto`.
  - Req/Res: `Ventas Obtener` (historial), `Venta Obtener` (detalle), `VentaConfirmar` (incluye items + IdCliente + IdListaPrecio + CobroDTO), `VentaAnular`, `ArticulosDeCatalogoObtener` (catálogo + lista de precios → items con precio+stock).

### DAL
- Mappers: `VentaMapper.cs`, `VentaDetalleMapper.cs`, `DocumentoMapper.cs`, `PagoMapper.cs` (Singleton; orden de índices = orden de columnas SQL).
- Repositorios: `VentaRepository.cs` (Add cabecera+detalles con `NroVenta` MAX+1, GetAll historial, GetById con detalles, `Anular` = update Estado), `DocumentoRepository.cs` (Add con `NroDocumento` MAX+1, GetByVenta), `PagoRepository.cs` (Add, GetByDocumento).
- Contratos: `DAL/Contracts/IVentaRepository.cs`, `IDocumentoRepository.cs`, `IPagoRepository.cs` (extienden `IGenericRepository<T>` con los métodos extra).
- UoW: agregar las 3 propiedades en `IBusinessUnitOfWorkRepository.cs` e instanciarlas en `BusinessUnitOfWorkRepository.cs`.

### BLL
- `BLL/Services/VentasBLL.cs` (Singleton):
  - `ObtenerListasPreciosVigentes(req)` — listas activas y vigentes a hoy (filtra `VigenciaDesde`/`VigenciaHasta` nulos o dentro de rango) para el combo del POS.
  - `ObtenerArticulosDeCatalogo(req)` — combina `CatalogosBLL.ObtenerArticulosAsignados` + `ArticulosBLL.ObtenerPorIds` + precios de `ListasPreciosBLL.Obtener(idLista)` → `List<VentaItemDTO>` con precio y stock.
  - `ConfirmarVenta(req)` — **una transacción**: inserta `Venta`+`VentaDetalle`, genera `MovimientoStock` Baja (reusa `context.Repositories.MovimientoStockRepository.Add`), inserta `Documento` (Tique/NoFiscal) y `Pago`. Devuelve `NroVenta`/`NroDocumento`.
  - `ObtenerLista(req)` / `Obtener(req)` — historial y detalle (con Documento + Pago + nombre de cliente/lista).
  - `Anular(req)` — **una transacción**: `Venta.Estado = Anulada`, genera `MovimientoStock` Alta (reintegra stock), inserta `Documento` NotaCredito.

### UI — Formularios
- `UI/Formularios/Ventas/frmVentas.cs` + `.Designer.cs` (+ `.resx`) — **POS**, `XtraForm` MDI (NO hereda `frmBaseABM`), implementa `IObserver`. Layout:
  - **Barra superior**: combo `ListaPrecio` (solo **vigentes**, default la predeterminada), combo/`LookUpEdit` `Cliente` con default "Consumidor Final" + botón **"+"**.
  - **Izquierda**: lista de catálogos (`ListBoxControl`/grid). Al seleccionar → carga artículos.
  - **Centro**: grid de artículos del catálogo (Código, Descripción, Precio, Stock). Doble clic agrega al carrito (cantidad 1). Filas con `StockActual <= 0` en rojo (evento `RowStyle`).
  - **Derecha**: grid carrito (`BindingList<VentaItemDTO>`) con `Cantidad` y `Descuento` editables (`RepositoryItemSpinEdit`), `PrecioUnitario`, `Subtotal` (recalcula en `CellValueChanged`), botón quitar fila. Filas en rojo si `Cantidad > StockActual`. Label `Total`. Botones **Cobrar** y **Limpiar**.
  - `Cobrar`: valida carrito no vacío; si alguna línea supera stock → `XtraMessageBox` de confirmación; abre `frmCobro` (modal). Si OK → `VentasBLL.ConfirmarVenta` → mensaje con Nº de venta/comprobante → limpia carrito.
  - `IObserver.Update`: ante `E_FormsServicesValues.Cliente` recarga el combo de clientes (soporta el flujo del "+").
- `UI/Formularios/Ventas/frmCobro.cs` + `.Designer.cs` (+ `.resx`) — **popup modal** (`XtraForm`, patrón `ShowDialog` como `frmLogin`). Muestra Total; combo `TipoComprobante` (Tique/TiqueNoFiscal); combo `FormaPago`; si Efectivo: `MontoRecibido` + `Vuelto` calculado (no permite confirmar si recibido < total). Propiedad `Resultado` (`CobroDTO`) + `DialogResult.OK`.
- `UI/Formularios/Ventas/frmVentasHistorial.cs` + `.Designer.cs` (+ `.resx`) — **pantalla separada**, hereda `frmBaseGrilla`. Columnas: NroVenta, Fecha, Cliente, Total, Estado. `OnNuevoClick` abre el POS (`frmVentas`); `OnDetalleClick` abre la vista de detalle. Implementa `Update` para `E_FormsServicesValues.Venta`.
- `UI/Formularios/Ventas/frmVentaVista.cs` + `.Designer.cs` (+ `.resx`) — detalle **solo lectura** de una venta: cabecera + grid de items + datos de Documento/Pago + botón **Anular** (visible solo si `Estado == Confirmada`). Anular → confirma → `VentasBLL.Anular` → `NotificarCambio(E_FormsServicesValues.Venta)` → cierra.

---

## Archivos a MODIFICAR

- `Services/Domain/Enums/E_FormsServicesValues.cs` — agregar `Venta`.
- `Services/Domain/Enums/E_Patentes.cs` — en región VENTAS agregar `PuntoDeVenta = 62` y `Ventas = 63` (60/61 ya usados por Clientes/ListasDePrecios).
- `UI/Formularios/FormulariosManager.cs` — `using UI.Formularios.Ventas;` + región VENTAS con métodos: `PuntoDeVenta()` (abre `frmVentas`), `VentasHistorial()` (abre `frmVentasHistorial`), `VentaVista(Guid id)` (abre `frmVentaVista`). El POS y el detalle se abren como MDI; `frmCobro` se abre con `ShowDialog` desde el POS.
- `UI/Principal/frmPrincipal.cs` — en `CrearMenuItems()`: dos items en `rbpVentas`: `PuntoDeVenta` (Patente 62, "Punto de Venta") y `Ventas` (Patente 63, "Ventas" → historial).
- **.csproj** (clásico, registrar TODO manualmente):
  - `Domain/Domain.csproj` — 4 entidades + `BLL\ReqResVentas.cs`.
  - `DAL/DAL.csproj` — 4 mappers + 3 repos + 3 contratos.
  - `BLL/BLL.csproj` — `Services\VentasBLL.cs`.
  - `Services/Services.csproj` — 3 enums nuevos.
  - `UI/UI.csproj` — 4 formularios (`<SubType>Form</SubType>` + `<DependentUpon>`) + 4 `.resx` (`<EmbeddedResource>`).
- `UI/I18n/es-MX` y `UI/I18n/en-US` — claves nuevas: `Punto de Venta`, `Carrito`, `Consumidor Final`, `Lista de Precios`, `Cobrar`, `Limpiar`, `Total`, `Subtotal`, `Descuento`, `Forma de Pago`, `Tipo de Comprobante`, `Efectivo`, `Tarjeta`, `MercadoPago`, `Monto Recibido`, `Vuelto`, `Tique`, `Tique No Fiscal`, `Nota de Crédito`, `Nota de Crédito No Fiscal`, `Anular`, `Ventas`, `Nº Venta`, `Cobrada`, `Anulada`, `El carrito está vacío`, `Hay artículos sin stock suficiente. ¿Desea continuar?`, `Venta confirmada`, `El monto recibido es insuficiente`, mensajes de éxito/error de anulación. (La clave siempre en español; no duplicar existentes — `Cliente`, `Cantidad`, `Precio`, `Catálogos`, `Fecha`, `Estado` ya existen.)

---

## Base de Datos (script a ejecutar el usuario)

```sql
-- El orden de columnas DEBE coincidir con los índices de cada Mapper
CREATE TABLE Ventas (
    IdVenta       UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    NroVenta      INT              NOT NULL,
    Fecha         DATETIME         NOT NULL,
    Estado        INT              NOT NULL,
    Total         DECIMAL(18,2)    NOT NULL,
    IdCliente     UNIQUEIDENTIFIER NULL REFERENCES Clientes(IdCliente),
    IdListaPrecio UNIQUEIDENTIFIER NOT NULL REFERENCES ListasPrecios(IdListaPrecio)
);
CREATE TABLE VentasDetalle (
    IdVentaDetalle UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    IdVenta        UNIQUEIDENTIFIER NOT NULL REFERENCES Ventas(IdVenta),
    IdArticulo     UNIQUEIDENTIFIER NOT NULL REFERENCES Articulos(IdArticulo),
    Cantidad       DECIMAL(18,2)    NOT NULL,
    PrecioUnitario DECIMAL(18,2)    NOT NULL,
    Descuento      DECIMAL(18,2)    NOT NULL DEFAULT 0,
    Subtotal       DECIMAL(18,2)    NOT NULL
);
CREATE TABLE Documentos (
    IdDocumento     UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    NroDocumento    INT              NOT NULL,
    Fecha           DATETIME         NOT NULL,
    TipoComprobante INT              NOT NULL,
    IdVenta         UNIQUEIDENTIFIER NOT NULL REFERENCES Ventas(IdVenta),
    Total           DECIMAL(18,2)    NOT NULL
);
CREATE TABLE Pagos (
    IdPago      UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    IdDocumento UNIQUEIDENTIFIER NOT NULL REFERENCES Documentos(IdDocumento),
    FormaPago   INT              NOT NULL,
    Importe     DECIMAL(18,2)    NOT NULL,
    Fecha       DATETIME         NOT NULL
);
INSERT INTO Patentes (Id, Descripcion, Estado) VALUES (62, 'Punto de Venta', 1);
INSERT INTO Patentes (Id, Descripcion, Estado) VALUES (63, 'Ventas', 1);
-- Asignar patentes 62 y 63 al usuario/familia correspondiente
```

> Nota: confirmar el nombre real de la tabla de listas de precios (`ListasPrecios` vs otro) al implementar, leyendo `ListaPrecioRepository.cs`.

---

## Verificación

1. **Build 0 errores** — compilar la solución completa.
2. **Menú** — con patentes 62/63 aparecen "Punto de Venta" y "Ventas" en el ribbon Ventas.
3. **POS happy path** — elegir lista de precios, navegar un catálogo, agregar 2 artículos, ver subtotales y total, Cobrar → popup → Tique + Efectivo + monto recibido → vuelto correcto → confirma → mensaje con Nº de venta. Verificar que `StockActual` bajó.
4. **Stock en rojo** — artículo con stock 0 o cantidad > stock se ve en rojo; al Cobrar pide confirmación y permite continuar.
5. **Cliente** — default "Consumidor Final"; botón "+" abre ABM de clientes, al aceptar el combo se recarga (Observer).
6. **Cambio de lista de precios** — recalcula precios del carrito.
7. **Historial** (pantalla separada) — la venta aparece; abrir detalle muestra items + Documento + Pago.
8. **Anulación** — Anular una venta Confirmada → genera Nota de Crédito, repone stock, Estado pasa a Anulada; el historial se refresca (Observer).
9. **I18n** — cambiar a inglés y verificar traducciones.
