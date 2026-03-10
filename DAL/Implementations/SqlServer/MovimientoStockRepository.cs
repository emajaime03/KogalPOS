using DAL.Implementations.SqlServer.Mappers;
using Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para MovimientosStock.
    /// Soporta lectura (GetAll, GetById), inserción (Add), y eliminación/restauración lógica (Remove/Restore).
    /// No soporta Update (los movimientos no se modifican una vez creados).
    /// </summary>
    public sealed class MovimientoStockRepository : BusinessRepository
    {
        public MovimientoStockRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        /// <summary>
        /// Obtiene todos los movimientos de stock (solo cabecera, sin ítems).
        /// </summary>
        public List<MovimientoStock> GetAll()
        {
            List<MovimientoStock> movimientos = new List<MovimientoStock>();

            string query = "SELECT IdMovimientoStock, Fecha, TipoMovimiento, Estado FROM MovimientosStock ORDER BY Fecha DESC";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    movimientos.Add(MovimientoStockMapper.Current.Fill(data));
                }
            }

            return movimientos;
        }

        /// <summary>
        /// Obtiene un movimiento de stock por ID, incluyendo sus ítems con datos del artículo.
        /// </summary>
        public MovimientoStock GetById(Guid id)
        {
            MovimientoStock movimiento = null;

            // Obtener cabecera
            string queryCabecera = "SELECT IdMovimientoStock, Fecha, TipoMovimiento, Estado FROM MovimientosStock WHERE IdMovimientoStock = @Id";
            using (var reader = base.ExecuteReader(queryCabecera, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    movimiento = MovimientoStockMapper.Current.Fill(data);
                }
            }

            if (movimiento == null) return null;

            // Obtener ítems con JOIN a Articulos
            string queryItems = @"SELECT mi.IdMovimientoItem, mi.IdMovimientoStock, mi.IdArticulo, mi.Cantidad, 
                                         a.Codigo, a.Descripcion
                                  FROM MovimientosItem mi
                                  INNER JOIN Articulos a ON mi.IdArticulo = a.IdArticulo
                                  WHERE mi.IdMovimientoStock = @Id";
            using (var reader = base.ExecuteReader(queryItems, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    movimiento.Items.Add(MovimientoItemMapper.Current.Fill(data));
                }
            }

            return movimiento;
        }

        /// <summary>
        /// Inserta un movimiento de stock completo: cabecera + ítems + actualiza StockActual de cada artículo.
        /// Todo dentro de la misma transacción del UnitOfWork.
        /// </summary>
        public void Add(MovimientoStock movimiento)
        {
            // 1. Insertar cabecera
            string queryCabecera = @"INSERT INTO MovimientosStock (IdMovimientoStock, Fecha, TipoMovimiento, Estado) 
                                     VALUES (@Id, @Fecha, @Tipo, @Estado)";
            base.ExecuteNonQuery(queryCabecera, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", movimiento.IdMovimientoStock),
                new SqlParameter("@Fecha", movimiento.Fecha),
                new SqlParameter("@Tipo", (int)movimiento.TipoMovimiento),
                new SqlParameter("@Estado", (int)movimiento.Estado)
            });

            // 2. Insertar cada ítem y actualizar StockActual del artículo
            foreach (var item in movimiento.Items)
            {
                // Insertar ítem
                string queryItem = @"INSERT INTO MovimientosItem (IdMovimientoItem, IdMovimientoStock, IdArticulo, Cantidad) 
                                     VALUES (@IdItem, @IdMov, @IdArt, @Cantidad)";
                base.ExecuteNonQuery(queryItem, CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@IdItem", item.IdMovimientoItem),
                    new SqlParameter("@IdMov", movimiento.IdMovimientoStock),
                    new SqlParameter("@IdArt", item.IdArticulo),
                    new SqlParameter("@Cantidad", item.Cantidad)
                });

                // Actualizar StockActual del artículo
                string signo = movimiento.TipoMovimiento == E_TipoMovimiento.Alta ? "+" : "-";
                string queryStock = $"UPDATE Articulos SET StockActual = StockActual {signo} @Cantidad WHERE IdArticulo = @IdArt";
                base.ExecuteNonQuery(queryStock, CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@Cantidad", item.Cantidad),
                    new SqlParameter("@IdArt", item.IdArticulo)
                });
            }
        }

        /// <summary>
        /// Eliminación lógica: cambia Estado a 0.
        /// </summary>
        public void Remove(Guid id)
        {
            string query = "UPDATE MovimientosStock SET Estado = @Estado WHERE IdMovimientoStock = @Id";
            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        /// <summary>
        /// Restauración: cambia Estado a 1.
        /// </summary>
        public void Restore(Guid id)
        {
            string query = "UPDATE MovimientosStock SET Estado = @Estado WHERE IdMovimientoStock = @Id";
            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }
    }
}

