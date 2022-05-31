using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts(string category);

    void Create(ProductDto product);

    ProductDto Read(int id);

    void Update(ProductDto product);

    ProductDto Delete(ushort id);
}