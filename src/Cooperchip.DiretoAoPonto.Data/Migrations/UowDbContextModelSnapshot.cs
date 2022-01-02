﻿// <auto-generated />
using System;
using Cooperchip.DiretoAoPonto.Data.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cooperchip.DiretoAoPonto.Data.Migrations
{
    [DbContext(typeof(UowDbContext))]
    partial class UowDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            //SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cooperchip.DiretoAoPonto.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("VooId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VooId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Cooperchip.DiretoAoPonto.Domain.Entities.Voo", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Disponibilidade")
                        .HasColumnType("int");

                    b.Property<string>("Nota")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Voo");
                });

            modelBuilder.Entity("Cooperchip.DiretoAoPonto.Domain.Entities.Pessoa", b =>
                {
                    b.HasOne("Cooperchip.DiretoAoPonto.Domain.Entities.Voo", "Voo")
                        .WithMany("Pessoas")
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("Cooperchip.DiretoAoPonto.Domain.Entities.Voo", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
