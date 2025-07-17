using BiogenomNutrition.Domain.Enums;

namespace BiogenomNutrition.Application.DTOs;

    public class NutrientIntakeDto
    {
        public string Name { get; set; }
        public decimal CurrentValue { get; set; }
        public string Unit { get; set; }
        public decimal NormValue { get; set; }
        public decimal Percentage { get; set; }
        public NutrientStatus Status { get; set; }
        public decimal? UpdatedValue { get; set; }
    }
