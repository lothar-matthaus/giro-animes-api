using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaotabelasdeestiloecorpobase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BaseTemplateId",
                schema: "misc",
                table: "email_templates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StyleId",
                schema: "misc",
                table: "email_templates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "email_template_styles",
                schema: "misc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Style = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_template_styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "base_email_templates",
                schema: "misc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LanguageID = table.Column<long>(type: "bigint", nullable: false),
                    StyleId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_email_templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_base_email_templates_email_template_styles_StyleId",
                        column: x => x.StyleId,
                        principalSchema: "misc",
                        principalTable: "email_template_styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_base_email_templates_languages_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_email_templates_BaseTemplateId",
                schema: "misc",
                table: "email_templates",
                column: "BaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_email_templates_StyleId",
                schema: "misc",
                table: "email_templates",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_base_email_templates_LanguageID",
                schema: "misc",
                table: "base_email_templates",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_base_email_templates_StyleId",
                schema: "misc",
                table: "base_email_templates",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_email_templates_base_email_templates_BaseTemplateId",
                schema: "misc",
                table: "email_templates",
                column: "BaseTemplateId",
                principalSchema: "misc",
                principalTable: "base_email_templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates",
                column: "StyleId",
                principalSchema: "misc",
                principalTable: "email_template_styles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_email_templates_base_email_templates_BaseTemplateId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropTable(
                name: "base_email_templates",
                schema: "misc");

            migrationBuilder.DropTable(
                name: "email_template_styles",
                schema: "misc");

            migrationBuilder.DropIndex(
                name: "IX_email_templates_BaseTemplateId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropIndex(
                name: "IX_email_templates_StyleId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropColumn(
                name: "BaseTemplateId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropColumn(
                name: "StyleId",
                schema: "misc",
                table: "email_templates");
        }
    }
}
