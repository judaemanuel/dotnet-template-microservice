namespace DotnetTemplateMsa.Domain.Categories;

public interface ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
}
