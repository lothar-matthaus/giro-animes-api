using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoisconfirmedparaaccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings",
                column: "InterfaceLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings",
                column: "InterfaceLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");
        }
    }
}
