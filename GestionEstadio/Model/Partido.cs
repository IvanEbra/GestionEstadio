using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionEstadio.Model
{
    [Table(name:"Partido")]
    public class Partido
    {
        public int PartidoId { get; set; }
        public int duracion { get; set; }
        [ForeignKey("Jornada")]
        public int JornadaId { get; set; }
        [ForeignKey("Pista")]
        public int PistaId { get; set; }

        //propiedad de navegacion con jornada
        public virtual Jornada Jornada { get; set; }
        //propiedad de navegacion con pista
        public virtual Pista Pista { get; set; }
        public virtual Equipo local { get; set; }
        public virtual Equipo visitante { get; set; }
    }
}
