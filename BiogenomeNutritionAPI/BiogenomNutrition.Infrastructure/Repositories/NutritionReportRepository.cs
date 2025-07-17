using Microsoft.EntityFrameworkCore;
using BiogenomNutrition.Domain.Entities;
using BiogenomNutrition.Domain.Interfaces;
using BiogenomNutrition.Application.DTOs;
using BiogenomNutrition.Infrastructure.Data;

namespace BiogenomNutrition.Infrastructure.Repositories
{
    public class NutritionReportRepository : INutritionReportRepository
    {
        private readonly NutritionDbContext _context;

        public NutritionReportRepository(NutritionDbContext context)
        {
            _context = context;
        }

        public async Task<NutritionReport> GetLatestReportAsync()
        {
            return await _context.NutritionReports
                .Include(r => r.NutrientIntakes)
                .ThenInclude(ni => ni.Nutrient)
                .Include(r => r.SupplementRecommendations)
                .ThenInclude(sr => sr.Supplement)
                .OrderByDescending(r => r.ReportDate)
                .FirstOrDefaultAsync();
        }
        
        public async Task<NutritionReport> GetReportByIdAsync(int reportId)
        {
            return await _context.NutritionReports
                .Include(r => r.NutrientIntakes)
                .ThenInclude(ni => ni.Nutrient)
                .Include(r => r.SupplementRecommendations)
                .ThenInclude(sr => sr.Supplement)
                .FirstOrDefaultAsync(r => r.Id == reportId);
        }

        public async Task<List<Nutrient>> GetAllNutrientsAsync()
        {
            return await _context.Nutrients.ToListAsync();
        }

        public async Task<List<Supplement>> GetRecommendedSupplementsAsync(int reportId)
        {
            return await _context.SupplementRecommendations
                .Where(sr => sr.ReportId == reportId)
                .Select(sr => sr.Supplement)
                .ToListAsync();
        }

        public async Task<ContentTemplateResponse> GetBenefitsTemplateAsync()
        {
            var template = await _context.ContentTemplates
                .Where(ct => ct.TemplateType == "benefits")
                .Select(ct => ct.Content)
                .FirstOrDefaultAsync();

            if (template != null)
            {
                return new ContentTemplateResponse(template, true);
            }
            return new ContentTemplateResponse(null, false, "Преимущества не найдены");
        }

        public async Task<List<NutrientIntake>> GetNutrientsByReportIdAsync(int reportId)
        {
            return await _context.NutrientIntakes
                .Where(ni => ni.ReportId == reportId)
                .Include(ni => ni.Nutrient)
                .ToListAsync();
        }

        public async Task<ContentTemplate> GetBenefitsTemplateAsync(int reportId)
        {
            return await _context.ContentTemplates
                .Where(ct => ct.TemplateType == "benefits")
                .FirstOrDefaultAsync();
        }
    }
}