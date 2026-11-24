using Bierbrouwerij.Application.DTO.Bier;
using Bierbrouwerij.Application.Extention.Mapping;  
using Bierbrouwerij.Application.Interfaces;
using Bierbrouwerij.Domain.Interfaces;

namespace Bierbrouwerij.Application.Service
{
    public class BierService : IBierService
    {
        private readonly IBierRepository _bierRepository;

        public BierService(IBierRepository bierRepository)
        {
            _bierRepository = bierRepository;
        }

        public async Task<List<BierListItemDto>> GetAllAsync()
        {
            var bieren = await _bierRepository.GetAllAsync();
            return bieren.Select(b => b.ToListItemDto()).ToList();
        }

        public async Task<BierDetailDto?> GetByIdAsync(int id)
        {
            var bier = await _bierRepository.GetByIdWithIngredientenAsync(id);
            return bier?.ToDetailDto();
        }

        public async Task CreateAsync(CreateBierDto dto)
        {
            if (dto.Alcoholpercentage < 0 || dto.Alcoholpercentage > 100)
                throw new ArgumentException("Alcoholpercentage moet tussen 0 en 100 liggen.");

            var bier = dto.ToEntity();
            await _bierRepository.AddAsync(bier);
        }
    }
}
