﻿// <auto-generated />
using System;
using MeetingService.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetingService.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeetingService.Entities.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tenant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoomId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("MeetingService.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScenarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tenant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VonageRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScenarioId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("MeetingService.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScenarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScenarioId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("MeetingService.Entities.Scenario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scenario");
                });

            modelBuilder.Entity("MeetingService.Entities.Participant", b =>
                {
                    b.HasOne("MeetingService.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetingService.Entities.Room", null)
                        .WithMany("Participants")
                        .HasForeignKey("RoomId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MeetingService.Entities.Role", b =>
                {
                    b.HasOne("MeetingService.Entities.Scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scenario");
                });

            modelBuilder.Entity("MeetingService.Entities.Room", b =>
                {
                    b.HasOne("MeetingService.Entities.Scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scenario");
                });

            modelBuilder.Entity("MeetingService.Entities.Room", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}