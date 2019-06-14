using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionEstadio.Model
{
    [Table(name:"Equipo")]
    public class Equipo
    {

        public Equipo()
        {
            Partidos = new HashSet<Partido>();
        }

        public int EquipoId { get; set; }
        [Required(ErrorMessage ="El nombre del equipo es obligatorio")]
        public String nombreEquipo { get; set; }
        public int DeporteId { get; set; }

        //propiedad de navegacion con deporte
        public virtual Deporte Deporte { get; set; }
        public ICollection<Partido> Partidos { get; set; }
    }
}
