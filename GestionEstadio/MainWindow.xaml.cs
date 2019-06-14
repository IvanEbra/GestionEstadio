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

namespace GestionEstadio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       

        public MainWindow()
        {
            InitializeComponent();
            
            CargarPaginaInicioSesion();
        }

        private void CargarPaginaInicioSesion()
        {
            PaginaInicioSesion paginaInicioSesion = new PaginaInicioSesion(this);
            framePaginas.Content = paginaInicioSesion;
        }

        private void menuUsuario_Click(object sender, RoutedEventArgs e)
        {
            framePaginas.Content = new PaginaUsuario(this);
        }

        private void menuDeporte_Click_1(object sender, RoutedEventArgs e)
        {
            framePaginas.Content = new PaginaDeportes(this);
        }

        private void menuEquipo_Click_2(object sender, RoutedEventArgs e)
        {
            framePaginas.Content = new PaginaEquipo(this);
        }

        private void menuEstadio_Click_3(object sender, RoutedEventArgs e)
        {
            framePaginas.Content = new PaginaEstadio(this);
        }

        private void menuJornada_Click_4(object sender, RoutedEventArgs e)
        {
            framePaginas.Content = new PaginaJornada(this);
        }

        private void menuInicio_Click_5(object sender, RoutedEventArgs e)
        {
            framePaginas.Content = new PaginaInicioSesion(this);
            this.menuUsuario.IsEnabled = false;
            this.menuDeporte.IsEnabled = false;
            this.menuEquipo.IsEnabled = false;
            this.menuEstadio.IsEnabled = false;
            this.menuJornada.IsEnabled = false;
        }

        private void MenuAyuda_Click(object sender, RoutedEventArgs e)
        {
            VentanaAyuda ventana = new VentanaAyuda();
            ventana.Show();
        }
    }
}
