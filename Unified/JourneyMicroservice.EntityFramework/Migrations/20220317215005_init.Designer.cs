﻿// <auto-generated />
using System;
using JourneyMicroservice.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JourneyMicroservice.EntityFramework.Migrations
{
    [DbContext(typeof(JourneyContext))]
    [Migration("20220317215005_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("JourneyMicroservice.Core.Entity.Journey", b =>
                {
                    b.Property<int>("IdJourney")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.HasKey("IdJourney");

                    b.ToTable("Journeys");
                });
#pragma warning restore 612, 618
        }
    }
}
