using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoschematabelasanime_titlestudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animes_Studio_StudioId",
                schema: "content",
                table: "animes");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeTitle_animes_AnimeId",
                table: "AnimeTitle");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeTitle_languages_LanguageId",
                table: "AnimeTitle");

            migrationBuilder.DropForeignKey(
                name: "FK_logos_Studio_StudioId",
                schema: "content",
                table: "logos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studio",
                table: "Studio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeTitle",
                table: "AnimeTitle");

            migrationBuilder.RenameTable(
                name: "Studio",
                newName: "studios",
                newSchema: "common");

            migrationBuilder.RenameTable(
                name: "AnimeTitle",
                newName: "anime_titles",
                newSchema: "content");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeTitle_LanguageId",
                schema: "content",
                table: "anime_titles",
                newName: "IX_anime_titles_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeTitle_AnimeId",
                schema: "content",
                table: "anime_titles",
                newName: "IX_anime_titles_AnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studios",
                schema: "common",
                table: "studios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_anime_titles",
                schema: "content",
                table: "anime_titles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_anime_titles_animes_AnimeId",
                schema: "content",
                table: "anime_titles",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_anime_titles_languages_LanguageId",
                schema: "content",
                table: "anime_titles",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animes_studios_StudioId",
                schema: "content",
                table: "animes",
                column: "StudioId",
                principalSchema: "common",
                principalTable: "studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_logos_studios_StudioId",
                schema: "content",
                table: "logos",
                column: "StudioId",
                principalSchema: "common",
                principalTable: "studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anime_titles_animes_AnimeId",
                schema: "content",
                table: "anime_titles");

            migrationBuilder.DropForeignKey(
                name: "FK_anime_titles_languages_LanguageId",
                schema: "content",
                table: "anime_titles");

            migrationBuilder.DropForeignKey(
                name: "FK_animes_studios_StudioId",
                schema: "content",
                table: "animes");

            migrationBuilder.DropForeignKey(
                name: "FK_logos_studios_StudioId",
                schema: "content",
                table: "logos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studios",
                schema: "common",
                table: "studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_anime_titles",
                schema: "content",
                table: "anime_titles");

            migrationBuilder.RenameTable(
                name: "studios",
                schema: "common",
                newName: "Studio");

            migrationBuilder.RenameTable(
                name: "anime_titles",
                schema: "content",
                newName: "AnimeTitle");

            migrationBuilder.RenameIndex(
                name: "IX_anime_titles_LanguageId",
                table: "AnimeTitle",
                newName: "IX_AnimeTitle_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_anime_titles_AnimeId",
                table: "AnimeTitle",
                newName: "IX_AnimeTitle_AnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studio",
                table: "Studio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeTitle",
                table: "AnimeTitle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_animes_Studio_StudioId",
                schema: "content",
                table: "animes",
                column: "StudioId",
                principalTable: "Studio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeTitle_animes_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeTitle_languages_LanguageId",
                table: "AnimeTitle",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_logos_Studio_StudioId",
                schema: "content",
                table: "logos",
                column: "StudioId",
                principalTable: "Studio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
