using System.ComponentModel.DataAnnotations;
using DotnetTemplateMsa.Domain.TodoLists;

namespace DotnetTemplateMsa.Api.TodoLists;

public class TodoListResource
{
    public int? Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; } = null!;
    
    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }    
}
