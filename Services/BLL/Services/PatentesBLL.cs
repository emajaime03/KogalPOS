using Services.DAL.Factories;
using Services.DAL.Implementations.SqlServer;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.BLL.Base;
using Services.Facade;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    internal class PatentesBLL
    {
        private readonly static PatentesBLL _instance = new PatentesBLL();

        public static PatentesBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private PatentesBLL()
        {
            //Implent here the initialization of your singleton
        }

        public ResPatentesObtener Obtener(ReqPatentesObtener req)
        {
            ResPatentesObtener res = new ResPatentesObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                res.Patentes = context.Repositories.PatenteRepository.GetAll();

                context.SaveChanges();
                    
            }

            return res;
        }
            
    }
}
