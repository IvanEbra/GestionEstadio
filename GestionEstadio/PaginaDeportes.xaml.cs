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
    /// Lógica de interacción para PaginaDeportes.xaml
    /// </summary>
    public partial class PaginaDeportes : Page
    {

        Deporte deporte = new Deporte();
        UnitOfWork uow = new UnitOfWork();
        PropertyValidateModel validador = new PropertyValidateModel();
        bool eliminado = false;

        public PaginaDeportes(MainWindow principal)
        {
            InitializeComponent();
            gridDatosDeporte.DataContext = deporte;
            dgDeportes.ItemsSource = uow.DeporteRepository.GetAll();
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

        private void TxtNombreDeporte_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNombreDeporte.Text = "";
        }

        private void TxtNombreDeporte_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreDeporte.Text))
            {
                txtNombreDeporte.Text = "Nombre deporte";
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscar.Text) && !txtBuscar.Text.Equals("Buscar nombre"))
            {
                String nombreBusqueda = txtBuscar.Text.ToLower();
                deporte = uow.DeporteRepository.Single(d => d.nombreDeporte.ToLower().Contains(nombreBusqueda));

                if (deporte != null)
                {
                    //pomos os datos do usuario nos textbox
                    gridDatosDeporte.DataContext = deporte;
                }
                else
                {
                    MessageBox.Show("Deporte no encontrado", "ERROR");
                }
            }
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            Deporte depor = uow.DeporteRepository.Single(d => d.nombreDeporte.Equals(deporte.nombreDeporte) && d.duracionPartidos == deporte.duracionPartidos);
            if (depor == null)
            {
                //engadimos o deporte
                uow.DeporteRepository.Añadir(deporte);
                if (validador.errores(deporte) == "")
                    MessageBox.Show("Deporte añadido");
                else
                    MessageBox.Show(validador.errores(deporte), "ERROR");

                dgDeportes.ItemsSource = uow.DeporteRepository.GetAll();
                dgDeportes.Items.Refresh();
            }
            else
            {
                MessageBox.Show("El deporte ya existe", "ERROR");
            }
        }

        private void DgDeportes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (eliminado == false)
            {
                deporte = dgDeportes.SelectedItem as Deporte;
                gridDatosDeporte.DataContext = deporte;
            }
            else
                eliminado = false;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int duracion = Convert.ToInt32(txtDuracionPartidos.Text);

            if (uow.DeporteRepository.Single(d => d.nombreDeporte.Equals(deporte.nombreDeporte) && d.duracionPartidos==duracion) != null)
            {
                uow.DeporteRepository.Delete(deporte);
                if (validador.errores(deporte) == "")
                {
                    eliminado = true;
                    MessageBox.Show("Deporte eliminado");
                }
                else
                {
                    MessageBox.Show(validador.errores(deporte), "ERROR");
                }
                dgDeportes.ItemsSource = uow.DeporteRepository.GetAll();
                dgDeportes.Items.Refresh();
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (deporte != null)
            {
                uow.DeporteRepository.Update(deporte);
                if (validador.errores(deporte) == "")
                {
                    MessageBox.Show("Deporte actualizado");
                    dgDeportes.Items.Refresh();
                }
                else
                {

                    MessageBox.Show(validador.errores(deporte), "ERROR");
                }
            }
        }
    }
}
