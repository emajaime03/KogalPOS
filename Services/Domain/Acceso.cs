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

        public bool Temp_Seleccionado { get; set; }

        #region Métodos estáticos para recorrer el Composite

        public static List<Patente> GetAllPatentes(List<Acceso> accesos)
        {
            var patentes = new List<Patente>();
            GetAllPatentesRecursive(accesos, patentes);
            return patentes;
        }

        private static void GetAllPatentesRecursive(List<Acceso> accesos, List<Patente> patentesReturn)
        {
            foreach (var acceso in accesos)
            {
                if (acceso is Patente patente)
                {
                    if (!patentesReturn.Any(o => o.Id == patente.Id))
                        patentesReturn.Add(patente);
                }
                else if (acceso is Familia familia)
                {
                    GetAllPatentesRecursive(familia.Accesos, patentesReturn);
                }
            }
        }

        public static List<Familia> GetAllFamilias(List<Acceso> accesos)
        {
            var familias = new List<Familia>();
            GetAllFamiliasRecursive(accesos, familias);
            return familias;
        }

        private static void GetAllFamiliasRecursive(List<Acceso> accesos, List<Familia> familiasReturn)
        {
            foreach (var acceso in accesos)
            {
                if (acceso is Familia familia)
                {
                    if (!familiasReturn.Any(o => o.Id == familia.Id))
                        familiasReturn.Add(familia);

                    GetAllFamiliasRecursive(familia.Accesos, familiasReturn);
                }
            }
        }

        #endregion

    }//end Component
}
