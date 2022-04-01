using DotnetTemplateMsa.Domain.Categories;

namespace DotnetTemplateMsa.Domain.Products;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public short QuantityInPackage { get; set; }
    public EUnitOfMeasurement UnitOfMeasurement { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}