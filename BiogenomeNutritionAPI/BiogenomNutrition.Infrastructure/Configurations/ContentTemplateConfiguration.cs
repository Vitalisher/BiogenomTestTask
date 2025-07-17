using BiogenomNutrition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomNutrition.Infrastructure.Repositories;

public class ContentTemplateConfiguration : IEntityTypeConfiguration<ContentTemplate>
{
    public void Configure(EntityTypeBuilder<ContentTemplate> builder)
    {
        builder.HasKey(ct => ct.Id);
        builder.Property(ct => ct.TemplateType).IsRequired().HasMaxLength(50);
        builder.Property(ct => ct.Content).IsRequired();
        builder.HasData(
            new ContentTemplate { Id = 1, TemplateType = "benefits", Content = "<ul><li>Устраняют дефицит</li></ul>" }
        );
    }
};