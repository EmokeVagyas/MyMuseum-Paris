using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleShopsForMuseum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Museums");

            migrationBuilder.AddColumn<int>(
                name: "TimeTableId",
                table: "SpecialRule",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ClosingTime",
                table: "ShopSchedules",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "ShopSchedules",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "ShopSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShopSchedules",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "ShopSchedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "ShopSchedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OpeningTime",
                table: "ShopSchedules",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "Shops",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeTableId",
                table: "OpeningPeriods",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeTableId",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeTableId",
                table: "ExceptionalDays",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    TimeTableId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.TimeTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRule_TimeTableId",
                table: "SpecialRule",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningPeriods_TimeTableId",
                table: "OpeningPeriods",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_MuseumSchedules_TimeTableId",
                table: "Schedules",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionalDays_TimeTableId",
                table: "ExceptionalDays",
                column: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExceptionalDays_TimeTable_TimeTableId",
                table: "ExceptionalDays",
                column: "TimeTableId",
                principalTable: "TimeTable",
                principalColumn: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_MuseumSchedules_TimeTable_TimeTableId",
                table: "Schedules",
                column: "TimeTableId",
                principalTable: "TimeTable",
                principalColumn: "TimeTableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningPeriods_TimeTable_TimeTableId",
                table: "OpeningPeriods",
                column: "TimeTableId",
                principalTable: "TimeTable",
                principalColumn: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialRule_TimeTable_TimeTableId",
                table: "SpecialRule",
                column: "TimeTableId",
                principalTable: "TimeTable",
                principalColumn: "TimeTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExceptionalDays_TimeTable_TimeTableId",
                table: "ExceptionalDays");

            migrationBuilder.DropForeignKey(
                name: "FK_MuseumSchedules_TimeTable_TimeTableId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningPeriods_TimeTable_TimeTableId",
                table: "OpeningPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialRule_TimeTable_TimeTableId",
                table: "SpecialRule");

            migrationBuilder.DropTable(
                name: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_SpecialRule_TimeTableId",
                table: "SpecialRule");

            migrationBuilder.DropIndex(
                name: "IX_OpeningPeriods_TimeTableId",
                table: "OpeningPeriods");

            migrationBuilder.DropIndex(
                name: "IX_MuseumSchedules_TimeTableId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_ExceptionalDays_TimeTableId",
                table: "ExceptionalDays");

            migrationBuilder.DropColumn(
                name: "TimeTableId",
                table: "SpecialRule");

            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "ShopSchedules");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "TimeTableId",
                table: "OpeningPeriods");

            migrationBuilder.DropColumn(
                name: "TimeTableId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TimeTableId",
                table: "ExceptionalDays");

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Museums",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
