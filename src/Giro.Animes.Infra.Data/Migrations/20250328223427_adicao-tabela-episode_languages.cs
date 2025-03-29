using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaotabelaepisode_languages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_languages_episodes_EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "IX_languages_EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.CreateTable(
                name: "episode_languages",
                schema: "content",
                columns: table => new
                {
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episode_languages", x => new { x.EpisodeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_episode_languages_episodes_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "content",
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_episode_languages_languages_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_episode_languages_LanguageId",
                schema: "content",
                table: "episode_languages",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "episode_languages",
                schema: "content");

            migrationBuilder.AddColumn<long>(
                name: "EpisodeId",
                schema: "common",
                table: "languages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_languages_EpisodeId",
                schema: "common",
                table: "languages",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_languages_episodes_EpisodeId",
                schema: "common",
                table: "languages",
                column: "EpisodeId",
                principalSchema: "content",
                principalTable: "episodes",
                principalColumn: "Id");
        }
    }
}
