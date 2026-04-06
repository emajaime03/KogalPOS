using System;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ILoyaltyRepository
    {
        /// <summary>
        /// Obtiene los puntos de fidelización de un cliente desde la API externa utilizando su DNI.
        /// </summary>
        int ObtenerPuntos(string nroDocumento);

        /// <summary>
        /// Suma puntos asíncronamente.
        /// </summary>
        Task SumarPuntosAsync(string nroDocumento, int puntos);

        /// <summary>
        /// Resta puntos asíncronamente devengados (ej: al canjear puntos).
        /// </summary>
        Task RestarPuntosAsync(string nroDocumento, int puntos);

        /// <summary>
        /// Sincroniza un premio (creación o modificación) en la nube.
        /// </summary>
        Task SyncPremioAsync(Guid idPremio, decimal puntosRequeridos, string descripcion);

        /// <summary>
        /// Elimina un premio de la nube.
        /// </summary>
        Task EliminarPremioAsync(Guid idPremio);
    }
}
