using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaotabelastemporadaserelacionamentocomepisodios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes");

            migrationBuilder.RenameColumn(
                name: "AnimeId",
                schema: "content",
                table: "episodes",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_episodes_AnimeId",
                schema: "content",
                table: "episodes",
                newName: "IX_episodes_SeasonId");

            migrationBuilder.CreateTable(
                name: "seasons",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seasons_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "season_sinopses",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_season_sinopses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_season_sinopses_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_season_sinopses_seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "content",
                        principalTable: "seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_season_sinopses_LanguageId",
                schema: "content",
                table: "season_sinopses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_season_sinopses_SeasonId",
                schema: "content",
                table: "season_sinopses",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_seasons_AnimeId",
                schema: "content",
                table: "seasons",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_seasons_SeasonId",
                schema: "content",
                table: "episodes",
                column: "SeasonId",
                principalSchema: "content",
                principalTable: "seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_seasons_SeasonId",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropTable(
                name: "season_sinopses",
                schema: "content");

            migrationBuilder.DropTable(
                name: "seasons",
                schema: "content");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                schema: "content",
                table: "episodes",
                newName: "AnimeId");

            migrationBuilder.RenameIndex(
                name: "IX_episodes_SeasonId",
                schema: "content",
                table: "episodes",
                newName: "IX_episodes_AnimeId");

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
