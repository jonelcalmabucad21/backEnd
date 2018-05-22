using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedOffernse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OffenseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Name = table.Column<string>(nullable: false),
                    OffenseTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offense_OffenseType_OffenseTypeId",
                        column: x => x.OffenseTypeId,
                        principalTable: "OffenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offense_Name",
                table: "Offense",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offense_OffenseTypeId",
                table: "Offense",
                column: "OffenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OffenseType_Name",
                table: "OffenseType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offense");

            migrationBuilder.DropTable(
                name: "OffenseType");
        }
    }
}
