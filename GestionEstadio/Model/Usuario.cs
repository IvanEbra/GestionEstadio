using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEstadio.Model
{
    [Table(name:"Usuario")]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage ="Debe introducir un nombre de usuario")]
        public String user { get; set; }
        [Required(ErrorMessage = "Debe introducir una contraseña")]
        public String contraseña { get; set; }
        [Required,RegularExpression("usuario|admin", ErrorMessage = "El tipo de cuenta debe ser usuario o admin")]
        public String tipoUsuario { get; set; }
    }
}
