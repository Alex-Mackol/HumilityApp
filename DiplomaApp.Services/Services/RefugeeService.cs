using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Enum;
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

        public void Update(RefugeesDto refugeesDto, UserDto userDto)
        {
            List<TypeOfHelp> typeics = new List<TypeOfHelp>();
            if (refugeesDto.Helps.Count > 0)
            {
                foreach (var help in refugeesDto.Helps)
                {
                    switch (help)
                    {
                        case "Допомога із іжею":
                            typeics.Add(TypeOfHelp.Food);
                            break;
                        case "Допомога із пошуком житла":
                            typeics.Add(TypeOfHelp.Apartaments);
                            break;
                        case "Допомога з одягом":
                            typeics.Add(TypeOfHelp.Clothes);
                            break;
                        case "Допомога з лікування":
                            typeics.Add(TypeOfHelp.Medicines);
                            break;
                        case "Допомога для дітей":
                            typeics.Add(TypeOfHelp.ChildrenGoods);
                            break;
                        default:
                            typeics.Add(TypeOfHelp.AnimalGoods);
                            break;
                    }
                }
            }


            var refugee = mapper.Map<Refugee>(refugeesDto);
            foreach (var type in typeics)
            {
                refugee.Id = 0;
                refugee.Helps = type;
                unitOfWork.Refugees.Create(refugee);
            }
            unitOfWork.Save();


        }
    }
}
