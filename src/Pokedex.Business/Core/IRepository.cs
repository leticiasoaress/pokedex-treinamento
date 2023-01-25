namespace Pokedex.Business.Core;

public interface IRepository : IDisposable
{
    Task CommitAsync();
}
