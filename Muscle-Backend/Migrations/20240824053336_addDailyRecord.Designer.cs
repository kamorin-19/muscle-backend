﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muscle_Backend.Database;

#nullable disable

namespace Muscle_Backend.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20240824053336_addDailyRecord")]
    partial class addDailyRecord
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Muscle_Backend.Models.BodyPart", b =>
                {
                    b.Property<int>("BodyPartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BodyPartId");

                    b.ToTable("BodyParts");
                });

            modelBuilder.Entity("Muscle_Backend.Models.Exercise", b =>
                {
                    b.Property<int>("ExercisePId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BodyPartId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("ExercisePId");

                    b.HasIndex("BodyPartId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Muscle_Backend.Models.Exercise", b =>
                {
                    b.HasOne("Muscle_Backend.Models.BodyPart", "BodyPart")
                        .WithMany()
                        .HasForeignKey("BodyPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyPart");
                });
#pragma warning restore 612, 618
        }
    }
}
