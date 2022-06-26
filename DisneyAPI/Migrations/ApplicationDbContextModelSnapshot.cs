﻿// <auto-generated />
using System;
using API.CoreBusiness.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisneyAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.CoreBusiness.Entity.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("API.CoreBusiness.Entity.PeliculaSerie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("Estreno")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("PeliculaSerie");
                });

            modelBuilder.Entity("API.CoreBusiness.Entity.Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Edad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Personaje");
                });

            modelBuilder.Entity("API.CoreBusiness.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PeliculaSeriePersonaje", b =>
                {
                    b.Property<int>("peliculaSeriesId")
                        .HasColumnType("int");

                    b.Property<int>("personajesId")
                        .HasColumnType("int");

                    b.HasKey("peliculaSeriesId", "personajesId");

                    b.HasIndex("personajesId");

                    b.ToTable("PeliculaSeriePersonaje");
                });

            modelBuilder.Entity("API.CoreBusiness.Entity.PeliculaSerie", b =>
                {
                    b.HasOne("API.CoreBusiness.Entity.Genero", null)
                        .WithMany("peliculaSeries")
                        .HasForeignKey("GeneroId");
                });

            modelBuilder.Entity("PeliculaSeriePersonaje", b =>
                {
                    b.HasOne("API.CoreBusiness.Entity.PeliculaSerie", null)
                        .WithMany()
                        .HasForeignKey("peliculaSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.CoreBusiness.Entity.Personaje", null)
                        .WithMany()
                        .HasForeignKey("personajesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.CoreBusiness.Entity.Genero", b =>
                {
                    b.Navigation("peliculaSeries");
                });
#pragma warning restore 612, 618
        }
    }
}