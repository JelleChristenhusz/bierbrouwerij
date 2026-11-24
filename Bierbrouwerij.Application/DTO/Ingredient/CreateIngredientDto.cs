namespace Bierbrouwerij.Application.DTO.Ingredient
{
    public class CreateIngredientDto
    {
        public string Naam { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double Hoeveelheid { get; set; }
    }
}
