using DotnetTemplateMsa.Domain.Categories;
using DotnetTemplateMsa.Domain.Products;
using DotnetTemplateMsa.Domain.TodoLists;
using DotnetTemplateMsa.Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace DotnetTemplateMsa.Infra.Persistence.EFCore;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<TodoList> TodoLists { get; set; } = null!;
    public DbSet<Todo> Todos { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TodoList>().ToTable("todo_lists");
        builder.Entity<TodoList>().HasKey(entity => entity.Id)
            .HasName("id");
        builder.Entity<TodoList>().Property(props => props.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Entity<TodoList>().Property(props => props.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(250);
        builder.Entity<TodoList>().Property(props => props.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(2000);
        builder.Entity<TodoList>().Property(props => props.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        builder.Entity<TodoList>().Property(props => props.UpdatedAt)
            .HasColumnName("updated_at");
        builder.Entity<TodoList>().HasMany(props => props.Todos)
            .WithOne(props => props.TodoLists)
            .HasForeignKey(props => props.TodoListId)
            .HasConstraintName("todo_list_id");

        builder.Entity<TodoList>().HasData(
            new TodoList { Id = 100, Name = "Market shopping List", Description = "Weekly market shopping", CreatedAt = DateTime.Now },
            new TodoList { Id = 101, Name = "Chores at home", CreatedAt = DateTime.Now }
        );

        builder.Entity<Todo>().ToTable("todo");
        builder.Entity<Todo>().HasKey(entity => entity.Id)
            .HasName("id");
        builder.Entity<Todo>().Property(props => props.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Entity<Todo>().Property(props => props.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(250);
        builder.Entity<Todo>().Property(props => props.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(2000);
        builder.Entity<Todo>().Property(props => props.Description)
            .HasColumnName("is_complete")
            .IsRequired();
        builder.Entity<Todo>().Property(props => props.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        builder.Entity<Todo>().Property(props => props.UpdatedAt)
            .HasColumnName("updated_at");        

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