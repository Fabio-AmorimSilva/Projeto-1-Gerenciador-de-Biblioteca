namespace LibraryManagement.Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

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