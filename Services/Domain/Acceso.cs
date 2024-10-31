using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public abstract class Acceso
    {

        public Guid Id { get; set; }
        public E_Estados Estado { get; set; }
        public string Descripcion { get; set; }

        public Acceso()
        {

        }


        /// 
        /// <param name="component"></param>
        public abstract void Add(Acceso component);

        /// 
        /// <param name="component"></param>
        public abstract void Remove(Acceso component);

        public abstract int GetCount();

    }//end Component
}
