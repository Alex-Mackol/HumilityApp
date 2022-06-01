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
        return _context.Products.Select(p=>p.Name).ToList();
    }

    public bool IsEntityExist(Product entity)
    {
        return _context.Products.Any(p => p.Name == entity.Name && p.Category.Name == entity.Category.Name
                                                                && p.Id != entity.Id);
    }

    public void Create(Product item)
    {
        _context.Products.Add(item);
    }

    public Product Read(int id)
    {
        return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
    }

    public void Update(Product item)
    {
       _context.Products.Update(item);
    }

    public void Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            product.IsAvailable = false;
            _context.Products.Update(product);
        }
    }
}