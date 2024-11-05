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

        public List<Patente> GetPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            GetAllPatentes(Accesos, patentes);

            return patentes;
        }

        private void GetAllPatentes(List<Acceso> accesos, List<Patente> patentesReturn)
        {
            foreach (var acceso in accesos)
            {
                //Cuál sería mi condición de corte?
                //Significa que estoy ante un elemento de tipo Leaf, Hoja, Primitivo
                if (acceso.GetCount() == 0)
                {
                    //Podría pasar que la patente ya esté agregada (Similar a un distinct)
                    if (!patentesReturn.Any(o => o.Id == acceso.Id))
                        patentesReturn.Add(acceso as Patente);
                }
                else
                {
                    //Tengo que tratar a mi "acceso" como si fuese una familia
                    GetAllPatentes((acceso as Familia).Accesos, patentesReturn);
                }
            }
        }

        public List<Familia> GetFamilias()
        {

            List<Familia> familias = new List<Familia>();

            GetAllFamilias(Accesos, familias);

            return familias;

        }

        private void GetAllFamilias(List<Acceso> accesos, List<Familia> famililaReturn)
        {
            foreach (var acceso in accesos)
            {
                //Cuál sería mi condición de corte?
                //Significa que estoy ante un elemento de tipo Composite
                if (acceso.GetCount() > 0)
                {
                    if (!famililaReturn.Any(o => o.Id == acceso.Id))
                        famililaReturn.Add(acceso as Familia);

                    GetAllFamilias((acceso as Familia).Accesos, famililaReturn);
                }
            }
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
