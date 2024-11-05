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

        public ResFamiliasObtener Obtener(ReqFamiliasObtener req)
        {
            ResFamiliasObtener res = new ResFamiliasObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                res.Familias = context.Repositories.FamiliaRepository.GetAll();

                context.SaveChanges();

            }

            return res;
        }

    }
}
