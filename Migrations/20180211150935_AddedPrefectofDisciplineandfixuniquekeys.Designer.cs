﻿// <auto-generated />
using backEnd.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace backEnd.Migrations
{
    [DbContext(typeof(QuonDbContext))]
    [Migration("20180211150935_AddedPrefectofDisciplineandfixuniquekeys")]
    partial class AddedPrefectofDisciplineandfixuniquekeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backEnd.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("backEnd.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeNumber");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasName("IX_Employees_PersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("backEnd.Models.EmployeeDesignation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DesignationId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeDesignations");
                });

            modelBuilder.Entity("backEnd.Models.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Effective");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("EmployeePositions");
                });

            modelBuilder.Entity("backEnd.Models.EmployeeStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StationId");

                    b.ToTable("EmployeeStations");
                });

            modelBuilder.Entity("backEnd.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("backEnd.Models.LevelSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("LevelId");

                    b.Property<int>("SchoolYear");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("SectionId", "SchoolYear")
                        .IsUnique();

                    b.ToTable("LevelSections");
                });

            modelBuilder.Entity("backEnd.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName")
                        .IsRequired();

                    b.Property<string>("SuffixName");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("Title", "FirstName", "MiddleName", "LastName", "SuffixName")
                        .HasName("UIX_Persons_FullName");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("backEnd.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("backEnd.Models.PrefectOfDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("LevelId");

                    b.Property<int>("SchoolYear");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LevelId", "EmployeeId", "SchoolYear")
                        .IsUnique();

                    b.ToTable("PrefectOfDisciplines");
                });

            modelBuilder.Entity("backEnd.Models.Principal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Principals");
                });

            modelBuilder.Entity("backEnd.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("backEnd.Models.SectionAdviser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("LevelSectionId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LevelSectionId")
                        .IsUnique();

                    b.ToTable("SectionAdvisers");
                });

            modelBuilder.Entity("backEnd.Models.SectionStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("SchoolYear");

                    b.Property<int>("SectionAdviserId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("SectionAdviserId");

                    b.HasIndex("StudentId", "SchoolYear")
                        .IsUnique();

                    b.ToTable("SectionStudents");
                });

            modelBuilder.Entity("backEnd.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("StationNumber");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UIX_Stations_Name");

                    b.HasIndex("StationNumber")
                        .IsUnique()
                        .HasName("UIX_Stations_StationNumber");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("backEnd.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("LrnNumber")
                        .IsRequired();

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("LrnNumber")
                        .IsUnique();

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("backEnd.Models.Employee", b =>
                {
                    b.HasOne("backEnd.Models.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("backEnd.Models.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.EmployeeDesignation", b =>
                {
                    b.HasOne("backEnd.Models.Designation", "Designation")
                        .WithMany("EmployeeDesignations")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("EmployeeDesignations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.EmployeePosition", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("EmployeePositions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Position", "Position")
                        .WithMany("EmployeePositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.EmployeeStation", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("EmployeeStations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Station", "Station")
                        .WithMany("EmployeeStations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.LevelSection", b =>
                {
                    b.HasOne("backEnd.Models.Level", "Level")
                        .WithMany("LevelSections")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Section", "Section")
                        .WithMany("LevelSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.PrefectOfDiscipline", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("PrefectOfDisciplines")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Level", "Level")
                        .WithMany("PrefectOfDisciplines")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.Principal", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("Principals")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.SectionAdviser", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("SectionAdvisers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.LevelSection", "LevelSection")
                        .WithOne("SectionAdviser")
                        .HasForeignKey("backEnd.Models.SectionAdviser", "LevelSectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.SectionStudent", b =>
                {
                    b.HasOne("backEnd.Models.SectionAdviser", "SectionAdviser")
                        .WithMany("SectionStudents")
                        .HasForeignKey("SectionAdviserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Student", "Student")
                        .WithMany("SectionStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.Student", b =>
                {
                    b.HasOne("backEnd.Models.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("backEnd.Models.Student", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
