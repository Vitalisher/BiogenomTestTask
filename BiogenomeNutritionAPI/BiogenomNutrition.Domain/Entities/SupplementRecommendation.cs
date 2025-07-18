namespace BiogenomNutrition.Domain.Entities;

    public class SupplementRecommendation
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int SupplementId { get; set; }

        public NutritionReport Report { get; set; } = null!;
        public Supplement Supplement { get; set; } = null!;
    }
