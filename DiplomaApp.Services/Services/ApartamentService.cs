using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Services
{
    public class ApartamentService: IApartamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ApartamentService(ApplicationContext context, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(context);
            this.mapper = mapper;
        }

        public IEnumerable<ApartamentDto> GetAparatments()
        {
            var aparts = unitOfWork.Apartaments.GetAll();
            var apartsDtos = mapper.Map<IEnumerable<ApartamentDto>>(aparts);

            return apartsDtos;
        }
    }
}
