namespace BiogenomNutrition.Application.DTOs;

    public class SupplementDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<NutrientIntakeDto> Nutrients { get; set; }
    }
