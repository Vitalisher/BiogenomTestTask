using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Repositories;

public class SupplementNutrientConfiguration : IEntityTypeConfiguration<SupplementNutrient>
{
    public void Configure(EntityTypeBuilder<SupplementNutrient> builder)
    {
        builder.HasKey(sn => sn.Id);
        builder.HasOne(sn => sn.Supplement)
            .WithMany()
            .HasForeignKey(sn => sn.SupplementId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(sn => sn.Nutrient)
            .WithMany()
            .HasForeignKey(sn => sn.NutrientId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(sn => sn.AddedValue);
    }
};