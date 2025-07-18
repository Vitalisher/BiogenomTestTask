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
        private readonly ILogger<NutritionReportController> _logger;

        public NutritionReportController(INutritionReportService service, ILogger<NutritionReportController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Получает отчет о питании по ID
        /// </summary>
        /// <param name="reportId">Идентификатор отчета</param>
        /// <returns>Данные отчета о питании</returns>
        [HttpGet("{reportId}")]
        public async Task<ActionResult<NutritionReportDto>> GetReport(int reportId)
        {
            try
            {
                if (reportId <= 0)
                    return BadRequest("Report ID must be greater than 0");

                var report = await _service.GetReportAsync(reportId);
                return Ok(report);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Report not found for ID: {ReportId}", reportId);
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting report for ID: {ReportId}", reportId);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        /// <summary>
        /// Получает список нутриентов для отчета
        /// </summary>
        /// <param name="reportId">Идентификатор отчета</param>
        /// <returns>Список нутриентов с их статусами</returns>
        [HttpGet("nutrients/{reportId}")]
        public async Task<ActionResult<List<NutrientIntakeDto>>> GetNutrients(int reportId)
        {
            try
            {
                if (reportId <= 0)
                    return BadRequest("Report ID must be greater than 0");

                var nutrients = await _service.GetNutrientsAsync(reportId);
                return Ok(nutrients);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Nutrients not found for report ID: {ReportId}", reportId);
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting nutrients for report ID: {ReportId}", reportId);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet("supplements/{reportId}")]
        public async Task<ActionResult<List<SupplementDto>>> GetSupplements(int reportId)
        {
            try
            {
                if (reportId <= 0)
                    return BadRequest("Report ID must be greater than 0");

                var supplements = await _service.GetSupplementsAsync(reportId);
                return Ok(supplements);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Supplements not found for report ID: {ReportId}", reportId);
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting supplements for report ID: {ReportId}", reportId);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet("benefits/{reportId}")]
        public async Task<ActionResult<ContentTemplateResponse>> GetBenefits(int reportId)
        {
            try
            {
                if (reportId <= 0)
                    return BadRequest("Report ID must be greater than 0");

                var response = await _service.GetBenefitsAsync(reportId);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return NotFound(new { error = response.ErrorMessage });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting benefits for report ID: {ReportId}", reportId);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet("nutrients/supplements/{reportId}")]
        public async Task<ActionResult<List<NutrientIntakeDto>>> GetNutrientsWithSupplements(int reportId)
        {
            try
            {
                if (reportId <= 0)
                    return BadRequest("Report ID must be greater than 0");

                var nutrients = await _service.GetNutrientsWithSupplementsAsync(reportId);
                return Ok(nutrients);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Nutrients with supplements not found for report ID: {ReportId}", reportId);
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting nutrients with supplements for report ID: {ReportId}", reportId);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
    }
}