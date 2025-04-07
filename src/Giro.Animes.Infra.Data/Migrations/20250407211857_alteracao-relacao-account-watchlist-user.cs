using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaorelacaoaccountwatchlistuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings");

            migrationBuilder.DropForeignKey(
                name: "FK_watchlist_accounts_AccountId",
                schema: "content",
                table: "watchlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_watchlist",
                schema: "content",
                table: "watchlist");

            migrationBuilder.DropIndex(
                name: "IX_watchlist_AnimeId",
                schema: "content",
                table: "watchlist");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                schema: "content",
                table: "watchlist",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_watchlist",
                schema: "content",
                table: "watchlist",
                columns: new[] { "AnimeId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_watchlist_UserId",
                schema: "content",
                table: "watchlist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings",
                column: "InterfaceLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_watchlist_users_UserId",
                schema: "content",
                table: "watchlist",
                column: "UserId",
                principalSchema: "management",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings");

            migrationBuilder.DropForeignKey(
                name: "FK_watchlist_users_UserId",
                schema: "content",
                table: "watchlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_watchlist",
                schema: "content",
                table: "watchlist");

            migrationBuilder.DropIndex(
                name: "IX_watchlist_UserId",
                schema: "content",
                table: "watchlist");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "content",
                table: "watchlist",
                newName: "AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_watchlist",
                schema: "content",
                table: "watchlist",
                columns: new[] { "AccountId", "AnimeId" });

            migrationBuilder.CreateIndex(
                name: "IX_watchlist_AnimeId",
                schema: "content",
                table: "watchlist",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings",
                column: "InterfaceLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watchlist_accounts_AccountId",
                schema: "content",
                table: "watchlist",
                column: "AccountId",
                principalSchema: "management",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
