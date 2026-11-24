using Bierbrouwerij.Application.DTO.Ingredient;
using Bierbrouwerij.Domain.Entities;

namespace Bierbrouwerij.Application.Extention.Mapping
{
    public static class IngredientMappingExtensions
    {
        public static IngredientListItemDto ToListItemDto(this Ingredient ingredient)
        {
            return new IngredientListItemDto
            {
                Naam = ingredient.Naam,
                Type = ingredient.Type,
                Hoeveelheid = ingredient.Hoeveelheid
            };
        }

        public static Ingredient ToEntity(this CreateIngredientDto dto)
        {
            return new Ingredient
            {
                Naam = dto.Naam,
                Type = dto.Type,
                Hoeveelheid = dto.Hoeveelheid
            };
        }
    }
}