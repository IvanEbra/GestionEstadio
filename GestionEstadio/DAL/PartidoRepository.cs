using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEstadio.Model;

namespace GestionEstadio.DAL
{
    public class PartidoRepository:GenericRepository<Partido>
    {
        public PartidoRepository(GestionEstadioContext context) : base(context)
        {

        }
    }
}
