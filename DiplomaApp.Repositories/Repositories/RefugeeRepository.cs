
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;

namespace DiplomaApp.Repositories.Repositories
{
    public class RefugeeRepository : IRepository<Refugee>
    {
        public IEnumerable<Refugee> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetEntityNames()
        {
            throw new NotImplementedException();
        }

        public bool IsEntityExist(Refugee entity)
        {
            throw new NotImplementedException();
        }

        public Refugee Read(ushort id)
        {
            throw new NotImplementedException();
        }

        public void Update(Refugee item)
        {
            throw new NotImplementedException();
        }
        public void Create(Refugee item)
        {
            throw new NotImplementedException();
        }

        public void Delete(ushort id)
        {
            throw new NotImplementedException();
        }
    }
}
