﻿// <auto-generated />
using System;
using MatrixSoftLabs.TestTask.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MatrixSoftLabs.TestTask.Migrations
{
    [DbContext(typeof(MatrixSoftLabsDbContext))]
    [Migration("20240522084639_Adjust_columns")]
    partial class Adjust_columns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.AspNetUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("ConfirmedTerms")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BossId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmploymentStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("ImageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConsultant")
                        .HasColumnType("bit");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.Vacancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateApproved")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserApprovedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VacancyCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VacancyStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserApprovedId");

                    b.HasIndex("VacancyCategoryId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.VacancyCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VacancyCategories");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.Employee", b =>
                {
                    b.HasOne("MatrixSoftLabs.TestTask.Entity.AspNetUser", "AspNetUser")
                        .WithOne("Employee")
                        .HasForeignKey("MatrixSoftLabs.TestTask.Entity.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetUser");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.Vacancy", b =>
                {
                    b.HasOne("MatrixSoftLabs.TestTask.Entity.AspNetUser", "UserApproved")
                        .WithMany("ApprovedVacancies")
                        .HasForeignKey("UserApprovedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatrixSoftLabs.TestTask.Entity.VacancyCategory", "VacancyCategory")
                        .WithMany("Vacancies")
                        .HasForeignKey("VacancyCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserApproved");

                    b.Navigation("VacancyCategory");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.AspNetUser", b =>
                {
                    b.Navigation("ApprovedVacancies");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MatrixSoftLabs.TestTask.Entity.VacancyCategory", b =>
                {
                    b.Navigation("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}