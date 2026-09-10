namespace LibraryManagement.Domain.Entities;

public class Role : Entity
{
    public const int NameMaxLength = 500;
    
    public string Name { get; private set; }
    
    private List<RolePermission> _permissions = [];
    public IReadOnlyCollection<RolePermission> Permissions => _permissions;
    
    public Role(string name)
    {
        Guard.IsNotEmpty(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(NameMaxLength));
        
        Name = name;
    }

    public void AddPermission(RolePermission permission)
    {
        var exists = _permissions.Any(rp => rp.PermissionId == permission.PermissionId);

        if (exists)
            return;
        
        _permissions.Add(permission);
    }

    public void RemovePermission(RolePermission permission)
    {
        var rolePermission = _permissions.FirstOrDefault(rp  => rp.PermissionId == permission.PermissionId);

        if (rolePermission is null)
            return;
        
        _permissions.Remove(permission);
    }
}