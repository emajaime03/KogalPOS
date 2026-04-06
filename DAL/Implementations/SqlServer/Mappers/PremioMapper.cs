using Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class PremioMapper
    {

		#region "Singleton"				
		private readonly static PremioMapper _instance = new PremioMapper();

		public static PremioMapper Current
		{
			get
			{
				return _instance;
			}
		}

		private PremioMapper()
		{
			//Implent here the initialization of your singleton
		}
        #endregion

        public Premio Fill(object[] values)
        {
            Premio pre = new Premio();
            pre.IdPremio = System.Guid.Parse(values[0].ToString());
            pre.Estado = (E_Estados)System.Convert.ToInt32(values[1]);
            pre.IdArticulo = System.Guid.Parse(values[2].ToString());
            pre.Descripcion = values[3].ToString();
            pre.PuntosRequeridos = System.Convert.ToDecimal(values[4]);

            return pre;
        }
    }
}
