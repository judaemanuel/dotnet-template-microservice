using DotnetTemplateMsa.Domain.TodoLists;

namespace DotnetTemplateMsa.Service.TodoLists;

public class TodoListService : ITodoListService
{
    private readonly ITodoListRepository _todoListRepository;

    public TodoListService(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<IEnumerable<TodoList>> ListAsync()
    {
        return await _todoListRepository.SelectAsync();
    }
}