using AutoMapper;
using HealthAssistant.Application.UseCases.Products.Commands.UpdateProduct;
using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCases.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>

    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken token)
        {
            var existingProduct = await _repo.GetByIdAsync(request.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException("Product doesn't exist.");

            // Обновляем поля продукта из запроса
            _mapper.Map(request, existingProduct);

            // Обновляем в базе данных
            await _repo.UpdateAsync(existingProduct, token);

        }
    }
}
