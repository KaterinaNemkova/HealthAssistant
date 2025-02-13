using HealthAssistant.Application.Others;
using HealthAssistant.Application.Others.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCases.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<List<ProductDto>>;

}
