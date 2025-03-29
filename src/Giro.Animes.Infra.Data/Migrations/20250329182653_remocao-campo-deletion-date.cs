using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class remocaocampodeletiondate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "watchlist");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "management",
                table: "users");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "common",
                table: "studios");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "sinopses");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "settings_anime_languages");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "management",
                table: "settings");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "ratings");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "logos");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "common",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "genre_titles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "genre_descriptions");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "episode_titles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "episode_sinopses");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "episode_languages");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "covers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "common",
                table: "biographies");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "avatars");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "common",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "author_works");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "animes_genres");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "animes");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "anime_titles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "content",
                table: "anime_screenshots");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                schema: "management",
                table: "accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "AirDate",
                schema: "content",
                table: "episodes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirDate",
                schema: "content",
                table: "episodes");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "watchlist",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "settings_anime_languages",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_sinopses",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_languages",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "author_works",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "animes_genres",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: true);
        }
    }
}
