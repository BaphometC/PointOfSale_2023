using System.Collections.Generic;
using System.Data;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Roles
    {
        CD_Roles CD_Roles = new CD_Roles();

        #region IdRol
        public int IdRol(string NombreRol)
        {
            return CD_Roles.IdRol(NombreRol);
        }
        #endregion

        #region NombreRol
        public CE_Roles NombreRol(int IdRol)
        {
            return CD_Roles.NombreRol(IdRol);
        // Esto sirve para identificar el id rol
        }
        #endregion

        #region ListaRoles
        public List<string> ListarRoles()
        {
            return CD_Roles.ObtenerRoles();
        }
        #endregion
    }
}
