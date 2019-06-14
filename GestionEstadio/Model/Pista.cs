using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEstadio.Model
{
    [Table(name:"Pista")]
    public class Pista
    {

        public Pista()
        {
            Partidos = new HashSet<Partido>();
        }
        public int PistaId { get; set; }
        public bool ocupada { get; set; }
        [ForeignKey("Estadio")]//como é derivada esta é forenea e clave
        public int EstadioId { get; set; }

        //propiedad de navegacion con estadio
        public virtual Estadio Estadio { get; set; }
        //propiedad de navegacion con partido
        public virtual ICollection<Partido> Partidos { get; set; }
    }
}
