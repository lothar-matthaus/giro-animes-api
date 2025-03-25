using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaonomecampostabelapasswordsalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "titles",
                schema: "content",
                newName: "titles",
                newSchema: "common");

            migrationBuilder.RenameColumn(
                name: "Password_Salt",
                schema: "management",
                table: "accounts",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                schema: "management",
                table: "accounts",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "titles",
                schema: "common",
                newName: "titles",
                newSchema: "content");

            migrationBuilder.RenameColumn(
                name: "Salt",
                schema: "management",
                table: "accounts",
                newName: "Password_Salt");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "management",
                table: "accounts",
                newName: "PasswordHash");
        }
    }
}
