using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMuseumAccessibilityAndLanguageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accessibility",
                table: "Museums");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Museums");

            migrationBuilder.CreateTable(
                name: "MuseumAccessibility",
                columns: table => new
                {
                    MuseumId = table.Column<int>(type: "integer", nullable: false),
                    Accessibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumAccessibility", x => new { x.MuseumId, x.Accessibility });
                    table.ForeignKey(
                        name: "FK_MuseumAccessibility_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "MuseumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuseumLanguage",
                columns: table => new
                {
                    MuseumId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumLanguage", x => new { x.MuseumId, x.Language });
                    table.ForeignKey(
                        name: "FK_MuseumLanguage_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "MuseumId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuseumAccessibility");

            migrationBuilder.DropTable(
                name: "MuseumLanguage");

            migrationBuilder.AddColumn<int>(
                name: "Accessibility",
                table: "Museums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Languages",
                table: "Museums",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
