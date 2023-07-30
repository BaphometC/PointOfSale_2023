using MySqlConnector;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Capa_Negocio;

namespace PRO2_PDV_2023.Views
{
    /// <summary>
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();

        #region Inicial
        public Usuarios()
        {
            InitializeComponent();
            Buscar("");
        }
        #endregion


        #region Agregar
        private void Agregar(object sender, RoutedEventArgs e)
        {
            CRUDUsuarios ventana = new CRUDUsuarios();
            FrameUsuarios.Content = ventana;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region Consultar
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            ventana.Titulo.Text = "Consulta de Usuario";
            ventana.tbNombre.IsEnabled= false;
            ventana.tbApellido.IsEnabled= false;
            ventana.tbDni.IsEnabled= false;
            ventana.tbCorreo.IsEnabled= false;
            ventana.tbIDRol.IsEnabled= false;
        }
        #endregion

        #region Actualizar
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            ventana.Titulo.Text = "Actualizar Usuario";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbApellido.IsEnabled = true;
            ventana.tbDni.IsEnabled = true;
            ventana.tbCorreo.IsEnabled = true;
            ventana.tbIDRol.IsEnabled = true;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            ventana.Titulo.Text = "Eliminar Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbDni.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbIDRol.IsEnabled = false;
            ventana.BtnEliminar.Visibility = Visibility.Visible;
        }
        #endregion

        #region Buscando
        public void Buscar(string buscar)
        {
            GridDatos.ItemsSource = objeto_CN_Usuarios.Buscar(buscar).DefaultView;
        }
        private void Buscando(object sender, TextChangedEventArgs e)
        {
            Buscar(txtBuscar.Text);
        }
        #endregion

        #region Sin_usar
        private void FrameUsuarios_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        #endregion
    }
}
