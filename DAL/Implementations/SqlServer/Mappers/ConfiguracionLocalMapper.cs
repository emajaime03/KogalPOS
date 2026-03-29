using Domain;
using Services.Domain.Enums;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class ConfiguracionLocalMapper
    {

        #region "Singleton"				
        private readonly static ConfiguracionLocalMapper _instance = new ConfiguracionLocalMapper();

        public static ConfiguracionLocalMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private ConfiguracionLocalMapper()
        {
            //Implent here the initialization of your singleton
        }
        #endregion


        public ConfiguracionLocal Fill(object[] values)
        {
            ConfiguracionLocal configuracionLocal = new ConfiguracionLocal();
        
            configuracionLocal.IdConfig = System.Guid.Parse(values[0].ToString());
            configuracionLocal.Loyalty_MontoRequerido = (decimal)values[1];
            configuracionLocal.Loyalty_PuntosOtorgados = (decimal)values[2];
            configuracionLocal.Loyalty_MontoMinimo = (decimal)values[3];
            configuracionLocal.Loyalty_IsEnabled = (bool)values[4];
            configuracionLocal.Loyalty_ApiEndpoint = values[5].ToString();
            configuracionLocal.Loyalty_ApiAccessKey = values[6].ToString();

            return configuracionLocal;
        }
    }
}
