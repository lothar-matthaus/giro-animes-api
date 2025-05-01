using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaotabeladebannersdeanimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes");

            migrationBuilder.CreateTable(
                name: "banners",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_banners_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_banners_AnimeId",
                schema: "content",
                table: "banners",
                column: "AnimeId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes");

            migrationBuilder.DropTable(
                name: "banners",
                schema: "content");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_animes_AnimeId",
                schema: "content",
                table: "episodes",
                column: "AnimeId",
                principalSchema: "content",
                principalTable: "animes",
                principalColumn: "Id");
        }
    }
}
