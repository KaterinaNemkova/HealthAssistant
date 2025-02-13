using AutoMapper;
using HealthAssistant.Application.UseCAses.Products.Commands.DeleteProduct;
using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCases.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repo;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repo = repository;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken token)
        {
            Product? entity = await _repo.GetByIdAsync(request.id);

            if (entity == null)
                throw new KeyNotFoundException($"Product doesn't exist.");

            await _repo.Delete(entity, token);

        }
    }
}
