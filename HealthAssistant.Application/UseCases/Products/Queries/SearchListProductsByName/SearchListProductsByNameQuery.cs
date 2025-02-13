using HealthAssistant.Domain.Entities;
using MediatR;


namespace HealthAssistant.Application.UseCases.Products.Queries.SearchListProductsByName
{
    public record SearchListProductsByNameQuery(string name) : IRequest<List<Product>>;

}
