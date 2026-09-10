namespace LibraryManagement.Infrastructure.Configs;

public class RolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder
            .ToTable("RolePermissions");

        builder
            .HasKey(rp => new
            {
                rp.RoleId,
                rp.PermissionId
            });
        
        builder
            .Property(rp => rp.RoleId)
            .IsRequired();
        
        builder
            .Property(rp => rp.PermissionId)
            .IsRequired();
    }
}