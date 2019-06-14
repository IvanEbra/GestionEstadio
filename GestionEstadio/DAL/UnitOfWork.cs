using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEstadio.DAL
{
    public class UnitOfWork :IDisposable
    {
        private GestionEstadioContext context = new GestionEstadioContext();
        private bool disposed = false;

        private DeporteRepository deporteRepository;
        private EquipoRepository equipoRepository;
        private EstadioRepository estadioRepository;
        private JornadaRepository jornadaRepository;
        private PartidoRepository partidoRepository;
        private PistaRepository pistaRepository;
        private UsuarioRepository usuarioRepository;

        public DeporteRepository DeporteRepository
        {
            get
            {
                if (deporteRepository == null)
                {
                    deporteRepository = new DeporteRepository(context);
                }

                return deporteRepository;
            }
        }


        public EquipoRepository EquipoRepository
        {
            get
            {
                if (equipoRepository == null)
                {
                    equipoRepository = new EquipoRepository(context);
                }

                return equipoRepository;
            }
        }

        public EstadioRepository EstadioRepository
        {
            get
            {
                if (estadioRepository == null)
                {
                    estadioRepository = new EstadioRepository(context);
                }

                return estadioRepository;
            }
        }

        public JornadaRepository JornadaRepository
        {
            get
            {
                if (jornadaRepository == null)
                {
                    jornadaRepository = new JornadaRepository(context);
                }

                return jornadaRepository;
            }
        }

        public PartidoRepository PartidoRepository
        {
            get
            {
                if (partidoRepository == null)
                {
                    partidoRepository = new PartidoRepository(context);
                }

                return partidoRepository;
            }
        }

        public PistaRepository PistaRepository
        {
            get
            {
                if (pistaRepository == null)
                {
                    pistaRepository = new PistaRepository(context);
                }

                return pistaRepository;
            }
        }

        public UsuarioRepository UsuarioRepository
        {
            get
            {
                if (usuarioRepository == null)
                {
                    usuarioRepository = new UsuarioRepository(context);
                }

                return usuarioRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
