using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Data;

namespace DiplomaApp.Repositories.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ApplicationContext context;
        public VolunteerRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Volunteer> GetAll()
        {
            return context.Volunteers.ToList();
        }

        public IEnumerable<string> GetEntityNames()
        {
            return context.Volunteers.Select(v => v.Name).ToList();
        }

        public bool IsEntityExist(Volunteer entity)
        {
            return context.Volunteers.Any(v =>
                v.Name == entity.Name && v.PhoneNumber == entity.PhoneNumber && v.UserId == entity.UserId &&
                v.Id != entity.Id);
        }

        public Volunteer Read(string id)
        {
            return context.Volunteers.Where(v => v.UserId == id).FirstOrDefault();
        }

        public void Create(Volunteer item)
        {
            context.Volunteers.Add(item);
        }
     
        public void Update(Volunteer item)
        {
            context.Volunteers.Update(item);
        }
        public void Delete(int id)
        {
            var volunt = context.Volunteers.Find(id);
            if (volunt != null)
            {
                context.Volunteers.Remove(volunt);
                ;
            }
        }
    }
}
