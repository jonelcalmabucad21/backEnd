using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedStudentCaseandothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Incident = table.Column<string>(nullable: false),
                    IncidentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvolveStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    SectionStudentId = table.Column<int>(nullable: false),
                    StudentCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolveStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvolveStudent_SectionStudents_SectionStudentId",
                        column: x => x.SectionStudentId,
                        principalTable: "SectionStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolveStudent_StudentCase_StudentCaseId",
                        column: x => x.StudentCaseId,
                        principalTable: "StudentCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentOffense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    InvolveStudentId = table.Column<int>(nullable: false),
                    OffenseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOffense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentOffense_InvolveStudent_InvolveStudentId",
                        column: x => x.InvolveStudentId,
                        principalTable: "InvolveStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentOffense_Offense_OffenseId",
                        column: x => x.OffenseId,
                        principalTable: "Offense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvolveStudent_StudentCaseId",
                table: "InvolveStudent",
                column: "StudentCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolveStudent_SectionStudentId_StudentCaseId",
                table: "InvolveStudent",
                columns: new[] { "SectionStudentId", "StudentCaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCase_Incident",
                table: "StudentCase",
                column: "Incident",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentOffense_OffenseId",
                table: "StudentOffense",
                column: "OffenseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOffense_InvolveStudentId_OffenseId",
                table: "StudentOffense",
                columns: new[] { "InvolveStudentId", "OffenseId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentOffense");

            migrationBuilder.DropTable(
                name: "InvolveStudent");

            migrationBuilder.DropTable(
                name: "StudentCase");
        }
    }
}
