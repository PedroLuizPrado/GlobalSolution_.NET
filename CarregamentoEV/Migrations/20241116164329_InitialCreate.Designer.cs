﻿// <auto-generated />
using System;
using CarregamentoEV.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarregamentoEV.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241116164329_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarregamentoEV.Models.ChargingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChargingStationId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("ChargingStationId");

                    b.ToTable("ChargingSessions");
                });

            modelBuilder.Entity("CarregamentoEV.Models.ChargingStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Disponivel")
                        .HasColumnType("BOOLEAN");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("Id");

                    b.ToTable("ChargingStations");
                });

            modelBuilder.Entity("CarregamentoEV.Models.ChargingSession", b =>
                {
                    b.HasOne("CarregamentoEV.Models.ChargingStation", "ChargingStation")
                        .WithMany()
                        .HasForeignKey("ChargingStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChargingStation");
                });
#pragma warning restore 612, 618
        }
    }
}
