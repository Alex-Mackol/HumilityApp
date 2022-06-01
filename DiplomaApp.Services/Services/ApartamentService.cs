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
            var aparts = unitOfWork.Apartaments.GetAll().Where(a=>a.IsAvailable==true);
            var apartsDtos = mapper.Map<IEnumerable<ApartamentDto>>(aparts);

            return apartsDtos;
        }

        public IEnumerable<ApartamentDto> GetAparatments(int volunteerId)
        {
            var aparts = unitOfWork.Apartaments.GetAll().Where(a=>a.VolunteerId == volunteerId && a.IsAvailable==true);
            var apartsDtos = mapper.Map<IEnumerable<ApartamentDto>>(aparts);

            return apartsDtos;
        }

        public void CreateApart(ApartamentDto apartamentDto)
        {
            if (apartamentDto.Price < 0 && string.IsNullOrEmpty(apartamentDto.Street) &&
                apartamentDto.PeopleCount < 0 && apartamentDto.RoomsAmount < 0)
            {
                throw new ArgumentException("Not valid data!");
            }
            var apartament = new Apartament
            {
                Price = apartamentDto.Price,
                Street = apartamentDto.Street,
                VolunteerId = apartamentDto.VolunteerId,
                RoomsAmount = apartamentDto.RoomsAmount,
                PeopleCount = apartamentDto.PeopleCount
            };
            switch (apartamentDto.TypeOfHouse)
            {
                case "Дім":
                    apartament.TypeOfHouse = TypeOfHouse.House;
                    break;
                default:
                    apartament.TypeOfHouse = TypeOfHouse.Flat;
                    break;
            }

            if (!unitOfWork.Apartaments.IsEntityExist(apartament))
            {
                apartament.IsAvailable = true;
                unitOfWork.Apartaments.Create(apartament);
                unitOfWork.Save();
            }
        }

        public ApartamentDto Delete(int id)
        {
            var apartament = unitOfWork.Apartaments.Read(id);
            if (apartament == null)
            {
                throw new ArgumentException("The object doesn`t find!");
            }

            unitOfWork.Apartaments.Delete(apartament.Id);
            unitOfWork.Save();

            return mapper.Map<ApartamentDto>(apartament);
        }
    }
}
