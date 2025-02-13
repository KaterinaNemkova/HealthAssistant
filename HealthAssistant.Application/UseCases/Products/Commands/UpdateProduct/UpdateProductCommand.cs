using HealthAssistant.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.UseCases.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand
        (
        Guid Id,
        string Name,
        double CaloriesPer100g,
        double ProteinsPer100g,
        double FatsPer100g,
        double CarbsPer100g,
        double FiberPer100g,
        double SugarPer100g) : IRequest;


}
