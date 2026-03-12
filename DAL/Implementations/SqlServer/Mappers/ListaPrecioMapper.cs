using Domain;
using Services.Domain.Enums;
using System;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class ListaPrecioMapper
    {
        #region singleton
        private readonly static ListaPrecioMapper _instance = new ListaPrecioMapper();

        public static ListaPrecioMapper Current
        {
            get { return _instance; }
        }

        private ListaPrecioMapper() { }
        #endregion

        /// <summary>
        /// Columnas esperadas: IdListaPrecio, Descripcion, Estado, EsPredeterminada, VigenciaDesde, VigenciaHasta
        /// </summary>
        public ListaPrecio Fill(object[] values)
        {
            ListaPrecio lp = new ListaPrecio();
            lp.IdListaPrecio = System.Guid.Parse(values[0].ToString());
            lp.Descripcion = values[1].ToString();
            lp.Estado = (E_Estados)Convert.ToInt32(values[2]);
            lp.EsPredeterminada = Convert.ToBoolean(values[3]);
            lp.VigenciaDesde = values[4] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(values[4]);
            lp.VigenciaHasta = values[5] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(values[5]);

            return lp;
        }
    }
}
