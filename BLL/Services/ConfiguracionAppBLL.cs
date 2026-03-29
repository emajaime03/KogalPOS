using DAL.Factories;
using Domain;
using Domain.BLL;
using System.Runtime.Remoting.Contexts;

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

                var configuracionLocal = context.Repositories.ConfiguracionLocalRepository.Get(); // falta llamada a bdd

                res.configuracionLocal = configuracionLocal;
                res.Success = true;
            }

            return res;
        }
    }
}
