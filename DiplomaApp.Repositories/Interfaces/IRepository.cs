using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<string> GetEntityNames();

        bool IsEntityExist(T entity);

        void Create(T item);

        T Read(ushort id);

        void Update(T item);

        void Delete(ushort id);
    }
}
