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
    }
}
