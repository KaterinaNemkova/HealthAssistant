using HealthAssistant.Domain.Entities;

namespace HealthAssistant.Domain.Abstractions
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<List<Product>> SearchByNameAsync(string name,CancellationToken token);
    }
}