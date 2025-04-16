using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracatabelassettingsaudiosubtitleepermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                schema: "management",
                table: "permissions");

            migrationBuilder.RenameTable(
                name: "settings_anime_subtitle_languages",
                schema: "content",
                newName: "settings_anime_subtitle_languages",
                newSchema: "management");

            migrationBuilder.RenameTable(
                name: "settings_anime_audio_languages",
                schema: "content",
                newName: "settings_anime_audio_languages",
                newSchema: "management");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "management",
                table: "permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGuest",
                schema: "management",
                table: "permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "user_permissions",
                schema: "management",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_permissions", x => new { x.PermissionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_user_permissions_permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "management",
                        principalTable: "permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_permissions_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "management",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_permissions_UserId",
                schema: "management",
                table: "user_permissions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_permissions",
                schema: "management");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "management",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "IsGuest",
                schema: "management",
                table: "permissions");

            migrationBuilder.RenameTable(
                name: "settings_anime_subtitle_languages",
                schema: "management",
                newName: "settings_anime_subtitle_languages",
                newSchema: "content");

            migrationBuilder.RenameTable(
                name: "settings_anime_audio_languages",
                schema: "management",
                newName: "settings_anime_audio_languages",
                newSchema: "content");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                schema: "management",
                table: "permissions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
