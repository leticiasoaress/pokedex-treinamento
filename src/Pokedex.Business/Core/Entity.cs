using FluentValidation.Results;

namespace Pokedex.Business.Core;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public void SetCreationDate(DateTime dateTime)
    {
        CreatedAt = dateTime;
    }

    public void SetUpdateDate(DateTime dateTime)
    {
        UpdatedAt = dateTime;
    }

    public virtual ValidationResult Validate()
    {
        throw new NotImplementedException(
            "Override the validate method with valid conditions");
    }
}
