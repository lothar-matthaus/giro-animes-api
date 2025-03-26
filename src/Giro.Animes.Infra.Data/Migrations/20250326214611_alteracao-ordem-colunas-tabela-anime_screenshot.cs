using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoordemcolunastabelaanime_screenshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<long>(
                name: "AnimeId",
                schema: "content",
                table: "anime_screenshots",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 101);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "logos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "episode_files",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "covers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "avatars",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "content",
                table: "anime_screenshots",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<long>(
                name: "AnimeId",
                schema: "content",
                table: "anime_screenshots",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 102);
        }
    }
}
