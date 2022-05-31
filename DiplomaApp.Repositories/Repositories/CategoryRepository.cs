using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Repositories.Repositories;

public class CategoryRepository:IRepository<Category>
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories
            .Include(c=>c.Products)
            .ToList();
    }

    public IEnumerable<string> GetEntityNames()
    {
        return _context.Categories.Select(c => c.Name).ToList();
    }

    public bool IsEntityExist(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Create(Category item)
    {
        throw new NotImplementedException();
    }

    public Category Read(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Category item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}