using Bierbrouwerij.Domain.Interfaces;

namespace Bierbrouwerij.Domain.Entities
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double Hoeveelheid { get; set; }

        public int BierId { get; set; }
        public Bier Bier { get; set; }
    }
}
