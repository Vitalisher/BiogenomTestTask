namespace BiogenomNutrition.Domain.Entities;

public class NutritionReport
{
    public int Id { get; set; }
    public DateTime ReportDate { get; set; } 
    public int DeficitCount { get; set; }
    public int SufficientCount { get; set; }

    public List<NutrientIntake> NutrientIntakes { get; set; } = new();
    public List<SupplementRecommendation> SupplementRecommendations { get; set; } = new();
}
