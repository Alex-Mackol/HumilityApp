using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Services;

public class ProductService: IProductService
{
    private readonly IProductUnitOfWork productUnitOfWork;
    private readonly IMapper mapper;
    public ProductService(ApplicationContext context, IMapper mapper)
    {
        productUnitOfWork = new ProductUnitOfWork(context);
        this.mapper = mapper;
    }

    public IEnumerable<ProductDto> GetProducts(string category)
    {
        var products = productUnitOfWork.Products.GetAll();

        if (!string.IsNullOrEmpty(category))
        {
            products = products.Where(p => p.Category.Name.ToLower() == category.ToLower()).ToList();
        }

        var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDtos;
    }

    public void Create(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public ProductDto Read(ushort id)
    {
        throw new NotImplementedException();
    }

    public void Update(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public ProductDto Delete(ushort id)
    {
        throw new NotImplementedException();
    }
}