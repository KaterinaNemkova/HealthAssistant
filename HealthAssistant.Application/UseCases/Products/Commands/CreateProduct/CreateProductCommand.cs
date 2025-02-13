using HealthAssistant.Application.Others.DTOs;
using HealthAssistant.Domain.Entities;
using MediatR;


namespace HealthAssistant.Application.UseCases.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        double CaloriesPer100g,
        double ProteinsPer100g,
        double FatsPer100g,
        double CarbsPer100g,
        double FiberPer100g,
        double SugarPer100g) : IRequest<ProductDto>;

}
