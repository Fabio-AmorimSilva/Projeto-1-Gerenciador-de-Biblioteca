namespace LibraryManagement.Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    protected User() {}
    
    public User(
        string name, 
        string email
    )
    {
        Name = name;
        Email = email;
    }
}