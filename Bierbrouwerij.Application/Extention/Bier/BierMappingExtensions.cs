using Bierbrouwerij.Application.DTO.Bier;
using Bierbrouwerij.Domain.Entities;

namespace Bierbrouwerij.Application.Extention.Mapping
{
    public static class BierMappingExtensions
    {
        public static BierListItemDto ToListItemDto(this Bier bier)
        {
            return new BierListItemDto
            {
                Id = bier.Id,
                Naam = bier.Naam,
                Beschrijving = bier.Beschrijving,
                Alcoholpercentage = bier.Alcoholpercentage
            };
        }

        public static BierDetailDto ToDetailDto(this Bier bier)
        {
            return new BierDetailDto
            {
                Id = bier.Id,
                Naam = bier.Naam,
                Beschrijving = bier.Beschrijving,
                Alcoholpercentage = bier.Alcoholpercentage,
                Ingredienten = bier.Ingredienten
                    .Select(i => i.ToListItemDto())
                    .ToList()
            };
        }

        public static Bier ToEntity(this CreateBierDto dto)
        {
            return new Bier
            {
                Naam = dto.Naam,
                Beschrijving = dto.Beschrijving,
                Alcoholpercentage = dto.Alcoholpercentage,
                Ingredienten = dto.Ingredienten
                    .Select(i => i.ToEntity())
                    .ToList()
            };
        }
    }
}