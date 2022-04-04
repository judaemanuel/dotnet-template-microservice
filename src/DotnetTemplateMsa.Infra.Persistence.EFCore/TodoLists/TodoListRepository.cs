using DotnetTemplateMsa.Domain.TodoLists;
using DotnetTemplateMsa.Infra.Persistence.EFCore.Base;
using Microsoft.EntityFrameworkCore;

namespace DotnetTemplateMsa.Infra.Persistence.EFCore.TodoLists;

public class TodoListRepository : BaseRepository, ITodoListRepository
{
    public TodoListRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<TodoList>> SelectAsync()
    {
        return await _dbContext.TodoLists.ToListAsync();
    }

    public async Task<TodoList> SelectAsync(int id)
    {
        #nullable disable
        return await _dbContext.TodoLists.FindAsync(id);
        #nullable enable
    }
}