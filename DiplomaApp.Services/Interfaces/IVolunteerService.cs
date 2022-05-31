using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces
{
    public interface IVolunteerService
    {
        VolunteerDto GetVolunteer(string userId);
        void Create(UserDto user);
    }
}
