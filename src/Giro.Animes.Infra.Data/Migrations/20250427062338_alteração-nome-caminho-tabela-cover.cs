using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãonomecaminhotabelacover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "content",
                table: "logos",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "content",
                table: "episode_files",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "content",
                table: "covers",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "content",
                table: "avatars",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "content",
                table: "anime_screenshots",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "content",
                table: "logos",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "content",
                table: "episode_files",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "content",
                table: "covers",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "content",
                table: "avatars",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "content",
                table: "anime_screenshots",
                newName: "Url");
        }
    }
}
