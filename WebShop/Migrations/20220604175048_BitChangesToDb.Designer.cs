﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Data;

namespace WebShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220604175048_BitChangesToDb")]
    partial class BitChangesToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebShop.Models.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPU_Type")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power_usage")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RAM_Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CPU");
                });

            modelBuilder.Entity("WebShop.Models.CPU_Motherboard", b =>
                {
                    b.Property<int>("CPU_Id")
                        .HasColumnType("int");

                    b.Property<int>("Motherboard_Id")
                        .HasColumnType("int");

                    b.HasKey("CPU_Id", "Motherboard_Id");

                    b.HasIndex("Motherboard_Id");

                    b.ToTable("CPU_Motherboard");
                });

            modelBuilder.Entity("WebShop.Models.CPU_RAM", b =>
                {
                    b.Property<int>("CPU_Id")
                        .HasColumnType("int");

                    b.Property<int>("RAM_Id")
                        .HasColumnType("int");

                    b.HasKey("CPU_Id", "RAM_Id");

                    b.HasIndex("RAM_Id");

                    b.ToTable("CPU_RAM");
                });

            modelBuilder.Entity("WebShop.Models.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power_usage")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GPU");
                });

            modelBuilder.Entity("WebShop.Models.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPU_Type")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RAM_Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Motherboard");
                });

            modelBuilder.Entity("WebShop.Models.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power_output")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PowerSupply");
                });

            modelBuilder.Entity("WebShop.Models.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RAM_Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RAM");
                });

            modelBuilder.Entity("WebShop.Models.RAM_Motherboard", b =>
                {
                    b.Property<int>("RAM_Id")
                        .HasColumnType("int");

                    b.Property<int>("Motherboard_Id")
                        .HasColumnType("int");

                    b.HasKey("RAM_Id", "Motherboard_Id");

                    b.HasIndex("Motherboard_Id");

                    b.ToTable("RAM_Motherboard");
                });

            modelBuilder.Entity("WebShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebShop.Models.CPU_Motherboard", b =>
                {
                    b.HasOne("WebShop.Models.CPU", "CPU")
                        .WithMany("CPU_Motherboards")
                        .HasForeignKey("CPU_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebShop.Models.Motherboard", "Motherboard")
                        .WithMany("CPU_Motherboards")
                        .HasForeignKey("Motherboard_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CPU");

                    b.Navigation("Motherboard");
                });

            modelBuilder.Entity("WebShop.Models.CPU_RAM", b =>
                {
                    b.HasOne("WebShop.Models.CPU", "CPU")
                        .WithMany("CPU_RAMs")
                        .HasForeignKey("CPU_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebShop.Models.RAM", "RAM")
                        .WithMany("CPU_RAMs")
                        .HasForeignKey("RAM_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CPU");

                    b.Navigation("RAM");
                });

            modelBuilder.Entity("WebShop.Models.RAM_Motherboard", b =>
                {
                    b.HasOne("WebShop.Models.Motherboard", "Motherboard")
                        .WithMany("RAM_Motherboards")
                        .HasForeignKey("Motherboard_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebShop.Models.RAM", "RAM")
                        .WithMany("RAM_Motherboards")
                        .HasForeignKey("RAM_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motherboard");

                    b.Navigation("RAM");
                });

            modelBuilder.Entity("WebShop.Models.CPU", b =>
                {
                    b.Navigation("CPU_Motherboards");

                    b.Navigation("CPU_RAMs");
                });

            modelBuilder.Entity("WebShop.Models.Motherboard", b =>
                {
                    b.Navigation("CPU_Motherboards");

                    b.Navigation("RAM_Motherboards");
                });

            modelBuilder.Entity("WebShop.Models.RAM", b =>
                {
                    b.Navigation("CPU_RAMs");

                    b.Navigation("RAM_Motherboards");
                });
#pragma warning restore 612, 618
        }
    }
}
