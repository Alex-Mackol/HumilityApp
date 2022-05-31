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
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Services
{
  
    public class RefugeeService:IRefugeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public RefugeeService(ApplicationContext context, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(context);
            this.mapper = mapper;
        }
        public void Create(string userId)
        {
            Refugee refugee = new Refugee {UserId = userId};
            unitOfWork.Refugees.Create(refugee);
            unitOfWork.Save();
        }
    }
}
