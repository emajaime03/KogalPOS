using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Premio
    {
        public Guid IdPremio { get; set; }
        public E_Estados Estado { get; set; }
        public Guid IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal PuntosRequeridos { get; set; }

        public Premio()
        {
            IdPremio = Guid.Empty;
            Estado = E_Estados.Activo;
            IdArticulo = Guid.Empty;
            Descripcion = "";
            PuntosRequeridos = 0;
        }
    }
}
