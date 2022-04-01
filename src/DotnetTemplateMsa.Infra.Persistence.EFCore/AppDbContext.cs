using DotnetTemplateMsa.Domain.Categories;
using DotnetTemplateMsa.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace DotnetTemplateMsa.Infra.Persistence.EFCore;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(keys => keys.Id);
        builder.Entity<Category>().Property(props => props.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(props => props.Name)
            .IsRequired()
            .HasMaxLength(30);
        builder.Entity<Category>().HasMany(props => props.Products)
            .WithOne(props => props.Category)
            .HasForeignKey(props => props.CategoryId);

        builder.Entity<Category>().HasData(
            new Category { Id = 100, Name = "Fruits and Vegetables" },
            new Category { Id = 101, Name = "Dairy" }
        );

        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(props => props.Id);
        builder.Entity<Product>().Property(props => props.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(props => props.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Entity<Product>().Property(props => props.QuantityInPackage)
            .IsRequired();
        builder.Entity<Product>().Property(props => props.UnitOfMeasurement)
            .IsRequired();
    }
}