using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEstadio.Model
{
    public class Deporte
    {

        public Deporte()
        {
            equipos = new HashSet<Equipo>();
        }
        public int DeporteId { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre del deporte")]
        public String nombreDeporte { get; set; }
        [Required(ErrorMessage = "Introduzca la duración de los partidos en minutos")]
        public int duracionPartidos { get; set; }

        //propiedad de navegacion con equipo
        public virtual ICollection<Equipo> equipos { get; set; }
    }
}
