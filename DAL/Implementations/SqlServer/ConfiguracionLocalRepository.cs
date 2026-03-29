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
    public sealed class ConfiguracionLocalRepository : BusinessRepository, IConfiguracionesRepository<ConfiguracionLocal>
    {
        public ConfiguracionLocalRepository(SqlConnection context, SqlTransaction transaction)
            : base(context, transaction)
        {
        }

        public void Update(ConfiguracionLocal obj)
        {
            string query = @"UPDATE ConfiguracionLocal 
                             SET Loyalty_MontoRequerido = @Loyalty_MontoRequerido,
                             Loyalty_PuntosOtorgados = @Loyalty_PuntosOtorgados,
                             Loyalty_MontoMinimo = @Loyalty_MontoMinimo
                             WHERE IdConfig = @IdConfig";

            base.ExecuteNonQuery(query, CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@IdConfig", obj.IdConfig),
                new SqlParameter("@Loyalty_MontoRequerido", obj.Loyalty_MontoRequerido),
                new SqlParameter("@Loyalty_PuntosOtorgados", obj.Loyalty_PuntosOtorgados),
                new SqlParameter("@Loyalty_MontoMinimo", obj.Loyalty_MontoMinimo)
            });
        }

        public ConfiguracionLocal Get() 
        {
            ConfiguracionLocal configuracionLocal = default;

            string query = "SELECT * FROM ConfiguracionLocal";
            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    configuracionLocal = ConfiguracionLocalMapper.Current.Fill(data);
                }
            }

            return configuracionLocal;
        }
    }
}
