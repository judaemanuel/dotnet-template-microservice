namespace DotnetTemplateMsa.Infra.Persistence.EFCore.Base;

public abstract class BaseRepository
{
    protected readonly AppDbContext _dbContext;

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}