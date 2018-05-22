using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedPrefectofDisciplineandfixuniquekeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SectionStudents_StudentId",
                table: "SectionStudents");

            migrationBuilder.DropIndex(
                name: "IX_SectionStudents_SectionAdviserId_StudentId_SchoolYear",
                table: "SectionStudents");

            migrationBuilder.DropIndex(
                name: "IX_SectionAdvisers_LevelSectionId",
                table: "SectionAdvisers");

            migrationBuilder.DropIndex(
                name: "IX_LevelSections_SectionId_LevelId_SchoolYear",
                table: "LevelSections");

            migrationBuilder.CreateTable(
                name: "PrefectOfDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    LevelId = table.Column<int>(nullable: false),
                    SchoolYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefectOfDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrefectOfDisciplines_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrefectOfDisciplines_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudents_SectionAdviserId",
                table: "SectionStudents",
                column: "SectionAdviserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudents_StudentId_SchoolYear",
                table: "SectionStudents",
                columns: new[] { "StudentId", "SchoolYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionAdvisers_LevelSectionId",
                table: "SectionAdvisers",
                column: "LevelSectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LevelSections_SectionId_SchoolYear",
                table: "LevelSections",
                columns: new[] { "SectionId", "SchoolYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrefectOfDisciplines_EmployeeId",
                table: "PrefectOfDisciplines",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefectOfDisciplines_LevelId_EmployeeId_SchoolYear",
                table: "PrefectOfDisciplines",
                columns: new[] { "LevelId", "EmployeeId", "SchoolYear" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrefectOfDisciplines");

            migrationBuilder.DropIndex(
                name: "IX_SectionStudents_SectionAdviserId",
                table: "SectionStudents");

            migrationBuilder.DropIndex(
                name: "IX_SectionStudents_StudentId_SchoolYear",
                table: "SectionStudents");

            migrationBuilder.DropIndex(
                name: "IX_SectionAdvisers_LevelSectionId",
                table: "SectionAdvisers");

            migrationBuilder.DropIndex(
                name: "IX_LevelSections_SectionId_SchoolYear",
                table: "LevelSections");

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudents_StudentId",
                table: "SectionStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudents_SectionAdviserId_StudentId_SchoolYear",
                table: "SectionStudents",
                columns: new[] { "SectionAdviserId", "StudentId", "SchoolYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionAdvisers_LevelSectionId",
                table: "SectionAdvisers",
                column: "LevelSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSections_SectionId_LevelId_SchoolYear",
                table: "LevelSections",
                columns: new[] { "SectionId", "LevelId", "SchoolYear" },
                unique: true);
        }
    }
}
