using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Enums
{
    public enum E_Patentes
    {
        #region ADMIN
        Admin = 1,
        #endregion

        #region COMPRAS
        Proveedores = 20,
        #endregion

        #region INVENTARIO
        Articulos = 40,
        AjustesStock = 41,
        #endregion

        #region VENTAS
        Clientes = 60,
        #endregion

    }
}
