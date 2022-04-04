namespace DotnetTemplateMsa.Domain.TodoLists;

public interface ITodoListRepository
{
    Task<IEnumerable<TodoList>> SelectAsync();
    Task<TodoList> SelectAsync(int id);
}