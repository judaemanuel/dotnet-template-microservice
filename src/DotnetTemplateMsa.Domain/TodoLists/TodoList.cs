using DotnetTemplateMsa.Domain.Todos;

namespace DotnetTemplateMsa.Domain.TodoLists;

public class TodoList
{
    #region entity properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    #endregion

    #region entity relationships
    public IEnumerable<Todo>? Todos { get; set; }
    #endregion
}
