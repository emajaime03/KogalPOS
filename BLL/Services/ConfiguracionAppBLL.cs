using DAL.Factories;
using Domain;
using Domain.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public sealed class ConfiguracionAppBLL
    {

		#region "Singleton"				
		private readonly static ConfiguracionAppBLL _instance = new ConfiguracionAppBLL();

		public static ConfiguracionAppBLL Current
		{
			get
			{
				return _instance;
			}
		}

		private ConfiguracionAppBLL()
		{
			//Implent here the initialization of your singleton
		}
        #endregion

        public ResConfiguracionAppObtener Obtener(ReqConfiguracionAppObtener req)
        {
            ResConfiguracionAppObtener res = new ResConfiguracionAppObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var configuracionLocal = new ConfiguracionLocal(); // falta llamada a bdd

                res.configuracionLocal = configuracionLocal;
                res.Success = true;
            }

            return res;
        }
    }
}
