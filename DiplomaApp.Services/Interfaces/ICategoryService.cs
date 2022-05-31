using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces;

public interface ICategoryService
{
    public IEnumerable<CategoryDto> GetCategories();
}