namespace GestionEstadio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class probandoTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deportes",
                c => new
                    {
                        DeporteId = c.Int(nullable: false, identity: true),
                        nombreDeporte = c.String(nullable: false),
                        duracionPartidos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeporteId);
            
            CreateTable(
                "dbo.Equipo",
                c => new
                    {
                        EquipoId = c.Int(nullable: false, identity: true),
                        nombreEquipo = c.String(nullable: false),
                        DeporteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipoId)
                .ForeignKey("dbo.Deportes", t => t.DeporteId, cascadeDelete: true)
                .Index(t => t.DeporteId);
            
            CreateTable(
                "dbo.Partido",
                c => new
                    {
                        PartidoId = c.Int(nullable: false, identity: true),
                        duracion = c.Int(nullable: false),
                        JornadaId = c.Int(nullable: false),
                        PistaId = c.Int(nullable: false),
                        local_EquipoId = c.Int(),
                        visitante_EquipoId = c.Int(),
                        Equipo_EquipoId = c.Int(),
                    })
                .PrimaryKey(t => t.PartidoId)
                .ForeignKey("dbo.Jornada", t => t.JornadaId, cascadeDelete: true)
                .ForeignKey("dbo.Equipo", t => t.local_EquipoId)
                .ForeignKey("dbo.Pista", t => t.PistaId, cascadeDelete: true)
                .ForeignKey("dbo.Equipo", t => t.visitante_EquipoId)
                .ForeignKey("dbo.Equipo", t => t.Equipo_EquipoId)
                .Index(t => t.JornadaId)
                .Index(t => t.PistaId)
                .Index(t => t.local_EquipoId)
                .Index(t => t.visitante_EquipoId)
                .Index(t => t.Equipo_EquipoId);
            
            CreateTable(
                "dbo.Jornada",
                c => new
                    {
                        JornadaId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.JornadaId);
            
            CreateTable(
                "dbo.Pista",
                c => new
                    {
                        PistaId = c.Int(nullable: false, identity: true),
                        ocupada = c.Boolean(nullable: false),
                        EstadioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PistaId)
                .ForeignKey("dbo.Estadio", t => t.EstadioId, cascadeDelete: true)
                .Index(t => t.EstadioId);
            
            CreateTable(
                "dbo.Estadio",
                c => new
                    {
                        EstadioId = c.Int(nullable: false, identity: true),
                        nombreEstadio = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        numeroPistas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        user = c.String(nullable: false),
                        contraseña = c.String(nullable: false),
                        tipoUsuario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partido", "Equipo_EquipoId", "dbo.Equipo");
            DropForeignKey("dbo.Partido", "visitante_EquipoId", "dbo.Equipo");
            DropForeignKey("dbo.Partido", "PistaId", "dbo.Pista");
            DropForeignKey("dbo.Pista", "EstadioId", "dbo.Estadio");
            DropForeignKey("dbo.Partido", "local_EquipoId", "dbo.Equipo");
            DropForeignKey("dbo.Partido", "JornadaId", "dbo.Jornada");
            DropForeignKey("dbo.Equipo", "DeporteId", "dbo.Deportes");
            DropIndex("dbo.Pista", new[] { "EstadioId" });
            DropIndex("dbo.Partido", new[] { "Equipo_EquipoId" });
            DropIndex("dbo.Partido", new[] { "visitante_EquipoId" });
            DropIndex("dbo.Partido", new[] { "local_EquipoId" });
            DropIndex("dbo.Partido", new[] { "PistaId" });
            DropIndex("dbo.Partido", new[] { "JornadaId" });
            DropIndex("dbo.Equipo", new[] { "DeporteId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Estadio");
            DropTable("dbo.Pista");
            DropTable("dbo.Jornada");
            DropTable("dbo.Partido");
            DropTable("dbo.Equipo");
            DropTable("dbo.Deportes");
        }
    }
}
