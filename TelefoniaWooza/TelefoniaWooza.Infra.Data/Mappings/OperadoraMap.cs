using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelefoniaWooza.Domain.Entities;

namespace TelefoniaWooza.Infra.Data.Mappings
{


    public class OperadoraMap : IEntityTypeConfiguration<Operadora>
    {
        public void Configure(EntityTypeBuilder<Operadora> builder)
        {
            builder.ToTable("Operadoras");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Nome).IsUnique();

            builder.Property(c => c.Id)
             .IsRequired()
             .UseIdentityColumn()
             .HasColumnName("Id");


            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");

        }
    }
}
