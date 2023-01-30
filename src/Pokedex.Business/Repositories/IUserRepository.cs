﻿using Pokedex.Business.Core.Auth;

namespace Pokedex.Business.Repositories;

public interface IUserRepository
{
    Task<User> GetByUserNameAsync(string userName);
}
