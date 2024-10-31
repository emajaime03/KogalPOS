using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Patente : Acceso
    {

        public E_Patentes DataKey { get; set; }

        public Patente()
        {

        }

        /// 
        /// <param name="component"></param>
        public override void Add(Acceso component)
        {

            throw new Exception("No se puede agregar un elemento");

        }

        /// 
        /// <param name="component"></param>
        public override void Remove(Acceso component)
        {

            throw new Exception("No se puede quitar un elemento");

        }

        public override int GetCount()
        {
            return 0;
        }
    }//end Leaf
}
