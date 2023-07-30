using System;
using MySqlConnector;
using System.Data;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Usuarios
    {
        private readonly CD_Connection con = new CD_Connection();
        private readonly CE_Usuarios ce = new CE_Usuarios();

        //CRUD Usuarios
        #region Create
        public string CD_Insertar(CE_Usuarios Usuarios)
        {
            string msg = "";
            try
            {
                MySqlCommand com = new MySqlCommand()
                {
                    Connection = con.AbrirConexion(),
                    CommandText = "insertar_usuario",
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.AddWithValue("nombre_user", Usuarios.Nombre);
                com.Parameters.AddWithValue("apellido_user", Usuarios.Apellido);
                com.Parameters.AddWithValue("dni_user", Usuarios.Dni);
                com.Parameters.AddWithValue("correo_user", Usuarios.Correo);
                com.Parameters.AddWithValue("id_rol_user", Usuarios.Id_rol);
                int i = com.ExecuteNonQuery();
                if (i==1) {
                    msg = "Usuario registrado";
                    return msg;
                }
                com.Parameters.Clear();
                con.CerrarConexion();
                return msg;
            }
            catch(MySqlException x)
            {
                if (x.Number==1644)
                {
                    msg = (x.Message);
                    //Funciona epecificamente para la excepcion del correo
                }
            }
            catch(Exception e)
            {
                msg = (e.Message);   
            }
            return msg;
        }
        #endregion

        #region Read
        public CE_Usuarios CD_Consulta(int IdUsuario)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("read_usuario", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("id_user_u", MySqlDbType.Int16).Value = IdUsuario;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Nombre = Convert.ToString(row[1]);
            ce.Apellido = Convert.ToString(row[2]);
            ce.Dni = Convert.ToString(row[3]);
            ce.Correo = Convert.ToString(row[4]);
            ce.Id_rol = Convert.ToInt16(row[5]);
            return ce;
        }
        #endregion

        #region Delete
        public void CD_Eliminar(CE_Usuarios Usuarios)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = con.AbrirConexion();
            com.CommandText = "delete_usuario";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id_user_u", Usuarios.Id_user);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region Update
        public void CD_Actualizar(CE_Usuarios Usuarios)
        {
            MySqlCommand com = new MySqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "update_usuario",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("id_user_u", Usuarios.Id_user);
            com.Parameters.AddWithValue("nombre_user", Usuarios.Nombre);
            com.Parameters.AddWithValue("apellido_user", Usuarios.Apellido);
            com.Parameters.AddWithValue("dni_user", Usuarios.Dni);
            com.Parameters.AddWithValue("correo_user", Usuarios.Correo);
            com.Parameters.AddWithValue("id_rol_user", Usuarios.Id_rol);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region BuscarUsuarios
        public DataTable Buscar(string buscar)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("find_user", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("buscar",MySqlDbType.VarChar).Value=buscar;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.CerrarConexion();

            return dt;
        }
        #endregion
    }
}
