﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Infra.Data.Migrations
{
    [DbContext(typeof(TelefoniaContext))]
    [Migration("20200516194806_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TelefoniaWooza.Domain.Entities.DDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("Sigla")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Sigla")
                        .IsUnique();

                    b.ToTable("DDDs");
                });

            modelBuilder.Entity("TelefoniaWooza.Domain.Entities.DDDPlano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DDDId")
                        .HasColumnName("DDDId")
                        .HasColumnType("int");

                    b.Property<int>("PLanoId")
                        .HasColumnName("PlanoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DDDId");

                    b.HasIndex("PLanoId", "DDDId")
                        .IsUnique();

                    b.ToTable("DDDPlanos");
                });

            modelBuilder.Entity("TelefoniaWooza.Domain.Entities.Operadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Operadoras");
                });

            modelBuilder.Entity("TelefoniaWooza.Domain.Entities.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("FranquiaInternet")
                        .HasColumnName("FranquiaInternet")
                        .HasColumnType("real");

                    b.Property<int>("Minutos")
                        .HasColumnName("Minutos")
                        .HasColumnType("int");

                    b.Property<string>("Operadora")
                        .IsRequired()
                        .HasColumnName("Operadora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnName("Tipo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnName("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("TelefoniaWooza.Domain.Entities.DDDPlano", b =>
                {
                    b.HasOne("TelefoniaWooza.Domain.Entities.DDD", "Ddd")
                        .WithMany("DDDPlanos")
                        .HasForeignKey("DDDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelefoniaWooza.Domain.Entities.Plano", "Plano")
                        .WithMany("DDDPlanos")
                        .HasForeignKey("PLanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}