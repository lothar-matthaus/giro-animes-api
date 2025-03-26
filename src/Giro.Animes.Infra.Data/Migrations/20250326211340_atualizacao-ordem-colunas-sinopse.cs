using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoordemcolunassinopse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sinopses_languages_LanguageId",
                schema: "content",
                table: "sinopses");

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "sinopses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "AnimeId",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId1",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "genre_descriptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "genre_descriptions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "common",
                table: "biographies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "common",
                table: "biographies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_sinopses_LanguageId1",
                schema: "content",
                table: "sinopses",
                column: "LanguageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_sinopses_languages_LanguageId",
                schema: "content",
                table: "sinopses",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sinopses_languages_LanguageId1",
                schema: "content",
                table: "sinopses",
                column: "LanguageId1",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sinopses_languages_LanguageId",
                schema: "content",
                table: "sinopses");

            migrationBuilder.DropForeignKey(
                name: "FK_sinopses_languages_LanguageId1",
                schema: "content",
                table: "sinopses");

            migrationBuilder.DropIndex(
                name: "IX_sinopses_LanguageId1",
                schema: "content",
                table: "sinopses");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                schema: "content",
                table: "sinopses");

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "sinopses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "AnimeId",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "genre_descriptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "content",
                table: "genre_descriptions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "common",
                table: "biographies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "common",
                table: "biographies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddForeignKey(
                name: "FK_sinopses_languages_LanguageId",
                schema: "content",
                table: "sinopses",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
