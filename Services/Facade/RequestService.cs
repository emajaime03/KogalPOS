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

namespace Services.Facade
{
    
    public class RequestService
    {
#region "Singleton"
        private readonly static RequestService _instance = new RequestService();

        public static RequestService Current
        {
            get
            {
                return _instance;
            }
        }

        private RequestService()
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
                        res = FamiliasBLL.Current.ObtenerLista((ReqFamiliasObtener)req);
                        break;
                    case ReqFamiliaObtener reqFamiliaObtener:
                        res = FamiliasBLL.Current.Obtener((ReqFamiliaObtener)req);
                        break;
                    case ReqPatentesSincronizar reqPatentesObtener:
                        res = PatentesBLL.Current.Sincronizar((ReqPatentesSincronizar)req);
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
