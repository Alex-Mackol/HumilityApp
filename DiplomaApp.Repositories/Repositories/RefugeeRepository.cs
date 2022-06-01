
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
            return context.Refugees.ToList();
        }

        public IEnumerable<string> GetEntityNames()
        {
            return context.Refugees.Select(r => r.UserId).ToList();
        }

        public bool IsEntityExist(Refugee entity)
        {
            return context.Refugees.Any(r =>
                r.FamilyAmount == entity.FamilyAmount && r.Helps == entity.Helps && r.Id != entity.Id);
        }

        public Refugee Read(int id)
        {
            return context.Refugees.Find(id);
        }

        public void Update(Refugee item)
        {
            context.Refugees.Update(item);
        }
        public void Create(Refugee item)
        {
            context.Refugees.Add(item);
        }

        public void Delete(int id)
        {
            var refugee = context.Refugees.Find(id);
            if (refugee != null)
            {
                context.Refugees.Update(refugee);
            }
        }
    }
}
