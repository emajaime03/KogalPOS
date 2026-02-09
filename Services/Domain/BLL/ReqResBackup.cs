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
        public string RutaArchivo { get; set; }
    }

    public class ResBackupRealizar : ResBase
    {
    }

    // === RESTORE ===
    public class ReqBackupRestaurar : ReqBase
    {
        public string RutaArchivo { get; set; }
    }

    public class ResBackupRestaurar : ResBase
    {
    }
}
