﻿using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mod6_TP1.Data
{
    public class Mod6_TP1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Mod6_TP1Context() : base("name=Mod6_TP1Context")
        {
        }

        public System.Data.Entity.DbSet<BO.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<BO.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO.ArtMartial> ArtMartials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //une Arme ne peut appartenir qu’à un seul samouraï
            modelBuilder.Entity<Samourai>().HasOptional(x => x.Arme).WithOptionalPrincipal();

            //Un samouraï possède désormais une liste d’arts martiaux
            //Un art martial peut être associé à zéro ou plusieurs samouraïs
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtMartials).WithMany();

        }
    }
}
