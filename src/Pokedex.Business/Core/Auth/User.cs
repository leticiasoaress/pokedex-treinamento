namespace Pokedex.Business.Core.Auth;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}
