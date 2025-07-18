using BiogenomNutrition.Domain.Entities;

namespace BiogenomNutrition.Domain.Interfaces;

    public interface INutritionReportRepository
    {
        Task<NutritionReport?> GetLatestReportAsync();
        Task<NutritionReport?> GetReportByIdAsync(int reportId);
        Task<List<Nutrient>> GetAllNutrientsAsync();
        Task<List<Supplement>> GetRecommendedSupplementsAsync(int reportId);
        Task<List<NutrientIntake>> GetNutrientsByReportIdAsync(int reportId);
        Task<ContentTemplate?> GetBenefitsTemplateAsync(int reportId);
    }
