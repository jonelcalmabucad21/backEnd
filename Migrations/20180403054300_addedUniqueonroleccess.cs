using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedUniqueonroleccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoleAccess_RoleId",
                table: "RoleAccess");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccess_RoleId_AccessId",
                table: "RoleAccess",
                columns: new[] { "RoleId", "AccessId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoleAccess_RoleId_AccessId",
                table: "RoleAccess");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccess_RoleId",
                table: "RoleAccess",
                column: "RoleId");
        }
    }
}
