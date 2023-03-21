using AutoMapper;
using ProductsCleanArch.Application.DTOs;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
