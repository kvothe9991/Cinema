using Cine.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.DAL
{
    public class CineContext: DbContext
    {
        public CineContext() : base("CineContext") {}

        public DbSet<Socio> Socios { get; set; }

        public DbSet<Entrada> Entradas { get; set; }

        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}