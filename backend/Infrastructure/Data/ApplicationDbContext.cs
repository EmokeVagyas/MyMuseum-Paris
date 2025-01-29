using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<MuseumFeature> MuseumFeatures { get; set; }
        public DbSet<MuseumFeatureOption> MuseumFeatureOptions { get; set; }
        public DbSet<MuseumFeatureAssociation> MuseumFeatureAssociations { get; set; }
    }
}
