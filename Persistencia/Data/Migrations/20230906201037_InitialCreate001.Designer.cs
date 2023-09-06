﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(TokenApiContext))]
    [Migration("20230906201037_InitialCreate001")]
    partial class InitialCreate001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Dominio.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Dominio.Entities.UserRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRols");
                });

            modelBuilder.Entity("RolUser", b =>
                {
                    b.Property<int>("RolsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RolUser");
                });

            modelBuilder.Entity("Dominio.Entities.UserRol", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("UsersRols")
                        .HasForeignKey("RolId");

                    b.HasOne("Dominio.Entities.User", "User")
                        .WithMany("UsersRols")
                        .HasForeignKey("UserId");

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RolUser", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("UsersRols");
                });

            modelBuilder.Entity("Dominio.Entities.User", b =>
                {
                    b.Navigation("UsersRols");
                });
#pragma warning restore 612, 618
        }
    }
}