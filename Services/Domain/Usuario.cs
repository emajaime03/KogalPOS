﻿using Services.Domain.Enums;
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
    }
}
