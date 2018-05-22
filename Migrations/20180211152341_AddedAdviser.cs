using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedAdviser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionAdvisers_Employees_EmployeeId",
                table: "SectionAdvisers");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "SectionAdvisers",
                newName: "AdviserId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionAdvisers_EmployeeId",
                table: "SectionAdvisers",
                newName: "IX_SectionAdvisers_AdviserId");

            migrationBuilder.CreateTable(
                name: "Advisers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advisers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisers_EmployeeId",
                table: "Advisers",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionAdvisers_Advisers_AdviserId",
                table: "SectionAdvisers",
                column: "AdviserId",
                principalTable: "Advisers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionAdvisers_Advisers_AdviserId",
                table: "SectionAdvisers");

            migrationBuilder.DropTable(
                name: "Advisers");

            migrationBuilder.RenameColumn(
                name: "AdviserId",
                table: "SectionAdvisers",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionAdvisers_AdviserId",
                table: "SectionAdvisers",
                newName: "IX_SectionAdvisers_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionAdvisers_Employees_EmployeeId",
                table: "SectionAdvisers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
