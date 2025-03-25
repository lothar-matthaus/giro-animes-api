using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "management");

            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.EnsureSchema(
                name: "content");

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
                name: "languages",
                schema: "common",
                columns: table => new
                {
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    NativeName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "management",
                columns: table => new
                {
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
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
                name: "titles",
                schema: "common",
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
                name: "accounts",
                schema: "management",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Salt = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Plan = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "management",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnableApplicationNotifications = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    EnableEmailNotifications = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Theme = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_settings_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "management",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "biography_authors",
                schema: "common",
                columns: table => new
                {
                    DescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biography_authors", x => new { x.AuthorId, x.DescriptionId });
                    table.ForeignKey(
                        name: "FK_biography_authors_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "common",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_biography_authors_descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalSchema: "common",
                        principalTable: "descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genre_descriptions",
                schema: "common",
                columns: table => new
                {
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    DescriptionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_descriptions", x => new { x.DescriptionId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_genre_descriptions_descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalSchema: "common",
                        principalTable: "descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genre_descriptions_genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "common",
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genre_titles",
                schema: "common",
                columns: table => new
                {
                    GenresId = table.Column<long>(type: "bigint", nullable: false),
                    TitlesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_titles", x => new { x.GenresId, x.TitlesId });
                    table.ForeignKey(
                        name: "FK_genre_titles_genres_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "common",
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genre_titles_titles_TitlesId",
                        column: x => x.TitlesId,
                        principalSchema: "common",
                        principalTable: "titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avatars",
                schema: "content",
                columns: table => new
                {
                    Url = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avatars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_avatars_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "management",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_UserId",
                schema: "management",
                table: "accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_avatars_AccountId",
                schema: "content",
                table: "avatars",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_biography_authors_DescriptionId",
                schema: "common",
                table: "biography_authors",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_descriptions_LanguageId",
                schema: "common",
                table: "descriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_descriptions_GenreId",
                schema: "common",
                table: "genre_descriptions",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_titles_TitlesId",
                schema: "common",
                table: "genre_titles",
                column: "TitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_settings_LanguageId",
                schema: "common",
                table: "settings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_settings_UserId",
                schema: "common",
                table: "settings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_titles_LanguageId",
                schema: "common",
                table: "titles",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avatars",
                schema: "content");

            migrationBuilder.DropTable(
                name: "biography_authors",
                schema: "common");

            migrationBuilder.DropTable(
                name: "genre_descriptions",
                schema: "common");

            migrationBuilder.DropTable(
                name: "genre_titles",
                schema: "common");

            migrationBuilder.DropTable(
                name: "settings",
                schema: "common");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "management");

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
                schema: "common");

            migrationBuilder.DropTable(
                name: "users",
                schema: "management");

            migrationBuilder.DropTable(
                name: "languages",
                schema: "common");
        }
    }
}
