using Microsoft.EntityFrameworkCore;
using BiogenomNutrition.Domain.Entities;
using BiogenomNutrition.Infrastructure.Repositories;

namespace BiogenomNutrition.Infrastructure.Data
{
    public class NutritionDbContext : DbContext
    {
        public NutritionDbContext(DbContextOptions<NutritionDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<NutritionReport> NutritionReports { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<NutrientIntake> NutrientIntakes { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SupplementRecommendation> SupplementRecommendations { get; set; }
        public DbSet<SupplementNutrient> SupplementNutrients { get; set; }
        public DbSet<ContentTemplate> ContentTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NutritionReportConfiguration());
            modelBuilder.ApplyConfiguration(new NutrientConfiguration());
            modelBuilder.ApplyConfiguration(new NutrientIntakeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplementConfiguration());
            modelBuilder.ApplyConfiguration(new SupplementRecommendationConfiguration());
            modelBuilder.ApplyConfiguration(new SupplementNutrientConfiguration());
            modelBuilder.ApplyConfiguration(new ContentTemplateConfiguration());
        }
    }
}