﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVaccineWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyGroups",
                columns: table => new
                {
                    FamilyGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroups", x => x.FamilyGroupId);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCategory",
                columns: table => new
                {
                    VaccineCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCategory", x => x.VaccineCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    RequiresBooster = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FamilyGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_FamilyGroups_FamilyGroupId",
                        column: x => x.FamilyGroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "FamilyGroupId");
                });

            migrationBuilder.CreateTable(
                name: "VaccineCategoryVaccines",
                columns: table => new
                {
                    CategoriesVaccineCategoryId = table.Column<int>(type: "int", nullable: false),
                    VaccinesVaccineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCategoryVaccines", x => new { x.CategoriesVaccineCategoryId, x.VaccinesVaccineId });
                    table.ForeignKey(
                        name: "FK_VaccineCategoryVaccines_VaccineCategory_CategoriesVaccineCategoryId",
                        column: x => x.CategoriesVaccineCategoryId,
                        principalTable: "VaccineCategory",
                        principalColumn: "VaccineCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccineCategoryVaccines_Vaccines_VaccinesVaccineId",
                        column: x => x.VaccinesVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_Allergies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    DependentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.DependentId);
                    table.ForeignKey(
                        name: "FK_Dependents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccineRecords",
                columns: table => new
                {
                    VaccineRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DependentId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    DateAdministered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministeredLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdministeredBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineRecords", x => x.VaccineRecordId);
                    table.ForeignKey(
                        name: "FK_VaccineRecords_Dependents_DependentId",
                        column: x => x.DependentId,
                        principalTable: "Dependents",
                        principalColumn: "DependentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccineRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_VaccineRecords_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_UserId",
                table: "Allergies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_UserId",
                table: "Dependents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCategoryVaccines_VaccinesVaccineId",
                table: "VaccineCategoryVaccines",
                column: "VaccinesVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineRecords_DependentId",
                table: "VaccineRecords",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineRecords_UserId",
                table: "VaccineRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineRecords_VaccineId",
                table: "VaccineRecords",
                column: "VaccineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "VaccineCategoryVaccines");

            migrationBuilder.DropTable(
                name: "VaccineRecords");

            migrationBuilder.DropTable(
                name: "VaccineCategory");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FamilyGroups");
        }
    }
}
