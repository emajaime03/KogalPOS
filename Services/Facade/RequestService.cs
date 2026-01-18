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
        }
        #endregion

        public ResBase GetResponse(ReqBase req)
        {
            ResBase res = new ResBase();

            try
            {
                switch (req)
                {
                    // Usuario - Login
                    case ReqUsuarioLogin reqLogin:
                        res = UsuarioBLL.Current.Login(reqLogin);
                        break;

                    // Usuario - CRUD
                    case ReqUsuariosObtener reqUsuariosObtener:
                        res = UsuarioBLL.Current.ObtenerLista(reqUsuariosObtener);
                        break;
                    case ReqUsuarioObtener reqUsuarioObtener:
                        res = UsuarioBLL.Current.Obtener(reqUsuarioObtener);
                        break;
                    case ReqUsuarioInsertar reqUsuarioInsertar:
                        res = UsuarioBLL.Current.Insertar(reqUsuarioInsertar);
                        break;
                    case ReqUsuarioModificar reqUsuarioModificar:
                        res = UsuarioBLL.Current.Modificar(reqUsuarioModificar);
                        break;
                    case ReqUsuarioEliminar reqUsuarioEliminar:
                        res = UsuarioBLL.Current.Eliminar(reqUsuarioEliminar);
                        break;
                    case ReqUsuarioRestaurar reqUsuarioRestaurar:
                        res = UsuarioBLL.Current.Restaurar(reqUsuarioRestaurar);
                        break;

                    // Patentes
                    case ReqPatentesObtener reqPatentesObtener:
                        res = PatentesBLL.Current.Obtener(reqPatentesObtener);
                        break;
                    case ReqPatentesSincronizar reqPatentesSincronizar:
                        res = PatentesBLL.Current.Sincronizar(reqPatentesSincronizar);
                        break;

                    // Familias
                    case ReqFamiliasObtener reqFamiliasObtener:
                        res = FamiliasBLL.Current.ObtenerLista(reqFamiliasObtener);
                        break;
                    case ReqFamiliaObtener reqFamiliaObtener:
                        res = FamiliasBLL.Current.Obtener(reqFamiliaObtener);
                        break;
                    case ReqFamiliaInsertar reqFamiliaInsertar:
                        res = FamiliasBLL.Current.Insertar(reqFamiliaInsertar);
                        break;
                    case ReqFamiliaModificar reqFamiliaModificar:
                        res = FamiliasBLL.Current.Modificar(reqFamiliaModificar);
                        break;
                    case ReqFamiliaEliminar reqFamiliaEliminar:
                        res = FamiliasBLL.Current.Eliminar(reqFamiliaEliminar);
                        break;
                    case ReqFamiliaRestaurar reqFamiliaRestaurar:
                        res = FamiliasBLL.Current.Restaurar(reqFamiliaRestaurar);
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
