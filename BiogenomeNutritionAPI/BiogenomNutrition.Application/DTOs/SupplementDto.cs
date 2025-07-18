using System.ComponentModel.DataAnnotations;

namespace BiogenomNutrition.Application.DTOs;

public class SupplementDto
{
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public List<NutrientIntakeDto>? Nutrients { get; set; }
}
