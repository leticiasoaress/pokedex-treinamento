using Pokedex.Business.Core;

namespace Pokedex.Infra.Core;

public class RepositoryBase : IRepository
{
    protected readonly EFDbContext _efContext;

	public RepositoryBase(EFDbContext efContext)
	{
        _efContext = efContext;
    }

    public Task CommitAsync()
    {
       return _efContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _efContext?.Dispose();
    }
}
