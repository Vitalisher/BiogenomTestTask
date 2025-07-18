using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Configurations;

public class NutrientIntakeConfiguration : IEntityTypeConfiguration<NutrientIntake>
{
    public void Configure(EntityTypeBuilder<NutrientIntake> builder)
    {
        builder.HasKey(ni => ni.Id);
        builder.HasOne(ni => ni.Report)
            .WithMany(r => r.NutrientIntakes)
            .HasForeignKey(ni => ni.ReportId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(ni => ni.Nutrient)
            .WithMany()
            .HasForeignKey(ni => ni.NutrientId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(ni => ni.CurrentValue);
        builder.Property(ni => ni.Percentage);
    }
};