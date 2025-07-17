using BiogenomNutrition.Application.DTOs;
using BiogenomNutrition.Domain.Entities;
using BiogenomNutrition.Domain.Interfaces;

namespace BiogenomNutrition.Application.Services
{
    public class NutritionReportService : INutritionReportService
    {
        private readonly INutritionReportRepository _repository;

        public NutritionReportService(INutritionReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<NutritionReportDto> GetReportAsync(int reportId)
        {
            var report = await _repository.GetReportByIdAsync(reportId);
            if (report == null) throw new ArgumentException("Report not found");
            return new NutritionReportDto
            {
                DeficitCount = report.DeficitCount,
                SufficientCount = report.SufficientCount,
                ReportDate = report.ReportDate
            };
        }

        public async Task<List<NutrientIntakeDto>> GetNutrientsAsync(int reportId)
        {
            var nutrientIntakes = await _repository.GetNutrientsByReportIdAsync(reportId);
            if (!nutrientIntakes.Any()) throw new ArgumentException("Nutrient data not found for the report");

            return nutrientIntakes.Select(ni => new NutrientIntakeDto
            {
                Name = ni.Nutrient.Name,
                CurrentValue = ni.CurrentValue,
                Unit = ni.Nutrient.Unit,
                NormValue = ni.Nutrient.NormValue,
                Percentage = ni.Percentage,
                Status = ni.Status
            }).ToList();
        }

        public async Task<List<SupplementDto>> GetSupplementsAsync(int reportId)
        {
            var report = await _repository.GetReportByIdAsync(reportId);
            if (report == null) throw new ArgumentException("Report not found");
            var supplements = await _repository.GetRecommendedSupplementsAsync(report.Id);
            return supplements.Select(s => new SupplementDto
            {
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                Description = s.Description
            }).ToList();
        }

        public async Task<ContentTemplateResponse> GetBenefitsAsync(int reportId)
        {
            var template = await _repository.GetBenefitsTemplateAsync(reportId);
            if (template == null)
                return new ContentTemplateResponse(null, false, "Benefits template not found");
            return new ContentTemplateResponse(template.Content, true);
        }

        public async Task<List<NutrientIntakeDto>> GetNutrientsWithSupplementsAsync(int reportId)
        {
            var nutrients = await GetNutrientsAsync(reportId);
            var supplements = await GetSupplementsAsync(reportId);
            foreach (var nutrient in nutrients)
            {
                var addedValue = supplements
                    .SelectMany(s => s.Nutrients ?? new List<NutrientIntakeDto>())
                    .Where(n => n.Name == nutrient.Name)
                    .Sum(n => n.CurrentValue);
                nutrient.UpdatedValue = nutrient.CurrentValue + addedValue;
            }
            return nutrients;
        }
    }
}