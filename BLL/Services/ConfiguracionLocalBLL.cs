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
    public sealed class ConfiguracionLocalBLL
    {
        #region "Singleton"				
        private readonly static ConfiguracionLocalBLL _instance = new ConfiguracionLocalBLL();

        public static ConfiguracionLocalBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private ConfiguracionLocalBLL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public ResConfiguracionLocalModificar Modificar(ReqConfiguracionLocalModificar req)
        {
            ResConfiguracionLocalModificar res = new ResConfiguracionLocalModificar();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                context.Repositories.ConfiguracionLocalRepository.Update(req.configuracionLocal);

                //Actualizo el recurso compartido del lado del servidor (En un futuro agregar synclock)
                ConfiguracionApp.Current.configuracionLocal = req.configuracionLocal;

                res.configuracionLocal = req.configuracionLocal;

                res.Success = true;
            }

            return res;
        }
    }
}
