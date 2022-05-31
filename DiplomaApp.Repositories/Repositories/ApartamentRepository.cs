using DiplomaApp.Data.Data;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Repositories.Repositories
{
    public class ApartamentRepository : IRepository<Apartament>
    {
        private readonly ApplicationContext context;
        public ApartamentRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Apartament> GetAll()
        {
            return context.Apartaments
                .Include(a=>a.Volunteer)
                .ToList();
        }

        public IEnumerable<string> GetEntityNames()
        {
            throw new NotImplementedException();
        }

        public bool IsEntityExist(Apartament entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Apartament item)
        {
            throw new NotImplementedException();
        }

        public void Delete(ushort id)
        {
            throw new NotImplementedException();
        }
      
        public Apartament Read(ushort id)
        {
            throw new NotImplementedException();
        }

        public void Update(Apartament item)
        {
            throw new NotImplementedException();
        }
    }
}
