using DotnetTemplateMsa.Domain.Categories;

namespace DotnetTemplateMsa.Service.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.SelectAsync();
    }
}