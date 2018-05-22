using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Positions_PositionId",
                table: "EmployeeStations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "EmployeeStations",
                nullable: false,
                defaultValueSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDesignation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDesignation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDesignation_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDesignation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designation_Name",
                table: "Designation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignation_DesignationId",
                table: "EmployeeDesignation",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignation_EmployeeId",
                table: "EmployeeDesignation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_Name",
                table: "Level",
                column: "Name",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Positions_PositionId",
                table: "EmployeeStations");

            migrationBuilder.DropTable(
                name: "EmployeeDesignation");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "EmployeeStations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GetUtcDate()");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStations_Positions_PositionId",
                table: "EmployeeStations",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
