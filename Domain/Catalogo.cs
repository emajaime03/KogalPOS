using Services.Domain.Enums;
using System;

namespace Domain
{
    public class Catalogo
    {
        public Guid IdCatalogo { get; set; }
        public string Descripcion { get; set; }
        public E_Estados Estado { get; set; }

        public Catalogo()
        {
            IdCatalogo = Guid.Empty;
            Descripcion = string.Empty;
            Estado = E_Estados.Activo;
        }
    }
}
