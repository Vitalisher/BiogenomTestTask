using BiogenomNutrition.Application.DTOs;
using BiogenomNutrition.Domain.Entities;

namespace BiogenomNutrition.Application.Services;

    public interface INutritionReportService
    {
        Task<NutritionReportDto> GetReportAsync(int reportId);
        Task<List<NutrientIntakeDto>> GetNutrientsAsync(int reportId);
        Task<List<SupplementDto>> GetSupplementsAsync(int reportId);
        Task<List<NutrientIntakeDto>> GetNutrientsWithSupplementsAsync(int reportId);
        Task<ContentTemplateResponse> GetBenefitsAsync(int reportId);
    }
