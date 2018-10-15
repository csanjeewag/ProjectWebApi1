﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebAPI4.Models;

namespace WebAPI4.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI4.Models.Department", b =>
                {
                    b.Property<string>("DprtId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DprtName");

                    b.HasKey("DprtId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("WebAPI4.Models.Emp", b =>
                {
                    b.Property<string>("EmpId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentDprtId");

                    b.Property<string>("EmpAddress");

                    b.Property<string>("EmpContact");

                    b.Property<string>("EmpEmail");

                    b.Property<string>("EmpName");

                    b.Property<string>("EmpPassword");

                    b.Property<string>("PositionPId");

                    b.HasKey("EmpId");

                    b.HasIndex("DepartmentDprtId");

                    b.HasIndex("PositionPId");

                    b.ToTable("emps");
                });

            modelBuilder.Entity("WebAPI4.Models.Position", b =>
                {
                    b.Property<string>("PId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PName");

                    b.Property<string>("Roles");

                    b.HasKey("PId");

                    b.ToTable("positions");
                });

            modelBuilder.Entity("WebAPI4.Models.Emp", b =>
                {
                    b.HasOne("WebAPI4.Models.Department")
                        .WithMany("Emp")
                        .HasForeignKey("DepartmentDprtId");

                    b.HasOne("WebAPI4.Models.Position")
                        .WithMany("Emp")
                        .HasForeignKey("PositionPId");
                });
#pragma warning restore 612, 618
        }
    }
}