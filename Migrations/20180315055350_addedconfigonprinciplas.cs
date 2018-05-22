using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedconfigonprinciplas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Principals_EmployeeId",
                table: "Principals");

            migrationBuilder.AddColumn<int>(
                name: "SchoolYear",
                table: "Principals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "Principals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Principals_StationId",
                table: "Principals",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_EmployeeId_SchoolYear_StationId",
                table: "Principals",
                columns: new[] { "EmployeeId", "SchoolYear", "StationId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_Stations_StationId",
                table: "Principals",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_Stations_StationId",
                table: "Principals");

            migrationBuilder.DropIndex(
                name: "IX_Principals_StationId",
                table: "Principals");

            migrationBuilder.DropIndex(
                name: "IX_Principals_EmployeeId_SchoolYear_StationId",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "Principals");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_EmployeeId",
                table: "Principals",
                column: "EmployeeId");
        }
    }
}
