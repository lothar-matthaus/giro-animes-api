using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "management");

            migrationBuilder.EnsureSchema(
                name: "content");

            migrationBuilder.EnsureSchema(
                name: "common");

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
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Twitter = table.Column<string>(type: "text", nullable: true),
                    Instagram = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
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
                name: "biographies",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_biographies_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "common",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_biographies_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "genre_descriptions",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genre_descriptions_genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "common",
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genre_descriptions_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genre_titles",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genre_titles_genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "common",
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genre_titles_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "animes",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudioId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_animes_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "logos",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudioId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_logos_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
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
                name: "anime_screenshots",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime_screenshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_anime_screenshots_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeTitle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeTitle_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeTitle_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "author_works",
                schema: "content",
                columns: table => new
                {
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_works", x => new { x.AnimeId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_author_works_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_author_works_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "common",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "covers",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_covers_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_covers_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episodes",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Duration = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_episodes_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sinopses",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sinopses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sinopses_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sinopses_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avatars",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "settings",
                schema: "management",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnableApplicationNotifications = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    EnableEmailNotifications = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Theme = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_settings_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "management",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "watchlist",
                schema: "content",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    AnimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlist", x => new { x.AccountId, x.AnimeId });
                    table.ForeignKey(
                        name: "FK_watchlist_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "management",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_watchlist_animes_AnimeId",
                        column: x => x.AnimeId,
                        principalSchema: "content",
                        principalTable: "animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episode_files",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episode_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_episode_files_episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "content",
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episode_titles",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletionDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episode_titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_episode_titles_episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalSchema: "content",
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_episode_titles_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
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
                name: "IX_anime_screenshots_AnimeId",
                schema: "content",
                table: "anime_screenshots",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_animes_StudioId",
                schema: "content",
                table: "animes",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTitle_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTitle_LanguageId",
                table: "AnimeTitle",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_author_works_AuthorId",
                schema: "content",
                table: "author_works",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_avatars_AccountId",
                schema: "content",
                table: "avatars",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_biographies_AuthorId",
                schema: "common",
                table: "biographies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_biographies_LanguageId",
                schema: "common",
                table: "biographies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_covers_AnimeId",
                schema: "content",
                table: "covers",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_covers_LanguageId",
                schema: "content",
                table: "covers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_episode_files_EpisodeId",
                schema: "content",
                table: "episode_files",
                column: "EpisodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_episode_titles_EpisodeId",
                schema: "content",
                table: "episode_titles",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_episode_titles_LanguageId",
                schema: "content",
                table: "episode_titles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_episodes_AnimeId",
                schema: "content",
                table: "episodes",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_descriptions_GenreId",
                schema: "content",
                table: "genre_descriptions",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_descriptions_LanguageId",
                schema: "content",
                table: "genre_descriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_titles_GenreId",
                schema: "content",
                table: "genre_titles",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_titles_LanguageId",
                schema: "content",
                table: "genre_titles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_logos_StudioId",
                schema: "content",
                table: "logos",
                column: "StudioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_settings_AccountId",
                schema: "management",
                table: "settings",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_settings_LanguageId",
                schema: "management",
                table: "settings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_sinopses_AnimeId",
                schema: "content",
                table: "sinopses",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_sinopses_LanguageId",
                schema: "content",
                table: "sinopses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_watchlist_AnimeId",
                schema: "content",
                table: "watchlist",
                column: "AnimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anime_screenshots",
                schema: "content");

            migrationBuilder.DropTable(
                name: "AnimeTitle");

            migrationBuilder.DropTable(
                name: "author_works",
                schema: "content");

            migrationBuilder.DropTable(
                name: "avatars",
                schema: "content");

            migrationBuilder.DropTable(
                name: "biographies",
                schema: "common");

            migrationBuilder.DropTable(
                name: "covers",
                schema: "content");

            migrationBuilder.DropTable(
                name: "episode_files",
                schema: "content");

            migrationBuilder.DropTable(
                name: "episode_titles",
                schema: "content");

            migrationBuilder.DropTable(
                name: "genre_descriptions",
                schema: "content");

            migrationBuilder.DropTable(
                name: "genre_titles",
                schema: "content");

            migrationBuilder.DropTable(
                name: "logos",
                schema: "content");

            migrationBuilder.DropTable(
                name: "settings",
                schema: "management");

            migrationBuilder.DropTable(
                name: "sinopses",
                schema: "content");

            migrationBuilder.DropTable(
                name: "watchlist",
                schema: "content");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "common");

            migrationBuilder.DropTable(
                name: "episodes",
                schema: "content");

            migrationBuilder.DropTable(
                name: "genres",
                schema: "common");

            migrationBuilder.DropTable(
                name: "languages",
                schema: "common");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "management");

            migrationBuilder.DropTable(
                name: "animes",
                schema: "content");

            migrationBuilder.DropTable(
                name: "users",
                schema: "management");

            migrationBuilder.DropTable(
                name: "Studio");
        }
    }
}
