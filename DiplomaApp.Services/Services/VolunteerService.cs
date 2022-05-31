using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;

namespace DiplomaApp.Services.Services
{
    public class VolunteerService:IVolunteerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public VolunteerService(ApplicationContext context, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(context);
            this.mapper = mapper;
        }
        public void Create(string userId)
        {
            Volunteer volunteer = new Volunteer { UserId = userId };
            unitOfWork.Volunteers.Create(volunteer);
            unitOfWork.Save();
        }
    }
}
