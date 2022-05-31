using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Repositories.Repositories;

public class ProductRepository:IRepository<Product>
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context; 
    }
    public IEnumerable<Product> GetAll()
    {
        return _context.Products
            .Include(p=>p.Category)
            .ToList();
    }

    public IEnumerable<string> GetEntityNames()
    {
        throw new NotImplementedException();
    }

    public bool IsEntityExist(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Create(Product item)
    {
        throw new NotImplementedException();
    }

    public Product Read(int id)
    {
        return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
    }

    public void Update(Product item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}