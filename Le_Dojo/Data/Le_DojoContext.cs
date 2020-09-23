using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Le_Dojo.Data
{
    public class Le_DojoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Le_DojoContext() : base("name=Le_DojoContext")
        {
        }

        public System.Data.Entity.DbSet<BO.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO.Arme> Armes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasOptional(v => v.Arme).WithOptionalPrincipal();
            modelBuilder.Entity<Samourai>().HasMany(f => f.ArtMartials).WithMany();
        }

        public System.Data.Entity.DbSet<BO.ArtMartial> ArtMartials { get; set; }
    }
}
