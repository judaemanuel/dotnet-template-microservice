using DotnetTemplateMsa.Domain.TodoLists;

namespace DotnetTemplateMsa.Api.TodoLists;

public class TodoListResource
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }    
}
