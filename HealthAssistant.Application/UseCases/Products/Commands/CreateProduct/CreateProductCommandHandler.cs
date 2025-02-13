using AutoMapper;
using HealthAssistant.Application.Others.DTOs;
using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using MediatR;


namespace HealthAssistant.Application.UseCases.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken token)
        {
            Product product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();

            await _repo.CreateAsync(product, token);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
