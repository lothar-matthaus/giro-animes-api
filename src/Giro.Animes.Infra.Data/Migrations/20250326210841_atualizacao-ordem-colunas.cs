using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoordemcolunas : Migration
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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "management",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                schema: "management",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "management",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "management",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Studio",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "sinopses",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "settings",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "management",
                table: "settings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "logos",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "logos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "languages",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "languages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "genres",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "genres",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "genre_titles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "genre_descriptions",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "genre_descriptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episodes",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "episodes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_titles",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "episode_titles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "episode_files",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "episode_files",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "covers",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "covers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "biographies",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "biographies",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "avatars",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "avatars",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "common",
                table: "authors",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AnimeTitle",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "animes",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "animes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "content",
                table: "anime_screenshots",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "anime_screenshots",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "accounts",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 101);

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
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "management",
                table: "accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
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
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "management",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                schema: "management",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "management",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                schema: "management",
                table: "users",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "management",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Studio",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Studio",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "management",
                table: "settings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "logos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "languages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "genres",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "genre_titles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "genre_descriptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "episodes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "episode_titles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "episode_files",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "covers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "biographies",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "avatars",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "common",
                table: "authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnimeTitle",
                type: "TIMESTAMP",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AnimeTitle",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "animes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "content",
                table: "anime_screenshots",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

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
                .OldAnnotation("Relational:ColumnOrder", 101);

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
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "management",
                table: "accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);
        }
    }
}
