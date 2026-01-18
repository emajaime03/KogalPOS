using Services.Domain.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BLL
{
    #region "LOGIN"
    public class ReqUsuarioLogin : ReqBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ResUsuarioLogin : ResBase
    {
        public Usuario Usuario { get; set; }
    }
    #endregion

    #region "OBTENER LISTA"
    public class ReqUsuariosObtener : ReqBase
    {
    }

    public class ResUsuariosObtener : ResBase
    {
        public List<Usuario> Usuarios { get; set; }
    }
    #endregion

    #region "OBTENER DETALLE"
    public class ReqUsuarioObtener : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResUsuarioObtener : ResBase
    {
        public Usuario Usuario { get; set; }
        public List<Familia> ListaFamilias { get; set; }
        public List<Patente> ListaPatentes { get; set; }
    }
    #endregion

    #region "INSERTAR"
    public class ReqUsuarioInsertar : ReqBase
    {
        public Usuario Usuario { get; set; }
        public List<Guid> FamiliasIds { get; set; }
        public List<Guid> PatentesIds { get; set; }
    }

    public class ResUsuarioInsertar : ResBase
    {
        public Usuario Usuario { get; set; }
    }
    #endregion

    #region "MODIFICAR"
    public class ReqUsuarioModificar : ReqBase
    {
        public Usuario Usuario { get; set; }
        public List<Guid> FamiliasIds { get; set; }
        public List<Guid> PatentesIds { get; set; }
    }

    public class ResUsuarioModificar : ResBase
    {
        public Usuario Usuario { get; set; }
    }
    #endregion

    #region "ELIMINAR"
    public class ReqUsuarioEliminar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResUsuarioEliminar : ResBase
    {
    }
    #endregion

    #region "RESTAURAR"
    public class ReqUsuarioRestaurar : ReqBase
    {
        public Guid Id { get; set; }
    }

    public class ResUsuarioRestaurar : ResBase
    {
    }
    #endregion
}
