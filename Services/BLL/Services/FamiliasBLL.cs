using Services.DAL.Factories;
using Services.Domain.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    internal class FamiliasBLL
    {
        #region "Singleton"

        private readonly static FamiliasBLL _instance = new FamiliasBLL();

        public static FamiliasBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliasBLL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public ResFamiliasObtener ObtenerLista(ReqFamiliasObtener req)
        {
            ResFamiliasObtener res = new ResFamiliasObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                res.Familias = context.Repositories.FamiliaRepository.GetAll();

                context.SaveChanges();

            }

            return res;
        }

        public ResFamiliaObtener Obtener(ReqFamiliaObtener req)
        {
            ResFamiliaObtener res = new ResFamiliaObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {

                res.ListaFamilias = context.Repositories.FamiliaRepository.GetAll();
                res.ListaPatentes = context.Repositories.PatenteRepository.GetAll();

                if (req.Id != null && req.Id != Guid.Empty)
                {
                    res.Familia = context.Repositories.FamiliaRepository.GetById(req.Id);
                    res.ListaFamilias = res.ListaFamilias.Where(f => !f.Accesos.Any(acceso => acceso.Id == res.Familia.Id) && !(f.Id == res.Familia.Id)).ToList();
                }

                context.SaveChanges();

            }

            return res;
        }

    }
}
