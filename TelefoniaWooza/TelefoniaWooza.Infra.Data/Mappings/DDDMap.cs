using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelefoniaWooza.Domain.Entities;

namespace TelefoniaWooza.Infra.Data.Mappings
{


    public class DDDMap : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.ToTable("Plano");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Sigla);


            builder.Property(c => c.Sigla)
                .IsRequired()
                .HasColumnName("Sigla");

        }
    }
}
