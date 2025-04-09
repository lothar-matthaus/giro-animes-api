using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class testes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_languages_episodes_EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropForeignKey(
                name: "FK_languages_episodes_EpisodeId1",
                schema: "common",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "IX_languages_EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "IX_languages_EpisodeId1",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "EpisodeId1",
                schema: "common",
                table: "languages");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "genre_descriptions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "episode_sinopses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "common",
                table: "biographies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "anime_sinopses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EpisodeId",
                schema: "common",
                table: "languages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EpisodeId1",
                schema: "common",
                table: "languages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "genre_descriptions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "episode_sinopses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "common",
                table: "biographies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "anime_sinopses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_languages_EpisodeId",
                schema: "common",
                table: "languages",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_languages_EpisodeId1",
                schema: "common",
                table: "languages",
                column: "EpisodeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_languages_episodes_EpisodeId",
                schema: "common",
                table: "languages",
                column: "EpisodeId",
                principalSchema: "content",
                principalTable: "episodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_languages_episodes_EpisodeId1",
                schema: "common",
                table: "languages",
                column: "EpisodeId1",
                principalSchema: "content",
                principalTable: "episodes",
                principalColumn: "Id");
        }
    }
}
