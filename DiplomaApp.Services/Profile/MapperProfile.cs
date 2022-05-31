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
                .ForMember(dst => dst.Category, act => act.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<CategoryDto, Category>()
                .ForMember(dst => dst.Products, act => act.Ignore())
                .ReverseMap();
            //User
            CreateMap<User, UserDto>().ReverseMap();
            //Role
            CreateMap<Role, RoleDto>()
                .ForMember(dst => dst.Name, act => act.MapFrom(src => src.Name));
        }
    }
}
