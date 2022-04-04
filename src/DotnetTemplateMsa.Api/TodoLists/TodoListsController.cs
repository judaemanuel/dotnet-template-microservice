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
    public async Task<IEnumerable<TodoListResource>> Get()
    {
        IEnumerable<TodoList> todoLists = await _todoListService.ListAsync();
        return _mapper.Map<IEnumerable<TodoList>, IEnumerable<TodoListResource>>(todoLists);
    }
}