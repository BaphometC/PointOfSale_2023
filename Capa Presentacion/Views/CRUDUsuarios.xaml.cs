using MySqlConnector;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using Capa_Entidad;
using Capa_Negocio;
using System.Collections.Generic;
using System.Windows.Interop;

namespace PRO2_PDV_2023.Views
{

    public partial class CRUDUsuarios : Page
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        readonly CE_Usuarios objeto_CE_Usuarios = new CE_Usuarios();
        readonly CN_Roles objeto_CN_Roles = new CN_Roles();

        #region Inicial
        public CRUDUsuarios()
        {
            InitializeComponent();
            CargarCB();
        }
        #endregion
        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        #endregion
        #region CargarRoles
        void CargarCB()
        {
            List<string> roles = objeto_CN_Roles.ListarRoles();
            for (int i = 0; i < roles.Count; i++)
            {
                tbIDRol.Items.Add(roles[i]);
            }
        }
        #endregion
        #region ValidaCamposVacios
        public bool CamposLlenos()
        {
            if (tbNombre.Text == "" || tbApellido.Text == "" || tbDni.Text == "" || tbCorreo.Text == "" || tbIDRol.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region CRUD(Create, Read, Update, Delete)
        public int IdUsuario;
        #region Create
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                int rol = objeto_CN_Roles.IdRol(tbIDRol.Text);
                objeto_CE_Usuarios.Nombre = tbNombre.Text;
                objeto_CE_Usuarios.Apellido = tbApellido.Text;
                objeto_CE_Usuarios.Dni = tbDni.Text;
                objeto_CE_Usuarios.Correo = tbCorreo.Text;
                objeto_CE_Usuarios.Id_rol = rol;

                string msg = objeto_CN_Usuarios.Insertar(objeto_CE_Usuarios);

                Content = new Usuarios();
                if (msg == "El correo electrónico del usuario NO cumple con el formato requerido.")
                {
                    MessageBox.Show(msg, "Formato Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (msg == "Usuario registrado")
                {
                    MessageBox.Show(msg, "Registro Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(msg, "Error Inesperado", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Campos Vacios!","Empty", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

            #endregion
            #region Read
            public void Consultar()
            {
                var a = objeto_CN_Usuarios.Consulta(IdUsuario);
                tbNombre.Text = a.Nombre.ToString();
                tbApellido.Text = a.Apellido.ToString();
                tbDni.Text = a.Dni.ToString();
                tbCorreo.Text = a.Correo.ToString();
                //pendiente
                var b = objeto_CN_Roles.NombreRol(a.Id_rol);
                tbIDRol.Text = b.Nombre_rol;
            }
            #endregion
            #region Update
            private void Actualizar(object sender, RoutedEventArgs e)
            {
                if (CamposLlenos() == true)
                {
                    int rol = objeto_CN_Roles.IdRol(tbIDRol.Text);
                    objeto_CE_Usuarios.Id_user = IdUsuario;
                    objeto_CE_Usuarios.Nombre = tbNombre.Text;
                    objeto_CE_Usuarios.Apellido = tbApellido.Text;
                    objeto_CE_Usuarios.Dni = tbDni.Text;
                    objeto_CE_Usuarios.Correo = tbCorreo.Text;
                    objeto_CE_Usuarios.Id_rol = rol;

                    objeto_CN_Usuarios.Actualizar(objeto_CE_Usuarios);
                    Content = new Usuarios();
                }
                else
                {
                    MessageBox.Show("Algunos campos estan vacios");
                }
            }
            #endregion
            #region Delete
            private void Eliminar(object sender, RoutedEventArgs e)
            {
                objeto_CE_Usuarios.Id_user = IdUsuario;
                objeto_CN_Usuarios.Eliminar(objeto_CE_Usuarios);
                Content = new Usuarios();
            }
            #endregion
            #endregion
        }
    }