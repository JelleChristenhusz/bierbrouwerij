using Bierbrouwerij.Application.DTO.Bier;

namespace Bierbrouwerij.Application.Interfaces
{
    public interface IBierService
    {
        Task<List<BierListItemDto>> GetAllAsync();
        Task<BierDetailDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateBierDto dto);
    }
}
