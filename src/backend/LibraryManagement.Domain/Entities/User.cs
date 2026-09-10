namespace LibraryManagement.Domain.Entities;

public class User : Entity
{
    public const int NameMaxLength = 200;
    public const int EmailMaxLength = 60;
    
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    
    private List<UserRole> _roles = [];
    public IReadOnlyCollection<UserRole> Roles => _roles; 

    protected User() {}
    
    public User(
        string name, 
        string email,
        string password
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsNotWhiteSpace(email);
        Guard.IsNotEmpty(password);
        
        Name = name;
        Email = email;
        Password = password;
    }

    public void AddRole(Guid roleId)
    {
        var exists = _roles.Any(id => id.RoleId == roleId);
        
        if (exists)
            return;

        var role = new UserRole(
            userId: Id,
            roleId: roleId
        );
        
        _roles.Add(role);
    }

    public void RemoveRole(Guid roleId)
    {
        var role = _roles.FirstOrDefault(r => r.RoleId == roleId);

        if (role is null)
            return;
        
        _roles.Remove(role);
    }
}