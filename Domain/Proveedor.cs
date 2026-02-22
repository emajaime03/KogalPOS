using Services.Domain.Enums;
using System;

namespace Domain
{
    public class Proveedor
    {
        public Guid IdProveedor { get; set; }
        public E_Estados Estado { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public Proveedor()
        {
            IdProveedor = Guid.Empty;
            Estado = E_Estados.Activo;
            Descripcion = string.Empty;
            Email = string.Empty;
            Celular = string.Empty;
        }
    }
}
