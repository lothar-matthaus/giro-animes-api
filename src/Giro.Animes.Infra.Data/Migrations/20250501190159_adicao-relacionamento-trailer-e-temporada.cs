using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaorelacionamentotraileretemporada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trailers",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonId = table.Column<long>(type: "bigint", nullable: false),
                    SeasonId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trailers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trailers_seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "content",
                        principalTable: "seasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trailers_seasons_SeasonId1",
                        column: x => x.SeasonId1,
                        principalSchema: "content",
                        principalTable: "seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_trailers_SeasonId",
                schema: "content",
                table: "trailers",
                column: "SeasonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trailers_SeasonId1",
                schema: "content",
                table: "trailers",
                column: "SeasonId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trailers",
                schema: "content");
        }
    }
}
