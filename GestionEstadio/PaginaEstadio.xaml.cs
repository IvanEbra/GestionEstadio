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
    /// Lógica de interacción para PaginaEstadio.xaml
    /// </summary>
    public partial class PaginaEstadio : Page
    {

        UnitOfWork uow = new UnitOfWork();
        Estadio estadio = new Estadio();
        PropertyValidateModel validador = new PropertyValidateModel();
        bool eliminado = false;

        public PaginaEstadio(MainWindow principal)
        {
            InitializeComponent();
            PistasCombo();
            gridDatosEstadio.DataContext = estadio;
            dgEstadios.ItemsSource = uow.EstadioRepository.GetAll();
        }

        private void PistasCombo()
        {
            List<String> listaNumeroPistas = new List<String> { "1", "2", "3", "4", "5" };
            cbNumeroPistas.ItemsSource = listaNumeroPistas;
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

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscar.Text) && !txtBuscar.Text.Equals("Buscar nombre"))
            {
                String nombreBusqueda = txtBuscar.Text.ToLower();
                estadio = uow.EstadioRepository.Single(es => es.nombreEstadio.ToLower().Contains(txtBuscar.Text));

                if (estadio != null)
                {
                    //pomos os datos do usuario nos textbox
                    gridDatosEstadio.DataContext = estadio;
                    cbNumeroPistas.SelectedItem = "" + estadio.numeroPistas;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "ERROR");
                }
            }
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            int numeroPistas = Convert.ToInt32(cbNumeroPistas.SelectedItem as String);
            estadio.numeroPistas = numeroPistas;

            Estadio est = uow.EstadioRepository.Single(es => es.nombreEstadio.Equals(estadio.nombreEstadio) && es.direccion.Equals(estadio.direccion) && es.numeroPistas == estadio.numeroPistas);

            if (est == null && estadio.numeroPistas>0)
            {
                for (int i = 0; i < estadio.numeroPistas; i++)
                {
                    Pista pista = new Pista();
                    pista.EstadioId = estadio.EstadioId;
                    pista.ocupada = false;
                    estadio.Pistas.Add(pista);
                }
                uow.EstadioRepository.Añadir(estadio);
                if (validador.errores(estadio) == "")
                {
                    MessageBox.Show("Estadio añadido");
                }
                else
                {
                    MessageBox.Show(validador.errores(estadio), "ERROR");
                }

                dgEstadios.ItemsSource = uow.EstadioRepository.GetAll();
                dgEstadios.Items.Refresh();
            }
            else
            {
                MessageBox.Show("El estadio ya existe", "ERROR");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(uow.EstadioRepository.Single(es=>es.nombreEstadio.Equals(estadio.nombreEstadio) && es.direccion.Equals(estadio.direccion) && es.numeroPistas == estadio.numeroPistas) != null)
            {
                uow.EstadioRepository.Delete(estadio);
                if (validador.errores(estadio) == "")
                {
                    eliminado = true;
                    MessageBox.Show("Estadio eliminado");
                }
                else
                {
                    MessageBox.Show(validador.errores(estadio), "ERROR");
                }
                dgEstadios.ItemsSource = uow.EstadioRepository.GetAll();
                dgEstadios.Items.Refresh();
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (estadio != null)
            {
                if (cbNumeroPistas.SelectedItem != null)
                {
                    estadio.numeroPistas = Convert.ToInt32(cbNumeroPistas.SelectedItem);
                    uow.EstadioRepository.Update(estadio);
                }
                else
                {
                    uow.EstadioRepository.Update(estadio);
                    if (validador.errores(estadio) == "")
                    {
                        MessageBox.Show("Estadio actualizado");
                        dgEstadios.Items.Refresh();
                    }
                    else
                    {

                        MessageBox.Show(validador.errores(estadio), "ERROR");
                    }
                }
                
            }
        }

        private void DgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(eliminado==false)
            {
                estadio = dgEstadios.SelectedItem as Estadio;
                gridDatosEstadio.DataContext = estadio;
                cbNumeroPistas.SelectedItem = estadio.numeroPistas;
            }
            else
            {
                eliminado = false;
            }
            
        }
    }
}
