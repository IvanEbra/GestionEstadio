namespace GestionEstadio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GestionEstadio.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<GestionEstadio.DAL.GestionEstadioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

     
    }
}
