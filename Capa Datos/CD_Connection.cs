using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Connection
    {
        private readonly MySqlConnection con = new MySqlConnection("SERVER=localhost;port=3308;UID=root;pwd=kutasic;DATABASE=sistemaventa_bd;sslmode=none;");

        public MySqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
                return con;
        }

        public MySqlConnection CerrarConexion()
        {
            if(con.State == ConnectionState.Open)
                con.Close();
                return con;
        }

    }
}
