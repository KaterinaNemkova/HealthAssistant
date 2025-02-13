using HealthAssistant.Application.UseCases.Products.Queries.SearchListProductsByName;
using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using MediatR;


namespace HealthAssistant.Application.UseCases.Products.Queries.SearchListProductsByName
{
    public class SearchListProductsByNameQueryHandler : IRequestHandler<SearchListProductsByNameQuery, List<Product>>
    {
        private readonly IProductRepository _repo;

        public SearchListProductsByNameQueryHandler(IProductRepository repository)
        {
            _repo = repository;
        }
        public async Task<List<Product>> Handle(SearchListProductsByNameQuery request, CancellationToken token)
        {
            List<Product>? products = await _repo.SearchByNameAsync(request.name, token);

            if (products == null)
                throw new KeyNotFoundException($"Products with such name not found.");

            return products;

        }
    }
}
