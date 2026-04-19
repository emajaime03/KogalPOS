using Domain;
using Domain.Enums;
using Services.Domain.Enums;

namespace DAL.Implementations.SqlServer.Mappers
{
    public sealed class MovimientoStockMapper
    {
        #region singleton
        private readonly static MovimientoStockMapper _instance = new MovimientoStockMapper();

        public static MovimientoStockMapper Current
        {
            get { return _instance; }
        }

        private MovimientoStockMapper() { }
        #endregion

        public MovimientoStock Fill(object[] values)
        {
            MovimientoStock mov = new MovimientoStock();
            mov.IdMovimientoStock = System.Guid.Parse(values[0].ToString());
            mov.Fecha = System.Convert.ToDateTime(values[1]);
            mov.TipoMovimiento = (E_TipoMovimientoStock)System.Convert.ToInt32(values[2]);
            mov.Estado = (E_Estados)System.Convert.ToInt32(values[3]);

            return mov;
        }
    }
}
