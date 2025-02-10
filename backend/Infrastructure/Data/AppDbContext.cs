// File: Backend/Infrastructure/Data/AppDbContext.cs
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<MuseumFeature> MuseumFeatures { get; set; }
        public DbSet<MuseumFeatureOption> MuseumFeatureOptions { get; set; }
        public DbSet<MuseumFeatureAssociation> MuseumFeatureAssociations { get; set; }
        // public DbSet<UserQuestionnaireResponse> UserQuestionnaireResponses { get; set; }
        // public DbSet<GroupQuestionnaireResponse> GroupQuestionnaireResponses { get; set; }
        // public DbSet<UserTravelDay> UserTravelDays { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        // public DbSet<Question> Questions { get; set; }
        
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<MuseumSchedule> MuseumSchedules { get; set; }
        public DbSet<ShopSchedule> ShopSchedules { get; set; }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<ExceptionalDay> ExceptionalDays { get; set; }
        public DbSet<OpeningPeriod> OpeningPeriods { get; set; }
        //public DbSet<SpecialRule> SpecialRules { get; set; }
        //public DbSet<Condition> Conditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MUSEUM RELATIONS
            modelBuilder.Entity<Museum>()
                .HasOne(m => m.Shop)
                .WithOne()
                .HasForeignKey<Shop>(s => s.ShopId);

            modelBuilder.Entity<Museum>()
                .HasMany(m => m.MuseumSchedules)
                .WithOne(ms => ms.Museum)
                .HasForeignKey(ms => ms.MuseumId)
                .OnDelete(DeleteBehavior.Cascade);

            // SHOP RELATIONS
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.ShopSchedules)
                .WithOne(ss => ss.Shop)
                .HasForeignKey(ss => ss.ShopId)
                .OnDelete(DeleteBehavior.Cascade);

            // SCHEDULE RELATIONS
            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.OpeningPeriods)
                .WithOne(op => op.Schedule)
                .HasForeignKey(op => op.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.ExceptionalDays)
                .WithOne(ed => ed.Schedule)
                .HasForeignKey(ed => ed.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            // MUSEUM SCHEDULE RELATIONS
            modelBuilder.Entity<MuseumSchedule>()
                .HasKey(ms => new { ms.MuseumId, ms.ScheduleId });

            modelBuilder.Entity<MuseumSchedule>()
                .HasOne(ms => ms.Museum)
                .WithMany(m => m.MuseumSchedules)
                .HasForeignKey(ms => ms.MuseumId);

            modelBuilder.Entity<MuseumSchedule>()
                .HasOne(ms => ms.Schedule)
                .WithMany()
                .HasForeignKey(ms => ms.ScheduleId);

            // SHOP SCHEDULE RELATIONS
            modelBuilder.Entity<ShopSchedule>()
                .HasKey(ss => new { ss.ShopId, ss.ScheduleId });

            modelBuilder.Entity<ShopSchedule>()
                .HasOne(ss => ss.Shop)
                .WithMany(s => s.ShopSchedules)
                .HasForeignKey(ss => ss.ShopId);

            modelBuilder.Entity<ShopSchedule>()
                .HasOne(ss => ss.Schedule)
                .WithMany()
                .HasForeignKey(ss => ss.ScheduleId);

            // EXCEPTIONAL DAY RELATIONS
            modelBuilder.Entity<ExceptionalDay>()
                .HasOne(ed => ed.Schedule)
                .WithMany(s => s.ExceptionalDays)
                .HasForeignKey(ed => ed.ScheduleId);

            modelBuilder.Entity<ExceptionalDay>()
                .HasMany(ed => ed.OpeningHours)
                .WithOne(oh => oh.ExceptionalDay)
                .HasForeignKey(oh => oh.ExceptionalDayId)
                .OnDelete(DeleteBehavior.Cascade);

            // SPECIAL RULE RELATIONS
            modelBuilder.Entity<SpecialRule>()
                .HasOne(sr => sr.Condition)
                .WithOne()
                .HasForeignKey<Condition>(c => c.ConditionId);

            // MUSEUM FEATURE ASSOCIATION RELATIONS
            modelBuilder.Entity<MuseumFeatureAssociation>()
                .HasKey(mfa => new { mfa.MuseumId, mfa.MuseumFeatureOptionId });

            modelBuilder.Entity<MuseumFeatureAssociation>()
                .HasOne(mfa => mfa.Museum)
                .WithMany(m => m.MuseumFeatureAssociations)
                .HasForeignKey(mfa => mfa.MuseumId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MuseumFeatureAssociation>()
                .HasOne(mfa => mfa.MuseumFeatureOption)
                .WithMany()
                .HasForeignKey(mfa => mfa.MuseumFeatureOptionId)
                .OnDelete(DeleteBehavior.Cascade);

            // GROUP QUESTIONNAIRE RESPONSE RELATIONS
            //modelBuilder.Entity<GroupQuestionnaireResponse>()
            //    .HasKey(gqr => gqr.Id);

            //modelBuilder.Entity<GroupQuestionnaireResponse>()
            //    .HasOne(gqr => gqr.User)
            //    .With

        }
    }
}