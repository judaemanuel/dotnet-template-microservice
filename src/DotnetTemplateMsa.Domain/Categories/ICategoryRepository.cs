namespace DotnetTemplateMsa.Domain.Categories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> SelectAsync();
}