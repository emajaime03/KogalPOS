﻿using Services.DAL.Contracts;
using Services.Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.Mappers
{
    public sealed class FamiliaMapper : IObjectMapper<Familia>
    {
        #region singleton
        private readonly static FamiliaMapper _instance = new FamiliaMapper();

        public static FamiliaMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliaMapper()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Familia Fill(object[] values)
        {
            //Nivel de hidratación 1 (Primitivos)
            Familia familia = new Familia();
            familia.Id = Guid.Parse(values[0].ToString());
            familia.Estado = (E_Estados)values[1];
            familia.Descripcion = values[2].ToString();

            return familia;
        }

    }
}
