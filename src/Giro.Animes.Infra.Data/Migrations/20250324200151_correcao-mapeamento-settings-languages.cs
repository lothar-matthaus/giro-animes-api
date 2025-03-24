using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class correcaomapeamentosettingslanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_LanguageId1",
                schema: "common",
                table: "settings");

            migrationBuilder.DropIndex(
                name: "IX_settings_LanguageId1",
                schema: "common",
                table: "settings");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                schema: "common",
                table: "settings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LanguageId1",
                schema: "common",
                table: "settings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_settings_LanguageId1",
                schema: "common",
                table: "settings",
                column: "LanguageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_LanguageId1",
                schema: "common",
                table: "settings",
                column: "LanguageId1",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");
        }
    }
}
