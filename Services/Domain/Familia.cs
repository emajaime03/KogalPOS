using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Familia : Acceso
    {
        private List<Acceso> accesos = new List<Acceso>();

        public Familia(Acceso acceso = null)
        {
            if (acceso != null)
                //acceso no debe ser null
                accesos.Add(acceso);
        }

        /// 
        /// <param name="component"></param>
        public override void Add(Acceso component)
        {
            if (accesos.Any(o => o.Id == component.Id))
                throw new Exception("Ya existe el acceso");
            accesos.Add(component);
        }

        /// 
        /// <param name="component"></param>
        public override void Remove(Acceso component)
        {
            //Ver que no puedo quedarme sin hijos...
            if (!accesos.Any(o => o.Id == component.Id)) 
                throw new Exception("No existe el acceso");
            else if (accesos.Count == 1)
                throw new Exception("No se puede quedar sin hijos");

            //accesos.Remove(component);
            accesos.RemoveAll(o => o.Id == component.Id);
        }

        public override int GetCount()
        {
            return Accesos.Count;
        }

        public List<Acceso> Accesos
        {
            get
            {
                return accesos;
            }
        }

    }//end Composite
}
