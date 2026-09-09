namespace LibraryManagement.Domain.Entities;

public class User : Entity
{
    public const int NameMaxLength = 200;
    public const int EmailMaxLength = 60;
    
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    protected User() {}
    
    public User(
        string name, 
        string email
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsNotWhiteSpace(email);
        
        Name = name;
        Email = email;
    }
}