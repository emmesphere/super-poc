using SuperPoc.BuildingBlocks.Domain.Entities;

namespace SuperPoc.BuildingBlocks.Infrastructure.Persistence
{
    public class EfRepository<T> where T : AggregateRoot<Guid>
    {
        private readonly AppDbContext _context;

        public EfRepository(AppDbContext context) => _context = context;

        public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
