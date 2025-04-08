using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaoidiomadeaudioeidiomadelegendaparaepisodefiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episode_files_languages_LanguageId",
                schema: "content",
                table: "episode_files");

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

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                schema: "content",
                table: "episode_files",
                newName: "SubtitleLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_episode_files_LanguageId",
                schema: "content",
                table: "episode_files",
                newName: "IX_episode_files_SubtitleLanguageId");

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

            migrationBuilder.AddColumn<long>(
                name: "AudioLanguageId",
                schema: "content",
                table: "episode_files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_episode_files_AudioLanguageId",
                schema: "content",
                table: "episode_files",
                column: "AudioLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_episode_files_languages_AudioLanguageId",
                schema: "content",
                table: "episode_files",
                column: "AudioLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_episode_files_languages_SubtitleLanguageId",
                schema: "content",
                table: "episode_files",
                column: "SubtitleLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episode_files_languages_AudioLanguageId",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropForeignKey(
                name: "FK_episode_files_languages_SubtitleLanguageId",
                schema: "content",
                table: "episode_files");

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

            migrationBuilder.DropIndex(
                name: "IX_episode_files_AudioLanguageId",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "EpisodeId1",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "AudioLanguageId",
                schema: "content",
                table: "episode_files");

            migrationBuilder.RenameColumn(
                name: "SubtitleLanguageId",
                schema: "content",
                table: "episode_files",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_episode_files_SubtitleLanguageId",
                schema: "content",
                table: "episode_files",
                newName: "IX_episode_files_LanguageId");

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
                name: "FK_episode_files_languages_LanguageId",
                schema: "content",
                table: "episode_files",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
