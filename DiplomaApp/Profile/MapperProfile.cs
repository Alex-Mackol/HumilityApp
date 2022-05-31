﻿using DiplomaApp.Data.Models;
using DiplomaApp.Models;
using DiplomaApp.Models.HelpRefugeeModels;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Profile;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        //User
        CreateMap<RegisterViewModel, UserDto>().ReverseMap();
        CreateMap<LoginViewModel, UserDto>().ReverseMap();
        CreateMap<RegisterHelpRefViewModel, RefugeesDto>();
        //Role
        CreateMap<Role, RoleDto>()
            .ForMember(dst => dst.Name, act => act.MapFrom(src => src.Name));
    }
}

