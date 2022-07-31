using AutoMapper;
using OrderingShop.Domain.Dtos;
using OrderingShop.Infrastructure.Context.Entities;

namespace OrderingShop.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

