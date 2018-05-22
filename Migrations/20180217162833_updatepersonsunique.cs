using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class updatepersonsunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UIX_Persons_FullName",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UIX_Persons_FullName",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SuffixName",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UIX_Persons_FullName",
                table: "Persons",
                columns: new[] { "Title", "FirstName", "MiddleName", "LastName", "SuffixName" });
        }
    }
}
