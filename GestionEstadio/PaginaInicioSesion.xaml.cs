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
using GestionEstadio.DAL;
using GestionEstadio.Model;

namespace GestionEstadio
{
    /// <summary>
    /// Lógica de interacción para PaginaInicioSesion.xaml
    /// </summary>
    public partial class PaginaInicioSesion : Page
    {

        MainWindow copiaPrincipal;
        UnitOfWork uow = new UnitOfWork();
        

        public PaginaInicioSesion(MainWindow principal)
        {
            InitializeComponent();
            copiaPrincipal = principal;
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            usr = uow.UsuarioRepository.Single(u => u.user.Equals(txtUsuario.Text) && u.contraseña.Equals(pbContraseña.Password));
            if (usr != null)
            {
                if (usr.tipoUsuario.Equals("admin"))
                {
                    copiaPrincipal.menuUsuario.IsEnabled = true;
                    copiaPrincipal.menuDeporte.IsEnabled = true;
                    copiaPrincipal.menuEquipo.IsEnabled = true;
                    copiaPrincipal.menuEstadio.IsEnabled = true;
                    copiaPrincipal.menuJornada.IsEnabled = true;
                    copiaPrincipal.framePaginas.Content = new PaginaUsuario(copiaPrincipal);
                }
                else
                {
                    copiaPrincipal.menuUsuario.IsEnabled = false;
                    copiaPrincipal.menuDeporte.IsEnabled = false;
                    copiaPrincipal.menuEquipo.IsEnabled = false;
                    copiaPrincipal.menuEstadio.IsEnabled = false;
                    copiaPrincipal.menuJornada.IsEnabled = true;
                    copiaPrincipal.framePaginas.Content = new PaginaJornada(copiaPrincipal);
                }
                //entramos
                
                
            }
            else if(String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(pbContraseña.Password))
            {
                MessageBox.Show("Rellene todos los campos","ERROR");
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "ERROR");
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            //cargar pagina registro
            copiaPrincipal.framePaginas.Content = new PaginaRegistroUsuario(copiaPrincipal);
        }
    }
}
