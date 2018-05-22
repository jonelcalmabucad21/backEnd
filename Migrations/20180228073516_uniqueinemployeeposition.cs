using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class uniqueinemployeeposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeePositions");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_EmployeeId_PositionId",
                table: "EmployeePositions",
                columns: new[] { "EmployeeId", "PositionId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeePositions_EmployeeId_PositionId",
                table: "EmployeePositions");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeePositions",
                column: "EmployeeId");
        }
    }
}
