using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedUniqueinSectionStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    SchoolYear = table.Column<int>(nullable: false),
                    SectionAdviserId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionStudents_SectionAdvisers_SectionAdviserId",
                        column: x => x.SectionAdviserId,
                        principalTable: "SectionAdvisers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudents_StudentId",
                table: "SectionStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudents_SectionAdviserId_StudentId_SchoolYear",
                table: "SectionStudents",
                columns: new[] { "SectionAdviserId", "StudentId", "SchoolYear" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionStudents");
        }
    }
}
