using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelefoniaWooza.Domain.Entities;

namespace TelefoniaWooza.Infra.Data.Mappings
{


    public class DDDPlanoMap : IEntityTypeConfiguration<DDDPlano>
    {
        public void Configure(EntityTypeBuilder<DDDPlano> builder)
        {
            builder.ToTable("DDDPlanos");

            builder.HasKey(c => c.Id);
            builder.HasIndex(x => new { x.PLanoId, x.DDDId }).IsUnique();

            builder.Property(c => c.Id)
             .IsRequired()
             .UseIdentityColumn()
             .HasColumnName("Id");

            builder.Property(c => c.PLanoId)
                .IsRequired()
                .HasColumnName("PlanoId");


            builder.Property(c => c.DDDId)
                .IsRequired()
                .HasColumnName("DDDId");


        }
    }
}
