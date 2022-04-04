namespace DotnetTemplateMsa.Domain.TodoLists;

public interface ITodoListService
{
    Task<IEnumerable<TodoList>> ListAsync();
    Task<TodoList> ListAsync(int id);
}