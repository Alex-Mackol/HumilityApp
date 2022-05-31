﻿using System;
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

            CreateMap<Apartament, ApartamentDto>()
                .ForMember(dst => dst.VolunteerPhone, act => act.MapFrom(src => src.Volunteer.PhoneNumber))
                .ForMember(dst => dst.VolunterName, act => act.MapFrom(src => src.Volunteer.Name))
                .ForMember(dst => dst.TypeOfHouse, act => act.MapFrom(src => src.TypeOfHouse));

            CreateMap<CategoryDto, Category>()
                .ForMember(dst => dst.Products, act => act.Ignore())
                .ReverseMap();
            //User
            CreateMap<User, UserDto>().ReverseMap();
            //Role
            CreateMap<Role, RoleDto>()
                .ForMember(dst => dst.Name, act => act.MapFrom(src => src.Name));

            CreateMap<Refugee, RefugeesDto>()
                .ForMember(dst => dst.Helps, act => act.MapFrom(src => src.Helps));
            CreateMap<RefugeesDto, Refugee>()
                .ForMember(dst => dst.Helps, act => act.Ignore());

        }
    }
}
