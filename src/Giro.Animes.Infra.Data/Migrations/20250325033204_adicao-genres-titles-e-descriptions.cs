using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaogenrestitlesedescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PenName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Twitter = table.Column<string>(type: "text", nullable: true),
                    Instagram = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "descriptions",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_descriptions_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "genres",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_titles_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "description_authors",
                schema: "common",
                columns: table => new
                {
                    AuthorsId = table.Column<long>(type: "bigint", nullable: false),
                    BiographyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_description_authors", x => new { x.AuthorsId, x.BiographyId });
                    table.ForeignKey(
                        name: "FK_description_authors_authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalSchema: "common",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_description_authors_descriptions_BiographyId",
                        column: x => x.BiographyId,
                        principalSchema: "common",
                        principalTable: "descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "description_genres",
                schema: "common",
                columns: table => new
                {
                    DescriptionsId = table.Column<long>(type: "bigint", nullable: false),
                    GenresId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_description_genres", x => new { x.DescriptionsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_description_genres_descriptions_DescriptionsId",
                        column: x => x.DescriptionsId,
                        principalSchema: "common",
                        principalTable: "descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_description_genres_genres_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "common",
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "title_genres",
                schema: "common",
                columns: table => new
                {
                    GenresId = table.Column<long>(type: "bigint", nullable: false),
                    TitlesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title_genres", x => new { x.GenresId, x.TitlesId });
                    table.ForeignKey(
                        name: "FK_title_genres_genres_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "common",
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_title_genres_titles_TitlesId",
                        column: x => x.TitlesId,
                        principalSchema: "content",
                        principalTable: "titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_description_authors_BiographyId",
                schema: "common",
                table: "description_authors",
                column: "BiographyId");

            migrationBuilder.CreateIndex(
                name: "IX_description_genres_GenresId",
                schema: "common",
                table: "description_genres",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_descriptions_LanguageId",
                schema: "common",
                table: "descriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_title_genres_TitlesId",
                schema: "common",
                table: "title_genres",
                column: "TitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_titles_LanguageId",
                schema: "content",
                table: "titles",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "description_authors",
                schema: "common");

            migrationBuilder.DropTable(
                name: "description_genres",
                schema: "common");

            migrationBuilder.DropTable(
                name: "title_genres",
                schema: "common");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "common");

            migrationBuilder.DropTable(
                name: "descriptions",
                schema: "common");

            migrationBuilder.DropTable(
                name: "genres",
                schema: "common");

            migrationBuilder.DropTable(
                name: "titles",
                schema: "content");
        }
    }
}
