using DotnetTemplateMsa.Domain.Products;

namespace DotnetTemplateMsa.Domain.Categories;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IList<Product>? Products { get; set; }
}