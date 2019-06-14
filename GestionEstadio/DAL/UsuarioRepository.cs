using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEstadio.Model;

namespace GestionEstadio.DAL
{
    public class UsuarioRepository:GenericRepository<Usuario>
    {
        public UsuarioRepository(GestionEstadioContext context) : base(context)
        {

        }
    }
}
