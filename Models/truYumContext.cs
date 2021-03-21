using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Turuyum.Models
{
    public class truYumContext :DbContext
    {
        public truYumContext() : base("name = TruYumContext") { }
        public DbSet<MenuItem> MenuItems { get; set; }
            public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}