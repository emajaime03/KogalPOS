using Services.Domain.Enums;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Domain
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public E_Estados Estado { get; set; }
        public string Descripcion { get; set; }
        public string NroDocumento { get; set; }
        public E_TipoDocumento TipoDocumento { get; set; }
        
        /// <summary>
        /// Este campo solo tiene sentido si tiene fidelización activa
        /// </summary>
        public int Puntos { get; set; }

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
