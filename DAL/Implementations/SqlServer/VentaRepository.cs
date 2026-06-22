using DAL.Implementations.SqlServer.Mappers;
using Domain;
using Domain.Enums;
using Services.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para Ventas.
    /// Soporta lectura (GetAll, GetById), inserción (Add, cabecera + detalle + NroVenta correlativo)
    /// y anulación lógica (Remove cambia Estado a Anulada). No soporta Update (las ventas no se modifican).
    /// </summary>
    public sealed class VentaRepository : BusinessRepository, IGenericRepository<Venta>
    {
        public VentaRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        /// <summary>
        /// Obtiene todas las ventas (solo cabecera, sin ítems), más recientes primero.
        /// </summary>
        public List<Venta> GetAll()
        {
            List<Venta> ventas = new List<Venta>();

            string query = "SELECT IdVenta, NroVenta, Fecha, Estado, Total, Descuento, IdCliente, IdListaPrecio FROM Ventas ORDER BY NroVenta DESC";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    ventas.Add(VentaMapper.Current.Fill(data));
                }
            }

            return ventas;
        }

        /// <summary>
        /// Obtiene una venta por ID incluyendo su detalle.
        /// </summary>
        public Venta GetById(Guid id)
        {
            Venta venta = null;

            string queryCabecera = "SELECT IdVenta, NroVenta, Fecha, Estado, Total, Descuento, IdCliente, IdListaPrecio FROM Ventas WHERE IdVenta = @Id";
            using (var reader = base.ExecuteReader(queryCabecera, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    venta = VentaMapper.Current.Fill(data);
                }
            }

            if (venta == null) return null;

            string queryItems = @"SELECT IdVentaDetalle, IdVenta, IdArticulo, Cantidad, PrecioUnitario, Descuento, Subtotal
                                  FROM VentasDetalle WHERE IdVenta = @Id";
            using (var reader = base.ExecuteReader(queryItems, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    venta.Items.Add(VentaDetalleMapper.Current.Fill(data));
                }
            }

            return venta;
        }

        /// <summary>
        /// Inserta una venta completa: cabecera (con NroVenta correlativo) + detalle.
        /// Asigna el NroVenta generado al objeto recibido.
        /// </summary>
        public void Add(Venta venta)
        {
            // Correlativo dentro de la transacción
            object max = base.ExecuteScalar("SELECT ISNULL(MAX(NroVenta), 0) + 1 FROM Ventas", CommandType.Text);
            venta.NroVenta = Convert.ToInt32(max);

            string queryCabecera = @"INSERT INTO Ventas (IdVenta, NroVenta, Fecha, Estado, Total, Descuento, IdCliente, IdListaPrecio)
                                     VALUES (@Id, @NroVenta, @Fecha, @Estado, @Total, @Descuento, @IdCliente, @IdListaPrecio)";
            base.ExecuteNonQuery(queryCabecera, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", venta.IdVenta),
                new SqlParameter("@NroVenta", venta.NroVenta),
                new SqlParameter("@Fecha", venta.Fecha),
                new SqlParameter("@Estado", (int)venta.Estado),
                new SqlParameter("@Total", venta.Total),
                new SqlParameter("@Descuento", venta.Descuento),
                new SqlParameter("@IdCliente", (object)venta.IdCliente ?? DBNull.Value),
                new SqlParameter("@IdListaPrecio", venta.IdListaPrecio)
            });

            foreach (var item in venta.Items)
            {
                string queryItem = @"INSERT INTO VentasDetalle (IdVentaDetalle, IdVenta, IdArticulo, Cantidad, PrecioUnitario, Descuento, Subtotal)
                                     VALUES (@IdItem, @IdVenta, @IdArt, @Cantidad, @PrecioUnitario, @Descuento, @Subtotal)";
                base.ExecuteNonQuery(queryItem, CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@IdItem", item.IdVentaDetalle),
                    new SqlParameter("@IdVenta", venta.IdVenta),
                    new SqlParameter("@IdArt", item.IdArticulo),
                    new SqlParameter("@Cantidad", item.Cantidad),
                    new SqlParameter("@PrecioUnitario", item.PrecioUnitario),
                    new SqlParameter("@Descuento", item.Descuento),
                    new SqlParameter("@Subtotal", item.Subtotal)
                });
            }
        }

        /// <summary>
        /// Anulación lógica: cambia Estado a Anulada.
        /// </summary>
        public void Remove(Guid id)
        {
            string query = "UPDATE Ventas SET Estado = @Estado WHERE IdVenta = @Id";
            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Estado", (int)E_EstadoVenta.Anulada)
            });
        }

        /// <summary>
        /// Restauración lógica: cambia Estado a Cobrada.
        /// </summary>
        public void Restore(Guid id)
        {
            string query = "UPDATE Ventas SET Estado = @Estado WHERE IdVenta = @Id";
            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Estado", (int)E_EstadoVenta.Cobrada)
            });
        }

        public void Update(Venta obj)
        {
            throw new NotImplementedException();
        }
    }
}
