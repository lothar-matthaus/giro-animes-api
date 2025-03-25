using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaorelacaoauthorsdescriptionbiography : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_description_authors_authors_AuthorsId",
                schema: "common",
                table: "description_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_description_authors_descriptions_BiographyId",
                schema: "common",
                table: "description_authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_description_authors",
                schema: "common",
                table: "description_authors");

            migrationBuilder.RenameTable(
                name: "description_authors",
                schema: "common",
                newName: "biography_authors",
                newSchema: "common");

            migrationBuilder.RenameColumn(
                name: "BiographyId",
                schema: "common",
                table: "biography_authors",
                newName: "BiographiesId");

            migrationBuilder.RenameIndex(
                name: "IX_description_authors_BiographyId",
                schema: "common",
                table: "biography_authors",
                newName: "IX_biography_authors_BiographiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_biography_authors",
                schema: "common",
                table: "biography_authors",
                columns: new[] { "AuthorsId", "BiographiesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_biography_authors_authors_AuthorsId",
                schema: "common",
                table: "biography_authors",
                column: "AuthorsId",
                principalSchema: "common",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_biography_authors_descriptions_BiographiesId",
                schema: "common",
                table: "biography_authors",
                column: "BiographiesId",
                principalSchema: "common",
                principalTable: "descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_biography_authors_authors_AuthorsId",
                schema: "common",
                table: "biography_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_biography_authors_descriptions_BiographiesId",
                schema: "common",
                table: "biography_authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_biography_authors",
                schema: "common",
                table: "biography_authors");

            migrationBuilder.RenameTable(
                name: "biography_authors",
                schema: "common",
                newName: "description_authors",
                newSchema: "common");

            migrationBuilder.RenameColumn(
                name: "BiographiesId",
                schema: "common",
                table: "description_authors",
                newName: "BiographyId");

            migrationBuilder.RenameIndex(
                name: "IX_biography_authors_BiographiesId",
                schema: "common",
                table: "description_authors",
                newName: "IX_description_authors_BiographyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_description_authors",
                schema: "common",
                table: "description_authors",
                columns: new[] { "AuthorsId", "BiographyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_description_authors_authors_AuthorsId",
                schema: "common",
                table: "description_authors",
                column: "AuthorsId",
                principalSchema: "common",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_description_authors_descriptions_BiographyId",
                schema: "common",
                table: "description_authors",
                column: "BiographyId",
                principalSchema: "common",
                principalTable: "descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
