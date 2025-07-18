namespace BiogenomNutrition.Domain.Entities;

public class Nutrient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public decimal NormValue { get; set; }
}
