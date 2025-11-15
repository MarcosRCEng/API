namespace CnpjRegistry.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
