using System;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ILoyaltyRepository
    {
        /// <summary>
        /// Obtiene los puntos de fidelización de un cliente desde la API externa de forma asíncrona.
        /// </summary>
        /// <param name="idFirebaseCliente">El identificador del cliente en la nube (ej. DNI o GUID en formato string).</param>
        Task<int> ObtenerPuntosAsync(string idFirebaseCliente);

        /// <summary>
        /// Sincroniza un premio (creación o modificación) en la nube de forma asíncrona.
        /// </summary>
        Task SyncPremioAsync(Guid idPremio, decimal puntosRequeridos, string descripcion);

        /// <summary>
        /// Elimina un premio de la nube de forma asíncrona.
        /// </summary>
        Task EliminarPremioAsync(Guid idPremio);

        /// <summary>
        /// Actualiza el balance de puntos mediante una mutación atómica en el servidor.
        /// Retorna true si la operación fue exitosa, permitiendo confirmar transacciones locales.
        /// </summary>
        /// <param name="idFirebaseCliente">El identificador del cliente en la nube.</param>
        /// <param name="deltaPuntos">La cantidad a sumar (positivo) o restar (negativo).</param>
        Task<bool> UpdatePuntosBalanceAsync(string idFirebaseCliente, int deltaPuntos);
    }
}