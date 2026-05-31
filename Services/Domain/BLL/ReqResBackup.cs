using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Domain.BLL.Base;

namespace Services.Domain.BLL
{
    // === BACKUP ===
    public class ReqBackupRealizar : ReqBase
    {
        public ReqBackupRealizar(GlobalCliente sesion) : base(sesion)
        {
        }

        public string RutaArchivo { get; set; }
    }

    public class ResBackupRealizar : ResBase
    {
    }

    // === RESTORE ===
    public class ReqBackupRestaurar : ReqBase
    {
        public ReqBackupRestaurar(GlobalCliente sesion) : base(sesion)
        {
        }

        public string RutaArchivo { get; set; }

        /// <summary>
        /// Nombre de la entrada en ConnectionStrings del config que identifica
        /// la base de datos de destino del restore. Si es null/vacío se usa
        /// la conexión por defecto de ApplicationSettings.
        /// </summary>
        public string ConnectionStringName { get; set; }
    }

    public class ResBackupRestaurar : ResBase
    {
    }
}
