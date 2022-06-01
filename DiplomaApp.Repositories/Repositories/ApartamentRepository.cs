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
            return context.Apartaments.Select(a => a.Street).ToList();
        }

        public bool IsEntityExist(Apartament entity)
        {
            return context.Apartaments.Any(a => a.VolunteerId == entity.VolunteerId && a.Street == entity.Street &&
                                                a.Price == entity.Price);
        }

        public void Create(Apartament item)
        {
            context.Apartaments.Add(item);
        }

        public void Delete(int id)
        {
            var apart = context.Apartaments.Find(id);
            if (apart != null)
            {
                apart.IsAvailable = false;
                context.Apartaments.Update(apart);
            }
        }
      
        public Apartament Read(int id)
        {
            return context.Apartaments.Find(id);
        }

        public void Update(Apartament item)
        {
            context.Apartaments.Update(item);
        }
    }
}
