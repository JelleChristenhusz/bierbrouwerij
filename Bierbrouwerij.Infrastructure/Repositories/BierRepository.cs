using Bierbrouwerij.Domain.Entities;
using Bierbrouwerij.Domain.Interfaces;
using Bierbrouwerij.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bierbrouwerij.Infrastructure.Repositories
{
    public class BierRepository : Repository<Bier>, IBierRepository
    {
        private readonly BierbrouwerijDbContext _context;

        public BierRepository(BierbrouwerijDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Bier?> GetByIdWithIngredientenAsync(int id)
        {
            return await _context.Bieren
                .Include(b => b.Ingredienten)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}