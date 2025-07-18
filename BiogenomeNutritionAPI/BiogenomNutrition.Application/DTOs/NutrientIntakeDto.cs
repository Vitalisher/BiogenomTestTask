using BiogenomNutrition.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BiogenomNutrition.Application.DTOs;

public class NutrientIntakeDto
{
    public string Name { get; set; } = string.Empty;
    
    public decimal CurrentValue { get; set; }

    public string Unit { get; set; } = string.Empty;
    
    public decimal NormValue { get; set; }
    
    public decimal Percentage { get; set; }
    
    public NutrientStatus Status { get; set; }
    
    public decimal? UpdatedValue { get; set; }
}
