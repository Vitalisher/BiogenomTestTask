namespace BiogenomNutrition.Domain.Entities;

    public class SupplementNutrient
    {
        public int Id { get; set; }
        public int SupplementId { get; set; }
        public int NutrientId { get; set; }
        public decimal AddedValue { get; set; }

        public Supplement Supplement { get; set; }
        public Nutrient Nutrient { get; set; }
    }
