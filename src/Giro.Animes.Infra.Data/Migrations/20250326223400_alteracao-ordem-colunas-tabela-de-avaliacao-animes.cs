using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoordemcolunastabeladeavaliacaoanimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
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
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "studios",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "ratings",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 102)
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "anime_titles",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101)
                .OldAnnotation("Relational:ColumnOrder", 31);

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
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100)
                .OldAnnotation("Relational:ColumnOrder", 30);
        }
    }
}
