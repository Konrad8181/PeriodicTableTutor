﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeriodicTableTutor.Data;

#nullable disable

namespace PeriodicTableTutor.Migrations
{
    [DbContext(typeof(ElementModelContext))]
    partial class ElementModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PeriodicTableTutor.Models.Entities.ElementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AtomicMass")
                        .HasColumnType("float");

                    b.Property<double>("Density")
                        .HasColumnType("float");

                    b.Property<string>("Discoverer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Electrons")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("LatinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MassNumber")
                        .HasColumnType("int");

                    b.Property<int>("Neutrons")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Phase")
                        .HasColumnType("int");

                    b.Property<int>("Protons")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("Type")
                        .HasMaxLength(24)
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });
#pragma warning restore 612, 618
        }
    }
}