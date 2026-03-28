using System;
using UI.Principal;
using UI.Formularios.Administrador.Patentes;
using UI.Formularios.Administrador.Familias;
using UI.Formularios.Administrador.Usuarios;
using UI.Formularios.Administrador.BackupRestore;
using UI.Formularios.Proveedores;
using UI.Formularios.Articulos;
using UI.Formularios.Clientes;
using UI.Formularios.AjustesStock;
using UI.Formularios.ListaPrecios;

namespace UI.Formularios
{
    
    public static class FormulariosManager
    {
        public static frmPrincipal frmPrincipal;

        #region "PATENTES"
        public static void Patentes()
        {
            frmPatentes frmPatentes = new frmPatentes(frmPrincipal.Sesion);
            frmPatentes.MdiParent = frmPrincipal;
            frmPatentes.MaximizeBox = true;
            frmPatentes.Show();
        }
        #endregion

        #region "FAMILIAS"
        public static void Familias()
        {
            frmFamilias frmFamilias = new frmFamilias(frmPrincipal.Sesion);
            frmFamilias.MdiParent = frmPrincipal;
            frmFamilias.MaximizeBox = true;
            frmFamilias.Show();
        }

        public static void FamiliasABM(Guid id = default)
        {
            frmFamiliasABM frmFamiliasABM = new frmFamiliasABM(frmPrincipal.Sesion, id);
            frmFamiliasABM.MdiParent = frmPrincipal;
            frmFamiliasABM.MaximizeBox = true;
            frmFamiliasABM.Show();
        }
        #endregion

        #region "USUARIOS"
        public static void Usuarios()
        {
            frmUsuarios frmUsuarios = new frmUsuarios(frmPrincipal.Sesion);
            frmUsuarios.MdiParent = frmPrincipal;
            frmUsuarios.MaximizeBox = true;
            frmUsuarios.Show();
        }

        public static void UsuariosABM(Guid id = default)
        {
            frmUsuariosABM frmUsuariosABM = new frmUsuariosABM(frmPrincipal.Sesion, id);
            frmUsuariosABM.MdiParent = frmPrincipal;
            frmUsuariosABM.MaximizeBox = true;
            frmUsuariosABM.Show();
        }
        #endregion

        #region "BACKUP"
        public static void CopiasSeguridad()
        {
            frmBackupRestore frm = new frmBackupRestore(frmPrincipal.Sesion);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = false; // Es un diÃ¡logo pequeÃ±o
            frm.Show();
        }
        #endregion

        #region "PROVEEDORES"
        public static void Proveedores()
        {
            frmProveedores frm = new frmProveedores(frmPrincipal.Sesion);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }

        public static void ProveedoresABM(System.Guid id = default)
        {
            frmProveedoresABM frm = new frmProveedoresABM(frmPrincipal.Sesion, id);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }
        #endregion

        #region "ARTICULOS"
        public static void Articulos()
        {
            frmArticulos frm = new frmArticulos(frmPrincipal.Sesion);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }

        public static void ArticulosABM(System.Guid id = default)
        {
            frmArticulosABM frm = new frmArticulosABM(frmPrincipal.Sesion, id);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }
        #endregion

        #region "CLIENTES"
        public static void Clientes()
        {
            frmClientes frm = new frmClientes(frmPrincipal.Sesion);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }

        public static void ClientesABM(System.Guid id = default)
        {
            frmClientesABM frm = new frmClientesABM(frmPrincipal.Sesion, id);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }
        #endregion

        #region "AJUSTES DE STOCK"
        public static void AjustesStock()
        {
            frmMovimientosStock frm = new frmMovimientosStock(frmPrincipal.Sesion);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }

        public static void AjusteStockABM(System.Guid id = default)
        {
            frmAjusteStock frm = new frmAjusteStock(frmPrincipal.Sesion, id);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }
        #endregion

        #region "LISTAS DE PRECIOS"
        public static void ListaPrecios()
        {
            frmListaPrecios frm = new frmListaPrecios(frmPrincipal.Sesion);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }

        public static void ListaPreciosABM(System.Guid id = default)
        {
            frmListaPreciosABM frm = new frmListaPreciosABM(frmPrincipal.Sesion, id);
            frm.MdiParent = frmPrincipal;
            frm.MaximizeBox = true;
            frm.Show();
        }
        #endregion
    }
}

