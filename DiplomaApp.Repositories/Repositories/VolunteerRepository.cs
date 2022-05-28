using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Repositories.Repositories
{
    public class VolunteerRepository : IRepository<Volunteer>
    {
        public IEnumerable<Volunteer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetEntityNames()
        {
            throw new NotImplementedException();
        }

        public bool IsEntityExist(Volunteer entity)
        {
            throw new NotImplementedException();
        }

        public Volunteer Read(ushort id)
        {
            throw new NotImplementedException();
        }

        public void Create(Volunteer item)
        {
            throw new NotImplementedException();
        }
     
        public void Update(Volunteer item)
        {
            throw new NotImplementedException();
        }
        public void Delete(ushort id)
        {
            throw new NotImplementedException();
        }
    }
}
