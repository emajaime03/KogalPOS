using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    public class MovimientosPuntosRepository : BusinessRepository, IMovimientosPuntosRepository
    {
        public MovimientosPuntosRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Add(MovimientoPuntos obj)
        {
            string query = @"INSERT INTO MovimientosPuntos (IdMovimientoPuntos, IdCliente, IdPremio, TipoMovimiento, Puntos, MontoOperacion, Observaciones) 
                             VALUES (@IdMovimientoPuntos, @IdCliente, @IdPremio, @TipoMovimiento, @Puntos, @MontoOperacion, @Observaciones)";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdMovimientoPuntos", obj.IdMovimientoPuntos),
                new SqlParameter("@IdCliente", obj.IdCliente),
                new SqlParameter("@IdPremio", (object)obj.IdPremio ?? DBNull.Value),
                new SqlParameter("@TipoMovimiento", obj.TipoMovimiento),
                new SqlParameter("@Puntos", obj.Puntos),
                new SqlParameter("@MontoOperacion", obj.MontoOperacion),
                new SqlParameter("@Observaciones", obj.Observaciones)
            });
        }

        public List<MovimientoPuntos> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovimientoPuntos GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Restore(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(MovimientoPuntos obj)
        {
            throw new NotImplementedException();
        }
    }
}
