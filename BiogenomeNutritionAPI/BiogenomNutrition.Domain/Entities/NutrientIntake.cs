using BiogenomNutrition.Domain.Enums;

namespace BiogenomNutrition.Domain.Entities;

    public class NutrientIntake
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int NutrientId { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal Percentage { get; set; }
        public NutrientStatus Status { get; set; }

        public NutritionReport Report { get; set; }
        public Nutrient Nutrient { get; set; }
    }
