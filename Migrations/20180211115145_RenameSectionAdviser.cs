using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class RenameSectionAdviser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionAdviser_Employees_EmployeeId",
                table: "SectionAdviser");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionAdviser_LevelSections_LevelSectionId",
                table: "SectionAdviser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionAdviser",
                table: "SectionAdviser");

            migrationBuilder.RenameTable(
                name: "SectionAdviser",
                newName: "SectionAdvisers");

            migrationBuilder.RenameIndex(
                name: "IX_SectionAdviser_LevelSectionId",
                table: "SectionAdvisers",
                newName: "IX_SectionAdvisers_LevelSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionAdviser_EmployeeId",
                table: "SectionAdvisers",
                newName: "IX_SectionAdvisers_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionAdvisers",
                table: "SectionAdvisers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionAdvisers_Employees_EmployeeId",
                table: "SectionAdvisers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionAdvisers_LevelSections_LevelSectionId",
                table: "SectionAdvisers",
                column: "LevelSectionId",
                principalTable: "LevelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionAdvisers_Employees_EmployeeId",
                table: "SectionAdvisers");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionAdvisers_LevelSections_LevelSectionId",
                table: "SectionAdvisers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionAdvisers",
                table: "SectionAdvisers");

            migrationBuilder.RenameTable(
                name: "SectionAdvisers",
                newName: "SectionAdviser");

            migrationBuilder.RenameIndex(
                name: "IX_SectionAdvisers_LevelSectionId",
                table: "SectionAdviser",
                newName: "IX_SectionAdviser_LevelSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionAdvisers_EmployeeId",
                table: "SectionAdviser",
                newName: "IX_SectionAdviser_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionAdviser",
                table: "SectionAdviser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionAdviser_Employees_EmployeeId",
                table: "SectionAdviser",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionAdviser_LevelSections_LevelSectionId",
                table: "SectionAdviser",
                column: "LevelSectionId",
                principalTable: "LevelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
