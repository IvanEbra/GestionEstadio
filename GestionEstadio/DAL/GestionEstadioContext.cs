using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GestionEstadio.Model;
using GestionEstadio.Migrations;

namespace GestionEstadio.DAL
{
    public class GestionEstadioContext:DbContext
    {
        public GestionEstadioContext():base("name=GestionEstadioEntities")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<GestionEstadioContext, Configuration>());
            }
            else
            {
                Database.SetInitializer(new creardb());
            }
        }

        public virtual DbSet<Deporte> deporte { get; set; }
        public virtual DbSet<Equipo> equipo { get; set; }
        public virtual DbSet<Estadio> estadio { get; set; }
        public virtual DbSet<Jornada> jornada { get; set; }
        public virtual DbSet<Partido> partido { get; set; }
        public virtual DbSet<Pista> pista { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }

        class creardb : CreateDatabaseIfNotExists<GestionEstadioContext>
        {
            protected override void Seed(GestionEstadio.DAL.GestionEstadioContext context)
            {
                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.

                Usuario usuario = new Usuario();
                usuario.user = "administrador";
                usuario.contraseña = "administrador";
                usuario.tipoUsuario = "admin";
                context.usuario.Add(usuario);

                Estadio estadio = new Estadio();
                estadio.nombreEstadio = "Estadio xinzo";
                estadio.direccion = "calle xinzo";
                estadio.numeroPistas = 3;
                context.estadio.Add(estadio);

                for (int i = 0; i < estadio.numeroPistas; i++)
                {
                    Pista pista = new Pista();
                    pista.ocupada = false;
                    pista.EstadioId = estadio.EstadioId;
                    pista.Estadio = estadio;
                    context.pista.Add(pista);
                }

                Deporte deporte = new Deporte();
                deporte.nombreDeporte = "Baloncesto";
                deporte.duracionPartidos = 40;
                context.deporte.Add(deporte);

            context.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
