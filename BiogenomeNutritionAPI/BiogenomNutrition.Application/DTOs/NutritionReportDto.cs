namespace BiogenomNutrition.Application.DTOs;

    public class NutritionReportDto
    {
        public int DeficitCount { get; set; }
        public int SufficientCount { get; set; }
        public DateTime ReportDate { get; set; }
    }
