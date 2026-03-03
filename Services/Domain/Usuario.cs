using Services.Domain.Enums;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Usuario
    {

        public Guid IdUsuario { get; set; }
        public E_Estados Estado { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Acceso> Accesos = new List<Acceso>();

        public string HashedDVH
        {
            get
            {
                return CryptographyService.Hash(this.IdUsuario.ToString() + (int)this.Estado + this.UserName + this.Password);
            }
        }

        public Usuario()
        {
            IdUsuario = Guid.NewGuid();
        }

        public Usuario(Guid idUsuario)
        {
            this.IdUsuario = idUsuario;
        }

        public bool CheckPatente(E_Patentes patente)
        {
            return GetPatentes().Any(p => p.DataKey == patente);
        }

        public List<Patente> GetPatentes()
        {
            return Acceso.GetAllPatentes(Accesos);
        }



        public List<Familia> GetFamilias()
        {
            return Acceso.GetAllFamilias(Accesos);
        }


    }
}
