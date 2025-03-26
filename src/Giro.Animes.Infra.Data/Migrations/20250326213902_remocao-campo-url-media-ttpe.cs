using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class remocaocampourlmediattpe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
