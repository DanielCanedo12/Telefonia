using System;
using Microsoft.EntityFrameworkCore;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Infra.Data.Mappings;

namespace TelefoniaWooza.Infra.Data.Contexts
{

    public class TelefoniaContext : DbContext
    {
        public DbSet<Plano> Planos { get; set; }
        public DbSet<DDD> DDDs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Port=1433;Database=TELEFONIA;Uid=sa;Pwd=P@ssw0rd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.ApplyConfiguration(new PlanoMap());
           modelBuilder.ApplyConfiguration(new DDDMap());
        }
    }

}
