namespace LibraryManagement.Infrastructure.Configs;

public class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder
            .ToTable("Permissions");

        builder
            .HasIndex(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasMaxLength(Permission.NameMaxLength)
            .IsRequired();
        
        builder
            .Property(p => p.Description)
            .HasMaxLength(Permission.DescriptionMaxLength)
            .IsRequired();
    }
}