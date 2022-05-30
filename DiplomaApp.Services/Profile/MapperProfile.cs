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
            //User
            CreateMap<User, UserDto>().ReverseMap();
            //Role
            CreateMap<Role, RoleDto>()
                .ForMember(dst => dst.Name, act => act.MapFrom(src => src.Name));
        }
    }
}
