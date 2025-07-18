using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Configurations;

public class SupplementConfiguration : IEntityTypeConfiguration<Supplement>
{
    public void Configure(EntityTypeBuilder<Supplement> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.ImageUrl).HasMaxLength(255);
        builder.Property(s => s.Description).HasMaxLength(1000);
        
        builder.HasData(
            new Supplement { Id = 1, Name = "Мультивитамины", ImageUrl = "url", Description = "Комплекс витаминов" }
        );
    }
};