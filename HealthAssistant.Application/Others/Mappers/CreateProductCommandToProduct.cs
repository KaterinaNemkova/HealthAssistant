using AutoMapper;
using HealthAssistant.Application.UseCases.Products.Commands.CreateProduct;
using HealthAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.Others.Mappers
{
    public class CreateProductCommandToProduct : Profile
    {
        public CreateProductCommandToProduct()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
        }
    }
}
