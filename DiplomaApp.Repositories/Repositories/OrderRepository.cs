using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;

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
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetEntityNames()
    {
        throw new NotImplementedException();
    }

    public bool IsEntityExist(Order entity)
    {
        throw new NotImplementedException();
    }

    public void Create(Order item)
    {
        throw new NotImplementedException();
    }

    public Order Read(ushort id)
    {
        throw new NotImplementedException();
    }

    public void Update(Order item)
    {
        throw new NotImplementedException();
    }

    public void Delete(ushort id)
    {
        throw new NotImplementedException();
    }
}