using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEstadio.Model;

namespace GestionEstadio.DAL
{
    public class JornadaRepository:GenericRepository<Jornada>
    {
        public JornadaRepository(GestionEstadioContext context) : base(context)
        {

        }

    }
}
