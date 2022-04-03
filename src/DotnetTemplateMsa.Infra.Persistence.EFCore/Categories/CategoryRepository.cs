using DotnetTemplateMsa.Domain.Categories;
using DotnetTemplateMsa.Infra.Persistence.EFCore.Base;
using Microsoft.EntityFrameworkCore;

namespace DotnetTemplateMsa.Infra.Persistence.EFCore.Categories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<Category>> SelectAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }
}