using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Principal;
using UI.Formularios.Administrador.Patentes;
using UI.Formularios.Administrador.Familias;

namespace UI.Formularios
{
    
    public static class FormulariosManager
    {
        public static frmPrincipal frmPrincipal;

        public static void Patentes()
        {
            frmPatentes frmPatentes = new frmPatentes();
            frmPatentes.MdiParent = frmPrincipal;
            frmPatentes.MaximizeBox = true;
            frmPatentes.Show();
        }

        public static void Familias()
        {
            frmFamilias frmFamilias = new frmFamilias();
            frmFamilias.MdiParent = frmPrincipal;
            frmFamilias.MaximizeBox = true;
            frmFamilias.Show();
        }

        public static void FamiliasABM(Guid id = default)
        {
            frmFamiliasABM frmFamiliasABM = new frmFamiliasABM(id);
            frmFamiliasABM.MdiParent = frmPrincipal;
            frmFamiliasABM.MaximizeBox = true;
            frmFamiliasABM.Show();
        }
    }
}
