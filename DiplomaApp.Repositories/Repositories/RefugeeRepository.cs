
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;

namespace DiplomaApp.Repositories.Repositories
{
    public class RefugeeRepository : IRepository<Refugee>
    {
        private readonly ApplicationContext context;
        public RefugeeRepository(ApplicationContext context)
        {
            this.context = context;
        }
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
            context.Refugees.Update(item);
        }
        public void Create(Refugee item)
        {
            context.Refugees.Add(item);
        }

        public void Delete(ushort id)
        {
            throw new NotImplementedException();
        }
    }
}
