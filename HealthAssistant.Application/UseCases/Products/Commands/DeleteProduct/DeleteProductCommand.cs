using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCAses.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid id) : IRequest;

}
