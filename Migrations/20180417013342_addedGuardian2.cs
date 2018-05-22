using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedGuardian2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guardian_Persons_PersonId",
                table: "Guardian");

            migrationBuilder.DropForeignKey(
                name: "FK_Guardian_Relation_RelationId",
                table: "Guardian");

            migrationBuilder.DropForeignKey(
                name: "FK_Guardian_Students_StudentId",
                table: "Guardian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relation",
                table: "Relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guardian",
                table: "Guardian");

            migrationBuilder.RenameTable(
                name: "Relation",
                newName: "Relations");

            migrationBuilder.RenameTable(
                name: "Guardian",
                newName: "Guardians");

            migrationBuilder.RenameIndex(
                name: "IX_Relation_Name",
                table: "Relations",
                newName: "IX_Relations_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Guardian_StudentId",
                table: "Guardians",
                newName: "IX_Guardians_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Guardian_RelationId",
                table: "Guardians",
                newName: "IX_Guardians_RelationId");

            migrationBuilder.RenameIndex(
                name: "IX_Guardian_PersonId",
                table: "Guardians",
                newName: "IX_Guardians_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guardians",
                table: "Guardians",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Persons_PersonId",
                table: "Guardians",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Relations_RelationId",
                table: "Guardians",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Students_StudentId",
                table: "Guardians",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Persons_PersonId",
                table: "Guardians");

            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Relations_RelationId",
                table: "Guardians");

            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Students_StudentId",
                table: "Guardians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guardians",
                table: "Guardians");

            migrationBuilder.RenameTable(
                name: "Relations",
                newName: "Relation");

            migrationBuilder.RenameTable(
                name: "Guardians",
                newName: "Guardian");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_Name",
                table: "Relation",
                newName: "IX_Relation_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Guardians_StudentId",
                table: "Guardian",
                newName: "IX_Guardian_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Guardians_RelationId",
                table: "Guardian",
                newName: "IX_Guardian_RelationId");

            migrationBuilder.RenameIndex(
                name: "IX_Guardians_PersonId",
                table: "Guardian",
                newName: "IX_Guardian_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relation",
                table: "Relation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guardian",
                table: "Guardian",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guardian_Persons_PersonId",
                table: "Guardian",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guardian_Relation_RelationId",
                table: "Guardian",
                column: "RelationId",
                principalTable: "Relation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guardian_Students_StudentId",
                table: "Guardian",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
