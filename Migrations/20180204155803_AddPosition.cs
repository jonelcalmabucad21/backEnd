using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Stations_StationId",
                table: "EmployeeStations");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "EmployeeStations",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "EffectiveDate",
                table: "EmployeeStations",
                newName: "Effective");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStations_StationId",
                table: "EmployeeStations",
                newName: "IX_EmployeeStations_PositionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "EmployeeStations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GetUtcDate()");

            migrationBuilder.CreateTable(
                name: "EmployeeStation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    StationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeStation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeStation_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStation_EmployeeId",
                table: "EmployeeStation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStation_StationId",
                table: "EmployeeStation",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Employees_EmployeeId",
                table: "EmployeeStations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStations_Positions_PositionId",
                table: "EmployeeStations");

            migrationBuilder.DropTable(
                name: "EmployeeStation");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "EmployeeStations",
                newName: "StationId");

            migrationBuilder.RenameColumn(
                name: "Effective",
                table: "EmployeeStations",
                newName: "EffectiveDate");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStations_PositionId",
                table: "EmployeeStations",
                newName: "IX_EmployeeStations_StationId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "EmployeeStations",
                nullable: false,
                defaultValueSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));

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
    }
}
