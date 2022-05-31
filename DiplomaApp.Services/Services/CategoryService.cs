using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Services;

public class CategoryService:ICategoryService
{
    private readonly IProductUnitOfWork productUnitOfWork;
    private readonly IMapper mapper;
    public CategoryService(ApplicationContext context, IMapper mapper)
    {
        productUnitOfWork = new ProductUnitOfWork(context);
        this.mapper = mapper;
    }

    public IEnumerable<CategoryDto> GetCategories()
    {
        var categories = productUnitOfWork.Categories.GetAll();
        var categoryDtos = mapper.Map<IEnumerable<CategoryDto>>(categories);

        return categoryDtos;
    }
}