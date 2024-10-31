using Services.DAL.Contracts;
using Services.Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.Mappers
{
    public sealed class PatenteMapper : IObjectMapper<Patente>
    {
        #region singleton
        private readonly static PatenteMapper _instance = new PatenteMapper();

        public static PatenteMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteMapper()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Patente Fill(object[] values)
        {
            Patente patente = new Patente();
            patente.Id = Guid.Parse(values[0].ToString());
            patente.Estado = (E_Estados)values[1];
            patente.Descripcion = values[2].ToString();
            patente.DataKey = (E_Patentes)values[3];

            return patente;
        }

    }
}
