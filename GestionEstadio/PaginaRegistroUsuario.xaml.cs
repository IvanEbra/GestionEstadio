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
    /// Lógica de interacción para PaginaRegistroUsuario.xaml
    /// </summary>
    public partial class PaginaRegistroUsuario : Page
    {

        MainWindow copiaPrincipal;
        UnitOfWork uow = new UnitOfWork();
        PropertyValidateModel validador = new PropertyValidateModel();

        public PaginaRegistroUsuario(MainWindow principal)
        {
            InitializeComponent();
            copiaPrincipal = principal;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            copiaPrincipal.framePaginas.Content = new PaginaInicioSesion(copiaPrincipal);
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtUsuario.Text) && !String.IsNullOrEmpty(txtContraseña.Text))
            {
                Usuario usr = new Usuario();
                usr = uow.UsuarioRepository.Single(u => u.user.Equals(txtUsuario.Text) && u.contraseña.Equals(txtContraseña.Text));
                //si non existe o usuario creamolo
                if (usr == null)
                {
                    Usuario usuario = new Usuario { user = txtUsuario.Text, contraseña = txtContraseña.Text, tipoUsuario = "usuario" };

                    if (validador.errores(usuario) == "")
                    {
                        uow.UsuarioRepository.Añadir(usuario);
                        MessageBox.Show("Usuario añadido");

                        //despois de engadilo con exito abrimos a ventana ca pagina por defecto
                        copiaPrincipal.menuJornada.IsEnabled = true;
                        copiaPrincipal.framePaginas.Content = new PaginaJornada(copiaPrincipal);
                       
                    }
                    else
                    {
                        MessageBox.Show(validador.errores(usuario));
                    }
                }
                //se existe mensaxe de usuario exostente
                else
                {
                    MessageBox.Show("El usuario ya existe", "ERROR");
                }
            }
            else
            {
                MessageBox.Show("Debe rellenar todos los campos", "ERROR");
            }
        }
    }
}
