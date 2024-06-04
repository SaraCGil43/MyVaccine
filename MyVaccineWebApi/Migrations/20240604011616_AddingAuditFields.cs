using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVaccineWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vaccines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vaccines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VaccineRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "VaccineRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FamilyGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "FamilyGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Dependents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Dependents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VaccineRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VaccineRecords");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FamilyGroups");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "FamilyGroups");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Allergies");
        }
    }
}
