---
description: Checklist completo para crear una nueva pantalla/formulario en KogalPOS
---

# Checklist: Nueva Pantalla / Formulario

Cada vez que se crea una nueva pantalla (grilla, ABM, o cualquier formulario), se deben completar TODOS estos pasos. No saltear ninguno.

## 1. Domain Layer
- [ ] Crear entidad en `Domain/` (ej: `Articulo.cs`)
- [ ] Crear DTOs Req/Res en `Domain/BLL/` (ej: `ReqResArticulos.cs`)
- [ ] Agregar ambos archivos a `Domain/Domain.csproj` en `<Compile Include="..." />`

## 2. DAL Layer
- [ ] Crear Mapper en `DAL/Implementations/SqlServer/Mappers/` (ej: `ArticuloMapper.cs`)
- [ ] Crear Repository en `DAL/Implementations/SqlServer/` (ej: `ArticuloRepository.cs`)
- [ ] Agregar propiedad al contrato `DAL/Contracts/IBusinessUnitOfWorkRepository.cs`
- [ ] Instanciar en `DAL/Implementations/SqlServer/UnitOfWork/BusinessUnitOfWorkRepository.cs`
- [ ] Agregar ambos archivos nuevos a `DAL/DAL.csproj` en `<Compile Include="..." />`

## 3. BLL Layer
- [ ] Crear servicio BLL en `BLL/Services/` (ej: `ArticuloBLL.cs`) — patrón Singleton
- [ ] Agregar archivo a `BLL/BLL.csproj` en `<Compile Include="..." />`

## 4. Services Layer
- [ ] Agregar valor al enum `Services/Domain/Enums/E_FormsServicesValues.cs`
- [ ] Agregar patente al enum `Services/Domain/Enums/E_Patentes.cs` (si no existe ya)

## 5. UI Layer — Formularios
- [ ] Crear formulario grilla en `UI/Formularios/[Entidad]/` (hereda de `frmBaseGrilla`)
- [ ] Crear formulario ABM en `UI/Formularios/[Entidad]/` (hereda de `frmBaseABM`)
- [ ] Usar `ControlFactory` para crear TODOS los controles (TextEdit, Label, LabelTitulo, ComboBox, LookUpEdit)
- [ ] Agregar archivos a `UI/UI.csproj` en `<Compile Include="..." />`

## 6. UI Layer — Integración (¡NO OLVIDAR!)

// turbo-all

### 6a. FormulariosManager
- [ ] Agregar métodos `NombreEntidad()` y `NombreEntidadABM(Guid id)` en `UI/Formularios/FormulariosManager.cs`

### 6b. frmPrincipal — Menú + Permisos
- [ ] Agregar entrada en el array de `CrearMenuItems()` dentro de `UI/Principal/frmPrincipal.cs`:
```csharp
new MenuItemConfig {
    Patente = E_Patentes.NuevaPatente,
    CaptionKey = "Texto del botón",
    GetPage = () => rbpPaginaCorrecta,  // rbpAdmin, rbpCompras, etc.
    OnClick = () => FormulariosManager.NuevoMetodo()
},
```
- [ ] Verificar que la Patente existe en `E_Patentes` con un ID numérico correcto
- [ ] Verificar que el `RibbonPage` (`rbpAdmin`, `rbpCompras`, etc.) existe en `frmPrincipal.Designer.cs`
  - Si no existe, crear el RibbonPage en el Designer

### 6c. SQL — Insertar Patente en la BD
- [ ] Ejecutar INSERT en la tabla de Patentes de la base de datos para que el permiso exista:
```sql
INSERT INTO Patentes (IdPatente, Descripcion, Estado) 
VALUES (NEWID(), 'NombrePatente', 1)
```
- [ ] Asignar la patente al usuario/familia que corresponda

## 7. Archivos de Idioma (¡NO OLVIDAR!)

Cada texto que se use con `.Translate()` DEBE agregarse a los archivos de idioma. El formato es `clave=valor` (una línea por entrada).

- [ ] Agregar TODAS las palabras/frases nuevas a `UI/I18n/es-MX` (español)
- [ ] Agregar TODAS las palabras/frases nuevas a `UI/I18n/en-US` (inglés)

Ejemplos de textos que se suelen necesitar:
```
# Títulos
Detalle Artículo=Article Detail
Nuevo Artículo=New Article
Artículos=Articles

# Validaciones
La descripción es requerida=Description is required
El código es requerido=Code is required

# Columnas de grilla
CÓDIGO=CODE
STOCK ACTUAL=CURRENT STOCK

# Labels
Descripción=Description
Código=Code
Proveedor=Supplier
```

> **IMPORTANTE:** Si una palabra ya existe en los archivos, NO duplicarla. Verificar antes de agregar.

## 8. Verificación
- [ ] Build exitoso (0 errores de compilación)
- [ ] La pantalla aparece en el menú del `frmPrincipal`
- [ ] Solo aparece si el usuario tiene el permiso correcto
- [ ] CRUD funcional: Crear, Ver, Modificar, Eliminar, Restaurar
- [ ] Los controles se ven con el mismo look & feel que los demás formularios
- [ ] Cambiar de idioma muestra TODOS los textos traducidos correctamente

