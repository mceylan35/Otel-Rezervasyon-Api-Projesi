using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Concrete
{
    public class OtelContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=OtelRezervasyon; Trusted_Connection=true");
        }

        public DbSet<Oda> Oda { get; set; }
        public DbSet<Otel> Otel { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rezervasyon> Rezervasyon { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
