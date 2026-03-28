using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public sealed class ConfiguracionApp
    {
		#region "Singleton"				
		private readonly static ConfiguracionApp _instance = new ConfiguracionApp();

		public static ConfiguracionApp Current
		{
			get
			{
				return _instance;
			}
		}

		private ConfiguracionApp()
		{
			//Implent here the initialization of your singleton
		}
		#endregion

		public ConfiguracionLocal configuracionLocal {  get; set; }
    }
}
