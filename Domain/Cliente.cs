using Services.Domain.Enums;
using System;

namespace Domain
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public E_Estados Estado { get; set; }
        public string Descripcion { get; set; }
        public string NroDocumento { get; set; }
        public E_TipoDocumento TipoDocumento { get; set; }

        public Cliente()
        {
            IdCliente = Guid.Empty;
            Estado = E_Estados.Activo;
            Descripcion = string.Empty;
            NroDocumento = string.Empty;
            TipoDocumento = E_TipoDocumento.DNI;
        }
    }
}
