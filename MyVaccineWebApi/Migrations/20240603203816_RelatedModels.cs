using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVaccineWebApi.Migrations
{
    /// <inheritdoc />
    public partial class RelatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FamilyGroups_FamilyGroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FamilyGroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FirstName",
                table: "Users",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastName",
                table: "Users",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FamilyGroupUser",
                columns: table => new
                {
                    FamilyGroupsFamilyGroupId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroupUser", x => new { x.FamilyGroupsFamilyGroupId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_FamilyGroupUser_FamilyGroups_FamilyGroupsFamilyGroupId",
                        column: x => x.FamilyGroupsFamilyGroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "FamilyGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyGroupUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AspNetUserId",
                table: "Users",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyGroupUser_UsersUserId",
                table: "FamilyGroupUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUserId",
                table: "Users",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUserId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FamilyGroupUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_AspNetUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FamilyGroupId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FamilyGroups_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "FamilyGroupId");
        }
    }
}
