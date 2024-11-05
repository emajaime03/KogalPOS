using Services.BLL.Services;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.BLL.Base;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{
    
    public class RequestBLL
    {
#region "Singleton"
        private readonly static RequestBLL _instance = new RequestBLL();

        public static RequestBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private RequestBLL()
        {
            //Implent here the initialization of your singleton
        }
#endregion

        public ResBase GetResponse(ReqBase req)
        {
            ResBase res = new ResBase();

            try
            {
                switch (req)
                {
                    case ReqUsuarioLogin reqLogin:
                        res = UsuarioBLL.Current.Login((ReqUsuarioLogin)req);
                        break;
                    case ReqPatentesObtener reqPatentesObtener:
                        res = PatentesBLL.Current.Obtener((ReqPatentesObtener)req);
                        break;
                    case ReqFamiliasObtener reqFamiliasObtener:
                        res = FamiliasBLL.Current.Obtener((ReqFamiliasObtener)req);
                        break;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = "Ha ocurrido un error";
                ex.Handle(this);
            }

            return res;
        }
             

    }
}
