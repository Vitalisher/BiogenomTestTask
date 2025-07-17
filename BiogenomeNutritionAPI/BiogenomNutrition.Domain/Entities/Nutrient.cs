namespace BiogenomNutrition.Domain.Entities;

    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal NormValue { get; set; }
    }
