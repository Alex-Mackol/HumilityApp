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
        return _context.Categories.Any(c => c.Name == entity.Name && c.Id != entity.Id);
    }

    public void Create(Category item)
    {
        _context.Categories.Add(item);
    }

    public Category Read(int id)
    {
        return _context.Categories.FirstOrDefault(c=> c.Id == id);
    }

    public void Update(Category item)
    {
        _context.Categories.Update(item);
    }

    public void Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        { 
            _context.Categories.Remove(category);
        }
    }
}