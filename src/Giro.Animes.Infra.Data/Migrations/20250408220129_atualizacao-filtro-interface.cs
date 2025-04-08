using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaofiltrointerface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
