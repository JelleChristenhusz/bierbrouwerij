using Bierbrouwerij.Application.DTO.Ingredient;

namespace Bierbrouwerij.Application.DTO.Bier
{
    public class CreateBierDto
    {
        public string Naam { get; set; } = string.Empty;
        public string Beschrijving { get; set; } = string.Empty;
        public double Alcoholpercentage { get; set; }

        public List<CreateIngredientDto> Ingredienten { get; set; } = new();
    }
}
