using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addeduniqueinlevelsections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LevelSections_SectionId_SchoolYear",
                table: "LevelSections");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSections_SectionId_SchoolYear_StationId_LevelId",
                table: "LevelSections",
                columns: new[] { "SectionId", "SchoolYear", "StationId", "LevelId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LevelSections_SectionId_SchoolYear_StationId_LevelId",
                table: "LevelSections");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSections_SectionId_SchoolYear",
                table: "LevelSections",
                columns: new[] { "SectionId", "SchoolYear" },
                unique: true);
        }
    }
}
