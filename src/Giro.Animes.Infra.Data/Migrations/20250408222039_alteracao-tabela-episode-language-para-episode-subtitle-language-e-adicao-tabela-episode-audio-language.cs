using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaotabelaepisodelanguageparaepisodesubtitlelanguageeadicaotabelaepisodeaudiolanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "episode_languages",
                schema: "content");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "episode_audio_languages",
                schema: "content");

            migrationBuilder.DropTable(
                name: "episode_subtitle_languages",
                schema: "content");

            migrationBuilder.CreateTable(
                name: "episode_languages",
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
    }
}
