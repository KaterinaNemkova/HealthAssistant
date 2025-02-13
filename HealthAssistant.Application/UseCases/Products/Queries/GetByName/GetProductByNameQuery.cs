using HealthAssistant.Application.Others.DTOs;
using HealthAssistant.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCases.Products.Queries.GetByName
{
    public record GetProductByNameQuery(string name) : IRequest<ProductDto>;
}
