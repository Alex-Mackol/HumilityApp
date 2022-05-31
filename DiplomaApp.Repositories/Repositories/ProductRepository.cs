﻿using DiplomaApp.Data.Data;
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

    public Product Read(ushort id)
    {
        throw new NotImplementedException();
    }

    public void Update(Product item)
    {
        throw new NotImplementedException();
    }

    public void Delete(ushort id)
    {
        throw new NotImplementedException();
    }
}