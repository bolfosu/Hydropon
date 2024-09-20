using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydropon.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserSettings",
                newName: "NotificationEmail");

            migrationBuilder.AddColumn<int>(
                name: "DefaultPlantProfileId",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NotificationsEnabled",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyOnECThreshold",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyOnPHThreshold",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyOnSystemFailure",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyOnWaterLevelLow",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MinPH = table.Column<decimal>(type: "TEXT", nullable: false),
                    MaxPH = table.Column<decimal>(type: "TEXT", nullable: false),
                    MinEC = table.Column<decimal>(type: "TEXT", nullable: false),
                    MaxEC = table.Column<decimal>(type: "TEXT", nullable: false),
                    LightOnTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    LightOffTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_DefaultPlantProfileId",
                table: "UserSettings",
                column: "DefaultPlantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantProfiles_UserId",
                table: "PlantProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_PlantProfiles_DefaultPlantProfileId",
                table: "UserSettings",
                column: "DefaultPlantProfileId",
                principalTable: "PlantProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Users_UserId",
                table: "UserSettings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_PlantProfiles_DefaultPlantProfileId",
                table: "UserSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_UserId",
                table: "UserSettings");

            migrationBuilder.DropTable(
                name: "PlantProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_DefaultPlantProfileId",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "DefaultPlantProfileId",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "NotificationsEnabled",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "NotifyOnECThreshold",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "NotifyOnPHThreshold",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "NotifyOnSystemFailure",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "NotifyOnWaterLevelLow",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSettings");

            migrationBuilder.RenameColumn(
                name: "NotificationEmail",
                table: "UserSettings",
                newName: "Username");
        }
    }
}
