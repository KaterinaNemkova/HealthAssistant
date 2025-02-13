using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthAssistant.Domain.Entities;

namespace HealthAssistant.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<Entity> CreateAsync(T entity,CancellationToken token);
        Task Delete(T entity,CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken token);
        Task<T?> GetByIdAsync(Guid id);
        Task<int> GetTotalCountAsync();
        Task UpdateAsync(T entity,CancellationToken cancellationToken);
    }
}
