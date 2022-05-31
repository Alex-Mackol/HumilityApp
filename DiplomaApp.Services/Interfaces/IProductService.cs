﻿using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts();

    void Create(ProductDto product);

    ProductDto Read(ushort id);

    void Update(ProductDto product);

    ProductDto Delete(ushort id);
}