using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaotabelaepisodesinopses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                schema: "content",
                table: "ratings",
                type: "double precision",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "episode_files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "episode_sinopses",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episode_sinopses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_episode_sinopses_episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "content",
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_episode_sinopses_languages_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_episode_files_LanguageId",
                schema: "content",
                table: "episode_files",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_episode_sinopses_EpisodeId",
                schema: "content",
                table: "episode_sinopses",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_episode_files_languages_LanguageId",
                schema: "content",
                table: "episode_files",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episode_files_languages_LanguageId",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropTable(
                name: "episode_sinopses",
                schema: "content");

            migrationBuilder.DropIndex(
                name: "IX_episode_files_LanguageId",
                schema: "content",
                table: "episode_files");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "content",
                table: "episode_files");

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                schema: "content",
                table: "ratings",
                type: "real",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldMaxLength: 5);
        }
    }
}
