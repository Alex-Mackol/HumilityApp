using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Repositories;

namespace DiplomaApp.Repositories.Models
{
    public class ProductUnitOfWork:IProductUnitOfWork
    {
        private readonly ApplicationContext context;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private OrderRepository orderRepository;
        private bool disposed = false;

        public ProductUnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }

        public IRepository<Product> Products => productRepository ??= new ProductRepository(context);

        public IRepository<Category> Categories => categoryRepository ??= new CategoryRepository(context);

        public IRepository<Order> Orders => orderRepository ??= new OrderRepository(context);

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
