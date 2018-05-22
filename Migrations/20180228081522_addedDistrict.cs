using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UIX_Stations_StationNumber",
                table: "Stations",
                newName: "IX_Stations_StationNumber");

            migrationBuilder.RenameIndex(
                name: "UIX_Stations_Name",
                table: "Stations",
                newName: "IX_Stations_Name");

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Name",
                table: "Districts",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.RenameIndex(
                name: "IX_Stations_StationNumber",
                table: "Stations",
                newName: "UIX_Stations_StationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Stations_Name",
                table: "Stations",
                newName: "UIX_Stations_Name");
        }
    }
}
