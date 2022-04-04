using DotnetTemplateMsa.Domain.TodoLists;
using DotnetTemplateMsa.Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace DotnetTemplateMsa.Infra.Persistence.EFCore;

public class AppDbContext : DbContext
{
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
            .HasMaxLength(2000);
        builder.Entity<Todo>().Property(props => props.Description)
            .HasColumnName("is_complete")
            .IsRequired();
        builder.Entity<Todo>().Property(props => props.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        builder.Entity<Todo>().Property(props => props.UpdatedAt)
            .HasColumnName("updated_at");
    }
}