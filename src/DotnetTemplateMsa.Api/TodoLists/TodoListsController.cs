using AutoMapper;
using DotnetTemplateMsa.Domain.TodoLists;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTemplateMsa.Api.TodoLists;

[ApiController]
[Route("api/[controller]")]
public class TodoListsController : Controller
{
    private readonly ITodoListService _todoListService;
    private readonly IMapper _mapper;

    public TodoListsController(ITodoListService todoListService, IMapper mapper)
    {
        _todoListService = todoListService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoListResource>>> Get()
    {
        IEnumerable<TodoList> todoLists = await _todoListService.ListAsync();
        if (todoLists == null || !todoLists.Any())
        {
            return NotFound();
        }

        return _mapper.Map<IEnumerable<TodoList>, IEnumerable<TodoListResource>>(todoLists).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoListResource>> Get(int id)
    {
        TodoList todoList = await _todoListService.ListAsync(id);
        if (todoList == null)
        {
            return NotFound();
        }

        return _mapper.Map<TodoList, TodoListResource>(todoList);
    }
}