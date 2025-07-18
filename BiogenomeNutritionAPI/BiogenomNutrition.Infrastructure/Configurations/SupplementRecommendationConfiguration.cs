using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Configurations;

public class SupplementRecommendationConfiguration : IEntityTypeConfiguration<SupplementRecommendation>
{
    public void Configure(EntityTypeBuilder<SupplementRecommendation> builder)
    {
        builder.HasKey(sr => sr.Id);
        builder.HasOne(sr => sr.Report)
            .WithMany(r => r.SupplementRecommendations)
            .HasForeignKey(sr => sr.ReportId)
            .OnDelete(DeleteBehavior.Cascade); 
        builder.HasOne(sr => sr.Supplement)
            .WithMany()
            .HasForeignKey(sr => sr.SupplementId)
            .OnDelete(DeleteBehavior.Restrict);
    }
};