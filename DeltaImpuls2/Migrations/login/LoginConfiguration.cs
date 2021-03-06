namespace DeltaImpuls2.Migrations.login
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class LoginConfiguration : DbMigrationsConfiguration<DeltaImpuls2.Models.ApplicationDbContext>
    {
        public LoginConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\login";
            ContextKey = "DeltaImpuls2.Models.ApplicationDbContext";
        }

        protected override void Seed(DeltaImpuls2.Models.ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("@Test123");
            context.Users.AddOrUpdate(u => u.Email,
                new ApplicationUser
                {
                    UserName = "Deltaimpuls@hotmail.com",
                    Email = "Deltaimpuls@hotmail.com",
                    PasswordHash = password
                });
            //if(!(context.Users.Any(u => u.Email == "Deltaimpuls@hotmail.com")))
            //{
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);
            //    var newUser = new ApplicationUser
            //    {
            //        UserName = "Deltaimpuls@hotmail.com",
            //        Email = "Deltaimpuls@hotmail.com",
            //        PasswordHash = "@Test123"
            //    };
            //    userManager.Create(newUser, "@Test123");
            //    base.Seed(context);
            //}
        }
    }
}
