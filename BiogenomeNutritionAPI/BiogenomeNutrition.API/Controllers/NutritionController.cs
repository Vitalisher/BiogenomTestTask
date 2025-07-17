using BiogenomNutrition.Application;
using Microsoft.AspNetCore.Mvc;
using BiogenomNutrition.Application.Services;
using BiogenomNutrition.Application.DTOs;

namespace BiogenomNutrition.API.Controllers
{
    [Route("api/nutrition/report")]
    [ApiController]
    public class NutritionReportController : ControllerBase
    {
        private readonly INutritionReportService _service;

        public NutritionReportController(INutritionReportService service)
        {
            _service = service;
        }

        [HttpGet("{reportId}")]
        public async Task<ActionResult<NutritionReportDto>> GetReport(int reportId)
        {
            var report = await _service.GetReportAsync(reportId);
            return Ok(report);
        }

        [HttpGet("nutrients/{reportId}")]
        public async Task<ActionResult<List<NutrientIntakeDto>>> GetNutrients(int reportId)
        {
            var nutrients = await _service.GetNutrientsAsync(reportId);
            return Ok(nutrients);
        }

        [HttpGet("supplements/{reportId}")]
        public async Task<ActionResult<List<SupplementDto>>> GetSupplements(int reportId)
        {
            var supplements = await _service.GetSupplementsAsync(reportId);
            return Ok(supplements);
        }

        [HttpGet("benefits/{reportId}")]
        public async Task<ActionResult<ContentTemplateResponse>> GetBenefits(int reportId)
        {
            var response = await _service.GetBenefitsAsync(reportId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(new { error = response.ErrorMessage });
        }

        [HttpGet("nutrients/supplements/{reportId}")]
        public async Task<ActionResult<List<NutrientIntakeDto>>> GetNutrientsWithSupplements(int reportId)
        {
            var nutrients = await _service.GetNutrientsWithSupplementsAsync(reportId);
            return Ok(nutrients);
        }
    }
}