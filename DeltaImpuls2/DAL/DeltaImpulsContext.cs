using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DeltaImpuls2.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DeltaImpuls2.DAL
{
    public class DeltaImpulsContext : DbContext
    {
        public DeltaImpulsContext() : base("codefirstDB")
        {
        }

        public DbSet<members> members { get; set; }
        public DbSet<categorie> categorie { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<ls> ls { get; set; }
        public DbSet<lj> lj { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}