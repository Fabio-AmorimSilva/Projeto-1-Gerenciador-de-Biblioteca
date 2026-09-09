namespace LibraryManagement.Domain.Entities.Base;

public class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}