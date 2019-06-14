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
    /// Lógica de interacción para PaginaEquipo.xaml
    /// </summary>
    public partial class PaginaEquipo : Page
    {

        UnitOfWork uow = new UnitOfWork();
        Equipo equipo = new Equipo();
        PropertyValidateModel validador = new PropertyValidateModel();
        bool eliminado = false;

        public PaginaEquipo(MainWindow principal)
        {
            InitializeComponent();
            EquiposCombo();
            gridDatosEquipo.DataContext = equipo;
            dgEquipo.ItemsSource = uow.EquipoRepository.GetAll();
        }

        private void EquiposCombo()
        {
            List<Deporte> listaDeportes = uow.DeporteRepository.GetAll();
            List<String> listaNombreDeportes = new List<String>();

            for (int i = 0; i < listaDeportes.Count; i++)
            {
                listaNombreDeportes.Add(listaDeportes[i].nombreDeporte);
            }

            cbDeportes.ItemsSource = listaNombreDeportes;
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
            if(!String.IsNullOrEmpty(txtBuscar.Text) && !txtBuscar.Text.Equals("Buscar nombre"))
            {
                String nombreBusqueda = txtBuscar.Text.ToLower();
                equipo = uow.EquipoRepository.Single(eq => eq.nombreEquipo.ToLower().Contains(nombreBusqueda));

                if (equipo != null)
                {
                    txtNombreEquipo.Text = equipo.nombreEquipo;
                    String deporteEquipo = uow.DeporteRepository.Single(d => d.DeporteId == equipo.DeporteId).nombreDeporte;
                    cbDeportes.SelectedItem = deporteEquipo;
                }
                else
                {
                    MessageBox.Show("Equipo no encontrado", "ERROR");
                }
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (equipo != null && cbDeportes.SelectedItem!=null)
            {
                String nombreDeporte = cbDeportes.SelectedItem.ToString();
                equipo.DeporteId = uow.DeporteRepository.Single(d => d.nombreDeporte.Equals(nombreDeporte)).DeporteId;
                uow.EquipoRepository.Update(equipo);
                if (validador.errores(equipo) == "")
                {
                    MessageBox.Show("Equipo actualizado");
                    dgEquipo.Items.Refresh();
                }
                else
                {
                    MessageBox.Show(validador.errores(equipo), "ERROR");
                }
            }
        }

        private void DgEquipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (eliminado == false)
                {
                    equipo = dgEquipo.SelectedItem as Equipo;
                    cbDeportes.SelectedItem = equipo.Deporte.nombreDeporte;
                    gridDatosEquipo.DataContext = equipo;
                }
                else
                {
                    eliminado = false;
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
                if (uow.EquipoRepository.Single(eq => eq.nombreEquipo.Equals(equipo.nombreEquipo) && eq.DeporteId == equipo.DeporteId) != null)
                {
                    List<Partido> listaPartidos = uow.PartidoRepository.GetAll();
                    foreach (Partido part in listaPartidos)
                    {
                        if(part.local==equipo || part.visitante == equipo)
                        {
                            //se pomos a pista dese partido como ocupada=false deberia ir 
                            uow.PartidoRepository.Delete(part);
                        }
                    }
                    uow.EquipoRepository.Delete(equipo);
                    if (validador.errores(equipo) == "")
                    {
                        eliminado = true;
                        MessageBox.Show("Equipo eliminado");
                    }
                    else
                    {
                        MessageBox.Show(validador.errores(equipo), "ERROR");
                    }
                    dgEquipo.ItemsSource = uow.EquipoRepository.GetAll();
                    dgEquipo.Items.Refresh();
                }

           
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            String nombreSeleccionado = "";
            Equipo equi=new Equipo();

            nombreSeleccionado = nombreSeleccionado = cbDeportes.SelectedItem as String;

            if (!String.IsNullOrEmpty(nombreSeleccionado))
            {
                equi = uow.EquipoRepository.Single(eq => eq.nombreEquipo.Equals(equipo.nombreEquipo) && eq.DeporteId == equipo.DeporteId);
            }
                

            if (equi == null)
            {
                nombreSeleccionado = cbDeportes.SelectedItem.ToString();
                equipo.DeporteId = uow.DeporteRepository.Single(d => d.nombreDeporte.Equals(nombreSeleccionado)).DeporteId;
                equipo.Deporte = uow.DeporteRepository.Single(d => d.DeporteId == equipo.DeporteId); 
                uow.EquipoRepository.Añadir(equipo);
                if(validador.errores(equipo) == "")
                {
                    MessageBox.Show("Equipo añadido");
                }
                else
                {
                    MessageBox.Show(validador.errores(equipo), "ERROR");
                }

                dgEquipo.ItemsSource = uow.EquipoRepository.GetAll();
                dgEquipo.Items.Refresh();
            }
            else
            {
                MessageBox.Show("El equipo ya existe", "ERROR");
            }
        }
    }
}
