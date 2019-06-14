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
    /// Lógica de interacción para PaginaJornada.xaml
    /// </summary>
    public partial class PaginaJornada : Page
    {

        Jornada jornada;
        UnitOfWork uow = new UnitOfWork();
        HashSet<int> posicionEquipo = new HashSet<int>();
        Random random = new Random();


        public PaginaJornada(MainWindow principal)
        {
            InitializeComponent();
            dgJornada.ItemsSource = uow.JornadaRepository.GetAll();
            dgJornada.Items.Refresh();
            dgPartidos.Items.Refresh();
        }

        private void BtnCrearJornada_Click(object sender, RoutedEventArgs e)
        {
            jornada = new Jornada();

            jornada.Partidos=CrearPartidos();

            if (jornada.Partidos != null)
            {
                uow.JornadaRepository.Añadir(jornada);
            }

            dgJornada.ItemsSource = uow.JornadaRepository.GetAll();
            dgJornada.Items.Refresh();
            dgPartidos.ItemsSource = jornada.Partidos;
            dgPartidos.Items.Refresh();
        }

        private List<Partido> CrearPartidos()
        {
            posicionEquipo.Clear();
            List<Partido> listaPartidos = new List<Partido>();
            int contador = 0;

            foreach (Pista pis in uow.PistaRepository.GetAll())
            {
                if (pis.ocupada == true)
                {
                    contador++;
                }
            }

            if(uow.EquipoRepository.GetAll().Count % 2 == 0 && uow.EquipoRepository.GetAll().Count > 0)
            {
                for (int i = 0; i < uow.EquipoRepository.GetAll().Count / 2; i++)
                {
                    Partido partido = new Partido();
                    //asignarlle unha pista ao partido
                    foreach (Pista pis in uow.PistaRepository.GetAll())//se hai varios estadios teriamos que saber en que estadio estamos facendo a xornada, neste caso solo hai un
                    {
                        if (contador == uow.PistaRepository.GetAll().Count)
                        {
                            foreach (Pista pista in uow.PistaRepository.GetAll())
                            {
                                pista.ocupada = false;
                            }
                        }
                        if (pis.ocupada == false)
                        {
                            partido.Pista = pis;
                            partido.PistaId = pis.PistaId;
                            pis.ocupada = true;
                            break;
                        }
                        else
                        {
                            contador++;
                        }
                    }

                    while (partido.visitante == null)
                    {
                        int pos = random.Next(0, uow.EquipoRepository.GetAll().Count);

                        if (!posicionEquipo.Contains(pos))//se a posicion dese equipo inda non saiu
                        {
                            if (partido.local == null)
                            {
                                partido.local = uow.EquipoRepository.Get().ElementAt(pos);
                                posicionEquipo.Add(pos);
                            }
                            else
                            {
                                partido.visitante = uow.EquipoRepository.Get().ElementAt(pos);
                                posicionEquipo.Add(pos);
                            }
                        }
                    }
                    partido.JornadaId = jornada.JornadaId;
                    partido.Jornada = jornada;
                    partido.duracion = 40;//demomento solo hai un deporte pero despois seria dependente das xorndas de cada deporte
                    listaPartidos.Add(partido);
                }
            }
            else
            {
                MessageBox.Show("Debe haber un número par de equipos");
                return null;
            }
            

            return listaPartidos;
        }

        private void DgJornada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jornada = dgJornada.SelectedItem as Jornada;
            dgPartidos.ItemsSource = jornada.Partidos;
            dgPartidos.Items.Refresh();
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
    }
}
