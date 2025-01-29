using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data
{
    public class MuseumContext : DbContext
    {
        public MuseumContext(DbContextOptions<MuseumContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<MuseumFeature> MuseumFeatures { get; set; }
        public DbSet<MuseumFeatureOption> MuseumFeatureOptions { get; set; }
        public DbSet<MuseumFeatureAssociation> MuseumFeatureAssociations { get; set; }
        public DbSet<UserQuestionnaireResponse> UserQuestionnaireResponses { get; set; }
        public DbSet<GroupQuestionnaireResponse> GroupQuestionnaireResponses { get; set; }
        public DbSet<UserTravelDay> UserTravelDays { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
