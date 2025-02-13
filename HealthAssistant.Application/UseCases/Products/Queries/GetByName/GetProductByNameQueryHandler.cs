using AutoMapper;
using HealthAssistant.Application.Others.DTOs;
using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCases.Products.Queries.GetByName
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, ProductDto>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public GetProductByNameQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;

        }
        public async Task<ProductDto> Handle(GetProductByNameQuery request, CancellationToken token)
        {
            Product? entity = await _repo.GetByNameAsync(request.name, token);

            if (entity == null)
                throw new KeyNotFoundException($"Product with such name doesn't exist.");

            return _mapper.Map<ProductDto>(entity);
        }
    }
}
