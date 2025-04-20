using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaodescricaotemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateType",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateDescription",
                schema: "misc",
                table: "email_templates",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "misc",
                table: "email_templates",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateDescription",
                schema: "misc",
                table: "email_templates",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "TemplateType",
                schema: "misc",
                table: "email_templates",
                type: "text",
                nullable: false,
                defaultValue: "0");
        }
    }
}
