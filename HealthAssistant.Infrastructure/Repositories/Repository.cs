using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HealthAssistant.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly HealthAssistantDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(HealthAssistantDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<Entity> CreateAsync(T entity, CancellationToken token)
        {
            await _entities.AddAsync(entity,token);
            await _context.SaveChangesAsync(token);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken token)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync(token);
        }


        public virtual Task Delete(T entity,CancellationToken token)
        {
            _entities.Remove(entity);
            _context.SaveChangesAsync(token);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync(CancellationToken token)
        {
            return await _entities.ToListAsync(token);
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await _entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _entities.CountAsync();
        }
    }

   
}
