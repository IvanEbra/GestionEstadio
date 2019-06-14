using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEstadio.Model
{
    [Table(name:"Estadio")]
    public class Estadio
    {
        public Estadio()
        {
            Pistas = new HashSet<Pista>();
        }
        public int EstadioId { get; set; }
        [Required(ErrorMessage = "Introduzca un nombre de estadio")]
        public String nombreEstadio { get; set; }
        [Required(ErrorMessage = "Introduzca una dirección")]
        public String direccion { get; set; }
        [Required(ErrorMessage = "Introduzca el número de pistas")]
        public int numeroPistas { get; set; }//derivado de cantar as pistas que teñan o id do estadio

        //propiedades navegacion con pista
        public virtual ICollection<Pista> Pistas { get; set; }
    }
}
