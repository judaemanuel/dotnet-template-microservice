using DotnetTemplateMsa.Domain.TodoLists;

namespace DotnetTemplateMsa.Domain.Todos;

public class Todo
{
    #region entity properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    #endregion

    #region entity relationships
    public int TodoListId { get; set; }
    public TodoList TodoLists { get; set; }
    #endregion
}