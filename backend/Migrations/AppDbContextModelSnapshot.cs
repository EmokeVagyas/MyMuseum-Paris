﻿// <auto-generated />
using System;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CityId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Condition", b =>
                {
                    b.Property<int>("ConditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConditionId"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("WeekOfMonth")
                        .HasColumnType("integer");

                    b.HasKey("ConditionId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ConditionExcludedMonth", b =>
                {
                    b.Property<int>("ConditionId")
                        .HasColumnType("integer");

                    b.Property<int>("ExcludedMonth")
                        .HasColumnType("integer");

                    b.HasKey("ConditionId", "ExcludedMonth");

                    b.ToTable("ConditionExcludedMonths");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CountryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExceptionalDay", b =>
                {
                    b.Property<int>("ExceptionalDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExceptionalDayId"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("ExceptionalDayId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ExceptionalDays");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Museum", b =>
                {
                    b.Property<int>("MuseumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MuseumId"));

                    b.Property<bool>("AudioGuide")
                        .HasColumnType("boolean");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Environment")
                        .HasColumnType("integer");

                    b.Property<bool>("GuidedTours")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MuseumId");

                    b.HasIndex("CityId");

                    b.ToTable("Museums");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumAccessibility", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer");

                    b.Property<int>("Accessibility")
                        .HasColumnType("integer");

                    b.HasKey("MuseumId", "Accessibility");

                    b.ToTable("MuseumAccessibilities");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FeatureType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MuseumFeatures");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureAssociation", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer");

                    b.Property<int>("MuseumFeatureOptionId")
                        .HasColumnType("integer");

                    b.HasKey("MuseumId", "MuseumFeatureOptionId");

                    b.HasIndex("MuseumFeatureOptionId");

                    b.ToTable("MuseumFeatureAssociations");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureOption", b =>
                {
                    b.Property<int>("MuseumFeatureOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MuseumFeatureOptionId"));

                    b.Property<int>("MuseumFeatureId")
                        .HasColumnType("integer");

                    b.Property<string>("OptionName")
                        .HasColumnType("text");

                    b.HasKey("MuseumFeatureOptionId");

                    b.HasIndex("MuseumFeatureId");

                    b.ToTable("MuseumFeatureOptions");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumLanguage", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.HasKey("MuseumId", "Language");

                    b.ToTable("MuseumLanguages");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumSchedule", b =>
                {
                    b.Property<int>("MuseumId")
                        .HasColumnType("integer");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("MuseumId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("MuseumSchedules");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningHour", b =>
                {
                    b.Property<int>("OpeningHourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OpeningHourId"));

                    b.Property<TimeOnly?>("ClosingTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<int?>("ExceptionalDayId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<int?>("OpeningPeriodId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly?>("OpeningTime")
                        .HasColumnType("time without time zone");

                    b.Property<int?>("ShopId")
                        .HasColumnType("integer");

                    b.HasKey("OpeningHourId");

                    b.HasIndex("ExceptionalDayId");

                    b.HasIndex("OpeningPeriodId");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningPeriod", b =>
                {
                    b.Property<int>("OpeningPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OpeningPeriodId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("LastEntryOffset")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("RoomClearingOffset")
                        .HasColumnType("interval");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("OpeningPeriodId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("OpeningPeriods");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScheduleId"));

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShopId"));

                    b.Property<int>("MuseumId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ShopId");

                    b.HasIndex("MuseumId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ShopSchedule", b =>
                {
                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("ShopId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ShopSchedules");
                });

            modelBuilder.Entity("Backend.Domain.Entities.SpecialRule", b =>
                {
                    b.Property<int>("SpecialRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SpecialRuleId"));

                    b.Property<int>("ConditionId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RuleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("SpecialRuleId");

                    b.HasIndex("ConditionId")
                        .IsUnique();

                    b.HasIndex("ScheduleId");

                    b.ToTable("SpecialRules");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Domain.Entities.City", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ConditionExcludedMonth", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Condition", "Condition")
                        .WithMany("ExcludedMonths")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExceptionalDay", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany("ExceptionalDays")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Museum", b =>
                {
                    b.HasOne("Backend.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumAccessibility", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Accessibilities")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureAssociation", b =>
                {
                    b.HasOne("Backend.Domain.Entities.MuseumFeatureOption", "MuseumFeatureOption")
                        .WithMany()
                        .HasForeignKey("MuseumFeatureOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("FeatureAssociations")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Museum");

                    b.Navigation("MuseumFeatureOption");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumFeatureOption", b =>
                {
                    b.HasOne("Backend.Domain.Entities.MuseumFeature", "MuseumFeature")
                        .WithMany("MuseumFeatureOptions")
                        .HasForeignKey("MuseumFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MuseumFeature");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumLanguage", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Languages")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MuseumSchedule", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Schedules")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Museum");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningHour", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExceptionalDay", "ExceptionalDay")
                        .WithMany("OpeningHours")
                        .HasForeignKey("ExceptionalDayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Domain.Entities.OpeningPeriod", null)
                        .WithMany("OpeningHours")
                        .HasForeignKey("OpeningPeriodId");

                    b.Navigation("ExceptionalDay");
                });

            modelBuilder.Entity("Backend.Domain.Entities.OpeningPeriod", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany("OpeningPeriods")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Shop", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Museum", "Museum")
                        .WithMany("Shops")
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ShopSchedule", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.Shop", "Shop")
                        .WithMany("ShopSchedules")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Backend.Domain.Entities.SpecialRule", b =>
                {
                    b.HasOne("Backend.Domain.Entities.Condition", "Condition")
                        .WithOne("SpecialRule")
                        .HasForeignKey("Backend.Domain.Entities.SpecialRule", "ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.Schedule", "Schedule")
                        .WithMany("SpecialRules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
