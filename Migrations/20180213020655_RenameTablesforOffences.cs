using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class RenameTablesforOffences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvolveStudent_SectionStudents_SectionStudentId",
                table: "InvolveStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_InvolveStudent_StudentCase_StudentCaseId",
                table: "InvolveStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentOffense_InvolveStudent_InvolveStudentId",
                table: "StudentOffense");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentOffense_Offense_OffenseId",
                table: "StudentOffense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentOffense",
                table: "StudentOffense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCase",
                table: "StudentCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvolveStudent",
                table: "InvolveStudent");

            migrationBuilder.RenameTable(
                name: "StudentOffense",
                newName: "StudentOffenses");

            migrationBuilder.RenameTable(
                name: "StudentCase",
                newName: "StudentCases");

            migrationBuilder.RenameTable(
                name: "InvolveStudent",
                newName: "InvolveStudents");

            migrationBuilder.RenameIndex(
                name: "IX_StudentOffense_InvolveStudentId_OffenseId",
                table: "StudentOffenses",
                newName: "IX_StudentOffenses_InvolveStudentId_OffenseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentOffense_OffenseId",
                table: "StudentOffenses",
                newName: "IX_StudentOffenses_OffenseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCase_Incident",
                table: "StudentCases",
                newName: "IX_StudentCases_Incident");

            migrationBuilder.RenameIndex(
                name: "IX_InvolveStudent_SectionStudentId_StudentCaseId",
                table: "InvolveStudents",
                newName: "IX_InvolveStudents_SectionStudentId_StudentCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_InvolveStudent_StudentCaseId",
                table: "InvolveStudents",
                newName: "IX_InvolveStudents_StudentCaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentOffenses",
                table: "StudentOffenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCases",
                table: "StudentCases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvolveStudents",
                table: "InvolveStudents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvolveStudents_SectionStudents_SectionStudentId",
                table: "InvolveStudents",
                column: "SectionStudentId",
                principalTable: "SectionStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvolveStudents_StudentCases_StudentCaseId",
                table: "InvolveStudents",
                column: "StudentCaseId",
                principalTable: "StudentCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOffenses_InvolveStudents_InvolveStudentId",
                table: "StudentOffenses",
                column: "InvolveStudentId",
                principalTable: "InvolveStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOffenses_Offense_OffenseId",
                table: "StudentOffenses",
                column: "OffenseId",
                principalTable: "Offense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvolveStudents_SectionStudents_SectionStudentId",
                table: "InvolveStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_InvolveStudents_StudentCases_StudentCaseId",
                table: "InvolveStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentOffenses_InvolveStudents_InvolveStudentId",
                table: "StudentOffenses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentOffenses_Offense_OffenseId",
                table: "StudentOffenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentOffenses",
                table: "StudentOffenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCases",
                table: "StudentCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvolveStudents",
                table: "InvolveStudents");

            migrationBuilder.RenameTable(
                name: "StudentOffenses",
                newName: "StudentOffense");

            migrationBuilder.RenameTable(
                name: "StudentCases",
                newName: "StudentCase");

            migrationBuilder.RenameTable(
                name: "InvolveStudents",
                newName: "InvolveStudent");

            migrationBuilder.RenameIndex(
                name: "IX_StudentOffenses_InvolveStudentId_OffenseId",
                table: "StudentOffense",
                newName: "IX_StudentOffense_InvolveStudentId_OffenseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentOffenses_OffenseId",
                table: "StudentOffense",
                newName: "IX_StudentOffense_OffenseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCases_Incident",
                table: "StudentCase",
                newName: "IX_StudentCase_Incident");

            migrationBuilder.RenameIndex(
                name: "IX_InvolveStudents_SectionStudentId_StudentCaseId",
                table: "InvolveStudent",
                newName: "IX_InvolveStudent_SectionStudentId_StudentCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_InvolveStudents_StudentCaseId",
                table: "InvolveStudent",
                newName: "IX_InvolveStudent_StudentCaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentOffense",
                table: "StudentOffense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCase",
                table: "StudentCase",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvolveStudent",
                table: "InvolveStudent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvolveStudent_SectionStudents_SectionStudentId",
                table: "InvolveStudent",
                column: "SectionStudentId",
                principalTable: "SectionStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvolveStudent_StudentCase_StudentCaseId",
                table: "InvolveStudent",
                column: "StudentCaseId",
                principalTable: "StudentCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOffense_InvolveStudent_InvolveStudentId",
                table: "StudentOffense",
                column: "InvolveStudentId",
                principalTable: "InvolveStudent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOffense_Offense_OffenseId",
                table: "StudentOffense",
                column: "OffenseId",
                principalTable: "Offense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
