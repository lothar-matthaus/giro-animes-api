using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionadonumerodevisualizacoesanime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "episode_sinopses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Views",
                schema: "content",
                table: "animes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                schema: "content",
                table: "animes");

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "episode_sinopses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
