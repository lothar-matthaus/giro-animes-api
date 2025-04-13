using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoisconfirmedparaaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                schema: "management",
                table: "accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                schema: "management",
                table: "accounts",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);
        }
    }
}
