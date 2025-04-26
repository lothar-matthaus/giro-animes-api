using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adiçãotabelastyledetemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_email_templates_StyleId",
                schema: "misc",
                table: "email_templates",
                column: "StyleId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_email_templates_email_template_styles_StyleId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropTable(
                name: "email_template_styles",
                schema: "misc");

            migrationBuilder.DropIndex(
                name: "IX_email_templates_StyleId",
                schema: "misc",
                table: "email_templates");

            migrationBuilder.DropColumn(
                name: "StyleId",
                schema: "misc",
                table: "email_templates");
        }
    }
}
