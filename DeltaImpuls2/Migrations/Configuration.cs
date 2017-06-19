namespace DeltaImpuls2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeltaImpuls2.DAL.DeltaImpulsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DeltaImpuls2.DAL.DeltaImpulsContext";
        }

        protected override void Seed(DeltaImpuls2.DAL.DeltaImpulsContext context)
        {

        }
    }
}
