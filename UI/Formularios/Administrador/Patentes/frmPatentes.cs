using Services.Domain;
using Services.Domain.BLL;
using Services.BLL.Services;
using Services.Facade.Extensions;
using UI.Formularios.Base;

namespace UI.Formularios.Administrador.Patentes
{
    public partial class frmPatentes : frmBaseGrilla
    {
        public frmPatentes()
        {
            InitializeComponent();

            MostrarBotonNuevo = false;
            MostrarBotonDetalle = false;
        }

        protected override void ConfigurarTextos()
        {
            // Llamar al método base para actualizar los botones de la barra de herramientas
            base.ConfigurarTextos();

            this.Text = "Patentes".Translate();

            // Actualizar captions de las columnas
            if (GridViewPrincipal.Columns.Count > 0)
            {
                var colId = GridViewPrincipal.Columns[nameof(Patente.Id)];
                var colDescripcion = GridViewPrincipal.Columns[nameof(Patente.Descripcion)];
                var colEstado = GridViewPrincipal.Columns[nameof(Patente.Estado)];

                if (colId != null) colId.Caption = "ID";
                if (colDescripcion != null) colDescripcion.Caption = "DESCRIPCIÓN".Translate();
                if (colEstado != null) colEstado.Caption = "ESTADO".Translate();
            }
        }

        protected override void ConfigurarColumnas()
        {
            AgregarColumnas(
                CrearColumna(nameof(Patente.Id), "ID", width: 80),
                CrearColumna(nameof(Patente.Descripcion), "DESCRIPCIÓN".Translate()),
                CrearColumna(nameof(Patente.Estado), "ESTADO".Translate(), width: 100)
            );

            // Configurar textos iniciales
            ConfigurarTextos();
        }

        protected override void CargarPantalla()
        {
            var res = PatentesBLL.Current.Obtener(new ReqPatentesObtener());
            EstablecerDataSource(res.Patentes);
        }
    }
}
