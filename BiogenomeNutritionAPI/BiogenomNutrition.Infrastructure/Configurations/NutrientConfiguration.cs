using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Repositories;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
    public void Configure(EntityTypeBuilder<Nutrient> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
        builder.Property(n => n.Unit).IsRequired().HasMaxLength(10);
        builder.Property(n => n.NormValue).IsRequired();
        
        builder.HasData(
            new Nutrient { Id = 1, Name = "Витамин C", Unit = "мг", NormValue = 90 }
        );
    }
};