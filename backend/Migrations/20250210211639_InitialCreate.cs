using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "MuseumFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRule",
                columns: table => new
                {
                    SpecialRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRule", x => x.SpecialRuleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuseumFeatureOptions",
                columns: table => new
                {
                    MuseumFeatureOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuseumFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumFeatureOptions", x => x.MuseumFeatureOptionId);
                    table.ForeignKey(
                        name: "FK_MuseumFeatureOptions_MuseumFeatures_MuseumFeatureId",
                        column: x => x.MuseumFeatureId,
                        principalTable: "MuseumFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionalDays",
                columns: table => new
                {
                    ExceptionalDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionalDays", x => x.ExceptionalDayId);
                    table.ForeignKey(
                        name: "FK_ExceptionalDays_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningPeriods",
                columns: table => new
                {
                    OpeningPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEntryOffset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomClearingOffset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningPeriods", x => x.OpeningPeriodId);
                    table.ForeignKey(
                        name: "FK_OpeningPeriods_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    WeekOfMonth = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ExcludedMonths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ConditionId);
                    table.ForeignKey(
                        name: "FK_Condition_SpecialRule_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "SpecialRule",
                        principalColumn: "SpecialRuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    MuseumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Environment = table.Column<int>(type: "int", nullable: false),
                    Accessibility = table.Column<int>(type: "int", nullable: false),
                    Languages = table.Column<int>(type: "int", nullable: false),
                    GuidedTours = table.Column<bool>(type: "bit", nullable: false),
                    AudioGuide = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.MuseumId);
                    table.ForeignKey(
                        name: "FK_Museums_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    OpeningHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    ClosingTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    ExceptionalDayId = table.Column<int>(type: "int", nullable: true),
                    OpeningPeriodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.OpeningHourId);
                    table.ForeignKey(
                        name: "FK_OpeningHours_ExceptionalDays_ExceptionalDayId",
                        column: x => x.ExceptionalDayId,
                        principalTable: "ExceptionalDays",
                        principalColumn: "ExceptionalDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpeningHours_OpeningPeriods_OpeningPeriodId",
                        column: x => x.OpeningPeriodId,
                        principalTable: "OpeningPeriods",
                        principalColumn: "OpeningPeriodId");
                });

            migrationBuilder.CreateTable(
                name: "MuseumFeatureAssociations",
                columns: table => new
                {
                    MuseumId = table.Column<int>(type: "int", nullable: false),
                    MuseumFeatureOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumFeatureAssociations", x => new { x.MuseumId, x.MuseumFeatureOptionId });
                    table.ForeignKey(
                        name: "FK_MuseumFeatureAssociations_MuseumFeatureOptions_MuseumFeatureOptionId",
                        column: x => x.MuseumFeatureOptionId,
                        principalTable: "MuseumFeatureOptions",
                        principalColumn: "MuseumFeatureOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuseumFeatureAssociations_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "MuseumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuseumSchedules",
                columns: table => new
                {
                    MuseumId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumSchedules", x => new { x.MuseumId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_MuseumSchedules_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "MuseumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuseumSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                    table.ForeignKey(
                        name: "FK_Shops_Museums_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Museums",
                        principalColumn: "MuseumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopSchedules",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSchedules", x => new { x.ShopId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_ShopSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopSchedules_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionalDays_ScheduleId",
                table: "ExceptionalDays",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MuseumFeatureAssociations_MuseumFeatureOptionId",
                table: "MuseumFeatureAssociations",
                column: "MuseumFeatureOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MuseumFeatureOptions_MuseumFeatureId",
                table: "MuseumFeatureOptions",
                column: "MuseumFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Museums_CityId",
                table: "Museums",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MuseumSchedules_ScheduleId",
                table: "MuseumSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHours_ExceptionalDayId",
                table: "OpeningHours",
                column: "ExceptionalDayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHours_OpeningPeriodId",
                table: "OpeningHours",
                column: "OpeningPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningPeriods_ScheduleId",
                table: "OpeningPeriods",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopSchedules_ScheduleId",
                table: "ShopSchedules",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "MuseumFeatureAssociations");

            migrationBuilder.DropTable(
                name: "MuseumSchedules");

            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropTable(
                name: "ShopSchedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SpecialRule");

            migrationBuilder.DropTable(
                name: "MuseumFeatureOptions");

            migrationBuilder.DropTable(
                name: "ExceptionalDays");

            migrationBuilder.DropTable(
                name: "OpeningPeriods");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "MuseumFeatures");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Museums");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
