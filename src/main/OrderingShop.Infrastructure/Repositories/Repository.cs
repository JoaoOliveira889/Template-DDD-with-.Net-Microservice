using Microsoft.EntityFrameworkCore;
using OrderingShop.Infrastructure.Context.Entities;
using OrderingShop.Infrastructure.Context;
using OrderingShop.Infrastructure.Interfaces;

namespace OrderingShop.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _entities.AsNoTracking().ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int? id) =>
            await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

        public virtual async Task<bool> InsertAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}