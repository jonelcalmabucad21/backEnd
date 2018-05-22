using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class AddedUniquePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UIX_Persons_FullName",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "SuffixName",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FirstName_MiddleName_LastName_SuffixName",
                table: "Persons",
                columns: new[] { "FirstName", "MiddleName", "LastName", "SuffixName" },
                unique: true,
                filter: "[SuffixName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_FirstName_MiddleName_LastName_SuffixName",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "SuffixName",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UIX_Persons_FullName",
                table: "Persons",
                columns: new[] { "FirstName", "MiddleName", "LastName" });
        }
    }
}
