using DotnetTemplateMsa.Domain.TodoLists;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTemplateMsa.Api.TodoLists;

[ApiController]
[Route("api/[controller]")]
public class TodoListsController : Controller
{
    private readonly ITodoListService _todoListService;

    public TodoListsController(ITodoListService todoListService)
    {
        _todoListService = todoListService;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoList>> Get()
    {
        return await _todoListService.ListAsync();
    }
}