using Bierbrouwerij.Domain.Interfaces;
using Bierbrouwerij.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bierbrouwerij.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly BierbrouwerijDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(BierbrouwerijDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
