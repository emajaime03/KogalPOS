using DAL.Contracts;
using DAL.Implementations.SqlServer.Mappers;
using Domain;
using Services.DAL.Contracts;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para ListaPrecios.
    /// Soporta CRUD completo de cabecera + ítems (artículos con sus precios).
    /// </summary>
    public sealed class ListaPrecioRepository : BusinessRepository, IListaPreciosRepository<ListaPrecio>
    {
        public ListaPrecioRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        /// <summary>
        /// Obtiene todas las listas de precios (solo cabecera, sin ítems).
        /// </summary>
        public List<ListaPrecio> GetAll()
        {
            List<ListaPrecio> listas = new List<ListaPrecio>();

            string query = "SELECT IdListaPrecio, Descripcion, Estado, EsPredeterminada, VigenciaDesde, VigenciaHasta FROM ListaPrecios ORDER BY Descripcion";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    listas.Add(ListaPrecioMapper.Current.Fill(data));
                }
            }

            return listas;
        }

        /// <summary>
        /// Obtiene una lista de precios por ID, incluyendo sus ítems con datos del artículo.
        /// </summary>
        public ListaPrecio GetById(Guid id)
        {
            ListaPrecio lista = null;

            // Obtener cabecera
            string queryCabecera = "SELECT IdListaPrecio, Descripcion, Estado, EsPredeterminada, VigenciaDesde, VigenciaHasta FROM ListaPrecios WHERE IdListaPrecio = @Id";
            using (var reader = base.ExecuteReader(queryCabecera, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    lista = ListaPrecioMapper.Current.Fill(data);
                }
            }

            if (lista == null) return null;

            // Obtener ítems con JOIN a Articulos
            string queryItems = @"SELECT lpa.IdListaPrecioArticulo, lpa.IdListaPrecio, lpa.IdArticulo, lpa.Precio, 
                                         a.Codigo, a.Descripcion
                                  FROM ListaPrecioArticulos lpa
                                  INNER JOIN Articulos a ON lpa.IdArticulo = a.IdArticulo
                                  WHERE lpa.IdListaPrecio = @Id";
            using (var reader = base.ExecuteReader(queryItems, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    lista.Items.Add(ListaPrecioArticuloMapper.Current.Fill(data));
                }
            }

            return lista;
        }

        /// <summary>
        /// Inserta una lista de precios completa: cabecera + ítems.
        /// </summary>
        public void Add(ListaPrecio lista)
        {
            // 1. Insertar cabecera
            string queryCabecera = @"INSERT INTO ListaPrecios (IdListaPrecio, Descripcion, Estado, EsPredeterminada, VigenciaDesde, VigenciaHasta) 
                                     VALUES (@Id, @Descripcion, @Estado, @EsPredeterminada, @VigenciaDesde, @VigenciaHasta)";
            base.ExecuteNonQuery(queryCabecera, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", lista.IdListaPrecio),
                new SqlParameter("@Descripcion", lista.Descripcion),
                new SqlParameter("@Estado", (int)lista.Estado),
                new SqlParameter("@EsPredeterminada", lista.EsPredeterminada),
                new SqlParameter("@VigenciaDesde", (object)lista.VigenciaDesde ?? DBNull.Value),
                new SqlParameter("@VigenciaHasta", (object)lista.VigenciaHasta ?? DBNull.Value)
            });

            // 2. Insertar cada ítem
            InsertarItems(lista);
        }

        /// <summary>
        /// Actualiza una lista de precios: cabecera + reemplaza todos los ítems.
        /// </summary>
        public void Update(ListaPrecio lista)
        {
            // 1. Actualizar cabecera
            string queryCabecera = @"UPDATE ListaPrecios 
                                     SET Descripcion = @Descripcion, EsPredeterminada = @EsPredeterminada, 
                                         VigenciaDesde = @VigenciaDesde, VigenciaHasta = @VigenciaHasta
                                     WHERE IdListaPrecio = @Id";
            base.ExecuteNonQuery(queryCabecera, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", lista.IdListaPrecio),
                new SqlParameter("@Descripcion", lista.Descripcion),
                new SqlParameter("@EsPredeterminada", lista.EsPredeterminada),
                new SqlParameter("@VigenciaDesde", (object)lista.VigenciaDesde ?? DBNull.Value),
                new SqlParameter("@VigenciaHasta", (object)lista.VigenciaHasta ?? DBNull.Value)
            });

            // 2. Borrar ítems existentes y re-insertar
            string queryDeleteItems = "DELETE FROM ListaPrecioArticulos WHERE IdListaPrecio = @Id";
            base.ExecuteNonQuery(queryDeleteItems, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", lista.IdListaPrecio)
            });

            InsertarItems(lista);
        }

        /// <summary>
        /// Eliminación lógica: cambia Estado a Inactivo.
        /// </summary>
        public void Remove(Guid id)
        {
            string query = "UPDATE ListaPrecios SET Estado = @Estado WHERE IdListaPrecio = @Id";
            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Estado", (int)E_Estados.Inactivo)
            });
        }

        /// <summary>
        /// Restauración: cambia Estado a Activo.
        /// </summary>
        public void Restore(Guid id)
        {
            string query = "UPDATE ListaPrecios SET Estado = @Estado WHERE IdListaPrecio = @Id";
            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Estado", (int)E_Estados.Activo)
            });
        }

        /// <summary>
        /// Verifica si una lista es predeterminada.
        /// </summary>
        public bool EsPredeterminada(Guid id)
        {
            string query = "SELECT EsPredeterminada FROM ListaPrecios WHERE IdListaPrecio = @Id";
            using (var reader = base.ExecuteReader(query, CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                if (reader.Read())
                {
                    return Convert.ToBoolean(reader[0]);
                }
            }
            return false;
        }

        #region "PRIVADO"

        private void InsertarItems(ListaPrecio lista)
        {
            foreach (var item in lista.Items)
            {
                string queryItem = @"INSERT INTO ListaPrecioArticulos (IdListaPrecioArticulo, IdListaPrecio, IdArticulo, Precio) 
                                     VALUES (@IdItem, @IdLista, @IdArt, @Precio)";
                base.ExecuteNonQuery(queryItem, CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@IdItem", item.IdListaPrecioArticulo),
                    new SqlParameter("@IdLista", lista.IdListaPrecio),
                    new SqlParameter("@IdArt", item.IdArticulo),
                    new SqlParameter("@Precio", item.Precio)
                });
            }
        }

        #endregion
    }
}
