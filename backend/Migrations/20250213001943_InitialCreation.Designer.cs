﻿// <auto-generated />
using System;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250213001943_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("city_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CityId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CityId")
                        .HasName("pk_cities");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_cities_country_id");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Condition", b =>
                {
                    b.Property<int>("ConditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("condition_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConditionId"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer")
                        .HasColumnName("day_of_week");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("end_time");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean")
                        .HasColumnName("is_free");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("start_time");

                    b.Property<int>("WeekOfMonth")
                        .HasColumnType("integer")
                        .HasColumnName("week_of_month");

                    b.HasKey("ConditionId")
                        .HasName("pk_conditions");

                    b.ToTable("conditions", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ConditionExcludedMonth", b =>
                {
                    b.Property<int>("ConditionId")
                        .HasColumnType("integer")
                        .HasColumnName("condition_id");

                    b.Property<int>("ExcludedMonth")
                        .HasColumnType("integer")
                        .HasColumnName("excluded_month");

                    b.HasKey("ConditionId", "ExcludedMonth")
                        .HasName("pk_condition_excluded_months");

                    b.ToTable("condition_excluded_months", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CountryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CountryId")
                        .HasName("pk_countries");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExceptionalDay", b =>
                {
                    b.Property<int>("ExceptionalDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("exceptional_day_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExceptionalDayId"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool?>("IsClosed")
                        .HasColumnType("boolean")
                        .HasColumnName("is_closed");

                    b.Property<bool?>("IsFree")
                        .HasColumnType("boolean")
                        .HasColumnName("is_free");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.HasKey("ExceptionalDayId")
                        .HasName("pk_exceptional_days");

                    b.HasIndex("ScheduleId")
                        .HasDatabaseName("ix_exceptional_days_schedule_id");

                    b.ToTable("exceptional_days", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Museum", b =>
                {
                    b.Property<int>("MuseumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("museum_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MuseumId"));

                    b.Property<bool>("AudioGuide")
                        .HasColumnType("boolean")
                        .HasColumnName("audio_guide");

                    b.Property<int>("CityId")
                        .HasColumnType("integer")
                        .HasColumnName("city_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Environment")
                        .HasColumnType("integer")
                        .HasColumnName("environment");

                    b.Property<bool>("GuidedTours")
                        .HasColumnType("boolean")
                        .HasColumnName("guided_tours");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("MuseumId")
                        .HasName("pk_museums");

                    b.HasIndex("CityId")
                        .HasDatabaseName("ix_museums_city_id");

                    b.ToTable("museums", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumAccessibility", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_id");

                    b.Property<int>("Accessibility")
                        .HasColumnType("integer")
                        .HasColumnName("accessibility");

                    b.HasKey("MuseumId", "Accessibility")
                        .HasName("pk_museum_accessibilities");

                    b.ToTable("museum_accessibilities", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FeatureType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("feature_type");

                    b.HasKey("Id")
                        .HasName("pk_museum_features");

                    b.ToTable("museum_features", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureAssociation", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_id");

                    b.Property<int>("MuseumFeatureOptionId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_feature_option_id");

                    b.HasKey("MuseumId", "MuseumFeatureOptionId")
                        .HasName("pk_museum_feature_associations");

                    b.HasIndex("MuseumFeatureOptionId")
                        .HasDatabaseName("ix_museum_feature_associations_museum_feature_option_id");

                    b.ToTable("museum_feature_associations", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureOption", b =>
                {
                    b.Property<int>("MuseumFeatureOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("museum_feature_option_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MuseumFeatureOptionId"));

                    b.Property<int>("MuseumFeatureId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_feature_id");

                    b.Property<string>("OptionName")
                        .HasColumnType("text")
                        .HasColumnName("option_name");

                    b.HasKey("MuseumFeatureOptionId")
                        .HasName("pk_museum_feature_options");

                    b.HasIndex("MuseumFeatureId")
                        .HasDatabaseName("ix_museum_feature_options_museum_feature_id");

                    b.ToTable("museum_feature_options", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumLanguage", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_id");

                    b.Property<int>("Language")
                        .HasColumnType("integer")
                        .HasColumnName("language");

                    b.HasKey("MuseumId", "Language")
                        .HasName("pk_museum_languages");

                    b.ToTable("museum_languages", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumSchedule", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_id");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.HasKey("MuseumId", "ScheduleId")
                        .HasName("pk_museum_schedules");

                    b.HasIndex("ScheduleId")
                        .HasDatabaseName("ix_museum_schedules_schedule_id");

                    b.ToTable("museum_schedules", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningHour", b =>
                {
                    b.Property<int>("OpeningHourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("opening_hour_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OpeningHourId"));

                    b.Property<TimeOnly?>("ClosingTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("closing_time");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer")
                        .HasColumnName("day_of_week");

                    b.Property<int?>("ExceptionalDayId")
                        .HasColumnType("integer")
                        .HasColumnName("exceptional_day_id");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean")
                        .HasColumnName("is_closed");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean")
                        .HasColumnName("is_free");

                    b.Property<int?>("OpeningPeriodId")
                        .HasColumnType("integer")
                        .HasColumnName("opening_period_id");

                    b.Property<TimeOnly?>("OpeningTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("opening_time");

                    b.HasKey("OpeningHourId")
                        .HasName("pk_opening_hours");

                    b.HasIndex("ExceptionalDayId")
                        .HasDatabaseName("ix_opening_hours_exceptional_day_id");

                    b.HasIndex("OpeningPeriodId")
                        .HasDatabaseName("ix_opening_hours_opening_period_id");

                    b.ToTable("opening_hours", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningPeriod", b =>
                {
                    b.Property<int>("OpeningPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("opening_period_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OpeningPeriodId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<TimeSpan?>("LastEntryOffset")
                        .HasColumnType("interval")
                        .HasColumnName("last_entry_offset");

                    b.Property<TimeSpan?>("RoomClearingOffset")
                        .HasColumnType("interval")
                        .HasColumnName("room_clearing_offset");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("OpeningPeriodId")
                        .HasName("pk_opening_periods");

                    b.HasIndex("ScheduleId")
                        .HasDatabaseName("ix_opening_periods_schedule_id");

                    b.ToTable("opening_periods", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScheduleId"));

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("ScheduleId")
                        .HasName("pk_schedules");

                    b.ToTable("schedules", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("shop_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShopId"));

                    b.Property<int>("MuseumId")
                        .HasColumnType("integer")
                        .HasColumnName("museum_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ShopId")
                        .HasName("pk_shops");

                    b.HasIndex("MuseumId")
                        .HasDatabaseName("ix_shops_museum_id");

                    b.ToTable("shops", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ShopSchedule", b =>
                {
                    b.Property<int>("ShopId")
                        .HasColumnType("integer")
                        .HasColumnName("shop_id");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.HasKey("ShopId", "ScheduleId")
                        .HasName("pk_shop_schedules");

                    b.HasIndex("ScheduleId")
                        .HasDatabaseName("ix_shop_schedules_schedule_id");

                    b.ToTable("shop_schedules", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.SpecialRule", b =>
                {
                    b.Property<int>("SpecialRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("special_rule_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SpecialRuleId"));

                    b.Property<int>("ConditionId")
                        .HasColumnType("integer")
                        .HasColumnName("condition_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("RuleType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rule_type");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.HasKey("SpecialRuleId")
                        .HasName("pk_special_rules");

                    b.HasIndex("ConditionId")
                        .IsUnique()
                        .HasDatabaseName("ix_special_rules_condition_id");

                    b.HasIndex("ScheduleId")
                        .HasDatabaseName("ix_special_rules_schedule_id");

                    b.ToTable("special_rules", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.HasKey("UserID")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Entities.City", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cities_countries_country_id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ConditionExcludedMonth", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Condition", "Condition")
                        .WithMany("ExcludedMonths")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_condition_excluded_months_conditions_condition_id");

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExceptionalDay", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany("ExceptionalDays")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_exceptional_days_schedules_schedule_id");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Museum", b =>
                {
                    b.HasOne("Backend.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museums_cities_city_id");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumAccessibility", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Accessibilities")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_accessibilities_museums_museum_id");

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureAssociation", b =>
                {
                    b.HasOne("Backend.Domain.Entities.MuseumFeatureOption", "MuseumFeatureOption")
                        .WithMany()
                        .HasForeignKey("MuseumFeatureOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_feature_associations_museum_feature_options_museum_f");

                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("FeatureAssociations")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_feature_associations_museums_museum_id");

                    b.Navigation("Museum");

                    b.Navigation("MuseumFeatureOption");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureOption", b =>
                {
                    b.HasOne("Backend.Domain.Entities.MuseumFeature", "MuseumFeature")
                        .WithMany("MuseumFeatureOptions")
                        .HasForeignKey("MuseumFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_feature_options_museum_features_museum_feature_id");

                    b.Navigation("MuseumFeature");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumLanguage", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Languages")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_languages_museums_museum_id");

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumSchedule", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Schedules")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_schedules_museums_museum_id");

                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_museum_schedules_schedules_schedule_id");

                    b.Navigation("Museum");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningHour", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExceptionalDay", "ExceptionalDay")
                        .WithMany("OpeningHours")
                        .HasForeignKey("ExceptionalDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_opening_hours_exceptional_days_exceptional_day_id");

                    b.HasOne("Backend.Domain.Entities.OpeningPeriod", null)
                        .WithMany("OpeningHours")
                        .HasForeignKey("OpeningPeriodId")
                        .HasConstraintName("fk_opening_hours_opening_periods_opening_period_id");

                    b.Navigation("ExceptionalDay");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningPeriod", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany("OpeningPeriods")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_opening_periods_schedules_schedule_id");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Shop", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Shops")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shops_museums_museum_id");

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ShopSchedule", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shop_schedules_schedules_schedule_id");

                    b.HasOne("Backend.Domain.Entities.Shop", "Shop")
                        .WithMany("ShopSchedules")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shop_schedules_shops_shop_id");

                    b.Navigation("Schedule");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Backend.Domain.Entities.SpecialRule", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Condition", "Condition")
                        .WithOne("SpecialRule")
                        .HasForeignKey("Backend.Domain.Entities.SpecialRule", "ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_special_rules_conditions_condition_id");

                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany("SpecialRules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_special_rules_schedules_schedule_id");

                    b.Navigation("Condition");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Condition", b =>
                {
                    b.Navigation("ExcludedMonths");

                    b.Navigation("SpecialRule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExceptionalDay", b =>
                {
                    b.Navigation("OpeningHours");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Museum", b =>
                {
                    b.Navigation("Accessibilities");

                    b.Navigation("FeatureAssociations");

                    b.Navigation("Languages");

                    b.Navigation("Schedules");

                    b.Navigation("Shops");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeature", b =>
                {
                    b.Navigation("MuseumFeatureOptions");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningPeriod", b =>
                {
                    b.Navigation("OpeningHours");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("ExceptionalDays");

                    b.Navigation("OpeningPeriods");

                    b.Navigation("SpecialRules");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Shop", b =>
                {
                    b.Navigation("ShopSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
