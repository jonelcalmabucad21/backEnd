using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addeduniqueemployeeStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeStations_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStations_EmployeeId_StationId",
                table: "EmployeeStations",
                columns: new[] { "EmployeeId", "StationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeStations_EmployeeId_StationId",
                table: "EmployeeStations");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStations_EmployeeId",
                table: "EmployeeStations",
                column: "EmployeeId");
        }
    }
}
