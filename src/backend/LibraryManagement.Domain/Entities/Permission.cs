namespace LibraryManagement.Domain.Entities;

public class Permission : Entity
{
    public const int NameMaxLength = 500;
    public const int DescriptionMaxLength = 500;
    
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Permission(string name, string description)
    {
        Guard.IsNotEmpty(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(NameMaxLength));
        Guard.IsNotEmpty(description);
        Guard.IsLessThanOrEqualTo(description.Length, DescriptionMaxLength, nameof(DescriptionMaxLength));
        
        Name = name;
        Description = description;
    }
}