using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Models;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Profile
{
    public class MapperProfile: AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dst => dst.Category, act => act.MapFrom(src => src.Category.Name));
            CreateMap<ProductDto, Product>()
                .ForPath(dst => dst.Category.Name, act => act.MapFrom(src => src.Category));

            CreateMap<Apartament, ApartamentDto>()
                .ForMember(dst => dst.VolunteerPhone, act => act.MapFrom(src => src.Volunteer.PhoneNumber))
                .ForMember(dst => dst.VolunterName, act => act.MapFrom(src => src.Volunteer.Name))
                .ForMember(dst => dst.TypeOfHouse, act => act.MapFrom(src => src.TypeOfHouse));

            CreateMap<ApartamentDto, Apartament>()
                .ForPath(dst => dst.Volunteer.Id, act => act.MapFrom(src => src.VolunteerId))
                .ForPath(dst => dst.Volunteer.Name, act => act.MapFrom(src => src.VolunterName))
                .ForPath(dst => dst.Volunteer.PhoneNumber, act => act.MapFrom(src => src.VolunteerPhone))
                .ForPath(dst => dst.TypeOfHouse, act => act.Ignore());

            CreateMap<CategoryDto, Category>()
                .ForMember(dst => dst.Products, act => act.Ignore())
                .ReverseMap();
            CreateMap<Category, CategoryDto>();

            CreateMap<Volunteer, VolunteerDto>().ReverseMap();
            //User
            CreateMap<User, UserDto>().ReverseMap();
            //Role
            CreateMap<Role, RoleDto>()
                .ForMember(dst => dst.Name, act => act.MapFrom(src => src.Name));

            CreateMap<Refugee, RefugeesDto>()
                .ForMember(dst => dst.Helps, act => act.MapFrom(src => src.Helps));
            CreateMap<RefugeesDto, Refugee>()
                .ForMember(dst => dst.Helps, act => act.Ignore());

            CreateMap<OrderDto, Order>().ReverseMap();

        }
    }
}
