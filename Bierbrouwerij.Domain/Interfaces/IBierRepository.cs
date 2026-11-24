using Bierbrouwerij.Domain.Entities;

namespace Bierbrouwerij.Domain.Interfaces
{
    public interface IBierRepository : IRepository<Bier>
    {
        Task<Bier?> GetByIdWithIngredientenAsync(int id);
    }
}
