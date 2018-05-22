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
    [Migration("20180510033806_addeduniqueindexonguardian")]
    partial class addeduniqueindexonguardian
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backEnd.Models.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Access");
                });

            modelBuilder.Entity("backEnd.Models.Adviser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Advisers");
                });

            modelBuilder.Entity("backEnd.Models.Barangay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Barangays");
                });

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

            modelBuilder.Entity("backEnd.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Districts");
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

                    b.HasIndex("EmployeeNumber")
                        .IsUnique()
                        .HasFilter("[EmployeeNumber] IS NOT NULL");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("backEnd.Models.EmployeeDesignation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DesignationId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeDesignations");
                });

            modelBuilder.Entity("backEnd.Models.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("PositionId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("EmployeeId", "PositionId")
                        .IsUnique();

                    b.ToTable("EmployeePositions");
                });

            modelBuilder.Entity("backEnd.Models.EmployeeStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.HasIndex("EmployeeId", "StationId")
                        .IsUnique();

                    b.ToTable("EmployeeStations");
                });

            modelBuilder.Entity("backEnd.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("backEnd.Models.Guardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact");

                    b.Property<int>("PersonId");

                    b.Property<int>("RelationId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("RelationId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("backEnd.Models.GuidanceCouncilor", b =>
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

                    b.ToTable("GuidanceCouncilors");
                });

            modelBuilder.Entity("backEnd.Models.InvolveStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("SectionStudentId");

                    b.Property<int>("StudentCaseId");

                    b.HasKey("Id");

                    b.HasIndex("StudentCaseId");

                    b.HasIndex("SectionStudentId", "StudentCaseId")
                        .IsUnique();

                    b.ToTable("InvolveStudents");
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

                    b.Property<int>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("StationId");

                    b.HasIndex("SectionId", "SchoolYear", "StationId", "LevelId")
                        .IsUnique();

                    b.ToTable("LevelSections");
                });

            modelBuilder.Entity("backEnd.Models.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("backEnd.Models.Offense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OffenseTypeId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OffenseTypeId");

                    b.ToTable("Offense");
                });

            modelBuilder.Entity("backEnd.Models.OffenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OffenseType");
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

                    b.HasIndex("FirstName", "MiddleName", "LastName", "SuffixName")
                        .IsUnique()
                        .HasFilter("[SuffixName] IS NOT NULL");

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

                    b.Property<int>("SchoolYear");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.HasIndex("EmployeeId", "SchoolYear", "StationId")
                        .IsUnique();

                    b.ToTable("Principals");
                });

            modelBuilder.Entity("backEnd.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("backEnd.Models.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("backEnd.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("backEnd.Models.RoleAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("RoleId", "AccessId")
                        .IsUnique();

                    b.ToTable("RoleAccess");
                });

            modelBuilder.Entity("backEnd.Models.Section", b =>
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

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("backEnd.Models.SectionAdviser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdviserId");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("LevelSectionId");

                    b.HasKey("Id");

                    b.HasIndex("AdviserId");

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

                    b.Property<int?>("SchoolId");

                    b.Property<int>("StationNumber");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SchoolId")
                        .IsUnique()
                        .HasFilter("[SchoolId] IS NOT NULL");

                    b.HasIndex("StationNumber")
                        .IsUnique();

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("backEnd.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("backEnd.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Contact");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("GenderId");

                    b.Property<string>("LrnNumber")
                        .IsRequired();

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("LrnNumber")
                        .IsUnique();

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("backEnd.Models.StudentAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BarangayId");

                    b.Property<int>("MunicipalityId");

                    b.Property<int>("ProvinceId");

                    b.Property<int?>("StreetId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("BarangayId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("StreetId");

                    b.HasIndex("StudentId", "ProvinceId", "BarangayId", "MunicipalityId")
                        .IsUnique();

                    b.ToTable("StudentAdresses");
                });

            modelBuilder.Entity("backEnd.Models.StudentCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Incident")
                        .IsRequired();

                    b.Property<DateTime>("IncidentDate");

                    b.HasKey("Id");

                    b.HasIndex("Incident")
                        .IsUnique();

                    b.ToTable("StudentCases");
                });

            modelBuilder.Entity("backEnd.Models.StudentOffense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("InvolveStudentId");

                    b.Property<int>("OffenseId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("OffenseId");

                    b.HasIndex("InvolveStudentId", "OffenseId")
                        .IsUnique();

                    b.ToTable("StudentOffenses");
                });

            modelBuilder.Entity("backEnd.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeNumber");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backEnd.Models.UserAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("UserId", "AccessId")
                        .IsUnique();

                    b.ToTable("UserAccess");
                });

            modelBuilder.Entity("backEnd.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("backEnd.Models.Adviser", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("Advisers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
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

            modelBuilder.Entity("backEnd.Models.Guardian", b =>
                {
                    b.HasOne("backEnd.Models.Person", "Person")
                        .WithOne("Guardian")
                        .HasForeignKey("backEnd.Models.Guardian", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Relation", "Relation")
                        .WithMany("Guardians")
                        .HasForeignKey("RelationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Student", "Student")
                        .WithMany("Guardians")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.GuidanceCouncilor", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithMany("GuidanceCouncilors")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.InvolveStudent", b =>
                {
                    b.HasOne("backEnd.Models.SectionStudent", "SectionStudent")
                        .WithMany("InvolveStudents")
                        .HasForeignKey("SectionStudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.StudentCase", "StudentCase")
                        .WithMany("InvolveStudents")
                        .HasForeignKey("StudentCaseId")
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

                    b.HasOne("backEnd.Models.Station", "Station")
                        .WithMany("LevelSections")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.Offense", b =>
                {
                    b.HasOne("backEnd.Models.OffenseType", "OffenseType")
                        .WithMany("Offenses")
                        .HasForeignKey("OffenseTypeId")
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

                    b.HasOne("backEnd.Models.Station", "Station")
                        .WithMany("Principals")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.RoleAccess", b =>
                {
                    b.HasOne("backEnd.Models.Access", "Access")
                        .WithMany("RoleAccesses")
                        .HasForeignKey("AccessId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Role", "Role")
                        .WithMany("RoleAccesses")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.SectionAdviser", b =>
                {
                    b.HasOne("backEnd.Models.Adviser", "Adviser")
                        .WithMany("SectionAdvisers")
                        .HasForeignKey("AdviserId")
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
                    b.HasOne("backEnd.Models.Gender", "Gender")
                        .WithMany("Students")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("backEnd.Models.Student", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.StudentAddress", b =>
                {
                    b.HasOne("backEnd.Models.Barangay", "Barangay")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("BarangayId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Municipality", "Municipality")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Province", "Province")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Street", "Street")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Student", "Student")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.StudentOffense", b =>
                {
                    b.HasOne("backEnd.Models.InvolveStudent", "InvolveStudent")
                        .WithMany("StudentOffenses")
                        .HasForeignKey("InvolveStudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.Offense", "Offense")
                        .WithMany("StudentOffenses")
                        .HasForeignKey("OffenseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.User", b =>
                {
                    b.HasOne("backEnd.Models.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("backEnd.Models.User", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.UserAccess", b =>
                {
                    b.HasOne("backEnd.Models.Access", "Access")
                        .WithMany("UserAccesses")
                        .HasForeignKey("AccessId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.User", "User")
                        .WithMany("UserAccesses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("backEnd.Models.UserRole", b =>
                {
                    b.HasOne("backEnd.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("backEnd.Models.User", "User")
                        .WithOne("UserRole")
                        .HasForeignKey("backEnd.Models.UserRole", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
