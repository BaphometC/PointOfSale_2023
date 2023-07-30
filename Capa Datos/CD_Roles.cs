using System.Data;
using MySqlConnector;
using Capa_Entidad;
using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public class CD_Roles
    {
        readonly CD_Connection con = new CD_Connection();
        readonly CE_Roles ce = new CE_Roles();

        #region IdRol
        public int IdRol(string Nombre_rol)
        {
            MySqlCommand com = new MySqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "ObtenerIDRol",
                CommandType = CommandType.StoredProcedure,
            };
            com.Parameters.AddWithValue("nom_rol", Nombre_rol);
            object valor = com.ExecuteScalar();
            int idrol = (int)valor;
            con.CerrarConexion();
            return idrol;
        }
        #endregion

        #region Nombre_Rol
        public CE_Roles NombreRol(int IdRol)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("ObtenerNomRol",con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("id_rol_r",MySqlDbType.Int32).Value=IdRol;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Nombre_rol = Convert.ToString(row[0]);
            return ce;
        }
        #endregion

        #region ListarRoles
        public List<string> ObtenerRoles()
        {
            MySqlCommand com = new MySqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "cargarRol",
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataReader reader = com.ExecuteReader();
            List<string> lista = new List<string>();
            while (reader.Read())
            {
                lista.Add(Convert.ToString(reader["nombre_rol"]));
            }
            con.CerrarConexion();

            return lista;
        }
        #endregion
    }
}
