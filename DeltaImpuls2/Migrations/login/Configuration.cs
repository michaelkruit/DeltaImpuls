namespace DeltaImpuls2.Migrations.login
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeltaImpuls2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\login";
            ContextKey = "DeltaImpuls2.Models.ApplicationDbContext";
        }

        protected override void Seed(DeltaImpuls2.Models.ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("@Test123");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Deltaimpuls@hotmail.com",
                    PasswordHash = password
                });
        }
    }
}
