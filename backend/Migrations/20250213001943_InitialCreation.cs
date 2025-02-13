using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conditions",
                columns: table => new
                {
                    condition_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    day_of_week = table.Column<int>(type: "integer", nullable: false),
                    week_of_month = table.Column<int>(type: "integer", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    is_free = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_conditions", x => x.condition_id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "museum_features",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    feature_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museum_features", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schedules", x => x.schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "condition_excluded_months",
                columns: table => new
                {
                    condition_id = table.Column<int>(type: "integer", nullable: false),
                    excluded_month = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_condition_excluded_months", x => new { x.condition_id, x.excluded_month });
                    table.ForeignKey(
                        name: "fk_condition_excluded_months_conditions_condition_id",
                        column: x => x.condition_id,
                        principalTable: "conditions",
                        principalColumn: "condition_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.city_id);
                    table.ForeignKey(
                        name: "fk_cities_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "museum_feature_options",
                columns: table => new
                {
                    museum_feature_option_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    option_name = table.Column<string>(type: "text", nullable: true),
                    museum_feature_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museum_feature_options", x => x.museum_feature_option_id);
                    table.ForeignKey(
                        name: "fk_museum_feature_options_museum_features_museum_feature_id",
                        column: x => x.museum_feature_id,
                        principalTable: "museum_features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exceptional_days",
                columns: table => new
                {
                    exceptional_day_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_closed = table.Column<bool>(type: "boolean", nullable: true),
                    is_free = table.Column<bool>(type: "boolean", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    schedule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exceptional_days", x => x.exceptional_day_id);
                    table.ForeignKey(
                        name: "fk_exceptional_days_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opening_periods",
                columns: table => new
                {
                    opening_period_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    last_entry_offset = table.Column<TimeSpan>(type: "interval", nullable: true),
                    room_clearing_offset = table.Column<TimeSpan>(type: "interval", nullable: true),
                    schedule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opening_periods", x => x.opening_period_id);
                    table.ForeignKey(
                        name: "fk_opening_periods_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "special_rules",
                columns: table => new
                {
                    special_rule_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rule_type = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    schedule_id = table.Column<int>(type: "integer", nullable: false),
                    condition_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_special_rules", x => x.special_rule_id);
                    table.ForeignKey(
                        name: "fk_special_rules_conditions_condition_id",
                        column: x => x.condition_id,
                        principalTable: "conditions",
                        principalColumn: "condition_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_special_rules_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "museums",
                columns: table => new
                {
                    museum_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    environment = table.Column<int>(type: "integer", nullable: false),
                    guided_tours = table.Column<bool>(type: "boolean", nullable: false),
                    audio_guide = table.Column<bool>(type: "boolean", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museums", x => x.museum_id);
                    table.ForeignKey(
                        name: "fk_museums_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opening_hours",
                columns: table => new
                {
                    opening_hour_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    day_of_week = table.Column<int>(type: "integer", nullable: false),
                    opening_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    closing_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    is_free = table.Column<bool>(type: "boolean", nullable: false),
                    is_closed = table.Column<bool>(type: "boolean", nullable: false),
                    exceptional_day_id = table.Column<int>(type: "integer", nullable: true),
                    opening_period_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opening_hours", x => x.opening_hour_id);
                    table.ForeignKey(
                        name: "fk_opening_hours_exceptional_days_exceptional_day_id",
                        column: x => x.exceptional_day_id,
                        principalTable: "exceptional_days",
                        principalColumn: "exceptional_day_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_opening_hours_opening_periods_opening_period_id",
                        column: x => x.opening_period_id,
                        principalTable: "opening_periods",
                        principalColumn: "opening_period_id");
                });

            migrationBuilder.CreateTable(
                name: "museum_accessibilities",
                columns: table => new
                {
                    museum_id = table.Column<int>(type: "integer", nullable: false),
                    accessibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museum_accessibilities", x => new { x.museum_id, x.accessibility });
                    table.ForeignKey(
                        name: "fk_museum_accessibilities_museums_museum_id",
                        column: x => x.museum_id,
                        principalTable: "museums",
                        principalColumn: "museum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "museum_feature_associations",
                columns: table => new
                {
                    museum_id = table.Column<int>(type: "integer", nullable: false),
                    museum_feature_option_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museum_feature_associations", x => new { x.museum_id, x.museum_feature_option_id });
                    table.ForeignKey(
                        name: "fk_museum_feature_associations_museum_feature_options_museum_f",
                        column: x => x.museum_feature_option_id,
                        principalTable: "museum_feature_options",
                        principalColumn: "museum_feature_option_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_museum_feature_associations_museums_museum_id",
                        column: x => x.museum_id,
                        principalTable: "museums",
                        principalColumn: "museum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "museum_languages",
                columns: table => new
                {
                    museum_id = table.Column<int>(type: "integer", nullable: false),
                    language = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museum_languages", x => new { x.museum_id, x.language });
                    table.ForeignKey(
                        name: "fk_museum_languages_museums_museum_id",
                        column: x => x.museum_id,
                        principalTable: "museums",
                        principalColumn: "museum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "museum_schedules",
                columns: table => new
                {
                    museum_id = table.Column<int>(type: "integer", nullable: false),
                    schedule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_museum_schedules", x => new { x.museum_id, x.schedule_id });
                    table.ForeignKey(
                        name: "fk_museum_schedules_museums_museum_id",
                        column: x => x.museum_id,
                        principalTable: "museums",
                        principalColumn: "museum_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_museum_schedules_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    shop_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    museum_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shops", x => x.shop_id);
                    table.ForeignKey(
                        name: "fk_shops_museums_museum_id",
                        column: x => x.museum_id,
                        principalTable: "museums",
                        principalColumn: "museum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shop_schedules",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "integer", nullable: false),
                    shop_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shop_schedules", x => new { x.shop_id, x.schedule_id });
                    table.ForeignKey(
                        name: "fk_shop_schedules_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shop_schedules_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "shop_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cities_country_id",
                table: "cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_exceptional_days_schedule_id",
                table: "exceptional_days",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_museum_feature_associations_museum_feature_option_id",
                table: "museum_feature_associations",
                column: "museum_feature_option_id");

            migrationBuilder.CreateIndex(
                name: "ix_museum_feature_options_museum_feature_id",
                table: "museum_feature_options",
                column: "museum_feature_id");

            migrationBuilder.CreateIndex(
                name: "ix_museum_schedules_schedule_id",
                table: "museum_schedules",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_museums_city_id",
                table: "museums",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_opening_hours_exceptional_day_id",
                table: "opening_hours",
                column: "exceptional_day_id");

            migrationBuilder.CreateIndex(
                name: "ix_opening_hours_opening_period_id",
                table: "opening_hours",
                column: "opening_period_id");

            migrationBuilder.CreateIndex(
                name: "ix_opening_periods_schedule_id",
                table: "opening_periods",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_shop_schedules_schedule_id",
                table: "shop_schedules",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_shops_museum_id",
                table: "shops",
                column: "museum_id");

            migrationBuilder.CreateIndex(
                name: "ix_special_rules_condition_id",
                table: "special_rules",
                column: "condition_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_special_rules_schedule_id",
                table: "special_rules",
                column: "schedule_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "condition_excluded_months");

            migrationBuilder.DropTable(
                name: "museum_accessibilities");

            migrationBuilder.DropTable(
                name: "museum_feature_associations");

            migrationBuilder.DropTable(
                name: "museum_languages");

            migrationBuilder.DropTable(
                name: "museum_schedules");

            migrationBuilder.DropTable(
                name: "opening_hours");

            migrationBuilder.DropTable(
                name: "shop_schedules");

            migrationBuilder.DropTable(
                name: "special_rules");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "museum_feature_options");

            migrationBuilder.DropTable(
                name: "exceptional_days");

            migrationBuilder.DropTable(
                name: "opening_periods");

            migrationBuilder.DropTable(
                name: "shops");

            migrationBuilder.DropTable(
                name: "conditions");

            migrationBuilder.DropTable(
                name: "museum_features");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "museums");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
