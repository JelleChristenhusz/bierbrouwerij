using Bierbrouwerij.Domain.Interfaces;

namespace Bierbrouwerij.Domain.Entities
{
    public class Bier : IEntity
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Beschrijving { get; set; } = string.Empty;
        public double Alcoholpercentage { get; set; }
        public List<Ingredient> Ingredienten { get; set; } = new();

    }
}
