namespace DeltaImpuls2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MainConfiguration : DbMigrationsConfiguration<DeltaImpuls2.Models.ApplicationDbContext>
    {
        public MainConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DeltaImpuls2.DAL.DeltaImpulsContext.cs";
        }

        protected override void Seed(DeltaImpuls2.Models.ApplicationDbContext context)
        {

        }
    }
}
