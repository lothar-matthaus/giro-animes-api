using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaorelacaobaseemailtemplatecomstyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_base_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "base_email_templates");

            migrationBuilder.DropForeignKey(
                name: "FK_base_email_templates_languages_LanguageID",
                schema: "misc",
                table: "base_email_templates");

            migrationBuilder.RenameColumn(
                name: "LanguageID",
                schema: "misc",
                table: "base_email_templates",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_base_email_templates_LanguageID",
                schema: "misc",
                table: "base_email_templates",
                newName: "IX_base_email_templates_LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_base_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "base_email_templates",
                column: "StyleId",
                principalSchema: "misc",
                principalTable: "email_template_styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_base_email_templates_languages_LanguageId",
                schema: "misc",
                table: "base_email_templates",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_base_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "base_email_templates");

            migrationBuilder.DropForeignKey(
                name: "FK_base_email_templates_languages_LanguageId",
                schema: "misc",
                table: "base_email_templates");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                schema: "misc",
                table: "base_email_templates",
                newName: "LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_base_email_templates_LanguageId",
                schema: "misc",
                table: "base_email_templates",
                newName: "IX_base_email_templates_LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_base_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "base_email_templates",
                column: "StyleId",
                principalSchema: "misc",
                principalTable: "email_template_styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_base_email_templates_languages_LanguageID",
                schema: "misc",
                table: "base_email_templates",
                column: "LanguageID",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
