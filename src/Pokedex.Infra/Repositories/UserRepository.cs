using Pokedex.Business.Core.Auth;
using Pokedex.Business.Repositories;

namespace Pokedex.Infra.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> GetByUserNameAsync(string userName)
    {
        return Task.FromResult(new User()
        {
            UserName = userName,
            Password = "81dc9bdb52d04dc20036dbd8313ed055", //1234
            Id = Guid.NewGuid(),
        });
    }
}
