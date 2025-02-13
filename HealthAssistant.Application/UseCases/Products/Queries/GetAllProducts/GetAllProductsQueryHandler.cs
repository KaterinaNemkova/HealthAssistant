using AutoMapper;
using HealthAssistant.Application.Others;
using HealthAssistant.Application.Others.DTOs;
using HealthAssistant.Application.UseCases.Products.Queries.GetAllProducts;
using HealthAssistant.Domain.Abstractions;
using MediatR;


namespace HealthAssistant.Application.UseCases.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repo.GetAllAsync(cancellationToken);

            var products = _mapper.Map<List<ProductDto>>(entities);

            return products;
        }
    }
}
