using AutoMapper;
using SalamAir.Domain.Entities;
using SalamAir.TestApi.DTOs;

namespace SalamAir.TestApi.Mappings
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ReverseMap();
            CreateMap<SubCategory, CategoryDto>()
                .ReverseMap();
            CreateMap<Item, ItemDto>()
                .ReverseMap();
            CreateMap<Cart, CartDto>()
                .ReverseMap();
        }
    }
}
