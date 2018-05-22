using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedStartandEndDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EffectiveDate",
                table: "EmployeeStations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Effective",
                table: "EmployeePositions",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeStations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "EmployeePositions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeDesignations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeDesignations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Advisers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Advisers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "EmployeeStations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "EmployeePositions");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "EmployeeDesignations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EmployeeDesignations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Advisers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Advisers");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "EmployeeStations",
                newName: "EffectiveDate");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "EmployeePositions",
                newName: "Effective");
        }
    }
}
