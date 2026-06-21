---
description: Guía arquitectural completa de KogalPOS y checklist exhaustivo para crear una nueva pantalla/formulario. Diseñado para que una IA entre en contexto rápido y sin errores.
---

# KogalPOS — Arquitectura y Guía de Desarrollo

> **Stack:** C# · .NET Framework 4.8 · WinForms · DevExpress · SQL Server · `.csproj` clásico (no SDK-style).

## 1. Visión General

KogalPOS es un POS de escritorio. La UI principal es un formulario MDI (`frmPrincipal`) con RibbonControl de DevExpress. Pestañas del ribbon: Admin, Compras, Inventario, Ventas, Fidelización — visibles según permisos del usuario.

## 2. Arquitectura en Capas (5 proyectos)

```
UI  →  BLL  →  DAL  →  Domain  →  Services
```

- **Services** — Capa BASE/framework. Interfaces genéricas (`IGenericRepository<T>`, `IUnitOfWork<T>`), clases base (`ReqBase`, `ResBase`, `UnitOfWorkSqlServerAdapter<T>`), Observer (`FormSubject`, `IObserver`), extensiones (`.Translate()`), enums del sistema (`E_Estados`, `E_Patentes`, `E_FormsServicesValues`), servicios transversales (`LanguageService`, `CryptographyService`). **REGLA CRÍTICA: NO debe tener absolutamente NADA de lógica de negocio. Es solo infraestructura.**
- **Domain** — Entidades de negocio (POCOs en la raíz) y DTOs Req/Res (en `Domain/BLL/`). Las entidades tienen constructor sin parámetros que inicializa todo, PK tipo `Guid`, campo `Estado` tipo `E_Estados`. Sin lógica.
- **DAL** — Repositorios SQL Server con ADO.NET puro. Contratos en `DAL/Contracts/`, implementaciones en `DAL/Implementations/SqlServer/`, Mappers Singleton en `Mappers/`. Unit of Work en `DAL/Implementations/SqlServer/UnitOfWork/`. Factory estática en `DAL/Factories/BusinessFactory.cs`.
- **BLL** — Toda la lógica de negocio. Servicios Singleton en `BLL/Services/`. Reciben `Req*` → devuelven `Res*`. Acceden a DAL vía `BusinessFactory.UnitOfWork.Create()`.
- **UI** — Formularios base (`frmBaseGrilla`, `frmBaseABM` en `UI/Formularios/Base/`), formularios concretos en `UI/Formularios/[Entidad]/`, helpers de estilo en `UI/Helpers/`, i18n en `UI/I18n/`.

## 3. Patrones Clave

**Singleton** — Todos los BLL y Mappers. Patrón: `private readonly static T _instance = new T()`, propiedad `Current`. Ver ejemplo: `BLL/Services/ArticulosBLL.cs`.

**Request/Response** — `Req*` hereda `ReqBase` (constructor con `GlobalCliente sesion`), `Res*` hereda `ResBase` (tiene `Success` y `Message`). Archivo por entidad en `Domain/BLL/ReqResXxx.cs`. Operaciones estándar: ObtenerLista, Obtener, Insertar, Modificar, Eliminar, Restaurar. Ver ejemplo: `Domain/BLL/ReqResArticulos.cs`.

**Unit of Work** — Lectura: `BusinessFactory.UnitOfWork.Create(useTransaction: false)`. Escritura: `BusinessFactory.UnitOfWork.Create()` + `context.SaveChanges()`. El adapter abre conexión, maneja transacción y hace dispose automático. Ver: `DAL/Factories/BusinessFactory.cs`, `DAL/Implementations/SqlServer/UnitOfWork/`.

**Repository** — Implementan `IGenericRepository<T>` (Add, Update, Remove, Restore, GetById, GetAll). Heredan de `BusinessRepository` (helpers SQL). Remove/Restore son eliminación/restauración LÓGICA (cambian `Estado`). Ver ejemplo: `DAL/Implementations/SqlServer/ArticuloRepository.cs`.

**Mapper** — Singleton que convierte `object[]` de SqlDataReader a entidad. El orden de índices DEBE coincidir con el orden de columnas en la tabla SQL. Ver ejemplo: `DAL/Implementations/SqlServer/Mappers/ArticuloMapper.cs`.

**Observer** — `FormSubject.Current` (Singleton) mantiene lista de `IObserver`. Los formularios se registran (`Attach`) en el constructor y se desregistran (`Detach`) en `OnFormClosed`. Los ABM notifican vía `NotificarCambio()` usando `E_FormsServicesValues`. Las grillas escuchan en `Update<T>()` y refrescan. Ver: `Services/Facade/Observer/`.

