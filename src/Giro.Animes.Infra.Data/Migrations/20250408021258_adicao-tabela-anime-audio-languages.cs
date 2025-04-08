using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaotabelaanimeaudiolanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings_anime_languages",
                schema: "content");

            migrationBuilder.CreateTable(
                name: "settings_anime_audio_languages",
                schema: "content",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    SettingsId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings_anime_audio_languages", x => new { x.LanguageId, x.SettingsId });
                    table.ForeignKey(
                        name: "FK_settings_anime_audio_languages_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_anime_audio_languages_settings_SettingsId",
                        column: x => x.SettingsId,
                        principalSchema: "management",
                        principalTable: "settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "settings_anime_subtitle_languages",
                schema: "content",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    SettingsId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings_anime_subtitle_languages", x => new { x.LanguageId, x.SettingsId });
                    table.ForeignKey(
                        name: "FK_settings_anime_subtitle_languages_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_anime_subtitle_languages_settings_SettingsId",
                        column: x => x.SettingsId,
                        principalSchema: "management",
                        principalTable: "settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_settings_anime_audio_languages_SettingsId",
                schema: "content",
                table: "settings_anime_audio_languages",
                column: "SettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_settings_anime_subtitle_languages_SettingsId",
                schema: "content",
                table: "settings_anime_subtitle_languages",
                column: "SettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings_anime_audio_languages",
                schema: "content");

            migrationBuilder.DropTable(
                name: "settings_anime_subtitle_languages",
                schema: "content");

            migrationBuilder.CreateTable(
                name: "settings_anime_languages",
                schema: "content",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    SettingsId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings_anime_languages", x => new { x.LanguageId, x.SettingsId });
                    table.ForeignKey(
                        name: "FK_settings_anime_languages_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_anime_languages_settings_SettingsId",
                        column: x => x.SettingsId,
                        principalSchema: "management",
                        principalTable: "settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_settings_anime_languages_SettingsId",
                schema: "content",
                table: "settings_anime_languages",
                column: "SettingsId");
        }
    }
}
