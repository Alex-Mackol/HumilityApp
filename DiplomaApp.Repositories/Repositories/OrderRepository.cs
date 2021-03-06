using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Repositories.Repositories;

public class OrderRepository:IRepository<Order>
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders.Include(x => x.Product).ToList();
    }

    public IEnumerable<string> GetEntityNames()
    {
        return _context.Orders.Select(o => o.CartId).ToList();
    }

    public bool IsEntityExist(Order entity)
    {
        return _context.Orders.Any(x => x.CartId == entity.CartId && x.Product.Name == entity.Product.Name && x.Id != entity.Id);
    }

    public void Create(Order item)
    {
        _context.Orders.Add(item);
    }

    public Order Read(int id)
    {
        return _context.Orders.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Order item)
    {
        _context.Orders.Update(item);
    }

    public void Delete(int id)
    {
        Order order = Read(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }
    }
}