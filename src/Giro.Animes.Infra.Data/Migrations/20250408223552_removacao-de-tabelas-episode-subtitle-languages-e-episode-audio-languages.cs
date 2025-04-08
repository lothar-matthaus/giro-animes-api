using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class removacaodetabelasepisodesubtitlelanguageseepisodeaudiolanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "episode_audio_languages",
                schema: "content");

            migrationBuilder.DropTable(
                name: "episode_subtitle_languages",
                schema: "content");

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "episodes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId1",
                schema: "content",
                table: "episodes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_episodes_LanguageId",
                schema: "content",
                table: "episodes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_episodes_LanguageId1",
                schema: "content",
                table: "episodes",
                column: "LanguageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_languages_LanguageId",
                schema: "content",
                table: "episodes",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_languages_LanguageId1",
                schema: "content",
                table: "episodes",
                column: "LanguageId1",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_languages_LanguageId",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_episodes_languages_LanguageId1",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropIndex(
                name: "IX_episodes_LanguageId",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropIndex(
                name: "IX_episodes_LanguageId1",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                schema: "content",
                table: "episodes");

            migrationBuilder.CreateTable(
                name: "episode_audio_languages",
                schema: "content",
                columns: table => new
                {
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episode_audio_languages", x => new { x.EpisodeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_episode_audio_languages_episodes_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "content",
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_episode_audio_languages_languages_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episode_subtitle_languages",
                schema: "content",
                columns: table => new
                {
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episode_subtitle_languages", x => new { x.EpisodeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_episode_subtitle_languages_episodes_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "content",
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_episode_subtitle_languages_languages_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_episode_audio_languages_LanguageId",
                schema: "content",
                table: "episode_audio_languages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_episode_subtitle_languages_LanguageId",
                schema: "content",
                table: "episode_subtitle_languages",
                column: "LanguageId");
        }
    }
}
