using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãocamposurlparasalvarapenascaminho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_covers_animes_AnimeId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropForeignKey(
                name: "FK_covers_languages_LanguageId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropIndex(
                name: "IX_covers_AnimeId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropIndex(
                name: "IX_covers_LanguageId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "Extension",
                schema: "content",
                table: "logos");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "content",
                table: "logos");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "content",
                table: "logos");

            migrationBuilder.DropColumn(
                name: "Extension",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "Extension",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "Extension",
                schema: "content",
                table: "avatars");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "content",
                table: "avatars");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "content",
                table: "avatars");

            migrationBuilder.DropColumn(
                name: "Extension",
                schema: "content",
                table: "anime_screenshots");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "content",
                table: "anime_screenshots");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "content",
                table: "anime_screenshots");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "logos",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "episode_files",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "covers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "avatars",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "anime_screenshots",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_covers_AnimeId",
                schema: "content",
                table: "covers",
                column: "AnimeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_covers_animes_AnimeId",
                schema: "content",
                table: "covers",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_covers_animes_AnimeId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropIndex(
                name: "IX_covers_AnimeId",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "content",
                table: "logos");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "content",
                table: "avatars");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "content",
                table: "anime_screenshots");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "covers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_covers_AnimeId",
                schema: "content",
                table: "covers",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_covers_LanguageId",
                schema: "content",
                table: "covers",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_covers_animes_AnimeId",
                schema: "content",
                table: "covers",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_covers_languages_LanguageId",
                schema: "content",
                table: "covers",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
