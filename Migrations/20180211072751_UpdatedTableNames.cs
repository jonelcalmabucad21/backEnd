using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class UpdatedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignation_Designation_DesignationId",
                table: "EmployeeDesignation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignation_Employees_EmployeeId",
                table: "EmployeeDesignation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStation_Employees_EmployeeId",
                table: "EmployeeStation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStation_Stations_StationId",
                table: "EmployeeStation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Positions_PositionId",
                table: "EmployeeStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Level",
                table: "Level");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStations",
                table: "EmployeeStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStation",
                table: "EmployeeStation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDesignation",
                table: "EmployeeDesignation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designation",
                table: "Designation");

            migrationBuilder.RenameTable(
                name: "Level",
                newName: "Levels");

            migrationBuilder.RenameTable(
                name: "EmployeeStations",
                newName: "EmployeePositions");

            migrationBuilder.RenameTable(
                name: "EmployeeStation",
                newName: "EmployeeStations");

            migrationBuilder.RenameTable(
                name: "EmployeeDesignation",
                newName: "EmployeeDesignations");

            migrationBuilder.RenameTable(
                name: "Designation",
                newName: "Designations");

            migrationBuilder.RenameIndex(
                name: "IX_Level_Name",
                table: "Levels",
                newName: "IX_Levels_Name");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStations_PositionId",
                table: "EmployeePositions",
                newName: "IX_EmployeePositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStations_EmployeeId",
                table: "EmployeePositions",
                newName: "IX_EmployeePositions_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStation_StationId",
                table: "EmployeeStations",
                newName: "IX_EmployeeStations_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStation_EmployeeId",
                table: "EmployeeStations",
                newName: "IX_EmployeeStations_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDesignation_EmployeeId",
                table: "EmployeeDesignations",
                newName: "IX_EmployeeDesignations_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDesignation_DesignationId",
                table: "EmployeeDesignations",
                newName: "IX_EmployeeDesignations_DesignationId");

            migrationBuilder.RenameIndex(
                name: "IX_Designation_Name",
                table: "Designations",
                newName: "IX_Designations_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Levels",
                table: "Levels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePositions",
                table: "EmployeePositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStations",
                table: "EmployeeStations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDesignations",
                table: "EmployeeDesignations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designations",
                table: "Designations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Employees_EmployeeId",
                table: "EmployeeDesignations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePositions_Employees_EmployeeId",
                table: "EmployeePositions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePositions_Positions_PositionId",
                table: "EmployeePositions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStations_Stations_StationId",
                table: "EmployeeStations",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Employees_EmployeeId",
                table: "EmployeeDesignations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePositions_Employees_EmployeeId",
                table: "EmployeePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePositions_Positions_PositionId",
                table: "EmployeePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Stations_StationId",
                table: "EmployeeStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Levels",
                table: "Levels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStations",
                table: "EmployeeStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePositions",
                table: "EmployeePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDesignations",
                table: "EmployeeDesignations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designations",
                table: "Designations");

            migrationBuilder.RenameTable(
                name: "Levels",
                newName: "Level");

            migrationBuilder.RenameTable(
                name: "EmployeeStations",
                newName: "EmployeeStation");

            migrationBuilder.RenameTable(
                name: "EmployeePositions",
                newName: "EmployeeStations");

            migrationBuilder.RenameTable(
                name: "EmployeeDesignations",
                newName: "EmployeeDesignation");

            migrationBuilder.RenameTable(
                name: "Designations",
                newName: "Designation");

            migrationBuilder.RenameIndex(
                name: "IX_Levels_Name",
                table: "Level",
                newName: "IX_Level_Name");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStations_StationId",
                table: "EmployeeStation",
                newName: "IX_EmployeeStation_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStations_EmployeeId",
                table: "EmployeeStation",
                newName: "IX_EmployeeStation_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeeStations",
                newName: "IX_EmployeeStations_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeeStations",
                newName: "IX_EmployeeStations_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDesignations_EmployeeId",
                table: "EmployeeDesignation",
                newName: "IX_EmployeeDesignation_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDesignations_DesignationId",
                table: "EmployeeDesignation",
                newName: "IX_EmployeeDesignation_DesignationId");

            migrationBuilder.RenameIndex(
                name: "IX_Designations_Name",
                table: "Designation",
                newName: "IX_Designation_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Level",
                table: "Level",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStation",
                table: "EmployeeStation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStations",
                table: "EmployeeStations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDesignation",
                table: "EmployeeDesignation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designation",
                table: "Designation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignation_Designation_DesignationId",
                table: "EmployeeDesignation",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignation_Employees_EmployeeId",
                table: "EmployeeDesignation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStation_Employees_EmployeeId",
                table: "EmployeeStation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStation_Stations_StationId",
                table: "EmployeeStation",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStations_Positions_PositionId",
                table: "EmployeeStations",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
