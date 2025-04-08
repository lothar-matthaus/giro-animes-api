using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaonometabelasinopseparaanimesinopses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sinopses_animes_AnimeId",
                schema: "content",
                table: "sinopses");

            migrationBuilder.DropForeignKey(
                name: "FK_sinopses_languages_LanguageId",
                schema: "content",
                table: "sinopses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sinopses",
                schema: "content",
                table: "sinopses");

            migrationBuilder.RenameTable(
                name: "sinopses",
                schema: "content",
                newName: "anime_sinopses",
                newSchema: "content");

            migrationBuilder.RenameIndex(
                name: "IX_sinopses_LanguageId",
                schema: "content",
                table: "anime_sinopses",
                newName: "IX_anime_sinopses_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_sinopses_AnimeId",
                schema: "content",
                table: "anime_sinopses",
                newName: "IX_anime_sinopses_AnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_anime_sinopses",
                schema: "content",
                table: "anime_sinopses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_anime_sinopses_animes_AnimeId",
                schema: "content",
                table: "anime_sinopses",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_anime_sinopses_languages_LanguageId",
                schema: "content",
                table: "anime_sinopses",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anime_sinopses_animes_AnimeId",
                schema: "content",
                table: "anime_sinopses");

            migrationBuilder.DropForeignKey(
                name: "FK_anime_sinopses_languages_LanguageId",
                schema: "content",
                table: "anime_sinopses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_anime_sinopses",
                schema: "content",
                table: "anime_sinopses");

            migrationBuilder.RenameTable(
                name: "anime_sinopses",
                schema: "content",
                newName: "sinopses",
                newSchema: "content");

            migrationBuilder.RenameIndex(
                name: "IX_anime_sinopses_LanguageId",
                schema: "content",
                table: "sinopses",
                newName: "IX_sinopses_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_anime_sinopses_AnimeId",
                schema: "content",
                table: "sinopses",
                newName: "IX_sinopses_AnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sinopses",
                schema: "content",
                table: "sinopses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sinopses_animes_AnimeId",
                schema: "content",
                table: "sinopses",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sinopses_languages_LanguageId",
                schema: "content",
                table: "sinopses",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
