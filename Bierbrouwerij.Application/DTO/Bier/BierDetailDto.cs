using Bierbrouwerij.Application.DTO.Ingredient;

namespace Bierbrouwerij.Application.DTO.Bier
{
    public class BierDetailDto
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Beschrijving { get; set; } = string.Empty;
        public double Alcoholpercentage { get; set; }

        public List<IngredientListItemDto> Ingredienten { get; set; }
    }
}
