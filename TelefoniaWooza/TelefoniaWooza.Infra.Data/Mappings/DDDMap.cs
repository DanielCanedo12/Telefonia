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
            builder.ToTable("DDDs");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Sigla).IsUnique();

            builder.Property(c => c.Id)
                .IsRequired()
                .UseIdentityColumn()
                .HasColumnName("Id");

            builder.Property(c => c.Sigla)
                .IsRequired()
                .HasColumnName("Sigla");

            builder.HasMany(x => x.DDDPlanos)
                .WithOne(x => x.Ddd)
                .HasForeignKey(x => x.DDDId).OnDelete(DeleteBehavior.ClientNoAction);

        }
    }
}
