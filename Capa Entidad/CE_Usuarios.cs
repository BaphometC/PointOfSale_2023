using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Usuarios
    {
        private int _id_user;
        private string _nombre;
        private string _apellido;
        private string _dni;
        private string _correo;
        private int _id_rol;

        public int Id_user { get => _id_user; set => _id_user = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int Id_rol { get => _id_rol; set => _id_rol = value; }
    }
}
