using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adiçãorelacionamentoentreemailtemplateestyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.AddForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates",
                column: "StyleId",
                principalSchema: "misc",
                principalTable: "email_template_styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.AddForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates",
                column: "StyleId",
                principalSchema: "misc",
                principalTable: "email_template_styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
