using System.Data;
using Capa_Datos;
using Capa_Entidad;


namespace Capa_Negocio
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios();


        // CRUD
        #region Read
        public CE_Usuarios Consulta(int IdUsuario)
        {
            return objDatos.CD_Consulta(IdUsuario);
        }
        #endregion

        #region Create
        public string Insertar(CE_Usuarios Usuarios)
        {
            string msg = objDatos.CD_Insertar(Usuarios);
            return msg;
        }
        #endregion

        #region Delete
        public void Eliminar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Eliminar(Usuarios);
        }
        #endregion

        #region Update
        public void Actualizar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Actualizar(Usuarios);
        }
        #endregion

        //Vista Usuarios
        #region BuscarUsuarios
        public DataTable Buscar(string buscar)
        {
            return objDatos.Buscar(buscar);
        }
        #endregion
    }
}
