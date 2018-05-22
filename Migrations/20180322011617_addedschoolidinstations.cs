using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedschoolidinstations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Stations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_SchoolId",
                table: "Stations",
                column: "SchoolId",
                unique: true,
                filter: "[SchoolId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stations_SchoolId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Stations");
        }
    }
}
