﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelefoniaWooza.Domain.Entities;

namespace TelefoniaWooza.Infra.Data.Mappings
{
    public class PlanoMap : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
			builder.ToTable("Planos");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id)
				.IsRequired()
				.UseIdentityColumn()
				.HasColumnName("Id");


			builder.Property(c => c.Codigo)
				.IsRequired()
				.HasColumnName("Codigo");

			builder.Property(c => c.Minutos)
				.IsRequired()
				.HasColumnName("Minutos");

			builder.Property(c => c.Operadora)
				.IsRequired()
				.HasColumnName("Operadora");

			builder.Property(c => c.Tipo)
				.IsRequired()
				.HasColumnName("Tipo");

			builder.Property(c => c.FranquiaInternet)
				.IsRequired()
				.HasColumnName("FranquiaInternet");

			builder.Property(c => c.Valor)
				.IsRequired()
				.HasColumnName("Valor");

			builder.HasMany(x => x.DDDPlanos)
                
			   .WithOne(x => x.Plano)
                
			   .HasForeignKey(x => x.PLanoId).OnDelete(DeleteBehavior.Cascade);
		}
	}
    
}
