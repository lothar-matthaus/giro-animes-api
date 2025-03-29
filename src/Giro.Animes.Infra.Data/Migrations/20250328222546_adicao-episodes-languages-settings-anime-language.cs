using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giro.Animes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaoepisodeslanguagessettingsanimelanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_biographies_languages_LanguageId",
                schema: "common",
                table: "biographies");

            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_LanguageId",
                schema: "management",
                table: "settings");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                schema: "management",
                table: "settings",
                newName: "InterfaceLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_settings_LanguageId",
                schema: "management",
                table: "settings",
                newName: "IX_settings_InterfaceLanguageId");

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<long>(
                name: "EpisodeId",
                schema: "common",
                table: "languages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "common",
                table: "biographies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "settings_anime_languages",
                schema: "content",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    SettingsId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings_anime_languages", x => new { x.LanguageId, x.SettingsId });
                    table.ForeignKey(
                        name: "FK_settings_anime_languages_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "common",
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_anime_languages_settings_SettingsId",
                        column: x => x.SettingsId,
                        principalSchema: "management",
                        principalTable: "settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_languages_EpisodeId",
                schema: "common",
                table: "languages",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_settings_anime_languages_SettingsId",
                schema: "content",
                table: "settings_anime_languages",
                column: "SettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_biographies_languages_LanguageId",
                schema: "common",
                table: "biographies",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_languages_episodes_EpisodeId",
                schema: "common",
                table: "languages",
                column: "EpisodeId",
                principalSchema: "content",
                principalTable: "episodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings",
                column: "InterfaceLanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_biographies_languages_LanguageId",
                schema: "common",
                table: "biographies");

            migrationBuilder.DropForeignKey(
                name: "FK_languages_episodes_EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropForeignKey(
                name: "FK_settings_languages_InterfaceLanguageId",
                schema: "management",
                table: "settings");

            migrationBuilder.DropTable(
                name: "settings_anime_languages",
                schema: "content");

            migrationBuilder.DropIndex(
                name: "IX_languages_EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                schema: "common",
                table: "languages");

            migrationBuilder.RenameColumn(
                name: "InterfaceLanguageId",
                schema: "management",
                table: "settings",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_settings_InterfaceLanguageId",
                schema: "management",
                table: "settings",
                newName: "IX_settings_LanguageId");

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "content",
                table: "sinopses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "LanguageId",
                schema: "common",
                table: "biographies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_biographies_languages_LanguageId",
                schema: "common",
                table: "biographies",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_settings_languages_LanguageId",
                schema: "management",
                table: "settings",
                column: "LanguageId",
                principalSchema: "common",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
