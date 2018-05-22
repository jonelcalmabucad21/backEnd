using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace backEnd.Migrations
{
    public partial class addedstudentaddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddress_Barangays_BarangayId",
                table: "StudentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddress_Municipalities_MunicipalityId",
                table: "StudentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddress_Provinces_ProvinceId",
                table: "StudentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddress_Streets_StreetId",
                table: "StudentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddress_Students_StudentId",
                table: "StudentAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAddress",
                table: "StudentAddress");

            migrationBuilder.RenameTable(
                name: "StudentAddress",
                newName: "StudentAdresses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAddress_StudentId_ProvinceId_BarangayId_MunicipalityId",
                table: "StudentAdresses",
                newName: "IX_StudentAdresses_StudentId_ProvinceId_BarangayId_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAddress_StreetId",
                table: "StudentAdresses",
                newName: "IX_StudentAdresses_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAddress_ProvinceId",
                table: "StudentAdresses",
                newName: "IX_StudentAdresses_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAddress_MunicipalityId",
                table: "StudentAdresses",
                newName: "IX_StudentAdresses_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAddress_BarangayId",
                table: "StudentAdresses",
                newName: "IX_StudentAdresses_BarangayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAdresses",
                table: "StudentAdresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdresses_Barangays_BarangayId",
                table: "StudentAdresses",
                column: "BarangayId",
                principalTable: "Barangays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdresses_Municipalities_MunicipalityId",
                table: "StudentAdresses",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdresses_Provinces_ProvinceId",
                table: "StudentAdresses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdresses_Streets_StreetId",
                table: "StudentAdresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdresses_Students_StudentId",
                table: "StudentAdresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdresses_Barangays_BarangayId",
                table: "StudentAdresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdresses_Municipalities_MunicipalityId",
                table: "StudentAdresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdresses_Provinces_ProvinceId",
                table: "StudentAdresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdresses_Streets_StreetId",
                table: "StudentAdresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdresses_Students_StudentId",
                table: "StudentAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAdresses",
                table: "StudentAdresses");

            migrationBuilder.RenameTable(
                name: "StudentAdresses",
                newName: "StudentAddress");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAdresses_StudentId_ProvinceId_BarangayId_MunicipalityId",
                table: "StudentAddress",
                newName: "IX_StudentAddress_StudentId_ProvinceId_BarangayId_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAdresses_StreetId",
                table: "StudentAddress",
                newName: "IX_StudentAddress_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAdresses_ProvinceId",
                table: "StudentAddress",
                newName: "IX_StudentAddress_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAdresses_MunicipalityId",
                table: "StudentAddress",
                newName: "IX_StudentAddress_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAdresses_BarangayId",
                table: "StudentAddress",
                newName: "IX_StudentAddress_BarangayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAddress",
                table: "StudentAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddress_Barangays_BarangayId",
                table: "StudentAddress",
                column: "BarangayId",
                principalTable: "Barangays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddress_Municipalities_MunicipalityId",
                table: "StudentAddress",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddress_Provinces_ProvinceId",
                table: "StudentAddress",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddress_Streets_StreetId",
                table: "StudentAddress",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddress_Students_StudentId",
                table: "StudentAddress",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
