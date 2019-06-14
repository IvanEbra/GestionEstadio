using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestionEstadio.Model;
using GestionEstadio.DAL;

namespace GestionEstadio
{
    /// <summary>
    /// Lógica de interacción para PaginaUsuario.xaml
    /// </summary>
    public partial class PaginaUsuario : Page
    {

        Usuario usuario = new Usuario();
        UnitOfWork uow = new UnitOfWork();
        PropertyValidateModel validador = new PropertyValidateModel();
        List<String> tipoCuenta = new List<String> { "usuario", "admin" };

        bool eliminado = false;

        public PaginaUsuario(MainWindow principal)
        {
            InitializeComponent();
            cbTipoCuentaUsuario.ItemsSource = tipoCuenta;
            dgUsuarios.ItemsSource = uow.UsuarioRepository.GetAll();
            gridDatosUsuario.DataContext = usuario;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //buscamos se o textbox de busqueda esta vacio
            if(!String.IsNullOrEmpty(txtBuscar.Text) && !txtBuscar.Text.Equals("Buscar nombre"))
            {
                String nombreBusqueda = txtBuscar.Text.ToLower();
                usuario = uow.UsuarioRepository.Single(u => u.user.ToLower().Contains(txtBuscar.Text));

                if (usuario != null)
                {
                    //pomos os datos do usuario nos textbox
                    gridDatosUsuario.DataContext = usuario;
                    cbTipoCuentaUsuario.SelectedItem = usuario.tipoUsuario;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "ERROR");
                }
            }
        }

        private void TxtBuscar_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void TxtBuscar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar nombre";
            }
        }

        private void DgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (eliminado == false)
                {
                    usuario = dgUsuarios.SelectedItem as Usuario;
                    gridDatosUsuario.DataContext = usuario;
                    cbTipoCuentaUsuario.SelectedItem = usuario.tipoUsuario;
                }
                else
                    eliminado = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
          
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(uow.UsuarioRepository.Single(u=>u.user.Equals(usuario.user) && u.contraseña.Equals(usuario.contraseña) && u.tipoUsuario.Equals(usuario.tipoUsuario)) != null)
            {
                uow.UsuarioRepository.Delete(usuario);
                if (validador.errores(usuario) == "")
                {
                    eliminado = true;
                    MessageBox.Show("Usuario eliminado");
                }
                else
                {
                    MessageBox.Show(validador.errores(usuario), "ERROR");
                }
                dgUsuarios.ItemsSource = uow.UsuarioRepository.GetAll();
                dgUsuarios.Items.Refresh();
            }
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            String tipoUsuario = cbTipoCuentaUsuario.SelectedItem as String;
            Usuario usr = uow.UsuarioRepository.Single(u =>u.user.Equals(usuario.user) && u.contraseña.Equals(usuario.contraseña) && u.tipoUsuario.Equals(tipoUsuario));
            if (usr == null)
            {
                //engadimos o usuario
                usuario.tipoUsuario = tipoUsuario;
                uow.UsuarioRepository.Añadir(usuario);
                if (validador.errores(usuario) == "")
                    MessageBox.Show("Usuario añadido");
                else
                    MessageBox.Show(validador.errores(usuario), "ERROR");
                dgUsuarios.ItemsSource = uow.UsuarioRepository.GetAll();
                dgUsuarios.Items.Refresh();
            }
            else
            {
                MessageBox.Show("El usuario ya existe", "ERROR");
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (usuario != null)
            {
                String tipoUs = cbTipoCuentaUsuario.SelectedItem as String;
                if (!String.IsNullOrEmpty(tipoUs))
                {
                    usuario.tipoUsuario = tipoUs;
                    uow.UsuarioRepository.Update(usuario);
                    if (validador.errores(usuario) == "")
                    {
                        MessageBox.Show("Usuario actualizado");
                        dgUsuarios.Items.Refresh();
                    }
                    else
                    {

                        MessageBox.Show(validador.errores(usuario), "ERROR");
                    }
                }
                else
                {
                    MessageBox.Show("El tipo de usuario no puede estar vacio", "ERROR");
                }
            }
        }

    }
}