**i18n** — Todo texto visible usa `.Translate()`. Archivos planos `clave=valor` en `UI/I18n/es-MX` y `UI/I18n/en-US`. La clave siempre es el texto en español. No duplicar claves existentes.

## 4. Formularios Base

**frmBaseGrilla** (`UI/Formularios/Base/frmBaseGrilla.cs`) — Hereda `XtraForm`, implementa `IObserver`. Provee GridControl con búsqueda/filtros, botones (Nuevo, Detalle, Actualizar, Exportar). Métodos virtuales: `ConfigurarTextos()`, `ConfigurarColumnas()`, `CargarPantalla()`, `OnNuevoClick()`, `OnDetalleClick()`. Helpers: `EstablecerDataSource()`, `AgregarColumnas()`, `CrearColumna()`, `ObtenerFilaSeleccionada<T>()`.

**frmBaseABM** (`UI/Formularios/Base/frmBaseABM.cs`) — Hereda `XtraForm` (en Designer), implementa `IObserver`. Panel superior (Modificar, Eliminar, Restaurar), panel inferior (Aceptar, Cancelar), panel central (`panelContenido` tipo `XtraScrollableControl` donde el hijo agrega sus controles). Maneja `E_TipoPantalla` (Visualizar, VisualizarEliminado, Modificar, Nuevo). Props: `Id`, `EsNuevo`, `EsModoEdicion`. Métodos virtuales: `ConfigurarTextos()`, `CargarDatos()`, `ValidarDatos()`, `GuardarDatos()`, `EliminarRegistro()`, `RestaurarRegistro()`, `OnTipoPantallaCambiado()`, `GetFormServiceValue()`. Llamar `InicializarFormulario()` al final del constructor del hijo.

## 5. UI: ControlFactory y Estilos

`UI/Helpers/ControlFactory.cs` es la fuente única de verdad para estilos. Usar siempre `ControlFactory.AplicarModo(esEditable, textEdits[], itemsLayout[], grillas[], botones[], checkEdits[])` para cambiar entre modo edición/visualización. Configurar LayoutControlItems con `ControlFactory.ConfigurarLayoutItem()`. NUNCA aplicar estilos manualmente.

## 6. frmPrincipal y Menú

`UI/Principal/frmPrincipal.cs` — MDI parent con RibbonControl. Los items de menú se definen en `CrearMenuItems()` como array de `MenuItemConfig { Patente, CaptionKey, GetPage, OnClick }`. Solo se agregan al ribbon si el usuario tiene la patente. RibbonPages sin items se ocultan automáticamente.

**RibbonPages existentes** (en `frmPrincipal.Designer.cs`): `rbpAdmin`, `rbpVentas`, `rbpCompras`, `rbpInventario`, `rbpFidelizacion`.

## 7. Regla Crítica: .csproj Clásico

Los proyectos usan formato `.csproj` clásico. **Cada archivo `.cs` nuevo DEBE agregarse manualmente** con `<Compile Include="..." />`. Los formularios llevan `<SubType>Form</SubType>` y los Designer llevan `<DependentUpon>NombreForm.cs</DependentUpon>`. Si no se agrega, NO compila.

---

## Checklist: Nueva Pantalla (Grilla + ABM)

Para ver ejemplos concretos de cada paso, consultar los archivos de la entidad **Articulo** como referencia canónica.

### Domain

- [ ] **Entidad** — Crear `Domain/[Entidad].cs`. Clase POCO, namespace `Domain`, PK `Guid`, campo `Estado`, constructor sin parámetros que inicializa todo. Referencia: `Domain/Articulo.cs`.
- [ ] **DTOs Req/Res** — Crear `Domain/BLL/ReqRes[Entidades].cs`. Un par Req/Res por operación (ObtenerLista, Obtener, Insertar, Modificar, Eliminar, Restaurar). Referencia: `Domain/BLL/ReqResArticulos.cs`.
- [ ] **Registrar en csproj** — Agregar ambos archivos a `Domain/Domain.csproj` como `<Compile Include>`.

### DAL

