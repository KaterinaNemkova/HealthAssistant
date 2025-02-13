using AutoMapper;
using HealthAssistant.Application.Others.DTOs;
using HealthAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Application.Others.Mappers
{
    public class ProductToProductDto : Profile
    {
        public ProductToProductDto()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
