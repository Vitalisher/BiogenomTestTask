using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Configurations;

public class NutritionReportConfiguration : IEntityTypeConfiguration<NutritionReport>
{
    public void Configure(EntityTypeBuilder<NutritionReport> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.ReportDate).IsRequired();
        builder.Property(r => r.DeficitCount).IsRequired();
        builder.Property(r => r.SufficientCount).IsRequired();
        
        builder.HasData(
            new NutritionReport() { Id = 1, ReportDate = DateTime.Now, DeficitCount = 1, SufficientCount = 1}
        );
    }
};