- [ ] **Mapper** — Crear `DAL/Implementations/SqlServer/Mappers/[Entidad]Mapper.cs`. Singleton, método `Fill(object[] values)`, índices coinciden con orden de columnas SQL. Referencia: `DAL/Implementations/SqlServer/Mappers/ArticuloMapper.cs`.
- [ ] **Repository** — Crear `DAL/Implementations/SqlServer/[Entidad]Repository.cs`. Hereda `BusinessRepository`, implementa `IGenericRepository<T>`. Remove/Restore son lógicos. Referencia: `DAL/Implementations/SqlServer/ArticuloRepository.cs`.
- [ ] **Contrato UoW** — Agregar propiedad en `DAL/Contracts/UnitOfWork/IBusinessUnitOfWorkRepository.cs`.
- [ ] **Implementación UoW** — Agregar propiedad + instanciar en constructor de `DAL/Implementations/SqlServer/UnitOfWork/BusinessUnitOfWorkRepository.cs`.
- [ ] **Registrar en csproj** — Agregar mapper y repository a `DAL/DAL.csproj`.

### BLL

- [ ] **Servicio BLL** — Crear `BLL/Services/[Entidades]BLL.cs`. Singleton, métodos CRUD usando `BusinessFactory.UnitOfWork`. Lecturas sin transacción, escrituras con transacción. Referencia: `BLL/Services/ArticulosBLL.cs`.
- [ ] **Registrar en csproj** — Agregar a `BLL/BLL.csproj`.

### Services (solo enums)

- [ ] **E_FormsServicesValues** — Agregar valor al enum en `Services/Domain/Enums/E_FormsServicesValues.cs`.
- [ ] **E_Patentes** — Agregar patente con ID numérico único en `Services/Domain/Enums/E_Patentes.cs`. Rangos: Admin=1, Compras=20+, Inventario=40+, Ventas=60+, Fidelización=80+.

### UI — Formularios

- [ ] **Grilla** — Crear `UI/Formularios/[Entidad]/frm[Entidad].cs` + `.Designer.cs`. Hereda `frmBaseGrilla`. Override: `ConfigurarTextos`, `ConfigurarColumnas`, `CargarPantalla`, `OnNuevoClick`, `OnDetalleClick`, `Update<T>`. Referencia: `UI/Formularios/Articulos/frmArticulos.cs`.
- [ ] **ABM** — Crear `UI/Formularios/[Entidad]/frm[Entidad]ABM.cs` + `.Designer.cs`. Hereda `frmBaseABM`. Los controles del hijo van dentro de `panelContenido` usando un `LayoutControl` con `Dock=Fill`. En el constructor: `InitializeComponent()` → `InicializarFormulario()` → configurar LayoutItems con `ControlFactory`. Override: `ConfigurarTextos`, `CargarDatos`, `ValidarDatos`, `GuardarDatos`, `EliminarRegistro`, `RestaurarRegistro`, `OnTipoPantallaCambiado`, `GetFormServiceValue`. Referencia: `UI/Formularios/Articulos/frmArticulosABM.cs` y `.Designer.cs`.

### UI — Integración

- [ ] **FormulariosManager** — Agregar `using` y 2 métodos (grilla y ABM) en `UI/Formularios/FormulariosManager.cs`. Patrón: crear form, `MdiParent = frmPrincipal`, `MaximizeBox = true`, `.Show()`. Referencia: ver región "ARTICULOS" en el mismo archivo.
- [ ] **frmPrincipal** — Agregar `MenuItemConfig` en `CrearMenuItems()` de `UI/Principal/frmPrincipal.cs` con la Patente, CaptionKey, GetPage (RibbonPage) y OnClick.
- [ ] **Registrar en csproj** — Agregar los 4 archivos de formularios a `UI/UI.csproj` con `<SubType>Form</SubType>` y `<DependentUpon>`.

### I18n

- [ ] Agregar TODOS los textos nuevos usados con `.Translate()` a `UI/I18n/es-MX` (español) y `UI/I18n/en-US` (inglés). Formato: `clave=valor`. La clave siempre es en español. NO duplicar claves existentes.

### Base de Datos

- [ ] **CREATE TABLE** — Crear tabla en SQL Server. El orden de columnas DEBE coincidir con los índices del Mapper.
- [ ] **INSERT Patente** — Insertar la patente en la tabla `Patentes` de la BD y asignarla al usuario/familia.

### Verificación

- [ ] Build exitoso (0 errores)
- [ ] Pantalla visible en el menú solo con el permiso correcto
- [ ] CRUD funcional: Crear, Ver, Modificar, Eliminar (lógico), Restaurar
- [ ] Controles con mismo look & feel (ControlFactory)
- [ ] Idioma: todos los textos se traducen correctamente
- [ ] Observer: la grilla se refresca al modificar desde el ABM
