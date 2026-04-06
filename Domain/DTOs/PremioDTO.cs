using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PremioDTO
    {
        public Guid IdPremio { get; set; }
        public E_Estados Estado { get; set; }
        public Guid IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal PuntosRequeridos { get; set; }
        public string Articulo { get; set; }

        public PremioDTO()
        {
            IdPremio = Guid.Empty;
            Estado = new E_Estados();
            IdArticulo = Guid.Empty;
            Descripcion = "";
            PuntosRequeridos = 0;
            Articulo = "";
        }
    }
}
