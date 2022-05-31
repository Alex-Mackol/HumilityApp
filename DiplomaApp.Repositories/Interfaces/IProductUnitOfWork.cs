using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Models;

namespace DiplomaApp.Repositories.Interfaces
{
    public interface IProductUnitOfWork
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<Order> Orders { get; }

        void Save();
    }
}
