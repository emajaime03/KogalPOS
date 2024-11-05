using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Formularios;

namespace UI.Principal
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPrincipal()
        {
            InitializeComponent();

            ControlesInicializar();
        }

        private void ControlesInicializar()
        {
            if (GlobalCliente.UsuarioLogin.CheckPatente(E_Patentes.Admin))
            {
                AgregarItem(E_MenuItems.Patentes, this.rbpAdmin);
                AgregarItem(E_MenuItems.Familias, this.rbpAdmin);
            }
        }

        enum E_MenuItems
        {
            Patentes,
            Familias
        }

        private void BarButtonItem_ItemClick(E_MenuItems item)
        {
            FormulariosManager.frmPrincipal = this;

            switch (item)
            {
                case E_MenuItems.Patentes:
                    FormulariosManager.Patentes();
                    break;

                case E_MenuItems.Familias:
                    FormulariosManager.Familias();
                    break;
            }
        }

        private void AgregarItem(E_MenuItems item, RibbonPage padre)
        {
            BarButtonItem barButtonItem = new BarButtonItem();

            barButtonItem.Caption = item.ToString();
            barButtonItem.Id = 15;
            barButtonItem.Name = $"barButtonItem_{item}";

            barButtonItem.ItemClick += (s, e) => BarButtonItem_ItemClick(item); // Suscribimos el evento

            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup();

            ribbonPageGroup.ItemLinks.Add(barButtonItem);
            ribbonPageGroup.Name = $"ribbonPageGroup{item}";

            padre.Groups.Add(ribbonPageGroup);

        }

    }
}