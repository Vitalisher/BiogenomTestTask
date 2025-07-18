namespace BiogenomNutrition.Domain.Entities;

    public class ContentTemplate
    {
        public int Id { get; set; }
        public string TemplateType { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
