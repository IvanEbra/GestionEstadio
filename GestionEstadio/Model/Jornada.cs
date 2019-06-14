using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionEstadio.Model
{
    [Table(name:"Jornada")]
    public class Jornada
    {

        public Jornada()
        {
            Partidos = new HashSet<Partido>();
        }

        public int JornadaId { get; set; }

        //propiedad de navegacion con partido
        public virtual ICollection<Partido> Partidos { get; set; }
    }
}
